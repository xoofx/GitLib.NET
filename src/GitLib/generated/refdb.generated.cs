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
        /// Create a new reference database with no backends.
        /// </summary>
        /// <param name="out">location to store the database pointer, if opened.
        /// Set to NULL if the open failed.</param>
        /// <param name="repo">the repository</param>
        /// <returns>0 or an error code</returns>
        /// <remarks>
        /// Before the Ref DB can be used for read/writing, a custom database
        /// backend must be manually set using `git_refdb_set_backend()`
        /// </remarks>
        public static git_result git_refdb_new(out git_refdb @out, git_repository repo)
        {
            var __result__ = git_refdb_new__(out @out, repo).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_refdb_new", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_refdb_new__(out git_refdb @out, git_repository repo);
        
        /// <summary>
        /// Create a new reference database and automatically add
        /// the default backends:
        /// </summary>
        /// <param name="out">location to store the database pointer, if opened.
        /// Set to NULL if the open failed.</param>
        /// <param name="repo">the repository</param>
        /// <returns>0 or an error code</returns>
        /// <remarks>
        /// - git_refdb_dir: read and write loose and packed refs
        /// from disk, assuming the repository dir as the folder
        /// </remarks>
        public static git_result git_refdb_open(out git_refdb @out, git_repository repo)
        {
            var __result__ = git_refdb_open__(out @out, repo).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_refdb_open", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_refdb_open__(out git_refdb @out, git_repository repo);
        
        /// <summary>
        /// Suggests that the given refdb compress or optimize its references.
        /// This mechanism is implementation specific.  For on-disk reference
        /// databases, for example, this may pack all loose references.
        /// </summary>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int git_refdb_compress(git_refdb refdb);
        
        /// <summary>
        /// Close an open reference database.
        /// </summary>
        /// <param name="refdb">reference database pointer or NULL</param>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void git_refdb_free(git_refdb refdb);
    }
}
