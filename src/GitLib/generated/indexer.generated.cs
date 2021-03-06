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
        public readonly partial struct git_indexer : IEquatable<git_indexer>
        {
            private readonly IntPtr _handle;
            
            public git_indexer(IntPtr handle) => _handle = handle;
            
            public IntPtr Handle => _handle;
            
            public bool Equals(git_indexer other) => _handle.Equals(other._handle);
            
            public override bool Equals(object obj) => obj is git_indexer other && Equals(other);
            
            public override int GetHashCode() => _handle.GetHashCode();
            
            public override string ToString() => "0x" + (IntPtr.Size == 8 ? _handle.ToString("X16") : _handle.ToString("X8"));
            
            public static bool operator ==(git_indexer left, git_indexer right) => left.Equals(right);
            
            public static bool operator !=(git_indexer left, git_indexer right) => !left.Equals(right);
        }
        
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public partial struct git_indexer_options
        {
            public uint version;
            
            /// <summary>
            /// progress_cb function to call with progress information
            /// </summary>
            public git_transfer_progress_cb progress_cb;
            
            /// <summary>
            /// progress_cb_payload payload for the progress callback
            /// </summary>
            public IntPtr progress_cb_payload;
            
            /// <summary>
            /// Do connectivity checks for the received pack
            /// </summary>
            public byte verify;
        }
        
        /// <summary>
        /// Initializes a `git_indexer_options` with default values. Equivalent to
        /// creating an instance with GIT_INDEXER_OPTIONS_INIT.
        /// </summary>
        /// <param name="opts">the `git_indexer_options` struct to initialize.</param>
        /// <param name="version">Version of struct; pass `GIT_INDEXER_OPTIONS_VERSION`</param>
        /// <returns>Zero on success; -1 on failure.</returns>
        public static git_result git_indexer_init_options(ref git_indexer_options opts, uint version)
        {
            var __result__ = git_indexer_init_options__(ref opts, version).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_indexer_init_options", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_indexer_init_options__(ref git_indexer_options opts, uint version);
        
        /// <summary>
        /// Create a new indexer instance
        /// </summary>
        /// <param name="out">where to store the indexer instance</param>
        /// <param name="path">to the directory where the packfile should be stored</param>
        /// <param name="mode">permissions to use creating packfile or 0 for defaults</param>
        /// <param name="odb">object database from which to read base objects when
        /// fixing thin packs. Pass NULL if no thin pack is expected (an error
        /// will be returned if there are bases missing)</param>
        /// <param name="opts">Optional structure containing additional options. See
        /// `git_indexer_options` above.</param>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int git_indexer_new(out git_indexer @out, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8MarshallerStrict))] string path, uint mode, git_odb odb, ref git_indexer_options opts);
        
        /// <summary>
        /// Add data to the indexer
        /// </summary>
        /// <param name="idx">the indexer</param>
        /// <param name="data">the data to add</param>
        /// <param name="size">the size of the data in bytes</param>
        /// <param name="stats">stat storage</param>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int git_indexer_append(git_indexer idx, IntPtr data, size_t size, ref git_transfer_progress stats);
        
        /// <summary>
        /// Finalize the pack and index
        /// </summary>
        /// <param name="idx">the indexer</param>
        /// <remarks>
        /// Resolve any pending deltas and write out the index file
        /// </remarks>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int git_indexer_commit(git_indexer idx, ref git_transfer_progress stats);
        
        /// <summary>
        /// Get the packfile's hash
        /// </summary>
        /// <param name="idx">the indexer instance</param>
        /// <remarks>
        /// A packfile's name is derived from the sorted hashing of all object
        /// names. This is only correct after the index has been finalized.
        /// </remarks>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ref readonly git_oid git_indexer_hash(git_indexer idx);
        
        /// <summary>
        /// Free the indexer and its resources
        /// </summary>
        /// <param name="idx">the indexer to free</param>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void git_indexer_free(git_indexer idx);
    }
}
