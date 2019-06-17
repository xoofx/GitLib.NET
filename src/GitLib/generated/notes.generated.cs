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
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public readonly partial struct git_iterator : IEquatable<git_iterator>
        {
            private readonly IntPtr _handle;
            
            public git_iterator(IntPtr handle) => _handle = handle;
            
            public IntPtr Handle => _handle;
            
            public bool Equals(git_iterator other) => _handle.Equals(other._handle);
            
            public override bool Equals(object obj) => obj is git_iterator other && Equals(other);
            
            public override int GetHashCode() => _handle.GetHashCode();
            
            public override string ToString() => "0x" + (IntPtr.Size == 8 ? _handle.ToString("X16") : _handle.ToString("X8"));
            
            public static bool operator ==(git_iterator left, git_iterator right) => left.Equals(right);
            
            public static bool operator !=(git_iterator left, git_iterator right) => !left.Equals(right);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int git_note_foreach_cb(in git_oid blob_id, in git_oid annotated_object_id, IntPtr payload);
        
        /// <summary>
        /// note iterator
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public readonly partial struct git_note_iterator : IEquatable<git_note_iterator>
        {
            public git_note_iterator(git_iterator value) => this.Value = value;
            
            public readonly git_iterator Value;
            
            public bool Equals(git_note_iterator other) =>  Value.Equals(other.Value);
            
            public override bool Equals(object obj) => obj is git_note_iterator other && Equals(other);
            
            public override int GetHashCode() => Value.GetHashCode();
            
            public override string ToString() => Value.ToString();
            
            public static implicit operator git_iterator(git_note_iterator from) => from.Value;
            
            public static implicit operator git_note_iterator(git_iterator from) => new git_note_iterator(from);
            
            public static bool operator ==(git_note_iterator left, git_note_iterator right) => left.Equals(right);
            
            public static bool operator !=(git_note_iterator left, git_note_iterator right) => !left.Equals(right);
        }
        
        /// <summary>
        /// Creates a new iterator for notes
        /// </summary>
        /// <param name="out">pointer to the iterator</param>
        /// <param name="repo">repository where to look up the note</param>
        /// <param name="notes_ref">canonical name of the reference to use (optional); defaults to
        /// "refs/notes/commits"</param>
        /// <returns>0 or an error code</returns>
        /// <remarks>
        /// The iterator must be freed manually by the user.
        /// </remarks>
        public static git_result git_note_iterator_new(out IntPtr @out, git_repository repo, [MarshalAs(UnmanagedType.LPUTF8Str)] string notes_ref)
        {
            var __result__ = git_note_iterator_new__(out @out, repo, notes_ref).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_note_iterator_new", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_note_iterator_new__(out IntPtr @out, git_repository repo, [MarshalAs(UnmanagedType.LPUTF8Str)] string notes_ref);
        
        /// <summary>
        /// Creates a new iterator for notes from a commit
        /// </summary>
        /// <param name="out">pointer to the iterator</param>
        /// <param name="notes_commit">a pointer to the notes commit object</param>
        /// <returns>0 or an error code</returns>
        /// <remarks>
        /// The iterator must be freed manually by the user.
        /// </remarks>
        public static git_result git_note_commit_iterator_new(out IntPtr @out, git_commit notes_commit)
        {
            var __result__ = git_note_commit_iterator_new__(out @out, notes_commit).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_note_commit_iterator_new", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_note_commit_iterator_new__(out IntPtr @out, git_commit notes_commit);
        
        /// <summary>
        /// Frees an git_note_iterator
        /// </summary>
        /// <param name="it">pointer to the iterator</param>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void git_note_iterator_free(ref git_note_iterator it);
        
        /// <summary>
        /// Return the current item (note_id and annotated_id) and advance the iterator
        /// internally to the next value
        /// </summary>
        /// <param name="note_id">id of blob containing the message</param>
        /// <param name="annotated_id">id of the git object being annotated</param>
        /// <param name="it">pointer to the iterator</param>
        /// <returns>0 (no error), GIT_ITEROVER (iteration is done) or an error code
        /// (negative value)</returns>
        public static git_result git_note_next(ref git_oid note_id, ref git_oid annotated_id, ref git_note_iterator it)
        {
            var __result__ = git_note_next__(ref note_id, ref annotated_id, ref it).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_note_next", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_note_next__(ref git_oid note_id, ref git_oid annotated_id, ref git_note_iterator it);
        
        /// <summary>
        /// Read the note for an object
        /// </summary>
        /// <param name="out">pointer to the read note; NULL in case of error</param>
        /// <param name="repo">repository where to look up the note</param>
        /// <param name="notes_ref">canonical name of the reference to use (optional); defaults to
        /// "refs/notes/commits"</param>
        /// <param name="oid">OID of the git object to read the note from</param>
        /// <returns>0 or an error code</returns>
        /// <remarks>
        /// The note must be freed manually by the user.
        /// </remarks>
        public static git_result git_note_read(out git_note @out, git_repository repo, [MarshalAs(UnmanagedType.LPUTF8Str)] string notes_ref, in git_oid oid)
        {
            var __result__ = git_note_read__(out @out, repo, notes_ref, oid).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_note_read", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_note_read__(out git_note @out, git_repository repo, [MarshalAs(UnmanagedType.LPUTF8Str)] string notes_ref, in git_oid oid);
        
        /// <summary>
        /// Read the note for an object from a note commit
        /// </summary>
        /// <param name="out">pointer to the read note; NULL in case of error</param>
        /// <param name="repo">repository where to look up the note</param>
        /// <param name="notes_commit">a pointer to the notes commit object</param>
        /// <param name="oid">OID of the git object to read the note from</param>
        /// <returns>0 or an error code</returns>
        /// <remarks>
        /// The note must be freed manually by the user.
        /// </remarks>
        public static git_result git_note_commit_read(out git_note @out, git_repository repo, git_commit notes_commit, in git_oid oid)
        {
            var __result__ = git_note_commit_read__(out @out, repo, notes_commit, oid).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_note_commit_read", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_note_commit_read__(out git_note @out, git_repository repo, git_commit notes_commit, in git_oid oid);
        
        /// <summary>
        /// Get the note author
        /// </summary>
        /// <param name="note">the note</param>
        /// <returns>the author</returns>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ref readonly git_signature git_note_author(git_note note);
        
        /// <summary>
        /// Get the note committer
        /// </summary>
        /// <param name="note">the note</param>
        /// <returns>the committer</returns>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ref readonly git_signature git_note_committer(git_note note);
        
        /// <summary>
        /// Get the note message
        /// </summary>
        /// <param name="note">the note</param>
        /// <returns>the note message</returns>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        [return:MarshalAs(UnmanagedType.LPUTF8Str)]
        public static extern string git_note_message(git_note note);
        
        /// <summary>
        /// Get the note object's id
        /// </summary>
        /// <param name="note">the note</param>
        /// <returns>the note object's id</returns>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ref readonly git_oid git_note_id(git_note note);
        
        /// <summary>
        /// Add a note for an object
        /// </summary>
        /// <param name="out">pointer to store the OID (optional); NULL in case of error</param>
        /// <param name="repo">repository where to store the note</param>
        /// <param name="notes_ref">canonical name of the reference to use (optional);
        /// defaults to "refs/notes/commits"</param>
        /// <param name="author">signature of the notes commit author</param>
        /// <param name="committer">signature of the notes commit committer</param>
        /// <param name="oid">OID of the git object to decorate</param>
        /// <param name="note">Content of the note to add for object oid</param>
        /// <param name="force">Overwrite existing note</param>
        /// <returns>0 or an error code</returns>
        public static git_result git_note_create(out git_oid @out, git_repository repo, [MarshalAs(UnmanagedType.LPUTF8Str)] string notes_ref, in git_signature author, in git_signature committer, in git_oid oid, [MarshalAs(UnmanagedType.LPUTF8Str)] string note, int force)
        {
            var __result__ = git_note_create__(out @out, repo, notes_ref, author, committer, oid, note, force).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_note_create", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_note_create__(out git_oid @out, git_repository repo, [MarshalAs(UnmanagedType.LPUTF8Str)] string notes_ref, in git_signature author, in git_signature committer, in git_oid oid, [MarshalAs(UnmanagedType.LPUTF8Str)] string note, int force);
        
        /// <summary>
        /// Add a note for an object from a commit
        /// </summary>
        /// <param name="notes_commit_out">pointer to store the commit (optional);
        /// NULL in case of error</param>
        /// <param name="notes_blob_out">a point to the id of a note blob (optional)</param>
        /// <param name="repo">repository where the note will live</param>
        /// <param name="parent">Pointer to parent note
        /// or NULL if this shall start a new notes tree</param>
        /// <param name="author">signature of the notes commit author</param>
        /// <param name="committer">signature of the notes commit committer</param>
        /// <param name="oid">OID of the git object to decorate</param>
        /// <param name="note">Content of the note to add for object oid</param>
        /// <param name="allow_note_overwrite">Overwrite existing note</param>
        /// <returns>0 or an error code</returns>
        /// <remarks>
        /// This function will create a notes commit for a given object,
        /// the commit is a dangling commit, no reference is created.
        /// </remarks>
        public static git_result git_note_commit_create(ref git_oid notes_commit_out, ref git_oid notes_blob_out, git_repository repo, git_commit parent, in git_signature author, in git_signature committer, in git_oid oid, [MarshalAs(UnmanagedType.LPUTF8Str)] string note, int allow_note_overwrite)
        {
            var __result__ = git_note_commit_create__(ref notes_commit_out, ref notes_blob_out, repo, parent, author, committer, oid, note, allow_note_overwrite).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_note_commit_create", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_note_commit_create__(ref git_oid notes_commit_out, ref git_oid notes_blob_out, git_repository repo, git_commit parent, in git_signature author, in git_signature committer, in git_oid oid, [MarshalAs(UnmanagedType.LPUTF8Str)] string note, int allow_note_overwrite);
        
        /// <summary>
        /// Remove the note for an object
        /// </summary>
        /// <param name="repo">repository where the note lives</param>
        /// <param name="notes_ref">canonical name of the reference to use (optional);
        /// defaults to "refs/notes/commits"</param>
        /// <param name="author">signature of the notes commit author</param>
        /// <param name="committer">signature of the notes commit committer</param>
        /// <param name="oid">OID of the git object to remove the note from</param>
        /// <returns>0 or an error code</returns>
        public static git_result git_note_remove(git_repository repo, [MarshalAs(UnmanagedType.LPUTF8Str)] string notes_ref, in git_signature author, in git_signature committer, in git_oid oid)
        {
            var __result__ = git_note_remove__(repo, notes_ref, author, committer, oid).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_note_remove", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_note_remove__(git_repository repo, [MarshalAs(UnmanagedType.LPUTF8Str)] string notes_ref, in git_signature author, in git_signature committer, in git_oid oid);
        
        /// <summary>
        /// Remove the note for an object
        /// </summary>
        /// <param name="notes_commit_out">pointer to store the new notes commit (optional);
        /// NULL in case of error.
        /// When removing a note a new tree containing all notes
        /// sans the note to be removed is created and a new commit
        /// pointing to that tree is also created.
        /// In the case where the resulting tree is an empty tree
        /// a new commit pointing to this empty tree will be returned.</param>
        /// <param name="repo">repository where the note lives</param>
        /// <param name="notes_commit">a pointer to the notes commit object</param>
        /// <param name="author">signature of the notes commit author</param>
        /// <param name="committer">signature of the notes commit committer</param>
        /// <param name="oid">OID of the git object to remove the note from</param>
        /// <returns>0 or an error code</returns>
        public static git_result git_note_commit_remove(ref git_oid notes_commit_out, git_repository repo, git_commit notes_commit, in git_signature author, in git_signature committer, in git_oid oid)
        {
            var __result__ = git_note_commit_remove__(ref notes_commit_out, repo, notes_commit, author, committer, oid).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_note_commit_remove", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_note_commit_remove__(ref git_oid notes_commit_out, git_repository repo, git_commit notes_commit, in git_signature author, in git_signature committer, in git_oid oid);
        
        /// <summary>
        /// Free a git_note object
        /// </summary>
        /// <param name="note">git_note object</param>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void git_note_free(git_note note);
        
        /// <summary>
        /// Get the default notes reference for a repository
        /// </summary>
        /// <param name="out">buffer in which to store the name of the default notes reference</param>
        /// <param name="repo">The Git repository</param>
        /// <returns>0 or an error code</returns>
        public static git_result git_note_default_ref(out git_buf @out, git_repository repo)
        {
            var __result__ = git_note_default_ref__(out @out, repo).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_note_default_ref", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_note_default_ref__(out git_buf @out, git_repository repo);
        
        /// <summary>
        /// Loop over all the notes within a specified namespace
        /// and issue a callback for each one.
        /// </summary>
        /// <param name="repo">Repository where to find the notes.</param>
        /// <param name="notes_ref">Reference to read from (optional); defaults to
        /// "refs/notes/commits".</param>
        /// <param name="note_cb">Callback to invoke per found annotation.  Return non-zero
        /// to stop looping.</param>
        /// <param name="payload">Extra parameter to callback function.</param>
        /// <returns>0 on success, non-zero callback return value, or error code</returns>
        public static git_result git_note_foreach(git_repository repo, [MarshalAs(UnmanagedType.LPUTF8Str)] string notes_ref, git_note_foreach_cb note_cb, IntPtr payload)
        {
            var __result__ = git_note_foreach__(repo, notes_ref, note_cb, payload).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_note_foreach", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_note_foreach__(git_repository repo, [MarshalAs(UnmanagedType.LPUTF8Str)] string notes_ref, git_note_foreach_cb note_cb, IntPtr payload);
    }
}