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
        /// Read the reflog for the given reference
        /// </summary>
        /// <param name="out">pointer to reflog</param>
        /// <param name="repo">the repostiory</param>
        /// <param name="name">reference to look up</param>
        /// <returns>0 or an error code</returns>
        /// <remarks>
        /// If there is no reflog file for the given
        /// reference yet, an empty reflog object will
        /// be returned.The reflog must be freed manually by using
        /// git_reflog_free().
        /// </remarks>
        public static git_result git_reflog_read(out git_reflog @out, git_repository repo, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8MarshallerStrict))] string name)
        {
            var __result__ = git_reflog_read__(out @out, repo, name).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_reflog_read", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_reflog_read__(out git_reflog @out, git_repository repo, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8MarshallerStrict))] string name);
        
        /// <summary>
        /// Write an existing in-memory reflog object back to disk
        /// using an atomic file lock.
        /// </summary>
        /// <param name="reflog">an existing reflog object</param>
        /// <returns>0 or an error code</returns>
        public static git_result git_reflog_write(git_reflog reflog)
        {
            var __result__ = git_reflog_write__(reflog).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_reflog_write", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_reflog_write__(git_reflog reflog);
        
        /// <summary>
        /// Add a new entry to the in-memory reflog.
        /// </summary>
        /// <param name="reflog">an existing reflog object</param>
        /// <param name="id">the OID the reference is now pointing to</param>
        /// <param name="committer">the signature of the committer</param>
        /// <param name="msg">the reflog message</param>
        /// <returns>0 or an error code</returns>
        /// <remarks>
        /// `msg` is optional and can be NULL.
        /// </remarks>
        public static git_result git_reflog_append(git_reflog reflog, in git_oid id, in git_signature committer, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8MarshallerStrict))] string msg)
        {
            var __result__ = git_reflog_append__(reflog, id, committer, msg).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_reflog_append", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_reflog_append__(git_reflog reflog, in git_oid id, in git_signature committer, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8MarshallerStrict))] string msg);
        
        /// <summary>
        /// Rename a reflog
        /// </summary>
        /// <param name="repo">the repository</param>
        /// <param name="old_name">the old name of the reference</param>
        /// <param name="name">the new name of the reference</param>
        /// <returns>0 on success, GIT_EINVALIDSPEC or an error code</returns>
        /// <remarks>
        /// The reflog to be renamed is expected to already existThe new name will be checked for validity.
        /// See `git_reference_create_symbolic()` for rules about valid names.
        /// </remarks>
        public static git_result git_reflog_rename(git_repository repo, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8MarshallerStrict))] string old_name, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8MarshallerStrict))] string name)
        {
            var __result__ = git_reflog_rename__(repo, old_name, name).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_reflog_rename", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_reflog_rename__(git_repository repo, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8MarshallerStrict))] string old_name, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8MarshallerStrict))] string name);
        
        /// <summary>
        /// Delete the reflog for the given reference
        /// </summary>
        /// <param name="repo">the repository</param>
        /// <param name="name">the reflog to delete</param>
        /// <returns>0 or an error code</returns>
        public static git_result git_reflog_delete(git_repository repo, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8MarshallerStrict))] string name)
        {
            var __result__ = git_reflog_delete__(repo, name).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_reflog_delete", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_reflog_delete__(git_repository repo, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8MarshallerStrict))] string name);
        
        /// <summary>
        /// Get the number of log entries in a reflog
        /// </summary>
        /// <param name="reflog">the previously loaded reflog</param>
        /// <returns>the number of log entries</returns>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern size_t git_reflog_entrycount(git_reflog reflog);
        
        /// <summary>
        /// Lookup an entry by its index
        /// </summary>
        /// <param name="reflog">a previously loaded reflog</param>
        /// <param name="idx">the position of the entry to lookup. Should be greater than or
        /// equal to 0 (zero) and less than `git_reflog_entrycount()`.</param>
        /// <returns>the entry; NULL if not found</returns>
        /// <remarks>
        /// Requesting the reflog entry with an index of 0 (zero) will
        /// return the most recently created entry.
        /// </remarks>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern git_reflog_entry git_reflog_entry_byindex(git_reflog reflog, size_t idx);
        
        /// <summary>
        /// Remove an entry from the reflog by its index
        /// </summary>
        /// <param name="reflog">a previously loaded reflog.</param>
        /// <param name="idx">the position of the entry to remove. Should be greater than or
        /// equal to 0 (zero) and less than `git_reflog_entrycount()`.</param>
        /// <param name="rewrite_previous_entry">1 to rewrite the history; 0 otherwise.</param>
        /// <returns>0 on success, GIT_ENOTFOUND if the entry doesn't exist
        /// or an error code.</returns>
        /// <remarks>
        /// To ensure there's no gap in the log history, set `rewrite_previous_entry`
        /// param value to 1. When deleting entry `n`, member old_oid of entry `n-1`
        /// (if any) will be updated with the value of member new_oid of entry `n+1`.
        /// </remarks>
        public static git_result git_reflog_drop(git_reflog reflog, size_t idx, int rewrite_previous_entry)
        {
            var __result__ = git_reflog_drop__(reflog, idx, rewrite_previous_entry).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_reflog_drop", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_reflog_drop__(git_reflog reflog, size_t idx, int rewrite_previous_entry);
        
        /// <summary>
        /// Get the old oid
        /// </summary>
        /// <param name="entry">a reflog entry</param>
        /// <returns>the old oid</returns>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ref readonly git_oid git_reflog_entry_id_old(git_reflog_entry entry);
        
        /// <summary>
        /// Get the new oid
        /// </summary>
        /// <param name="entry">a reflog entry</param>
        /// <returns>the new oid at this time</returns>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ref readonly git_oid git_reflog_entry_id_new(git_reflog_entry entry);
        
        /// <summary>
        /// Get the committer of this entry
        /// </summary>
        /// <param name="entry">a reflog entry</param>
        /// <returns>the committer</returns>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ref readonly git_signature git_reflog_entry_committer(git_reflog_entry entry);
        
        /// <summary>
        /// Get the log message
        /// </summary>
        /// <param name="entry">a reflog entry</param>
        /// <returns>the log msg</returns>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8MarshallerRelaxedNoCleanup))]
        public static extern string git_reflog_entry_message(git_reflog_entry entry);
        
        /// <summary>
        /// Free the reflog
        /// </summary>
        /// <param name="reflog">reflog to free</param>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void git_reflog_free(git_reflog reflog);
    }
}
