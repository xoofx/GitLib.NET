using System;
using System.Collections.Generic;
using System.IO;
using CppAst;
using CppAst.CodeGen.Common;
using CppAst.CodeGen.CSharp;
using Zio.FileSystems;

namespace LibGit2.CodeGen
{
    class Program
    {
        private CppTypedef _gitResultType;
        
        static void Main(string[] args)
        {
            var program = new Program();
            program.Run();
        }

        public void Run()
        {
            var srcFolder = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\..\..\..\..\libgit2\include"));
            var destFolder = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\..\..\LibGit2\generated"));
            if (!Directory.Exists(srcFolder))
            {
                throw new DirectoryNotFoundException($"The source folder `{srcFolder}` doesn't exist");
            }
            if (!Directory.Exists(destFolder))
            {
                throw new DirectoryNotFoundException($"The destination folder `{destFolder}` doesn't exist");
            }

            var csOptions = new CSharpConverterOptions()
            {
                DefaultClassLib = "libgit2",
                DefaultNamespace = "LibGit2",
                DefaultOutputFilePath = "/libgit2.generated.cs",
                DefaultDllImportNameAndArguments = "LibGit2Name",

                PreHeaderText = @"
// A result integer from a git function. 0 if successful, < 0 if an error.
typedef int git_result;",
                
                DispatchOutputPerInclude = true,
                DefaultMarshalForString = new CSharpMarshalAttribute(CSharpUnmanagedKind.LPUTF8Str),

                MappingRules =
                {
                    // Remove this function as it is not supported (varargs)
                    e => e.Map<CppFunction>("git_libgit2_opts").Discard(),
                    
                    // Mappings for repository.h
                    e => e.MapMacroToConst("GIT_REPOSITORY_INIT_OPTIONS_VERSION", "unsigned int"),
                    e => e.Map<CppParameter>("git_repository_open_ext::flags").Type("git_repository_open_flag_t"),
                    e => e.Map<CppParameter>("git_repository_init::is_bare").Type("bool").MarshalAs(CSharpUnmanagedKind.I4),
                    e => e.Map<CppParameter>("git_repository_discover::across_fs").Type("bool").MarshalAs(CSharpUnmanagedKind.I4),
                    e => e.Map<CppParameter>("git_repository_init_init_options::version").InitValue("GIT_REPOSITORY_INIT_OPTIONS_VERSION"),
                    e => e.Map<CppParameter>("git_repository_set_workdir::update_gitlink").Type("bool").MarshalAs(CSharpUnmanagedKind.I4),
                    e => e.Map<CppField>("git_repository_init_options::flags").Type("git_repository_init_flag_t"),
                    e => e.Map<CppField>("git_repository_init_options::mode").Type("git_repository_init_mode_t"),
                    e => e.Map<CppFunction>("git_repository_state").Type("git_repository_state_t"),
                    e => e.Map<CppFunction>("git_repository_is_shallow").Type("bool").MarshalAs(CSharpUnmanagedKind.I4),
                    e => e.Map<CppFunction>("git_repository_ident").Type("git_result"),
                    e => e.Map<CppFunction>("git_repository_set_ident").Type("git_result"),
                    
                    e => e.Map<CppField>("git_strarray::strings").Private(),
                    e => e.Map<CppField>("git_strarray::count").Private(),
                    e => e.MapAll<CppParameter>().CSharpAction(ProcessCSharpParameter),
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
            
            var fs = new PhysicalFileSystem();
            var subfs = new SubFileSystem(fs, fs.ConvertPathFromInternal(destFolder));
            
            var codeWriter = new CodeWriter(new CodeWriterOptions(subfs));
            csCompilation.DumpTo(codeWriter);
        }

        /// <summary>
        /// List of functions to not modify regarding strarray handling
        /// </summary>
        private static readonly HashSet<string> KeepRefForStrArrayMethods = new HashSet<string>()
        {
            "git_strarray_free",
            "git_strarray_copy",
        };

        private void ProcessCSharpParameter(CSharpConverter converter, CSharpElement element)
        {
            if (element is CSharpParameter csParam)
            {
                if (csParam.ParameterType is CSharpRefType refType)
                {
                    if (csParam.Name == "@out" && refType.Kind == CSharpRefKind.Ref)
                    {
                        refType.Kind = CSharpRefKind.Out;
                    }
                    else if (refType.ElementType is CSharpStruct csStruct && csStruct.Name == "git_strarray" && refType.Kind == CSharpRefKind.Ref)
                    {
                        if (csParam.Parent is CSharpMethod csParentMethod && !KeepRefForStrArrayMethods.Contains(csParentMethod.Name))
                        {
                            refType.Kind = CSharpRefKind.Out;
                        }
                    }
                }
            }
        }

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

        private void ProcessCppFunctions(CSharpConverter converter, CppElement cppFunctionElement)
        {
            var cppFunction = (CppFunction) cppFunctionElement;
            
            for (var i = cppFunction.Comment.Children.Count - 1; i >= 0; i--)
            {
                var csComment = cppFunction.Comment.Children[i];
                if (csComment is CppCommentBlockCommand blockCommand && blockCommand.CommandName == "return")
                {
                    var returnText = blockCommand.ChildrenToString().Trim().Replace("\r\n", " ").Replace("\n", " ");

                    if (((returnText.Contains("Zero on success") && returnText.Contains("-1 on failure")) ||
                         (returnText.Contains("0 on success") && returnText.Contains("0 on failure")) ||
                         (returnText.StartsWith("0") && (
                              returnText.Contains("or an error") ||
                              returnText.Contains("-1 on error") ||
                              returnText.Contains("or error") ||
                              returnText.Contains("error code otherwise") ||
                              returnText.Contains("other errors") ||
                              (returnText.Contains("or ") && returnText.Contains("on error"))))))
                    {

                        if (_gitResultType == null)
                        {
                            foreach (var typedef in converter.CurrentCppCompilation.Typedefs)
                            {
                                if (typedef.Name == "git_result")
                                {
                                    _gitResultType = typedef;
                                    break;
                                }
                            }
                        }

                        if (_gitResultType != null)
                        {
                            cppFunction.ReturnType = _gitResultType;
                        }
                    }

                    break;
                }
            }
        }

        private void ProcessCSharpMethods(CSharpConverter converter, CSharpElement element)
        {
            if (_gitResultType != null && element is CSharpMethod csMethod)
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

                var isGitResultMethod = csMethod.ReturnType.CppElement == _gitResultType;
                
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