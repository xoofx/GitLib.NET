using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using CppAst;
using CppAst.CodeGen.Common;
using CppAst.CodeGen.CSharp;
using Zio;
using Zio.FileSystems;

namespace GitLib.CodeGen
{
    public partial class Program
    {
        private CppTypedef _gitResultType;
        private CppTypedef _gitResultBoolType;
        private readonly Dictionary<string, List<string>> _gitResultFunctionsDetectedButNotRegistered;
        private List<CSharpStruct> _structs;
        private Dictionary<CSharpStruct, HashSet<CSharpRefKind>> _structRefUsages;

        private Program()
        {
            _structs = new List<CSharpStruct>();
            _structRefUsages = new Dictionary<CSharpStruct, HashSet<CSharpRefKind>>();
            _gitResultFunctionsDetectedButNotRegistered = new Dictionary<string, List<string>>();
        }

        static void Main(string[] args)
        {
            var program = new Program();
            program.Run();
        }

        public void Run()
        {
            var srcFolder = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\..\..\..\..\libgit2\include"));
            var destFolder = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\..\..\GitLib\generated"));
            var destTestsFolder = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\..\..\GitLib.Tests"));
            
            if (!Directory.Exists(srcFolder))
            {
                throw new DirectoryNotFoundException($"The source folder `{srcFolder}` doesn't exist");
            }
            if (!Directory.Exists(destFolder))
            {
                throw new DirectoryNotFoundException($"The destination folder `{destFolder}` doesn't exist");
            }
            if (!Directory.Exists(destTestsFolder))
            {
                throw new DirectoryNotFoundException($"The destination tests folder `{destTestsFolder}` doesn't exist");
            }

            var csOptions = new CSharpConverterOptions()
            {
                DefaultClassLib = "libgit2",
                DefaultNamespace = "GitLib",
                DefaultOutputFilePath = "/libgit2.generated.cs",
                DefaultDllImportNameAndArguments = "GitLibName",

                PreHeaderText = @"
// A result integer from a git function. 0 if successful, < 0 if an error.
typedef int git_result;
typedef int git_result_bool;
",
                
                DispatchOutputPerInclude = true,
                DefaultMarshalForString = new CSharpMarshalAttribute(CSharpUnmanagedKind.CustomMarshaler) { MarshalTypeRef = "typeof(UTF8MarshallerRelaxedNoCleanup)" },

                MappingRules =
                {
                    // Remove this function as it is not supported (varargs)
                    e => e.Map<CppFunction>("git_libgit2_opts").Discard(),
                    
                    // Mappings for repository.h
                    e => e.MapMacroToConst("GIT_REPOSITORY_INIT_OPTIONS_VERSION", "unsigned int"),
                    e => e.Map<CppParameter>("git_repository_open_ext::flags").Type("git_repository_open_flag_t"),
                    e => e.Map<CppParameter>("git_repository_init::is_bare").Type("bool").MarshalAs(CSharpUnmanagedKind.Bool),
                    e => e.Map<CppParameter>("git_repository_discover::across_fs").Type("bool").MarshalAs(CSharpUnmanagedKind.Bool),
                    e => e.Map<CppParameter>("git_repository_init_init_options::version").InitValue("GIT_REPOSITORY_INIT_OPTIONS_VERSION"),
                    e => e.Map<CppParameter>("git_repository_set_workdir::update_gitlink").Type("bool").MarshalAs(CSharpUnmanagedKind.Bool),
                    e => e.Map<CppField>("git_repository_init_options::flags").Type("git_repository_init_flag_t"),
                    e => e.Map<CppField>("git_repository_init_options::mode").Type("git_repository_init_mode_t"),
                    e => e.Map<CppFunction>("git_repository_state").Type("git_repository_state_t"),
                    e => e.Map<CppFunction>("git_repository_ident").Type("git_result"),
                    e => e.Map<CppFunction>("git_repository_set_ident").Type("git_result"),
                    e => e.Map<CppFunction>("git_repository_fetchhead_foreach").Type("git_result"),
                    
                    e => e.Map<CppFunction>("git_repository_is_shallow").Type("bool").MarshalAs(CSharpUnmanagedKind.Bool),
                    e => e.Map<CppFunction>("git_repository_is_bare").Type("bool").MarshalAs(CSharpUnmanagedKind.Bool),
                    e => e.Map<CppFunction>("git_repository_is_worktree").Type("bool").MarshalAs(CSharpUnmanagedKind.Bool),
                    
                    // Mappings for revwalk.h
                    e => e.Map<CppParameter>("git_revwalk_sorting::sort_mode").Type("git_sort_t"),
                    e => e.Map<CppFunction>("git_revwalk_next").Type("bool").MarshalAs(CSharpUnmanagedKind.Bool),
                    
                    e => e.Map<CppField>("git_strarray::strings").Private(),
                    e => e.Map<CppField>("git_strarray::count").Private(),
                    e => e.MapAll<CppClass>().CSharpAction(ProcessCSharpStruct),
                    e => e.MapAll<CppFunction>().CppAction(ProcessCppFunctions).CSharpAction(ProcessCSharpMethods)
                }
            };
            csOptions.IncludeFolders.Add(srcFolder);
            var files = new List<string>()
            {
                Path.Combine(srcFolder, "git2.h"),
                Path.Combine(srcFolder, "git2", "trace.h")
            };

            var csCompilation = CSharpConverter.Convert(files, csOptions);

            if (csCompilation.HasErrors)
            {
                foreach (var message in csCompilation.Diagnostics.Messages)
                {
                    Console.Error.WriteLine(message);
                }
                Console.Error.WriteLine("Unexpected parsing errors");
                Environment.Exit(1);
            }
            
            ProcessStringMarshallingForStructs();
            
            var fs = new PhysicalFileSystem();
            
            {
                var subfs = new SubFileSystem(fs, fs.ConvertPathFromInternal(destFolder));
                var codeWriter = new CodeWriter(new CodeWriterOptions(subfs));
                csCompilation.DumpTo(codeWriter);
            }

            // --------------------------------------------------------------------------
            // Generate test files
            // --------------------------------------------------------------------------
            var testGeneratedCompilation = new CSharpCompilation();
            foreach (var file in csCompilation.Members.OfType<CSharpGeneratedFile>())
            {
                var name = file.FilePath.GetName();
                var nameWithoutGenerated = name.Substring(0, name.IndexOf("."));
                name = ToPascalCase(nameWithoutGenerated);

                var allMethods = file.Members.OfType<CSharpNamespace>().First().Members.OfType<CSharpClass>().First().Members.OfType<CSharpMethod>().Where(x => x.Visibility == CSharpVisibility.Public).ToList();
                
                // Generate all tests: generated/xxx.generated.cs 
                {
                    var testGeneratedFile = new CSharpGeneratedFile(UPath.Combine("/generated/", file.FilePath.GetName()));
                    testGeneratedCompilation.Members.Add(testGeneratedFile);

                    var ns = new CSharpNamespace("GitLib.Tests");
                    testGeneratedFile.Members.Add(ns);

                    var csTest = new CSharpClass($"{name}Tests") {Modifiers = CSharpModifiers.Partial};
                    csTest.BaseTypes.Add(new CSharpFreeType("GitLibTestsBase"));
                    ns.Members.Add(csTest);
                    
                    csTest.Members.Add(new CSharpLineElement($"public {csTest.Name}() : base(\"{nameWithoutGenerated}\") {{}}"));

                    var csCheckMethod = new CSharpMethod() {Name = "Check", Visibility = CSharpVisibility.Private, ReturnType = CSharpPrimitiveType.Void};
                    csTest.Members.Add(csCheckMethod);

                    csCheckMethod.Body = (writer, element) =>
                    {
                        foreach (var method in allMethods)
                        {
                            writer.WriteLine($"Test_{method.Name}();");
                        }
                    };
                }

                // Generate all tests: xxx.cs (WARNING, THIS IS NOT INTENDED TO BE USED AFTER A FIRST RUN)
                // The following code is now disabled as it was only used once for generating all tests methods
//                {
//                    var testGeneratedFile = new CSharpGeneratedFile($"/{nameWithoutGenerated}.cs") { EmitAutoGenerated = false };
//                    testGeneratedCompilation.Members.Add(testGeneratedFile);
//
//                    testGeneratedFile.Members.Add(new CSharpUsingDeclaration("System"));
//                    testGeneratedFile.Members.Add(new CSharpUsingDeclaration("System.IO"));
//                    testGeneratedFile.Members.Add(new CSharpUsingDeclaration("NUnit.Framework"));
//
//                    var ns = new CSharpNamespace("GitLib.Tests");
//                    testGeneratedFile.Members.Add(ns);
//                    
//                    ns.Members.Add(new CSharpUsingDeclaration("libgit2") { IsStatic =  true });
//                    
//                    var csTest = new CSharpClass($"{name}Tests") {Modifiers = CSharpModifiers.Partial};
//                    ns.Members.Add(csTest);
//
//                    foreach (var method in allMethods)
//                    {
//                        var csTestMethod = new CSharpMethod() {Name = $"Test_{method.Name}", Visibility = CSharpVisibility.Public, ReturnType = CSharpPrimitiveType.Void};
//                        csTestMethod.Attributes.Add(new CSharpFreeAttribute("Test"));
//                        csTest.Members.Add(csTestMethod);
//
//                        csTestMethod.Body = (writer, element) => { writer.WriteLine($"Assert.Fail($\"Tests for method `{{nameof({method.Name})}}` are not yet implemented\");"); };
//                    }
//                }
            }



            
            {
                var subfs = new SubFileSystem(fs, fs.ConvertPathFromInternal(destTestsFolder));
                var codeWriter = new CodeWriter(new CodeWriterOptions(subfs));
                testGeneratedCompilation.DumpTo(codeWriter);
            }
            
            ReportFunctionWithPossibleGitResultNotRegistered();
        }


