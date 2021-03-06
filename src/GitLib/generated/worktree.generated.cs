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
        /// Flags which can be passed to git_worktree_prune to alter its
        /// behavior.
        /// </summary>
        [Flags]
        public enum git_worktree_prune_t : int
        {
            /// <summary>
            /// Prune working tree even if working tree is valid
            /// </summary>
            GIT_WORKTREE_PRUNE_VALID = (int)1u<<0,
            
            /// <summary>
            /// Prune working tree even if it is locked
            /// </summary>
            GIT_WORKTREE_PRUNE_LOCKED = (int)1u<<1,
            
            /// <summary>
            /// Prune checked out working tree
            /// </summary>
            GIT_WORKTREE_PRUNE_WORKING_TREE = (int)1u<<2,
        }
        
        /// <summary>
        /// Prune working tree even if working tree is valid
        /// </summary>
        public const git_worktree_prune_t GIT_WORKTREE_PRUNE_VALID = git_worktree_prune_t.GIT_WORKTREE_PRUNE_VALID;
        
        /// <summary>
        /// Prune working tree even if it is locked
        /// </summary>
        public const git_worktree_prune_t GIT_WORKTREE_PRUNE_LOCKED = git_worktree_prune_t.GIT_WORKTREE_PRUNE_LOCKED;
        
        /// <summary>
        /// Prune checked out working tree
        /// </summary>
        public const git_worktree_prune_t GIT_WORKTREE_PRUNE_WORKING_TREE = git_worktree_prune_t.GIT_WORKTREE_PRUNE_WORKING_TREE;
        
        /// <summary>
        /// Worktree add options structure
        /// </summary>
        /// <remarks>
        /// Initialize with `GIT_WORKTREE_ADD_OPTIONS_INIT`. Alternatively, you can
        /// use `git_worktree_add_init_options`.
        /// </remarks>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public partial struct git_worktree_add_options
        {
            public uint version;
            
            /// <summary>
            /// lock newly created worktree
            /// </summary>
            public int @lock;
            
            /// <summary>
            /// reference to use for the new worktree HEAD
            /// </summary>
            public git_reference @ref;
        }
        
        /// <summary>
        /// Worktree prune options structure
        /// </summary>
        /// <remarks>
        /// Initialize with `GIT_WORKTREE_PRUNE_OPTIONS_INIT`. Alternatively, you can
        /// use `git_worktree_prune_init_options`.
        /// </remarks>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public partial struct git_worktree_prune_options
        {
            public uint version;
            
            public uint flags;
        }
        
        /// <summary>
        /// List names of linked working trees
        /// </summary>
        /// <param name="out">pointer to the array of working tree names</param>
        /// <param name="repo">the repo to use when listing working trees</param>
        /// <returns>0 or an error code</returns>
        /// <remarks>
        /// The returned list should be released with `git_strarray_free`
        /// when no longer needed.
        /// </remarks>
        public static git_result git_worktree_list(out string[] @out, git_repository repo)
        {
            git_strarray @out__;
            var __result__ = git_worktree_list__(out @out__, repo).Check();
            @out = @out__.ToArray();
            git_strarray_free(ref @out__);
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_worktree_list", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_worktree_list__(out git_strarray @out, git_repository repo);
        
        /// <summary>
        /// Lookup a working tree by its name for a given repository
        /// </summary>
        /// <param name="out">Output pointer to looked up worktree or `NULL`</param>
        /// <param name="repo">The repository containing worktrees</param>
        /// <param name="name">Name of the working tree to look up</param>
        /// <returns>0 or an error code</returns>
        public static git_result git_worktree_lookup(out git_worktree @out, git_repository repo, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8MarshallerStrict))] string name)
        {
            var __result__ = git_worktree_lookup__(out @out, repo, name).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_worktree_lookup", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_worktree_lookup__(out git_worktree @out, git_repository repo, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8MarshallerStrict))] string name);
        
        /// <summary>
        /// Open a worktree of a given repository
        /// </summary>
        /// <param name="out">Out-pointer for the newly allocated worktree</param>
        /// <param name="repo">Repository to look up worktree for</param>
        /// <remarks>
        /// If a repository is not the main tree but a worktree, this
        /// function will look up the worktree inside the parent
        /// repository and create a new `git_worktree` structure.
        /// </remarks>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int git_worktree_open_from_repository(out git_worktree @out, git_repository repo);
        
        /// <summary>
        /// Free a previously allocated worktree
        /// </summary>
        /// <param name="wt">worktree handle to close. If NULL nothing occurs.</param>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void git_worktree_free(git_worktree wt);
        
        /// <summary>
        /// Check if worktree is valid
        /// </summary>
        /// <param name="wt">Worktree to check</param>
        /// <returns>0 when worktree is valid, error-code otherwise</returns>
        /// <remarks>
        /// A valid worktree requires both the git data structures inside
        /// the linked parent repository and the linked working copy to be
        /// present.
        /// </remarks>
        public static git_result git_worktree_validate(git_worktree wt)
        {
            var __result__ = git_worktree_validate__(wt).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_worktree_validate", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_worktree_validate__(git_worktree wt);
        
        /// <summary>
        /// Initialize git_worktree_add_options structure
        /// </summary>
        /// <param name="opts">The `git_worktree_add_options` struct to initialize.</param>
        /// <param name="version">The struct version; pass `GIT_WORKTREE_ADD_OPTIONS_VERSION`.</param>
        /// <returns>Zero on success; -1 on failure.</returns>
        /// <remarks>
        /// Initializes a `git_worktree_add_options` with default values. Equivalent to
        /// creating an instance with `GIT_WORKTREE_ADD_OPTIONS_INIT`.
        /// </remarks>
        public static git_result git_worktree_add_init_options(ref git_worktree_add_options opts, uint version)
        {
            var __result__ = git_worktree_add_init_options__(ref opts, version).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_worktree_add_init_options", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_worktree_add_init_options__(ref git_worktree_add_options opts, uint version);
        
        /// <summary>
        /// Add a new working tree
        /// </summary>
        /// <param name="out">Output pointer containing new working tree</param>
        /// <param name="repo">Repository to create working tree for</param>
        /// <param name="name">Name of the working tree</param>
        /// <param name="path">Path to create working tree at</param>
        /// <param name="opts">Options to modify default behavior. May be NULL</param>
        /// <returns>0 or an error code</returns>
        /// <remarks>
        /// Add a new working tree for the repository, that is create the
        /// required data structures inside the repository and check out
        /// the current HEAD at `path`
        /// </remarks>
        public static git_result git_worktree_add(out git_worktree @out, git_repository repo, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8MarshallerStrict))] string name, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8MarshallerStrict))] string path, in git_worktree_add_options opts)
        {
            var __result__ = git_worktree_add__(out @out, repo, name, path, opts).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_worktree_add", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_worktree_add__(out git_worktree @out, git_repository repo, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8MarshallerStrict))] string name, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8MarshallerStrict))] string path, in git_worktree_add_options opts);
        
        /// <summary>
        /// Lock worktree if not already locked
        /// </summary>
        /// <param name="wt">Worktree to lock</param>
        /// <param name="reason">Reason why the working tree is being locked</param>
        /// <returns>0 on success, non-zero otherwise</returns>
        /// <remarks>
        /// Lock a worktree, optionally specifying a reason why the linked
        /// working tree is being locked.
        /// </remarks>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int git_worktree_lock(git_worktree wt, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8MarshallerStrict))] string reason);
        
        /// <summary>
        /// Unlock a locked worktree
        /// </summary>
        /// <param name="wt">Worktree to unlock</param>
        /// <returns>0 on success, 1 if worktree was not locked, error-code
        /// otherwise</returns>
        public static git_result git_worktree_unlock(git_worktree wt)
        {
            var __result__ = git_worktree_unlock__(wt).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_worktree_unlock", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_worktree_unlock__(git_worktree wt);
        
        /// <summary>
        /// Check if worktree is locked
        /// </summary>
        /// <param name="reason">Buffer to store reason in. If NULL no reason is stored.</param>
        /// <param name="wt">Worktree to check</param>
        /// <returns>0 when the working tree not locked, a value greater
        /// than zero if it is locked, less than zero if there was an
        /// error</returns>
        /// <remarks>
        /// A worktree may be locked if the linked working tree is stored
        /// on a portable device which is not available.
        /// </remarks>
        public static git_result git_worktree_is_locked(ref git_buf reason, git_worktree wt)
        {
            var __result__ = git_worktree_is_locked__(ref reason, wt).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_worktree_is_locked", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_worktree_is_locked__(ref git_buf reason, git_worktree wt);
        
        /// <summary>
        /// Retrieve the name of the worktree
        /// </summary>
        /// <param name="wt">Worktree to get the name for</param>
        /// <returns>The worktree's name. The pointer returned is valid for the
        /// lifetime of the git_worktree</returns>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8MarshallerRelaxedNoCleanup))]
        public static extern string git_worktree_name(git_worktree wt);
        
        /// <summary>
        /// Retrieve the filesystem path for the worktree
        /// </summary>
        /// <param name="wt">Worktree to get the path for</param>
        /// <returns>The worktree's filesystem path. The pointer returned
        /// is valid for the lifetime of the git_worktree.</returns>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8MarshallerRelaxedNoCleanup))]
        public static extern string git_worktree_path(git_worktree wt);
        
        /// <summary>
        /// Initialize git_worktree_prune_options structure
        /// </summary>
        /// <param name="opts">The `git_worktree_prune_options` struct to initialize.</param>
        /// <param name="version">The struct version; pass `GIT_WORKTREE_PRUNE_OPTIONS_VERSION`.</param>
        /// <returns>Zero on success; -1 on failure.</returns>
        /// <remarks>
        /// Initializes a `git_worktree_prune_options` with default values. Equivalent to
        /// creating an instance with `GIT_WORKTREE_PRUNE_OPTIONS_INIT`.
        /// </remarks>
        public static git_result git_worktree_prune_init_options(ref git_worktree_prune_options opts, uint version)
        {
            var __result__ = git_worktree_prune_init_options__(ref opts, version).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_worktree_prune_init_options", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_worktree_prune_init_options__(ref git_worktree_prune_options opts, uint version);
        
        /// <summary>
        /// Is the worktree prunable with the given options?
        /// </summary>
        /// <remarks>
        /// A worktree is not prunable in the following scenarios:- the worktree is linking to a valid on-disk worktree. The
        /// `valid` member will cause this check to be ignored.
        /// - the worktree is locked. The `locked` flag will cause this
        /// check to be ignored.If the worktree is not valid and not locked or if the above
        /// flags have been passed in, this function will return a
        /// positive value.
        /// </remarks>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int git_worktree_is_prunable(git_worktree wt, ref git_worktree_prune_options opts);
        
        /// <summary>
        /// Prune working tree
        /// </summary>
        /// <param name="wt">Worktree to prune</param>
        /// <param name="opts">Specifies which checks to override. See
        /// `git_worktree_is_prunable`. May be NULL</param>
        /// <returns>0 or an error code</returns>
        /// <remarks>
        /// Prune the working tree, that is remove the git data
        /// structures on disk. The repository will only be pruned of
        /// `git_worktree_is_prunable` succeeds.
        /// </remarks>
        public static git_result git_worktree_prune(git_worktree wt, ref git_worktree_prune_options opts)
        {
            var __result__ = git_worktree_prune__(wt, ref opts).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_worktree_prune", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_worktree_prune__(git_worktree wt, ref git_worktree_prune_options opts);
    }
}
