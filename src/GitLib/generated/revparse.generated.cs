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
        /// Revparse flags.  These indicate the intended behavior of the spec passed to
        /// git_revparse.
        /// </summary>
        [Flags]
        public enum git_revparse_mode_t : int
        {
            /// <summary>
            /// The spec targeted a single object.
            /// </summary>
            GIT_REVPARSE_SINGLE = (int)1 << 0,
            
            /// <summary>
            /// The spec targeted a range of commits.
            /// </summary>
            GIT_REVPARSE_RANGE = (int)1 << 1,
            
            /// <summary>
            /// The spec used the '...' operator, which invokes special semantics.
            /// </summary>
            GIT_REVPARSE_MERGE_BASE = (int)1 << 2,
        }
        
        /// <summary>
        /// The spec targeted a single object.
        /// </summary>
        public const git_revparse_mode_t GIT_REVPARSE_SINGLE = git_revparse_mode_t.GIT_REVPARSE_SINGLE;
        
        /// <summary>
        /// The spec targeted a range of commits.
        /// </summary>
        public const git_revparse_mode_t GIT_REVPARSE_RANGE = git_revparse_mode_t.GIT_REVPARSE_RANGE;
        
        /// <summary>
        /// The spec used the '...' operator, which invokes special semantics.
        /// </summary>
        public const git_revparse_mode_t GIT_REVPARSE_MERGE_BASE = git_revparse_mode_t.GIT_REVPARSE_MERGE_BASE;
        
        /// <summary>
        /// Git Revision Spec: output of a `git_revparse` operation
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public partial struct git_revspec
        {
            /// <summary>
            /// The left element of the revspec; must be freed by the user
            /// </summary>
            public git_object from;
            
            /// <summary>
            /// The right element of the revspec; must be freed by the user
            /// </summary>
            public git_object to;
            
            /// <summary>
            /// The intent of the revspec (i.e. `git_revparse_mode_t` flags)
            /// </summary>
            public uint flags;
        }
        
        /// <summary>
        /// Find a single object, as specified by a revision string.
        /// </summary>
        /// <param name="out">pointer to output object</param>
        /// <param name="repo">the repository to search in</param>
        /// <param name="spec">the textual specification for an object</param>
        /// <returns>0 on success, GIT_ENOTFOUND, GIT_EAMBIGUOUS, GIT_EINVALIDSPEC or an error code</returns>
        /// <remarks>
        /// See `man gitrevisions`, or
        /// http://git-scm.com/docs/git-rev-parse.html#_specifying_revisions for
        /// information on the syntax accepted.The returned object should be released with `git_object_free` when no
        /// longer needed.
        /// </remarks>
        public static git_result git_revparse_single(out git_object @out, git_repository repo, [MarshalAs(UnmanagedType.LPUTF8Str)] string spec)
        {
            var __result__ = git_revparse_single__(out @out, repo, spec).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_revparse_single", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_revparse_single__(out git_object @out, git_repository repo, [MarshalAs(UnmanagedType.LPUTF8Str)] string spec);
        
        /// <summary>
        /// Find a single object and intermediate reference by a revision string.
        /// </summary>
        /// <param name="object_out">pointer to output object</param>
        /// <param name="reference_out">pointer to output reference or NULL</param>
        /// <param name="repo">the repository to search in</param>
        /// <param name="spec">the textual specification for an object</param>
        /// <returns>0 on success, GIT_ENOTFOUND, GIT_EAMBIGUOUS, GIT_EINVALIDSPEC
        /// or an error code</returns>
        /// <remarks>
        /// See `man gitrevisions`, or
        /// http://git-scm.com/docs/git-rev-parse.html#_specifying_revisions for
        /// information on the syntax accepted.In some cases (`
        /// @
        /// {
        /// &lt;
        /// -n&gt;}` or `
        /// &lt;branchname
        /// &gt;
        /// @
        /// {upstream}`), the expression may
        /// point to an intermediate reference. When such expressions are being passed
        /// in, `reference_out` will be valued as well.The returned object should be released with `git_object_free` and the
        /// returned reference with `git_reference_free` when no longer needed.
        /// </remarks>
        public static git_result git_revparse_ext(out git_object object_out, out git_reference reference_out, git_repository repo, [MarshalAs(UnmanagedType.LPUTF8Str)] string spec)
        {
            var __result__ = git_revparse_ext__(out object_out, out reference_out, repo, spec).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_revparse_ext", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_revparse_ext__(out git_object object_out, out git_reference reference_out, git_repository repo, [MarshalAs(UnmanagedType.LPUTF8Str)] string spec);
        
        /// <summary>
        /// Parse a revision string for `from`, `to`, and intent.
        /// </summary>
        /// <param name="revspec">Pointer to an user-allocated git_revspec struct where
        /// the result of the rev-parse will be stored</param>
        /// <param name="repo">the repository to search in</param>
        /// <param name="spec">the rev-parse spec to parse</param>
        /// <returns>0 on success, GIT_INVALIDSPEC, GIT_ENOTFOUND, GIT_EAMBIGUOUS or an error code</returns>
        /// <remarks>
        /// See `man gitrevisions` or
        /// http://git-scm.com/docs/git-rev-parse.html#_specifying_revisions for
        /// information on the syntax accepted.
        /// </remarks>
        public static git_result git_revparse(ref git_revspec revspec, git_repository repo, [MarshalAs(UnmanagedType.LPUTF8Str)] string spec)
        {
            var __result__ = git_revparse__(ref revspec, repo, spec).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_revparse", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_revparse__(ref git_revspec revspec, git_repository repo, [MarshalAs(UnmanagedType.LPUTF8Str)] string spec);
    }
}