        private static string ToPascalCase(string name)
        {
            var builder = new StringBuilder();
            builder.Append(char.ToUpper(name[0]));
            int start = 1;
            int nextUnderscore;
            while ((nextUnderscore = name.IndexOf('_', start)) >= 0)
            {
                builder.Append(name, start, nextUnderscore - start);
                start = nextUnderscore + 1;
                builder.Append(char.ToUpper(name[start]));
                start++;
            }

            if (start < name.Length)
            {
                builder.Append(name.Substring(start));
            }

            return builder.ToString();
        }

        /// <summary>
        /// List of functions to not modify regarding strarray handling
        /// </summary>
        private static readonly HashSet<string> KeepRefForStrArrayMethods = new HashSet<string>()
        {
            "git_strarray_free",
            "git_strarray_copy",
        };

        private static bool IsStrArray(CSharpParameter csParam, out CSharpRefKind refKind)
        {
            refKind = CSharpRefKind.None;
            if (csParam.ParameterType is CSharpRefType refType)
            {
                refKind = refType.Kind;
                if (refType.ElementType is CSharpStruct csStruct && csStruct.Name == "git_strarray")
                {
                    return true;
                }
            }
            return false;
        }

        private void ReportFunctionWithPossibleGitResultNotRegistered()
        {
            if (_gitResultFunctionsDetectedButNotRegistered.Count == 0) return;
            
            Console.WriteLine($"// The following functions are possible returning a git_result but are not registered a such");
            
            foreach (var keyPair in _gitResultFunctionsDetectedButNotRegistered.OrderBy(x => x.Key))
            {
                Console.WriteLine($"// {keyPair.Key}");
                foreach (var functionName in keyPair.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"\"{functionName}\",");
                }
            }
        }

