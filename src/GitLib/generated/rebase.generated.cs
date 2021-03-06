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
        /// Type of rebase operation in-progress after calling `git_rebase_next`.
        /// </summary>
        public enum git_rebase_operation_t : int
        {
            /// <summary>
            /// The given commit is to be cherry-picked.  The client should commit
            /// the changes and continue if there are no conflicts.
            /// </summary>
            GIT_REBASE_OPERATION_PICK = (int)0,
            
            /// <summary>
            /// The given commit is to be cherry-picked, but the client should prompt
            /// the user to provide an updated commit message.
            /// </summary>
            GIT_REBASE_OPERATION_REWORD,
            
            /// <summary>
            /// The given commit is to be cherry-picked, but the client should stop
            /// to allow the user to edit the changes before committing them.
            /// </summary>
            GIT_REBASE_OPERATION_EDIT,
            
            /// <summary>
            /// The given commit is to be squashed into the previous commit.  The
            /// commit message will be merged with the previous message.
            /// </summary>
            GIT_REBASE_OPERATION_SQUASH,
            
            /// <summary>
            /// The given commit is to be squashed into the previous commit.  The
            /// commit message from this commit will be discarded.
            /// </summary>
            GIT_REBASE_OPERATION_FIXUP,
            
            /// <summary>
            /// No commit will be cherry-picked.  The client should run the given
            /// command and (if successful) continue.
            /// </summary>
            GIT_REBASE_OPERATION_EXEC,
        }
        
        /// <summary>
        /// The given commit is to be cherry-picked.  The client should commit
        /// the changes and continue if there are no conflicts.
        /// </summary>
        public const git_rebase_operation_t GIT_REBASE_OPERATION_PICK = git_rebase_operation_t.GIT_REBASE_OPERATION_PICK;
        
        /// <summary>
        /// The given commit is to be cherry-picked, but the client should prompt
        /// the user to provide an updated commit message.
        /// </summary>
        public const git_rebase_operation_t GIT_REBASE_OPERATION_REWORD = git_rebase_operation_t.GIT_REBASE_OPERATION_REWORD;
        
        /// <summary>
        /// The given commit is to be cherry-picked, but the client should stop
        /// to allow the user to edit the changes before committing them.
        /// </summary>
        public const git_rebase_operation_t GIT_REBASE_OPERATION_EDIT = git_rebase_operation_t.GIT_REBASE_OPERATION_EDIT;
        
        /// <summary>
        /// The given commit is to be squashed into the previous commit.  The
        /// commit message will be merged with the previous message.
        /// </summary>
        public const git_rebase_operation_t GIT_REBASE_OPERATION_SQUASH = git_rebase_operation_t.GIT_REBASE_OPERATION_SQUASH;
        
        /// <summary>
        /// The given commit is to be squashed into the previous commit.  The
        /// commit message from this commit will be discarded.
        /// </summary>
        public const git_rebase_operation_t GIT_REBASE_OPERATION_FIXUP = git_rebase_operation_t.GIT_REBASE_OPERATION_FIXUP;
        
        /// <summary>
        /// No commit will be cherry-picked.  The client should run the given
        /// command and (if successful) continue.
        /// </summary>
        public const git_rebase_operation_t GIT_REBASE_OPERATION_EXEC = git_rebase_operation_t.GIT_REBASE_OPERATION_EXEC;
        
        /// <summary>
        /// Rebase options
        /// </summary>
        /// <remarks>
        /// Use to tell the rebase machinery how to operate.
        /// </remarks>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public partial struct git_rebase_options
        {
            public uint version;
            
            /// <summary>
            /// Used by `git_rebase_init`, this will instruct other clients working
            /// on this rebase that you want a quiet rebase experience, which they
            /// may choose to provide in an application-specific manner.  This has no
            /// effect upon libgit2 directly, but is provided for interoperability
            /// between Git tools.
            /// </summary>
            public int quiet;
            
            /// <summary>
            /// Used by `git_rebase_init`, this will begin an in-memory rebase,
            /// which will allow callers to step through the rebase operations and
            /// commit the rebased changes, but will not rewind HEAD or update the
            /// repository to be in a rebasing state.  This will not interfere with
            /// the working directory (if there is one).
            /// </summary>
            public int inmemory;
            
            /// <summary>
            /// Used by `git_rebase_finish`, this is the name of the notes reference
            /// used to rewrite notes for rebased commits when finishing the rebase;
            /// if NULL, the contents of the configuration option `notes.rewriteRef`
            /// is examined, unless the configuration option `notes.rewrite.rebase`
            /// is set to false.  If `notes.rewriteRef` is also NULL, notes will
            /// not be rewritten.
            /// </summary>
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8MarshallerRelaxedNoCleanup))]
            public string rewrite_notes_ref;
            
            /// <summary>
            /// Options to control how trees are merged during `git_rebase_next`.
            /// </summary>
            public git_merge_options merge_options;
            
            /// <summary>
            /// Options to control how files are written during `git_rebase_init`,
            /// `git_rebase_next` and `git_rebase_abort`.  Note that a minimum
            /// strategy of `GIT_CHECKOUT_SAFE` is defaulted in `init` and `next`,
            /// and a minimum strategy of `GIT_CHECKOUT_FORCE` is defaulted in
            /// `abort` to match git semantics.
            /// </summary>
            public git_checkout_options checkout_options;
        }
        
        /// <summary>
        /// A rebase operation
        /// </summary>
        /// <remarks>
        /// Describes a single instruction/operation to be performed during the
        /// rebase.
        /// </remarks>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public partial struct git_rebase_operation
        {
            /// <summary>
            /// The type of rebase operation.
            /// </summary>
            public git_rebase_operation_t type;
            
            /// <summary>
            /// The commit ID being cherry-picked.  This will be populated for
            /// all operations except those of type `GIT_REBASE_OPERATION_EXEC`.
            /// </summary>
            public git_oid id;
            
            /// <summary>
            /// The executable the user has requested be run.  This will only
            /// be populated for operations of type `GIT_REBASE_OPERATION_EXEC`.
            /// </summary>
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8MarshallerRelaxedNoCleanup))]
            public string exec;
        }
        
        /// <summary>
        /// Initialize git_rebase_options structure
        /// </summary>
        /// <param name="opts">The `git_rebase_options` struct to initialize.</param>
        /// <param name="version">The struct version; pass `GIT_REBASE_OPTIONS_VERSION`.</param>
        /// <returns>Zero on success; -1 on failure.</returns>
        /// <remarks>
        /// Initializes a `git_rebase_options` with default values. Equivalent to
        /// creating an instance with `GIT_REBASE_OPTIONS_INIT`.
        /// </remarks>
        public static git_result git_rebase_init_options(ref git_rebase_options opts, uint version)
        {
            var __result__ = git_rebase_init_options__(ref opts, version).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_rebase_init_options", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_rebase_init_options__(ref git_rebase_options opts, uint version);
        
        /// <summary>
        /// Initializes a rebase operation to rebase the changes in `branch`
        /// relative to `upstream` onto another branch.  To begin the rebase
        /// process, call `git_rebase_next`.  When you have finished with this
        /// object, call `git_rebase_free`.
        /// </summary>
        /// <param name="out">Pointer to store the rebase object</param>
        /// <param name="repo">The repository to perform the rebase</param>
        /// <param name="branch">The terminal commit to rebase, or NULL to rebase the
        /// current branch</param>
        /// <param name="upstream">The commit to begin rebasing from, or NULL to rebase all
        /// reachable commits</param>
        /// <param name="onto">The branch to rebase onto, or NULL to rebase onto the given
        /// upstream</param>
        /// <param name="opts">Options to specify how rebase is performed, or NULL</param>
        /// <returns>Zero on success; -1 on failure.</returns>
        public static git_result git_rebase_init(out git_rebase @out, git_repository repo, git_annotated_commit branch, git_annotated_commit upstream, git_annotated_commit onto, in git_rebase_options opts)
        {
            var __result__ = git_rebase_init__(out @out, repo, branch, upstream, onto, opts).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_rebase_init", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_rebase_init__(out git_rebase @out, git_repository repo, git_annotated_commit branch, git_annotated_commit upstream, git_annotated_commit onto, in git_rebase_options opts);
        
        /// <summary>
        /// Opens an existing rebase that was previously started by either an
        /// invocation of `git_rebase_init` or by another client.
        /// </summary>
        /// <param name="out">Pointer to store the rebase object</param>
        /// <param name="repo">The repository that has a rebase in-progress</param>
        /// <param name="opts">Options to specify how rebase is performed</param>
        /// <returns>Zero on success; -1 on failure.</returns>
        public static git_result git_rebase_open(out git_rebase @out, git_repository repo, in git_rebase_options opts)
        {
            var __result__ = git_rebase_open__(out @out, repo, opts).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_rebase_open", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_rebase_open__(out git_rebase @out, git_repository repo, in git_rebase_options opts);
        
        /// <summary>
        /// Gets the count of rebase operations that are to be applied.
        /// </summary>
        /// <param name="rebase">The in-progress rebase</param>
        /// <returns>The number of rebase operations in total</returns>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern size_t git_rebase_operation_entrycount(git_rebase rebase);
        
        /// <summary>
        /// Gets the index of the rebase operation that is currently being applied.
        /// If the first operation has not yet been applied (because you have
        /// called `init` but not yet `next`) then this returns
        /// `GIT_REBASE_NO_OPERATION`.
        /// </summary>
        /// <param name="rebase">The in-progress rebase</param>
        /// <returns>The index of the rebase operation currently being applied.</returns>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern size_t git_rebase_operation_current(git_rebase rebase);
        
        /// <summary>
        /// Gets the rebase operation specified by the given index.
        /// </summary>
        /// <param name="rebase">The in-progress rebase</param>
        /// <param name="idx">The index of the rebase operation to retrieve</param>
        /// <returns>The rebase operation or NULL if `idx` was out of bounds</returns>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ref git_rebase_operation git_rebase_operation_byindex(git_rebase rebase, size_t idx);
        
        /// <summary>
        /// Performs the next rebase operation and returns the information about it.
        /// If the operation is one that applies a patch (which is any operation except
        /// GIT_REBASE_OPERATION_EXEC) then the patch will be applied and the index and
        /// working directory will be updated with the changes.  If there are conflicts,
        /// you will need to address those before committing the changes.
        /// </summary>
        /// <param name="operation">Pointer to store the rebase operation that is to be performed next</param>
        /// <param name="rebase">The rebase in progress</param>
        /// <returns>Zero on success; -1 on failure.</returns>
        public static git_result git_rebase_next(out IntPtr operation, git_rebase rebase)
        {
            var __result__ = git_rebase_next__(out operation, rebase).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_rebase_next", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_rebase_next__(out IntPtr operation, git_rebase rebase);
        
        /// <summary>
        /// Gets the index produced by the last operation, which is the result
        /// of `git_rebase_next` and which will be committed by the next
        /// invocation of `git_rebase_commit`.  This is useful for resolving
        /// conflicts in an in-memory rebase before committing them.  You must
        /// call `git_index_free` when you are finished with this.
        /// </summary>
        /// <remarks>
        /// This is only applicable for in-memory rebases; for rebases within
        /// a working directory, the changes were applied to the repository's
        /// index.
        /// </remarks>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int git_rebase_inmemory_index(out git_index index, git_rebase rebase);
        
        /// <summary>
        /// Commits the current patch.  You must have resolved any conflicts that
        /// were introduced during the patch application from the `git_rebase_next`
        /// invocation.
        /// </summary>
        /// <param name="id">Pointer in which to store the OID of the newly created commit</param>
        /// <param name="rebase">The rebase that is in-progress</param>
        /// <param name="author">The author of the updated commit, or NULL to keep the
        /// author from the original commit</param>
        /// <param name="committer">The committer of the rebase</param>
        /// <param name="message_encoding">The encoding for the message in the commit,
        /// represented with a standard encoding name.  If message is NULL,
        /// this should also be NULL, and the encoding from the original
        /// commit will be maintained.  If message is specified, this may be
        /// NULL to indicate that "UTF-8" is to be used.</param>
        /// <param name="message">The message for this commit, or NULL to use the message
        /// from the original commit.</param>
        /// <returns>Zero on success, GIT_EUNMERGED if there are unmerged changes in
        /// the index, GIT_EAPPLIED if the current commit has already
        /// been applied to the upstream and there is nothing to commit,
        /// -1 on failure.</returns>
        public static git_result git_rebase_commit(ref git_oid id, git_rebase rebase, in git_signature author, in git_signature committer, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8MarshallerStrict))] string message_encoding, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8MarshallerStrict))] string message)
        {
            var __result__ = git_rebase_commit__(ref id, rebase, author, committer, message_encoding, message).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_rebase_commit", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_rebase_commit__(ref git_oid id, git_rebase rebase, in git_signature author, in git_signature committer, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8MarshallerStrict))] string message_encoding, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8MarshallerStrict))] string message);
        
        /// <summary>
        /// Aborts a rebase that is currently in progress, resetting the repository
        /// and working directory to their state before rebase began.
        /// </summary>
        /// <param name="rebase">The rebase that is in-progress</param>
        /// <returns>Zero on success; GIT_ENOTFOUND if a rebase is not in progress,
        /// -1 on other errors.</returns>
        public static git_result git_rebase_abort(git_rebase rebase)
        {
            var __result__ = git_rebase_abort__(rebase).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_rebase_abort", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_rebase_abort__(git_rebase rebase);
        
        /// <summary>
        /// Finishes a rebase that is currently in progress once all patches have
        /// been applied.
        /// </summary>
        /// <param name="rebase">The rebase that is in-progress</param>
        /// <param name="signature">The identity that is finishing the rebase (optional)</param>
        /// <returns>Zero on success; -1 on error</returns>
        public static git_result git_rebase_finish(git_rebase rebase, in git_signature signature)
        {
            var __result__ = git_rebase_finish__(rebase, signature).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_rebase_finish", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_rebase_finish__(git_rebase rebase, in git_signature signature);
        
        /// <summary>
        /// Frees the `git_rebase` object.
        /// </summary>
        /// <param name="rebase">The rebase object</param>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void git_rebase_free(git_rebase rebase);
    }
}
