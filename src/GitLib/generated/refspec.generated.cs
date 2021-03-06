//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;

namespace GitLib
{
    using System.Runtime.InteropServices;
    
    public static partial class libgit2
    {
        /// <summary>
        /// Parse a given refspec string
        /// </summary>
        /// <param name="refspec">a pointer to hold the refspec handle</param>
        /// <param name="input">the refspec string</param>
        /// <param name="is_fetch">is this a refspec for a fetch</param>
        /// <returns>0 if the refspec string could be parsed, -1 otherwise</returns>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int git_refspec_parse(out git_refspec refspec, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8MarshallerStrict))] string input, int is_fetch);
        
        /// <summary>
        /// Free a refspec object which has been created by git_refspec_parse
        /// </summary>
        /// <param name="refspec">the refspec object</param>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void git_refspec_free(git_refspec refspec);
        
        /// <summary>
        /// Get the source specifier
        /// </summary>
        /// <param name="refspec">the refspec</param>
        /// <returns>the refspec's source specifier</returns>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8MarshallerRelaxedNoCleanup))]
        public static extern string git_refspec_src(git_refspec refspec);
        
        /// <summary>
        /// Get the destination specifier
        /// </summary>
        /// <param name="refspec">the refspec</param>
        /// <returns>the refspec's destination specifier</returns>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8MarshallerRelaxedNoCleanup))]
        public static extern string git_refspec_dst(git_refspec refspec);
        
        /// <summary>
        /// Get the refspec's string
        /// </summary>
        /// <param name="refspec">the refspec</param>
        /// <remarks>
        /// @returns the refspec's original string
        /// </remarks>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8MarshallerRelaxedNoCleanup))]
        public static extern string git_refspec_string(git_refspec refspec);
        
        /// <summary>
        /// Get the force update setting
        /// </summary>
        /// <param name="refspec">the refspec</param>
        /// <returns>1 if force update has been set, 0 otherwise</returns>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int git_refspec_force(git_refspec refspec);
        
        /// <summary>
        /// Get the refspec's direction.
        /// </summary>
        /// <param name="spec">refspec</param>
        /// <returns>GIT_DIRECTION_FETCH or GIT_DIRECTION_PUSH</returns>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern git_direction git_refspec_direction(git_refspec spec);
        
        /// <summary>
        /// Check if a refspec's source descriptor matches a reference
        /// </summary>
        /// <param name="refspec">the refspec</param>
        /// <param name="refname">the name of the reference to check</param>
        /// <returns>1 if the refspec matches, 0 otherwise</returns>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int git_refspec_src_matches(git_refspec refspec, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8MarshallerStrict))] string refname);
        
        /// <summary>
        /// Check if a refspec's destination descriptor matches a reference
        /// </summary>
        /// <param name="refspec">the refspec</param>
        /// <param name="refname">the name of the reference to check</param>
        /// <returns>1 if the refspec matches, 0 otherwise</returns>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int git_refspec_dst_matches(git_refspec refspec, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8MarshallerStrict))] string refname);
        
        /// <summary>
        /// Transform a reference to its target following the refspec's rules
        /// </summary>
        /// <param name="out">where to store the target name</param>
        /// <param name="spec">the refspec</param>
        /// <param name="name">the name of the reference to transform</param>
        /// <returns>0, GIT_EBUFS or another error</returns>
        public static git_result git_refspec_transform(out git_buf @out, git_refspec spec, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8MarshallerStrict))] string name)
        {
            var __result__ = git_refspec_transform__(out @out, spec, name).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_refspec_transform", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_refspec_transform__(out git_buf @out, git_refspec spec, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8MarshallerStrict))] string name);
        
        /// <summary>
        /// Transform a target reference to its source reference following the refspec's rules
        /// </summary>
        /// <param name="out">where to store the source reference name</param>
        /// <param name="spec">the refspec</param>
        /// <param name="name">the name of the reference to transform</param>
        /// <returns>0, GIT_EBUFS or another error</returns>
        public static git_result git_refspec_rtransform(out git_buf @out, git_refspec spec, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8MarshallerStrict))] string name)
        {
            var __result__ = git_refspec_rtransform__(out @out, spec, name).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_refspec_rtransform", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_refspec_rtransform__(out git_buf @out, git_refspec spec, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8MarshallerStrict))] string name);
    }
}