        private void ProcessCppFunctions(CSharpConverter converter, CppElement cppFunctionElement)
        {
            var cppFunction = (CppFunction) cppFunctionElement;

            // We are only looking for functions returning an int
            if (!cppFunction.ReturnType.Equals(CppPrimitiveType.Int)) return;
            
            // If the function is not registered as a git_result, we will try to detect if it is a potential one
            if (!_gitResultFunctions.Contains(cppFunction.Name) && !_gitResultFunctionsWithBoolReturned.Contains(cppFunction.Name))
            {
                if (cppFunction.Comment == null) return;

                // Start from the bottom of the comments to catch "return" more quickly
                for (int i = cppFunction.Comment.Children.Count - 1; i >= 0; i--)
                {
                    var csComment = cppFunction.Comment.Children[i];
                    if (csComment is CppCommentBlockCommand blockCommand && blockCommand.CommandName == "return")
                    {
                        var returnText = blockCommand.ChildrenToString().Trim().Replace("\r\n", " ")
                            .Replace("\n", " ");
                        if ((returnText.StartsWith("Zero") || returnText.StartsWith("0")) &&
                            (returnText.Contains("failure") || returnText.Contains("error")))
                        {
                            var includeName = Path.GetFileName(cppFunction.Span.Start.File);

                            if (!_gitResultFunctionsDetectedButNotRegistered.TryGetValue(includeName,
                                out var functionList))
                            {
                                functionList = new List<string>();
                                _gitResultFunctionsDetectedButNotRegistered.Add(includeName, functionList);
                            }

                            functionList.Add(cppFunction.Name);
                        }
                    }
                }
            }
            else
            {
                if (_gitResultType == null)
                {
                    _gitResultType = (CppTypedef) converter.CurrentCppCompilation.FindByName("git_result");
                    _gitResultBoolType = (CppTypedef) converter.CurrentCppCompilation.FindByName("git_result_bool");
                    Debug.Assert(_gitResultType != null);
                    Debug.Assert(_gitResultBoolType != null);
                }

                cppFunction.ReturnType = _gitResultFunctionsWithBoolReturned.Contains(cppFunction.Name) ? _gitResultBoolType : _gitResultType;
            }
        }
        
