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
        /// Lookup a commit object from a repository.
        /// </summary>
        /// <param name="commit">pointer to the looked up commit</param>
        /// <param name="repo">the repo to use when locating the commit.</param>
        /// <param name="id">identity of the commit to locate. If the object is
        /// an annotated tag it will be peeled back to the commit.</param>
        /// <returns>0 or an error code</returns>
        /// <remarks>
        /// The returned object should be released with `git_commit_free` when no
        /// longer needed.
        /// </remarks>
        public static git_result git_commit_lookup(out git_commit commit, git_repository repo, in git_oid id)
        {
            var __result__ = git_commit_lookup__(out commit, repo, id).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_commit_lookup", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_commit_lookup__(out git_commit commit, git_repository repo, in git_oid id);
        
        /// <summary>
        /// Lookup a commit object from a repository, given a prefix of its
        /// identifier (short id).
        /// </summary>
        /// <seealso cref="git_object_lookup_prefix"/>
        /// 
        /// <param name="commit">pointer to the looked up commit</param>
        /// <param name="repo">the repo to use when locating the commit.</param>
        /// <param name="id">identity of the commit to locate. If the object is
        /// an annotated tag it will be peeled back to the commit.</param>
        /// <param name="len">the length of the short identifier</param>
        /// <returns>0 or an error code</returns>
        /// <remarks>
        /// The returned object should be released with `git_commit_free` when no
        /// longer needed.
        /// </remarks>
        public static git_result git_commit_lookup_prefix(out git_commit commit, git_repository repo, in git_oid id, size_t len)
        {
            var __result__ = git_commit_lookup_prefix__(out commit, repo, id, len).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_commit_lookup_prefix", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_commit_lookup_prefix__(out git_commit commit, git_repository repo, in git_oid id, size_t len);
        
        /// <summary>
        /// Close an open commit
        /// </summary>
        /// <param name="commit">the commit to close</param>
        /// <remarks>
        /// This is a wrapper around git_object_free()IMPORTANT:
        /// It *is* necessary to call this method when you stop
        /// using a commit. Failure to do so will cause a memory leak.
        /// </remarks>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void git_commit_free(git_commit commit);
        
        /// <summary>
        /// Get the id of a commit.
        /// </summary>
        /// <param name="commit">a previously loaded commit.</param>
        /// <returns>object identity for the commit.</returns>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ref readonly git_oid git_commit_id(git_commit commit);
        
        /// <summary>
        /// Get the repository that contains the commit.
        /// </summary>
        /// <param name="commit">A previously loaded commit.</param>
        /// <returns>Repository that contains this commit.</returns>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern git_repository git_commit_owner(git_commit commit);
        
        /// <summary>
        /// Get the encoding for the message of a commit,
        /// as a string representing a standard encoding name.
        /// </summary>
        /// <param name="commit">a previously loaded commit.</param>
        /// <returns>NULL, or the encoding</returns>
        /// <remarks>
        /// The encoding may be NULL if the `encoding` header
        /// in the commit is missing; in that case UTF-8 is assumed.
        /// </remarks>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8MarshallerRelaxedNoCleanup))]
        public static extern string git_commit_message_encoding(git_commit commit);
        
        /// <summary>
        /// Get the full message of a commit.
        /// </summary>
        /// <param name="commit">a previously loaded commit.</param>
        /// <returns>the message of a commit</returns>
        /// <remarks>
        /// The returned message will be slightly prettified by removing any
        /// potential leading newlines.
        /// </remarks>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8MarshallerRelaxedNoCleanup))]
        public static extern string git_commit_message(git_commit commit);
        
        /// <summary>
        /// Get the full raw message of a commit.
        /// </summary>
        /// <param name="commit">a previously loaded commit.</param>
        /// <returns>the raw message of a commit</returns>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8MarshallerRelaxedNoCleanup))]
        public static extern string git_commit_message_raw(git_commit commit);
        
        /// <summary>
        /// Get the short "summary" of the git commit message.
        /// </summary>
        /// <param name="commit">a previously loaded commit.</param>
        /// <returns>the summary of a commit or NULL on error</returns>
        /// <remarks>
        /// The returned message is the summary of the commit, comprising the
        /// first paragraph of the message with whitespace trimmed and squashed.
        /// </remarks>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8MarshallerRelaxedNoCleanup))]
        public static extern string git_commit_summary(git_commit commit);
        
        /// <summary>
        /// Get the long "body" of the git commit message.
        /// </summary>
        /// <param name="commit">a previously loaded commit.</param>
        /// <returns>the body of a commit or NULL when no the message only
        /// consists of a summary</returns>
        /// <remarks>
        /// The returned message is the body of the commit, comprising
        /// everything but the first paragraph of the message. Leading and
        /// trailing whitespaces are trimmed.
        /// </remarks>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8MarshallerRelaxedNoCleanup))]
        public static extern string git_commit_body(git_commit commit);
        
        /// <summary>
        /// Get the commit time (i.e. committer time) of a commit.
        /// </summary>
        /// <param name="commit">a previously loaded commit.</param>
        /// <returns>the time of a commit</returns>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern git_time_t git_commit_time(git_commit commit);
        
        /// <summary>
        /// Get the commit timezone offset (i.e. committer's preferred timezone) of a commit.
        /// </summary>
        /// <param name="commit">a previously loaded commit.</param>
        /// <returns>positive or negative timezone offset, in minutes from UTC</returns>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int git_commit_time_offset(git_commit commit);
        
        /// <summary>
        /// Get the committer of a commit.
        /// </summary>
        /// <param name="commit">a previously loaded commit.</param>
        /// <returns>the committer of a commit</returns>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ref readonly git_signature git_commit_committer(git_commit commit);
        
        /// <summary>
        /// Get the author of a commit.
        /// </summary>
        /// <param name="commit">a previously loaded commit.</param>
        /// <returns>the author of a commit</returns>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ref readonly git_signature git_commit_author(git_commit commit);
        
        /// <summary>
        /// Get the committer of a commit, using the mailmap to map names and email
        /// addresses to canonical real names and email addresses.
        /// </summary>
        /// <param name="out">a pointer to store the resolved signature.</param>
        /// <param name="commit">a previously loaded commit.</param>
        /// <param name="mailmap">the mailmap to resolve with. (may be NULL)</param>
        /// <returns>0 or an error code</returns>
        /// <remarks>
        /// Call `git_signature_free` to free the signature.
        /// </remarks>
        public static git_result git_commit_committer_with_mailmap(out IntPtr @out, git_commit commit, git_mailmap mailmap)
        {
            var __result__ = git_commit_committer_with_mailmap__(out @out, commit, mailmap).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_commit_committer_with_mailmap", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_commit_committer_with_mailmap__(out IntPtr @out, git_commit commit, git_mailmap mailmap);
        
        /// <summary>
        /// Get the author of a commit, using the mailmap to map names and email
        /// addresses to canonical real names and email addresses.
        /// </summary>
        /// <param name="out">a pointer to store the resolved signature.</param>
        /// <param name="commit">a previously loaded commit.</param>
        /// <param name="mailmap">the mailmap to resolve with. (may be NULL)</param>
        /// <returns>0 or an error code</returns>
        /// <remarks>
        /// Call `git_signature_free` to free the signature.
        /// </remarks>
        public static git_result git_commit_author_with_mailmap(out IntPtr @out, git_commit commit, git_mailmap mailmap)
        {
            var __result__ = git_commit_author_with_mailmap__(out @out, commit, mailmap).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_commit_author_with_mailmap", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_commit_author_with_mailmap__(out IntPtr @out, git_commit commit, git_mailmap mailmap);
        
        /// <summary>
        /// Get the full raw text of the commit header.
        /// </summary>
        /// <param name="commit">a previously loaded commit</param>
        /// <returns>the header text of the commit</returns>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8MarshallerRelaxedNoCleanup))]
        public static extern string git_commit_raw_header(git_commit commit);
        
        /// <summary>
        /// Get the tree pointed to by a commit.
        /// </summary>
        /// <param name="tree_out">pointer where to store the tree object</param>
        /// <param name="commit">a previously loaded commit.</param>
        /// <returns>0 or an error code</returns>
        public static git_result git_commit_tree(out git_tree tree_out, git_commit commit)
        {
            var __result__ = git_commit_tree__(out tree_out, commit).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_commit_tree", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_commit_tree__(out git_tree tree_out, git_commit commit);
        
        /// <summary>
        /// Get the id of the tree pointed to by a commit. This differs from
        /// `git_commit_tree` in that no attempts are made to fetch an object
        /// from the ODB.
        /// </summary>
        /// <param name="commit">a previously loaded commit.</param>
        /// <returns>the id of tree pointed to by commit.</returns>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ref readonly git_oid git_commit_tree_id(git_commit commit);
        
        /// <summary>
        /// Get the number of parents of this commit
        /// </summary>
        /// <param name="commit">a previously loaded commit.</param>
        /// <returns>integer of count of parents</returns>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint git_commit_parentcount(git_commit commit);
        
        /// <summary>
        /// Get the specified parent of the commit.
        /// </summary>
        /// <param name="out">Pointer where to store the parent commit</param>
        /// <param name="commit">a previously loaded commit.</param>
        /// <param name="n">the position of the parent (from 0 to `parentcount`)</param>
        /// <returns>0 or an error code</returns>
        public static git_result git_commit_parent(out git_commit @out, git_commit commit, uint n)
        {
            var __result__ = git_commit_parent__(out @out, commit, n).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_commit_parent", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_commit_parent__(out git_commit @out, git_commit commit, uint n);
        
        /// <summary>
        /// Get the oid of a specified parent for a commit. This is different from
        /// `git_commit_parent`, which will attempt to load the parent commit from
        /// the ODB.
        /// </summary>
        /// <param name="commit">a previously loaded commit.</param>
        /// <param name="n">the position of the parent (from 0 to `parentcount`)</param>
        /// <returns>the id of the parent, NULL on error.</returns>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ref readonly git_oid git_commit_parent_id(git_commit commit, uint n);
        
        /// <summary>
        /// Get the commit object that is the 
        /// &lt;n
        /// &gt;th generation ancestor
        /// of the named commit object, following only the first parents.
        /// The returned commit has to be freed by the caller.
        /// </summary>
        /// <param name="ancestor">Pointer where to store the ancestor commit</param>
        /// <param name="commit">a previously loaded commit.</param>
        /// <param name="n">the requested generation</param>
        /// <returns>0 on success; GIT_ENOTFOUND if no matching ancestor exists
        /// or an error code</returns>
        /// <remarks>
        /// Passing `0` as the generation number returns another instance of the
        /// base commit itself.
        /// </remarks>
        public static git_result git_commit_nth_gen_ancestor(out git_commit ancestor, git_commit commit, uint n)
        {
            var __result__ = git_commit_nth_gen_ancestor__(out ancestor, commit, n).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_commit_nth_gen_ancestor", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_commit_nth_gen_ancestor__(out git_commit ancestor, git_commit commit, uint n);
        
        /// <summary>
        /// Get an arbitrary header field
        /// </summary>
        /// <param name="out">the buffer to fill; existing content will be
        /// overwritten</param>
        /// <param name="commit">the commit to look in</param>
        /// <param name="field">the header field to return</param>
        /// <returns>0 on succeess, GIT_ENOTFOUND if the field does not exist,
        /// or an error code</returns>
        public static git_result git_commit_header_field(out git_buf @out, git_commit commit, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8MarshallerStrict))] string field)
        {
            var __result__ = git_commit_header_field__(out @out, commit, field).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_commit_header_field", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_commit_header_field__(out git_buf @out, git_commit commit, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8MarshallerStrict))] string field);
        
        /// <summary>
        /// Extract the signature from a commit
        /// </summary>
        /// <param name="signature">the signature block; existing content will be
        /// overwritten</param>
        /// <param name="signed_data">signed data; this is the commit contents minus the signature block;
        /// existing content will be overwritten</param>
        /// <param name="repo">the repository in which the commit exists</param>
        /// <param name="commit_id">the commit from which to extract the data</param>
        /// <param name="field">the name of the header field containing the signature
        /// block; pass `NULL` to extract the default 'gpgsig'</param>
        /// <returns>0 on success, GIT_ENOTFOUND if the id is not for a commit
        /// or the commit does not have a signature.</returns>
        /// <remarks>
        /// If the id is not for a commit, the error class will be
        /// `GIT_ERROR_INVALID`. If the commit does not have a signature, the
        /// error class will be `GIT_ERROR_OBJECT`.
        /// </remarks>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int git_commit_extract_signature(ref git_buf signature, ref git_buf signed_data, git_repository repo, ref git_oid commit_id, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8MarshallerStrict))] string field);
        
        /// <summary>
        /// Create new commit in the repository from a list of `git_object` pointers
        /// </summary>
        /// <param name="id">Pointer in which to store the OID of the newly created commit</param>
        /// <param name="repo">Repository where to store the commit</param>
        /// <param name="update_ref">If not NULL, name of the reference that
        /// will be updated to point to this commit. If the reference
        /// is not direct, it will be resolved to a direct reference.
        /// Use "HEAD" to update the HEAD of the current branch and
        /// make it point to this commit. If the reference doesn't
        /// exist yet, it will be created. If it does exist, the first
        /// parent must be the tip of this branch.</param>
        /// <param name="author">Signature with author and author time of commit</param>
        /// <param name="committer">Signature with committer and * commit time of commit</param>
        /// <param name="message_encoding">The encoding for the message in the
        /// commit, represented with a standard encoding name.
        /// E.g. "UTF-8". If NULL, no encoding header is written and
        /// UTF-8 is assumed.</param>
        /// <param name="message">Full message for this commit</param>
        /// <param name="tree">An instance of a `git_tree` object that will
        /// be used as the tree for the commit. This tree object must
        /// also be owned by the given `repo`.</param>
        /// <param name="parent_count">Number of parents for this commit</param>
        /// <param name="parents">Array of `parent_count` pointers to `git_commit`
        /// objects that will be used as the parents for this commit. This
        /// array may be NULL if `parent_count` is 0 (root commit). All the
        /// given commits must be owned by the `repo`.</param>
        /// <returns>0 or an error code
        /// The created commit will be written to the Object Database and
        /// the given reference will be updated to point to it</returns>
        /// <remarks>
        /// The message will **not** be cleaned up automatically. You can do that
        /// with the `git_message_prettify()` function.
        /// </remarks>
        public static git_result git_commit_create(ref git_oid id, git_repository repo, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8MarshallerStrict))] string update_ref, in git_signature author, in git_signature committer, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8MarshallerStrict))] string message_encoding, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8MarshallerStrict))] string message, git_tree tree, size_t parent_count, [MarshalAs(UnmanagedType.LPArray)] git_commit[] parents)
        {
            var __result__ = git_commit_create__(ref id, repo, update_ref, author, committer, message_encoding, message, tree, parent_count, parents).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_commit_create", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_commit_create__(ref git_oid id, git_repository repo, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8MarshallerStrict))] string update_ref, in git_signature author, in git_signature committer, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8MarshallerStrict))] string message_encoding, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8MarshallerStrict))] string message, git_tree tree, size_t parent_count, [MarshalAs(UnmanagedType.LPArray)] git_commit[] parents);
        
        /// <summary>
        /// Create new commit in the repository using a variable argument list.
        /// </summary>
        /// <seealso cref="git_commit_create"/>
        /// 
        /// <remarks>
        /// The message will **not** be cleaned up automatically. You can do that
        /// with the `git_message_prettify()` function.The parents for the commit are specified as a variable list of pointers
        /// to `const git_commit *`. Note that this is a convenience method which may
        /// not be safe to export for certain languages or compilersAll other parameters remain the same as `git_commit_create()`.
        /// </remarks>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int git_commit_create_v(ref git_oid id, git_repository repo, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8MarshallerStrict))] string update_ref, in git_signature author, in git_signature committer, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8MarshallerStrict))] string message_encoding, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8MarshallerStrict))] string message, git_tree tree, size_t parent_count);
        
        /// <summary>
        /// Amend an existing commit by replacing only non-NULL values.
        /// </summary>
        /// <seealso cref="git_commit_create"/>
        /// 
        /// <remarks>
        /// This creates a new commit that is exactly the same as the old commit,
        /// except that any non-NULL values will be updated.  The new commit has
        /// the same parents as the old commit.The `update_ref` value works as in the regular `git_commit_create()`,
        /// updating the ref to point to the newly rewritten commit.  If you want
        /// to amend a commit that is not currently the tip of the branch and then
        /// rewrite the following commits to reach a ref, pass this as NULL and
        /// update the rest of the commit chain and ref separately.Unlike `git_commit_create()`, the `author`, `committer`, `message`,
        /// `message_encoding`, and `tree` parameters can be NULL in which case this
        /// will use the values from the original `commit_to_amend`.All parameters have the same meanings as in `git_commit_create()`.
        /// </remarks>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int git_commit_amend(ref git_oid id, git_commit commit_to_amend, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8MarshallerStrict))] string update_ref, in git_signature author, in git_signature committer, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8MarshallerStrict))] string message_encoding, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8MarshallerStrict))] string message, git_tree tree);
        
        /// <summary>
        /// Create a commit and write it into a buffer
        /// </summary>
        /// <param name="out">the buffer into which to write the commit object content</param>
        /// <param name="repo">Repository where the referenced tree and parents live</param>
        /// <param name="author">Signature with author and author time of commit</param>
        /// <param name="committer">Signature with committer and * commit time of commit</param>
        /// <param name="message_encoding">The encoding for the message in the
        /// commit, represented with a standard encoding name.
        /// E.g. "UTF-8". If NULL, no encoding header is written and
        /// UTF-8 is assumed.</param>
        /// <param name="message">Full message for this commit</param>
        /// <param name="tree">An instance of a `git_tree` object that will
        /// be used as the tree for the commit. This tree object must
        /// also be owned by the given `repo`.</param>
        /// <param name="parent_count">Number of parents for this commit</param>
        /// <param name="parents">Array of `parent_count` pointers to `git_commit`
        /// objects that will be used as the parents for this commit. This
        /// array may be NULL if `parent_count` is 0 (root commit). All the
        /// given commits must be owned by the `repo`.</param>
        /// <returns>0 or an error code</returns>
        /// <remarks>
        /// Create a commit as with `git_commit_create()` but instead of
        /// writing it to the objectdb, write the contents of the object into a
        /// buffer.
        /// </remarks>
        public static git_result git_commit_create_buffer(out git_buf @out, git_repository repo, in git_signature author, in git_signature committer, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8MarshallerStrict))] string message_encoding, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8MarshallerStrict))] string message, git_tree tree, size_t parent_count, [MarshalAs(UnmanagedType.LPArray)] git_commit[] parents)
        {
            var __result__ = git_commit_create_buffer__(out @out, repo, author, committer, message_encoding, message, tree, parent_count, parents).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_commit_create_buffer", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_commit_create_buffer__(out git_buf @out, git_repository repo, in git_signature author, in git_signature committer, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8MarshallerStrict))] string message_encoding, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8MarshallerStrict))] string message, git_tree tree, size_t parent_count, [MarshalAs(UnmanagedType.LPArray)] git_commit[] parents);
        
        /// <summary>
        /// Create a commit object from the given buffer and signature
        /// </summary>
        /// <param name="out">the resulting commit id</param>
        /// <param name="commit_content">the content of the unsigned commit object</param>
        /// <param name="signature">the signature to add to the commit</param>
        /// <param name="signature_field">which header field should contain this
        /// signature. Leave `NULL` for the default of "gpgsig"</param>
        /// <returns>0 or an error code</returns>
        /// <remarks>
        /// Given the unsigned commit object's contents, its signature and the
        /// header field in which to store the signature, attach the signature
        /// to the commit and write it into the given repository.
        /// </remarks>
        public static git_result git_commit_create_with_signature(out git_oid @out, git_repository repo, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8MarshallerStrict))] string commit_content, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8MarshallerStrict))] string signature, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8MarshallerStrict))] string signature_field)
        {
            var __result__ = git_commit_create_with_signature__(out @out, repo, commit_content, signature, signature_field).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_commit_create_with_signature", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_commit_create_with_signature__(out git_oid @out, git_repository repo, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8MarshallerStrict))] string commit_content, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8MarshallerStrict))] string signature, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8MarshallerStrict))] string signature_field);
        
        /// <summary>
        /// Create an in-memory copy of a commit. The copy must be explicitly
        /// free'd or it will leak.
        /// </summary>
        /// <param name="out">Pointer to store the copy of the commit</param>
        /// <param name="source">Original commit to copy</param>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int git_commit_dup(out git_commit @out, git_commit source);
    }
}
