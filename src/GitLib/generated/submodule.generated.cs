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
        /// Return codes for submodule status.
        /// </summary>
        /// <remarks>
        /// A combination of these flags will be returned to describe the status of a
        /// submodule.  Depending on the "ignore" property of the submodule, some of
        /// the flags may never be returned because they indicate changes that are
        /// supposed to be ignored.Submodule info is contained in 4 places: the HEAD tree, the index, config
        /// files (both .git/config and .gitmodules), and the working directory.  Any
        /// or all of those places might be missing information about the submodule
        /// depending on what state the repo is in.  We consider all four places to
        /// build the combination of status flags.There are four values that are not really status, but give basic info
        /// about what sources of submodule data are available.  These will be
        /// returned even if ignore is set to "ALL".* IN_HEAD   - superproject head contains submodule
        /// * IN_INDEX  - superproject index contains submodule
        /// * IN_CONFIG - superproject gitmodules has submodule
        /// * IN_WD     - superproject workdir has submoduleThe following values will be returned so long as ignore is not "ALL".* INDEX_ADDED       - in index, not in head
        /// * INDEX_DELETED     - in head, not in index
        /// * INDEX_MODIFIED    - index and head don't match
        /// * WD_UNINITIALIZED  - workdir contains empty directory
        /// * WD_ADDED          - in workdir, not index
        /// * WD_DELETED        - in index, not workdir
        /// * WD_MODIFIED       - index and workdir head don't matchThe following can only be returned if ignore is "NONE" or "UNTRACKED".* WD_INDEX_MODIFIED - submodule workdir index is dirty
        /// * WD_WD_MODIFIED    - submodule workdir has modified filesLastly, the following will only be returned for ignore "NONE".* WD_UNTRACKED      - wd contains untracked files
        /// </remarks>
        [Flags]
        public enum git_submodule_status_t : int
        {
            GIT_SUBMODULE_STATUS_IN_HEAD = (int)(1u<<0),
            
            GIT_SUBMODULE_STATUS_IN_INDEX = (int)(1u<<1),
            
            GIT_SUBMODULE_STATUS_IN_CONFIG = (int)(1u<<2),
            
            GIT_SUBMODULE_STATUS_IN_WD = (int)(1u<<3),
            
            GIT_SUBMODULE_STATUS_INDEX_ADDED = (int)(1u<<4),
            
            GIT_SUBMODULE_STATUS_INDEX_DELETED = (int)(1u<<5),
            
            GIT_SUBMODULE_STATUS_INDEX_MODIFIED = (int)(1u<<6),
            
            GIT_SUBMODULE_STATUS_WD_UNINITIALIZED = (int)(1u<<7),
            
            GIT_SUBMODULE_STATUS_WD_ADDED = (int)(1u<<8),
            
            GIT_SUBMODULE_STATUS_WD_DELETED = (int)(1u<<9),
            
            GIT_SUBMODULE_STATUS_WD_MODIFIED = (int)(1u<<10),
            
            GIT_SUBMODULE_STATUS_WD_INDEX_MODIFIED = (int)(1u<<11),
            
            GIT_SUBMODULE_STATUS_WD_WD_MODIFIED = (int)(1u<<12),
            
            GIT_SUBMODULE_STATUS_WD_UNTRACKED = (int)(1u<<13),
        }
        
        public const git_submodule_status_t GIT_SUBMODULE_STATUS_IN_HEAD = git_submodule_status_t.GIT_SUBMODULE_STATUS_IN_HEAD;
        
        public const git_submodule_status_t GIT_SUBMODULE_STATUS_IN_INDEX = git_submodule_status_t.GIT_SUBMODULE_STATUS_IN_INDEX;
        
        public const git_submodule_status_t GIT_SUBMODULE_STATUS_IN_CONFIG = git_submodule_status_t.GIT_SUBMODULE_STATUS_IN_CONFIG;
        
        public const git_submodule_status_t GIT_SUBMODULE_STATUS_IN_WD = git_submodule_status_t.GIT_SUBMODULE_STATUS_IN_WD;
        
        public const git_submodule_status_t GIT_SUBMODULE_STATUS_INDEX_ADDED = git_submodule_status_t.GIT_SUBMODULE_STATUS_INDEX_ADDED;
        
        public const git_submodule_status_t GIT_SUBMODULE_STATUS_INDEX_DELETED = git_submodule_status_t.GIT_SUBMODULE_STATUS_INDEX_DELETED;
        
        public const git_submodule_status_t GIT_SUBMODULE_STATUS_INDEX_MODIFIED = git_submodule_status_t.GIT_SUBMODULE_STATUS_INDEX_MODIFIED;
        
        public const git_submodule_status_t GIT_SUBMODULE_STATUS_WD_UNINITIALIZED = git_submodule_status_t.GIT_SUBMODULE_STATUS_WD_UNINITIALIZED;
        
        public const git_submodule_status_t GIT_SUBMODULE_STATUS_WD_ADDED = git_submodule_status_t.GIT_SUBMODULE_STATUS_WD_ADDED;
        
        public const git_submodule_status_t GIT_SUBMODULE_STATUS_WD_DELETED = git_submodule_status_t.GIT_SUBMODULE_STATUS_WD_DELETED;
        
        public const git_submodule_status_t GIT_SUBMODULE_STATUS_WD_MODIFIED = git_submodule_status_t.GIT_SUBMODULE_STATUS_WD_MODIFIED;
        
        public const git_submodule_status_t GIT_SUBMODULE_STATUS_WD_INDEX_MODIFIED = git_submodule_status_t.GIT_SUBMODULE_STATUS_WD_INDEX_MODIFIED;
        
        public const git_submodule_status_t GIT_SUBMODULE_STATUS_WD_WD_MODIFIED = git_submodule_status_t.GIT_SUBMODULE_STATUS_WD_WD_MODIFIED;
        
        public const git_submodule_status_t GIT_SUBMODULE_STATUS_WD_UNTRACKED = git_submodule_status_t.GIT_SUBMODULE_STATUS_WD_UNTRACKED;
        
        /// <summary>
        /// Submodule update options structure
        /// </summary>
        /// <remarks>
        /// Initialize with `GIT_SUBMODULE_UPDATE_OPTIONS_INIT`. Alternatively, you can
        /// use `git_submodule_update_init_options`.
        /// </remarks>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public partial struct git_submodule_update_options
        {
            public uint version;
            
            /// <summary>
            /// These options are passed to the checkout step. To disable
            /// checkout, set the `checkout_strategy` to
            /// `GIT_CHECKOUT_NONE`. Generally you will want the use
            /// GIT_CHECKOUT_SAFE to update files in the working
            /// directory.
            /// </summary>
            public git_checkout_options checkout_opts;
            
            /// <summary>
            /// Options which control the fetch, including callbacks.
            /// </summary>
            /// <remarks>
            /// The callbacks to use for reporting fetch progress, and for acquiring
            /// credentials in the event they are needed.
            /// </remarks>
            public git_fetch_options fetch_opts;
            
            /// <summary>
            /// Allow fetching from the submodule's default remote if the target
            /// commit isn't found. Enabled by default.
            /// </summary>
            public int allow_fetch;
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int git_submodule_cb(git_submodule sm, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, IntPtr payload);
        
        /// <summary>
        /// Initialize git_submodule_update_options structure
        /// </summary>
        /// <param name="opts">The `git_submodule_update_options` struct to initialize.</param>
        /// <param name="version">The struct version; pass `GIT_SUBMODULE_UPDATE_OPTIONS_VERSION`.</param>
        /// <returns>Zero on success; -1 on failure.</returns>
        /// <remarks>
        /// Initializes a `git_submodule_update_options` with default values. Equivalent to
        /// creating an instance with `GIT_SUBMODULE_UPDATE_OPTIONS_INIT`.
        /// </remarks>
        public static git_result git_submodule_update_init_options(ref git_submodule_update_options opts, uint version)
        {
            var __result__ = git_submodule_update_init_options__(ref opts, version).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_submodule_update_init_options", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_submodule_update_init_options__(ref git_submodule_update_options opts, uint version);
        
        /// <summary>
        /// Update a submodule. This will clone a missing submodule and
        /// checkout the subrepository to the commit specified in the index of
        /// the containing repository. If the submodule repository doesn't contain
        /// the target commit (e.g. because fetchRecurseSubmodules isn't set), then
        /// the submodule is fetched using the fetch options supplied in options.
        /// </summary>
        /// <param name="submodule">Submodule object</param>
        /// <param name="init">If the submodule is not initialized, setting this flag to true
        /// will initialize the submodule before updating. Otherwise, this will
        /// return an error if attempting to update an uninitialzed repository.
        /// but setting this to true forces them to be updated.</param>
        /// <param name="options">configuration options for the update.  If NULL, the
        /// function works as though GIT_SUBMODULE_UPDATE_OPTIONS_INIT was passed.</param>
        /// <returns>0 on success, any non-zero return value from a callback
        /// function, or a negative value to indicate an error (use
        /// `git_error_last` for a detailed error message).</returns>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int git_submodule_update(git_submodule submodule, int init, ref git_submodule_update_options options);
        
        /// <summary>
        /// Lookup submodule information by name or path.
        /// </summary>
        /// <param name="out">Output ptr to submodule; pass NULL to just get return code</param>
        /// <param name="repo">The parent repository</param>
        /// <param name="name">The name of or path to the submodule; trailing slashes okay</param>
        /// <returns>0 on success, GIT_ENOTFOUND if submodule does not exist,
        /// GIT_EEXISTS if a repository is found in working directory only,
        /// -1 on other errors.</returns>
        /// <remarks>
        /// Given either the submodule name or path (they are usually the same), this
        /// returns a structure describing the submodule.There are two expected error scenarios:- The submodule is not mentioned in the HEAD, the index, and the config,
        /// but does "exist" in the working directory (i.e. there is a subdirectory
        /// that appears to be a Git repository).  In this case, this function
        /// returns GIT_EEXISTS to indicate a sub-repository exists but not in a
        /// state where a git_submodule can be instantiated.
        /// - The submodule is not mentioned in the HEAD, index, or config and the
        /// working directory doesn't contain a value git repo at that path.
        /// There may or may not be anything else at that path, but nothing that
        /// looks like a submodule.  In this case, this returns GIT_ENOTFOUND.You must call `git_submodule_free` when done with the submodule.
        /// </remarks>
        public static git_result git_submodule_lookup(out git_submodule @out, git_repository repo, [MarshalAs(UnmanagedType.LPUTF8Str)] string name)
        {
            var __result__ = git_submodule_lookup__(out @out, repo, name).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_submodule_lookup", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_submodule_lookup__(out git_submodule @out, git_repository repo, [MarshalAs(UnmanagedType.LPUTF8Str)] string name);
        
        /// <summary>
        /// Release a submodule
        /// </summary>
        /// <param name="submodule">Submodule object</param>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void git_submodule_free(git_submodule submodule);
        
        /// <summary>
        /// Iterate over all tracked submodules of a repository.
        /// </summary>
        /// <param name="repo">The repository</param>
        /// <param name="callback">Function to be called with the name of each submodule.
        /// Return a non-zero value to terminate the iteration.</param>
        /// <param name="payload">Extra data to pass to callback</param>
        /// <returns>0 on success, -1 on error, or non-zero return value of callback</returns>
        /// <remarks>
        /// See the note on `git_submodule` above.  This iterates over the tracked
        /// submodules as described therein.If you are concerned about items in the working directory that look like
        /// submodules but are not tracked, the diff API will generate a diff record
        /// for workdir items that look like submodules but are not tracked, showing
        /// them as added in the workdir.  Also, the status API will treat the entire
        /// subdirectory of a contained git repo as a single GIT_STATUS_WT_NEW item.
        /// </remarks>
        public static git_result git_submodule_foreach(git_repository repo, git_submodule_cb callback, IntPtr payload)
        {
            var __result__ = git_submodule_foreach__(repo, callback, payload).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_submodule_foreach", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_submodule_foreach__(git_repository repo, git_submodule_cb callback, IntPtr payload);
        
        /// <summary>
        /// Set up a new git submodule for checkout.
        /// </summary>
        /// <param name="out">The newly created submodule ready to open for clone</param>
        /// <param name="repo">The repository in which you want to create the submodule</param>
        /// <param name="url">URL for the submodule's remote</param>
        /// <param name="path">Path at which the submodule should be created</param>
        /// <param name="use_gitlink">Should workdir contain a gitlink to the repo in
        /// .git/modules vs. repo directly in workdir.</param>
        /// <returns>0 on success, GIT_EEXISTS if submodule already exists,
        /// -1 on other errors.</returns>
        /// <remarks>
        /// This does "git submodule add" up to the fetch and checkout of the
        /// submodule contents.  It preps a new submodule, creates an entry in
        /// .gitmodules and creates an empty initialized repository either at the
        /// given path in the working directory or in .git/modules with a gitlink
        /// from the working directory to the new repo.To fully emulate "git submodule add" call this function, then open the
        /// submodule repo and perform the clone step as needed.  Lastly, call
        /// `git_submodule_add_finalize()` to wrap up adding the new submodule and
        /// .gitmodules to the index to be ready to commit.You must call `git_submodule_free` on the submodule object when done.
        /// </remarks>
        public static git_result git_submodule_add_setup(out git_submodule @out, git_repository repo, [MarshalAs(UnmanagedType.LPUTF8Str)] string url, [MarshalAs(UnmanagedType.LPUTF8Str)] string path, int use_gitlink)
        {
            var __result__ = git_submodule_add_setup__(out @out, repo, url, path, use_gitlink).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_submodule_add_setup", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_submodule_add_setup__(out git_submodule @out, git_repository repo, [MarshalAs(UnmanagedType.LPUTF8Str)] string url, [MarshalAs(UnmanagedType.LPUTF8Str)] string path, int use_gitlink);
        
        /// <summary>
        /// Resolve the setup of a new git submodule.
        /// </summary>
        /// <param name="submodule">The submodule to finish adding.</param>
        /// <remarks>
        /// This should be called on a submodule once you have called add setup
        /// and done the clone of the submodule.  This adds the .gitmodules file
        /// and the newly cloned submodule to the index to be ready to be committed
        /// (but doesn't actually do the commit).
        /// </remarks>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int git_submodule_add_finalize(git_submodule submodule);
        
        /// <summary>
        /// Add current submodule HEAD commit to index of superproject.
        /// </summary>
        /// <param name="submodule">The submodule to add to the index</param>
        /// <param name="write_index">Boolean if this should immediately write the index
        /// file.  If you pass this as false, you will have to get the
        /// git_index and explicitly call `git_index_write()` on it to
        /// save the change.</param>
        /// <returns>0 on success, 
        /// &lt;
        /// 0 on failure</returns>
        public static git_result git_submodule_add_to_index(git_submodule submodule, int write_index)
        {
            var __result__ = git_submodule_add_to_index__(submodule, write_index).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_submodule_add_to_index", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_submodule_add_to_index__(git_submodule submodule, int write_index);
        
        /// <summary>
        /// Get the containing repository for a submodule.
        /// </summary>
        /// <param name="submodule">Pointer to submodule object</param>
        /// <returns>Pointer to `git_repository`</returns>
        /// <remarks>
        /// This returns a pointer to the repository that contains the submodule.
        /// This is a just a reference to the repository that was passed to the
        /// original `git_submodule_lookup()` call, so if that repository has been
        /// freed, then this may be a dangling reference.
        /// </remarks>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern git_repository git_submodule_owner(git_submodule submodule);
        
        /// <summary>
        /// Get the name of submodule.
        /// </summary>
        /// <param name="submodule">Pointer to submodule object</param>
        /// <returns>Pointer to the submodule name</returns>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        [return:MarshalAs(UnmanagedType.LPUTF8Str)]
        public static extern string git_submodule_name(git_submodule submodule);
        
        /// <summary>
        /// Get the path to the submodule.
        /// </summary>
        /// <param name="submodule">Pointer to submodule object</param>
        /// <returns>Pointer to the submodule path</returns>
        /// <remarks>
        /// The path is almost always the same as the submodule name, but the
        /// two are actually not required to match.
        /// </remarks>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        [return:MarshalAs(UnmanagedType.LPUTF8Str)]
        public static extern string git_submodule_path(git_submodule submodule);
        
        /// <summary>
        /// Get the URL for the submodule.
        /// </summary>
        /// <param name="submodule">Pointer to submodule object</param>
        /// <returns>Pointer to the submodule url</returns>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        [return:MarshalAs(UnmanagedType.LPUTF8Str)]
        public static extern string git_submodule_url(git_submodule submodule);
        
        /// <summary>
        /// Resolve a submodule url relative to the given repository.
        /// </summary>
        /// <param name="out">buffer to store the absolute submodule url in</param>
        /// <param name="repo">Pointer to repository object</param>
        /// <param name="url">Relative url</param>
        /// <returns>0 or an error code</returns>
        public static git_result git_submodule_resolve_url(out git_buf @out, git_repository repo, [MarshalAs(UnmanagedType.LPUTF8Str)] string url)
        {
            var __result__ = git_submodule_resolve_url__(out @out, repo, url).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_submodule_resolve_url", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_submodule_resolve_url__(out git_buf @out, git_repository repo, [MarshalAs(UnmanagedType.LPUTF8Str)] string url);
        
        /// <summary>
        /// Get the branch for the submodule.
        /// </summary>
        /// <param name="submodule">Pointer to submodule object</param>
        /// <returns>Pointer to the submodule branch</returns>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        [return:MarshalAs(UnmanagedType.LPUTF8Str)]
        public static extern string git_submodule_branch(git_submodule submodule);
        
        /// <summary>
        /// Set the branch for the submodule in the configuration
        /// </summary>
        /// <param name="repo">the repository to affect</param>
        /// <param name="name">the name of the submodule to configure</param>
        /// <param name="branch">Branch that should be used for the submodule</param>
        /// <returns>0 on success, 
        /// &lt;
        /// 0 on failure</returns>
        /// <remarks>
        /// After calling this, you may wish to call `git_submodule_sync()` to
        /// write the changes to the checked out submodule repository.
        /// </remarks>
        public static git_result git_submodule_set_branch(git_repository repo, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, [MarshalAs(UnmanagedType.LPUTF8Str)] string branch)
        {
            var __result__ = git_submodule_set_branch__(repo, name, branch).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_submodule_set_branch", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_submodule_set_branch__(git_repository repo, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, [MarshalAs(UnmanagedType.LPUTF8Str)] string branch);
        
        /// <summary>
        /// Set the URL for the submodule in the configuration
        /// </summary>
        /// <param name="repo">the repository to affect</param>
        /// <param name="name">the name of the submodule to configure</param>
        /// <param name="url">URL that should be used for the submodule</param>
        /// <returns>0 on success, 
        /// &lt;
        /// 0 on failure</returns>
        /// <remarks>
        /// After calling this, you may wish to call `git_submodule_sync()` to
        /// write the changes to the checked out submodule repository.
        /// </remarks>
        public static git_result git_submodule_set_url(git_repository repo, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, [MarshalAs(UnmanagedType.LPUTF8Str)] string url)
        {
            var __result__ = git_submodule_set_url__(repo, name, url).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_submodule_set_url", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_submodule_set_url__(git_repository repo, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, [MarshalAs(UnmanagedType.LPUTF8Str)] string url);
        
        /// <summary>
        /// Get the OID for the submodule in the index.
        /// </summary>
        /// <param name="submodule">Pointer to submodule object</param>
        /// <returns>Pointer to git_oid or NULL if submodule is not in index.</returns>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ref readonly git_oid git_submodule_index_id(git_submodule submodule);
        
        /// <summary>
        /// Get the OID for the submodule in the current HEAD tree.
        /// </summary>
        /// <param name="submodule">Pointer to submodule object</param>
        /// <returns>Pointer to git_oid or NULL if submodule is not in the HEAD.</returns>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ref readonly git_oid git_submodule_head_id(git_submodule submodule);
        
        /// <summary>
        /// Get the OID for the submodule in the current working directory.
        /// </summary>
        /// <param name="submodule">Pointer to submodule object</param>
        /// <returns>Pointer to git_oid or NULL if submodule is not checked out.</returns>
        /// <remarks>
        /// This returns the OID that corresponds to looking up 'HEAD' in the checked
        /// out submodule.  If there are pending changes in the index or anything
        /// else, this won't notice that.  You should call `git_submodule_status()`
        /// for a more complete picture about the state of the working directory.
        /// </remarks>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ref readonly git_oid git_submodule_wd_id(git_submodule submodule);
        
        /// <summary>
        /// Get the ignore rule that will be used for the submodule.
        /// </summary>
        /// <param name="submodule">The submodule to check</param>
        /// <returns>The current git_submodule_ignore_t valyue what will be used for
        /// this submodule.</returns>
        /// <remarks>
        /// These values control the behavior of `git_submodule_status()` for this
        /// submodule.  There are four ignore values:- **GIT_SUBMODULE_IGNORE_NONE** will consider any change to the contents
        /// of the submodule from a clean checkout to be dirty, including the
        /// addition of untracked files.  This is the default if unspecified.
        /// - **GIT_SUBMODULE_IGNORE_UNTRACKED** examines the contents of the
        /// working tree (i.e. call `git_status_foreach()` on the submodule) but
        /// UNTRACKED files will not count as making the submodule dirty.
        /// - **GIT_SUBMODULE_IGNORE_DIRTY** means to only check if the HEAD of the
        /// submodule has moved for status.  This is fast since it does not need to
        /// scan the working tree of the submodule at all.
        /// - **GIT_SUBMODULE_IGNORE_ALL** means not to open the submodule repo.
        /// The working directory will be consider clean so long as there is a
        /// checked out version present.
        /// </remarks>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern git_submodule_ignore_t git_submodule_ignore(git_submodule submodule);
        
        /// <summary>
        /// Set the ignore rule for the submodule in the configuration
        /// </summary>
        /// <param name="repo">the repository to affect</param>
        /// <param name="name">the name of the submdule</param>
        /// <param name="ignore">The new value for the ignore rule</param>
        /// <returns>0 or an error code</returns>
        /// <remarks>
        /// This does not affect any currently-loaded instances.
        /// </remarks>
        public static git_result git_submodule_set_ignore(git_repository repo, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, git_submodule_ignore_t ignore)
        {
            var __result__ = git_submodule_set_ignore__(repo, name, ignore).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_submodule_set_ignore", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_submodule_set_ignore__(git_repository repo, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, git_submodule_ignore_t ignore);
        
        /// <summary>
        /// Get the update rule that will be used for the submodule.
        /// </summary>
        /// <param name="submodule">The submodule to check</param>
        /// <returns>The current git_submodule_update_t value that will be used
        /// for this submodule.</returns>
        /// <remarks>
        /// This value controls the behavior of the `git submodule update` command.
        /// There are four useful values documented with `git_submodule_update_t`.
        /// </remarks>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern git_submodule_update_t git_submodule_update_strategy(git_submodule submodule);
        
        /// <summary>
        /// Set the update rule for the submodule in the configuration
        /// </summary>
        /// <param name="repo">the repository to affect</param>
        /// <param name="name">the name of the submodule to configure</param>
        /// <param name="update">The new value to use</param>
        /// <returns>0 or an error code</returns>
        /// <remarks>
        /// This setting won't affect any existing instances.
        /// </remarks>
        public static git_result git_submodule_set_update(git_repository repo, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, git_submodule_update_t update)
        {
            var __result__ = git_submodule_set_update__(repo, name, update).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_submodule_set_update", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_submodule_set_update__(git_repository repo, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, git_submodule_update_t update);
        
        /// <summary>
        /// Read the fetchRecurseSubmodules rule for a submodule.
        /// </summary>
        /// <returns>0 if fetchRecurseSubmodules is false, 1 if true</returns>
        /// <remarks>
        /// This accesses the submodule.
        /// &lt;name
        /// &gt;.fetchRecurseSubmodules value for
        /// the submodule that controls fetching behavior for the submodule.Note that at this time, libgit2 does not honor this setting and the
        /// fetch functionality current ignores submodules.
        /// </remarks>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern git_submodule_recurse_t git_submodule_fetch_recurse_submodules(git_submodule submodule);
        
        /// <summary>
        /// Set the fetchRecurseSubmodules rule for a submodule in the configuration
        /// </summary>
        /// <param name="repo">the repository to affect</param>
        /// <param name="name">the submodule to configure</param>
        /// <param name="fetch_recurse_submodules">Boolean value</param>
        /// <returns>old value for fetchRecurseSubmodules</returns>
        /// <remarks>
        /// This setting won't affect any existing instances.
        /// </remarks>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int git_submodule_set_fetch_recurse_submodules(git_repository repo, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, git_submodule_recurse_t fetch_recurse_submodules);
        
        /// <summary>
        /// Copy submodule info into ".git/config" file.
        /// </summary>
        /// <param name="submodule">The submodule to write into the superproject config</param>
        /// <param name="overwrite">By default, existing entries will not be overwritten,
        /// but setting this to true forces them to be updated.</param>
        /// <returns>0 on success, 
        /// &lt;
        /// 0 on failure.</returns>
        /// <remarks>
        /// Just like "git submodule init", this copies information about the
        /// submodule into ".git/config".  You can use the accessor functions
        /// above to alter the in-memory git_submodule object and control what
        /// is written to the config, overriding what is in .gitmodules.
        /// </remarks>
        public static git_result git_submodule_init(git_submodule submodule, int overwrite)
        {
            var __result__ = git_submodule_init__(submodule, overwrite).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_submodule_init", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_submodule_init__(git_submodule submodule, int overwrite);
        
        /// <summary>
        /// Set up the subrepository for a submodule in preparation for clone.
        /// </summary>
        /// <param name="out">Output pointer to the created git repository.</param>
        /// <param name="sm">The submodule to create a new subrepository from.</param>
        /// <param name="use_gitlink">Should the workdir contain a gitlink to
        /// the repo in .git/modules vs. repo directly in workdir.</param>
        /// <returns>0 on success, 
        /// &lt;
        /// 0 on failure.</returns>
        /// <remarks>
        /// This function can be called to init and set up a submodule
        /// repository from a submodule in preparation to clone it from
        /// its remote.
        /// </remarks>
        public static git_result git_submodule_repo_init(out git_repository @out, git_submodule sm, int use_gitlink)
        {
            var __result__ = git_submodule_repo_init__(out @out, sm, use_gitlink).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_submodule_repo_init", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_submodule_repo_init__(out git_repository @out, git_submodule sm, int use_gitlink);
        
        /// <summary>
        /// Copy submodule remote info into submodule repo.
        /// </summary>
        /// <remarks>
        /// This copies the information about the submodules URL into the checked out
        /// submodule config, acting like "git submodule sync".  This is useful if
        /// you have altered the URL for the submodule (or it has been altered by a
        /// fetch of upstream changes) and you need to update your local repo.
        /// </remarks>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int git_submodule_sync(git_submodule submodule);
        
        /// <summary>
        /// Open the repository for a submodule.
        /// </summary>
        /// <param name="repo">Pointer to the submodule repo which was opened</param>
        /// <param name="submodule">Submodule to be opened</param>
        /// <returns>0 on success, 
        /// &lt;
        /// 0 if submodule repo could not be opened.</returns>
        /// <remarks>
        /// This is a newly opened repository object.  The caller is responsible for
        /// calling `git_repository_free()` on it when done.  Multiple calls to this
        /// function will return distinct `git_repository` objects.  This will only
        /// work if the submodule is checked out into the working directory.
        /// </remarks>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int git_submodule_open(out git_repository repo, git_submodule submodule);
        
        /// <summary>
        /// Reread submodule info from config, index, and HEAD.
        /// </summary>
        /// <param name="submodule">The submodule to reload</param>
        /// <param name="force">Force reload even if the data doesn't seem out of date</param>
        /// <returns>0 on success, 
        /// &lt;
        /// 0 on error</returns>
        /// <remarks>
        /// Call this to reread cached submodule information for this submodule if
        /// you have reason to believe that it has changed.
        /// </remarks>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int git_submodule_reload(git_submodule submodule, int force);
        
        /// <summary>
        /// Get the status for a submodule.
        /// </summary>
        /// <param name="status">Combination of `GIT_SUBMODULE_STATUS` flags</param>
        /// <param name="repo">the repository in which to look</param>
        /// <param name="name">name of the submodule</param>
        /// <param name="ignore">the ignore rules to follow</param>
        /// <returns>0 on success, 
        /// &lt;
        /// 0 on error</returns>
        /// <remarks>
        /// This looks at a submodule and tries to determine the status.  It
        /// will return a combination of the `GIT_SUBMODULE_STATUS` values above.
        /// How deeply it examines the working directory to do this will depend
        /// on the `git_submodule_ignore_t` value for the submodule.
        /// </remarks>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int git_submodule_status(ref uint status, git_repository repo, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, git_submodule_ignore_t ignore);
        
        /// <summary>
        /// Get the locations of submodule information.
        /// </summary>
        /// <param name="location_status">Combination of first four `GIT_SUBMODULE_STATUS` flags</param>
        /// <param name="submodule">Submodule for which to get status</param>
        /// <returns>0 on success, 
        /// &lt;
        /// 0 on error</returns>
        /// <remarks>
        /// This is a bit like a very lightweight version of `git_submodule_status`.
        /// It just returns a made of the first four submodule status values (i.e.
        /// the ones like GIT_SUBMODULE_STATUS_IN_HEAD, etc) that tell you where the
        /// submodule data comes from (i.e. the HEAD commit, gitmodules file, etc.).
        /// This can be useful if you want to know if the submodule is present in the
        /// working directory at this point in time, etc.
        /// </remarks>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int git_submodule_location(ref uint location_status, git_submodule submodule);
    }
}