        private void ProcessCSharpStruct(CSharpConverter converter, CSharpElement csElement)
        {
            if (!(csElement is CSharpStruct csStruct))
            {
                return;
            }
            _structs.Add(csStruct);
        }

        private void RecordStructUsage(CSharpRefKind refKind, CSharpStruct csStruct)
        {
            if (!_structRefUsages.TryGetValue(csStruct, out var listRefs))
            {
                listRefs = new HashSet<CSharpRefKind>();
                _structRefUsages.Add(csStruct, listRefs);
            }
            listRefs.Add(refKind);
        }

        private void ProcessStringMarshallingForStructs()
        {
            foreach (var csStruct in _structs)
            {
                if (!_structRefUsages.TryGetValue(csStruct, out var refKinds))
                {
                    continue;
                }

                bool isIn = false;
                bool isOut = false;
                foreach (var refKind in refKinds)
                {
                    switch (refKind)
                    {
                        case CSharpRefKind.None:
                        case CSharpRefKind.In:
                            isIn = true;
                            break;
                        case CSharpRefKind.Out:
                            isOut = true;
                            break;
                        case CSharpRefKind.Ref:
                        case CSharpRefKind.RefReadOnly:
                            isIn = true;
                            isOut = true;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }

                foreach (var csField in csStruct.Members.OfType<CSharpField>())
                {
                    if (csField.FieldType is CSharpTypeWithAttributes csTypeWithAttributes && csTypeWithAttributes.ElementType is CSharpPrimitiveType csPrimitiveType &&  csPrimitiveType.Kind == CSharpPrimitiveKind.String)
                    {
                        if (isIn && !isOut)
                        {
                            csTypeWithAttributes = new CSharpTypeWithAttributes(csTypeWithAttributes.ElementType);
                            csTypeWithAttributes.Attributes.Add(new CSharpMarshalAttribute(CSharpUnmanagedKind.CustomMarshaler) {MarshalTypeRef = "typeof(UTF8MarshallerStrict)"});
                            csField.FieldType = csTypeWithAttributes;
                        }
                    }
                }
            }
        }

        private void ProcessCSharpParameter(CSharpElement parent, CSharpParameter csParam)
        {
            // If method is returning a string, don't try to release the memory
            if (csParam.ParameterType is CSharpTypeWithAttributes typeWithAttr && typeWithAttr.ElementType == CSharpPrimitiveType.String)
            {
                csParam.ParameterType = new CSharpTypeWithAttributes(CSharpPrimitiveType.String)
                {
                    Attributes =
                    {
                        new CSharpMarshalAttribute(CSharpUnmanagedKind.CustomMarshaler) {MarshalTypeRef = "typeof(UTF8MarshallerStrict)"}
                    }
                };
                return;
            }            
            
            if (csParam.ParameterType is CSharpRefType refType)
            {
                var csStruct = refType.ElementType as CSharpStruct;
                if (csStruct != null)
                {
                    RecordStructUsage(refType.Kind, csStruct);
                }
                
                if (csParam.Name == "@out" && refType.Kind == CSharpRefKind.Ref)
                {
                    refType.Kind = CSharpRefKind.Out;
                }
                else if (csStruct != null && csStruct.Name == "git_strarray" && refType.Kind == CSharpRefKind.Ref)
                {
                    if (csParam.Parent is CSharpMethod csParentMethod && !KeepRefForStrArrayMethods.Contains(csParentMethod.Name))
                    {
                        refType.Kind = CSharpRefKind.Out;
                    }
                }
            }
            else if (csParam.ParameterType is CSharpStruct csStruct)

            {
                RecordStructUsage(CSharpRefKind.None, csStruct);
            }
        }

        private void ProcessCSharpMethods(CSharpConverter converter, CSharpElement element)
        {
            if (element is CSharpMethod csMethod)
            {
                foreach (var csParam in csMethod.Parameters)
                {
                    ProcessCSharpParameter(csMethod, csParam);
                }
                
                if (_gitResultType != null)
                {
                    bool hasGitStrarray = false;
                    if (!KeepRefForStrArrayMethods.Contains(csMethod.Name))
                    {
                        foreach (var csParam in csMethod.Parameters)
                        {
                            if (IsStrArray(csParam, out _))
                            {
                                hasGitStrarray = true;
                                break;
                            }
                        }
                    }

                    var isGitResultMethod = csMethod.ReturnType.CppElement == _gitResultType || csMethod.ReturnType.CppElement == _gitResultBoolType;

                    if (hasGitStrarray || isGitResultMethod)
                    {
                        var csWrapMethod = csMethod.Wrap();

                        StrArrayParam[] strArrayParams = null;
                        var hasInStrArray = false;
                        if (hasGitStrarray)
                        {
                            strArrayParams = new StrArrayParam[csWrapMethod.Parameters.Count];
                            for (var i = 0; i < csWrapMethod.Parameters.Count; i++)
                            {
                                var csParam = csWrapMethod.Parameters[i];
                                if (IsStrArray(csParam, out var refKind))
                                {
                                    strArrayParams[i] = new StrArrayParam(csParam, refKind);
                                    if (refKind == CSharpRefKind.Out)
                                    {
                                        csParam.ParameterType = new CSharpRefType(refKind, new CSharpArrayType(CSharpPrimitiveType.String));
                                    }
                                    else if (refKind == CSharpRefKind.In)
                                    {
                                        csParam.ParameterType = new CSharpArrayType(CSharpPrimitiveType.String);
                                        hasInStrArray = true;
                                    }
                                }
                            }
                        }

                        csWrapMethod.Body = (writer, sharpElement) =>
                        {
                            if (strArrayParams != null)
                            {
                                for (var i = 0; i < csWrapMethod.Parameters.Count; i++)
                                {
                                    var strArrayParam = strArrayParams[i];
                                    if (strArrayParam != null)
                                    {
                                        var csParam = strArrayParam.CsParameter;
                                        if (strArrayParam.RefKind == CSharpRefKind.In)
                                        {
                                            writer.WriteLine($"var {csParam.Name}__ = git_strarray.Allocate({csParam.Name});");
                                        }
                                        else
                                        {
                                            writer.WriteLine($"git_strarray {csParam.Name}__;");
                                        }
                                    }
                                }
                            }

                            bool isVoidReturn = (csMethod.ReturnType is CSharpPrimitiveType cSharpPrimitiveType && cSharpPrimitiveType.Kind == CSharpPrimitiveKind.Void);
                            if (!isVoidReturn)
                            {
                                writer.Write("var __result__ = ");
                            }

                            writer.Write(csMethod.Name).Write("(");
                            for (var i = 0; i < csMethod.Parameters.Count; i++)
                            {
                                var p = csMethod.Parameters[i];
                                if (i > 0) writer.Write(", ");
                                if (strArrayParams != null && strArrayParams[i] != null)
                                {
                                    var strArrayParam = strArrayParams[i];
                                    strArrayParam.RefKind.DumpTo(writer);
                                    writer.Write($"{strArrayParam.CsParameter.Name}__");
                                }
                                else
                                {
                                    p.DumpArgTo(writer);
                                }
                            }

                            writer.Write(")");

                            if (hasInStrArray)
                            {
                                writer.WriteLine(";");
                                for (var i = 0; i < csWrapMethod.Parameters.Count; i++)
                                {
                                    var strParamArray = strArrayParams[i];
                                    if (strParamArray != null && strParamArray.RefKind == CSharpRefKind.In)
                                    {
                                        writer.WriteLine($"{strParamArray.CsParameter.Name}__.Free();");
                                    }
                                }
                            }

                            if (isGitResultMethod)
                            {
                                if (hasInStrArray)
                                {
                                    writer.WriteLine("__result__.Check();");
                                }
                                else
                                {
                                    writer.WriteLine(".Check();");
                                }
                            }
                            else
                            {
                                writer.WriteLine(";");
                            }

                            if (strArrayParams != null)
                            {
                                for (var i = 0; i < csWrapMethod.Parameters.Count; i++)
                                {
                                    var strParamArray = strArrayParams[i];
                                    if (strParamArray != null && strParamArray.RefKind == CSharpRefKind.Out)
                                    {
                                        writer.WriteLine($"{strParamArray.CsParameter.Name} = {strParamArray.CsParameter.Name}__.ToArray();");
                                        writer.WriteLine($"git_strarray_free(ref {strParamArray.CsParameter.Name}__);");
                                    }
                                }
                            }

                            if (!isVoidReturn)
                            {
                                writer.WriteLine("return __result__;");
                            }
                        };
                    }
                }
            }
        }

        private class StrArrayParam
        {
            public StrArrayParam(CSharpParameter csParameter, CSharpRefKind refKind)
            {
                CsParameter = csParameter;
                RefKind = refKind;
            }

            public readonly CSharpParameter CsParameter;

            public readonly CSharpRefKind RefKind;
        }
    }
}