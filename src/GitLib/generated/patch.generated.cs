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
        /// The diff patch is used to store all the text diffs for a delta.
        /// </summary>
        /// <remarks>
        /// You can easily loop over the content of patches and get information about
        /// them.
        /// </remarks>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public readonly partial struct git_patch : IEquatable<git_patch>
        {
            private readonly IntPtr _handle;
            
            public git_patch(IntPtr handle) => _handle = handle;
            
            public IntPtr Handle => _handle;
            
            public bool Equals(git_patch other) => _handle.Equals(other._handle);
            
            public override bool Equals(object obj) => obj is git_patch other && Equals(other);
            
            public override int GetHashCode() => _handle.GetHashCode();
            
            public override string ToString() => "0x" + (IntPtr.Size == 8 ? _handle.ToString("X16") : _handle.ToString("X8"));
            
            public static bool operator ==(git_patch left, git_patch right) => left.Equals(right);
            
            public static bool operator !=(git_patch left, git_patch right) => !left.Equals(right);
        }
        
        /// <summary>
        /// Return a patch for an entry in the diff list.
        /// </summary>
        /// <param name="out">Output parameter for the delta patch object</param>
        /// <param name="diff">Diff list object</param>
        /// <param name="idx">Index into diff list</param>
        /// <returns>0 on success, other value 
        /// &lt;
        /// 0 on error</returns>
        /// <remarks>
        /// The `git_patch` is a newly created object contains the text diffs
        /// for the delta.  You have to call `git_patch_free()` when you are
        /// done with it.  You can use the patch object to loop over all the hunks
        /// and lines in the diff of the one delta.For an unchanged file or a binary file, no `git_patch` will be
        /// created, the output will be set to NULL, and the `binary` flag will be
        /// set true in the `git_diff_delta` structure.It is okay to pass NULL for either of the output parameters; if you pass
        /// NULL for the `git_patch`, then the text diff will not be calculated.
        /// </remarks>
        public static git_result git_patch_from_diff(out git_patch @out, git_diff diff, size_t idx)
        {
            var __result__ = git_patch_from_diff__(out @out, diff, idx).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_patch_from_diff", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_patch_from_diff__(out git_patch @out, git_diff diff, size_t idx);
        
        /// <summary>
        /// Directly generate a patch from the difference between two blobs.
        /// </summary>
        /// <param name="out">The generated patch; NULL on error</param>
        /// <param name="old_blob">Blob for old side of diff, or NULL for empty blob</param>
        /// <param name="old_as_path">Treat old blob as if it had this filename; can be NULL</param>
        /// <param name="new_blob">Blob for new side of diff, or NULL for empty blob</param>
        /// <param name="new_as_path">Treat new blob as if it had this filename; can be NULL</param>
        /// <param name="opts">Options for diff, or NULL for default options</param>
        /// <returns>0 on success or error code 
        /// &lt;
        /// 0</returns>
        /// <remarks>
        /// This is just like `git_diff_blobs()` except it generates a patch object
        /// for the difference instead of directly making callbacks.  You can use the
        /// standard `git_patch` accessor functions to read the patch data, and
        /// you must call `git_patch_free()` on the patch when done.
        /// </remarks>
        public static git_result git_patch_from_blobs(out git_patch @out, git_blob old_blob, [MarshalAs(UnmanagedType.LPUTF8Str)] string old_as_path, git_blob new_blob, [MarshalAs(UnmanagedType.LPUTF8Str)] string new_as_path, in git_diff_options opts)
        {
            var __result__ = git_patch_from_blobs__(out @out, old_blob, old_as_path, new_blob, new_as_path, opts).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_patch_from_blobs", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_patch_from_blobs__(out git_patch @out, git_blob old_blob, [MarshalAs(UnmanagedType.LPUTF8Str)] string old_as_path, git_blob new_blob, [MarshalAs(UnmanagedType.LPUTF8Str)] string new_as_path, in git_diff_options opts);
        
        /// <summary>
        /// Directly generate a patch from the difference between a blob and a buffer.
        /// </summary>
        /// <param name="out">The generated patch; NULL on error</param>
        /// <param name="old_blob">Blob for old side of diff, or NULL for empty blob</param>
        /// <param name="old_as_path">Treat old blob as if it had this filename; can be NULL</param>
        /// <param name="buffer">Raw data for new side of diff, or NULL for empty</param>
        /// <param name="buffer_len">Length of raw data for new side of diff</param>
        /// <param name="buffer_as_path">Treat buffer as if it had this filename; can be NULL</param>
        /// <param name="opts">Options for diff, or NULL for default options</param>
        /// <returns>0 on success or error code 
        /// &lt;
        /// 0</returns>
        /// <remarks>
        /// This is just like `git_diff_blob_to_buffer()` except it generates a patch
        /// object for the difference instead of directly making callbacks.  You can
        /// use the standard `git_patch` accessor functions to read the patch
        /// data, and you must call `git_patch_free()` on the patch when done.
        /// </remarks>
        public static git_result git_patch_from_blob_and_buffer(out git_patch @out, git_blob old_blob, [MarshalAs(UnmanagedType.LPUTF8Str)] string old_as_path, IntPtr buffer, size_t buffer_len, [MarshalAs(UnmanagedType.LPUTF8Str)] string buffer_as_path, in git_diff_options opts)
        {
            var __result__ = git_patch_from_blob_and_buffer__(out @out, old_blob, old_as_path, buffer, buffer_len, buffer_as_path, opts).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_patch_from_blob_and_buffer", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_patch_from_blob_and_buffer__(out git_patch @out, git_blob old_blob, [MarshalAs(UnmanagedType.LPUTF8Str)] string old_as_path, IntPtr buffer, size_t buffer_len, [MarshalAs(UnmanagedType.LPUTF8Str)] string buffer_as_path, in git_diff_options opts);
        
        /// <summary>
        /// Directly generate a patch from the difference between two buffers.
        /// </summary>
        /// <param name="out">The generated patch; NULL on error</param>
        /// <param name="old_buffer">Raw data for old side of diff, or NULL for empty</param>
        /// <param name="old_len">Length of the raw data for old side of the diff</param>
        /// <param name="old_as_path">Treat old buffer as if it had this filename; can be NULL</param>
        /// <param name="new_buffer">Raw data for new side of diff, or NULL for empty</param>
        /// <param name="new_len">Length of raw data for new side of diff</param>
        /// <param name="new_as_path">Treat buffer as if it had this filename; can be NULL</param>
        /// <param name="opts">Options for diff, or NULL for default options</param>
        /// <returns>0 on success or error code 
        /// &lt;
        /// 0</returns>
        /// <remarks>
        /// This is just like `git_diff_buffers()` except it generates a patch
        /// object for the difference instead of directly making callbacks.  You can
        /// use the standard `git_patch` accessor functions to read the patch
        /// data, and you must call `git_patch_free()` on the patch when done.
        /// </remarks>
        public static git_result git_patch_from_buffers(out git_patch @out, IntPtr old_buffer, size_t old_len, [MarshalAs(UnmanagedType.LPUTF8Str)] string old_as_path, IntPtr new_buffer, size_t new_len, [MarshalAs(UnmanagedType.LPUTF8Str)] string new_as_path, in git_diff_options opts)
        {
            var __result__ = git_patch_from_buffers__(out @out, old_buffer, old_len, old_as_path, new_buffer, new_len, new_as_path, opts).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_patch_from_buffers", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_patch_from_buffers__(out git_patch @out, IntPtr old_buffer, size_t old_len, [MarshalAs(UnmanagedType.LPUTF8Str)] string old_as_path, IntPtr new_buffer, size_t new_len, [MarshalAs(UnmanagedType.LPUTF8Str)] string new_as_path, in git_diff_options opts);
        
        /// <summary>
        /// Free a git_patch object.
        /// </summary>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void git_patch_free(git_patch patch);
        
        /// <summary>
        /// Get the delta associated with a patch.  This delta points to internal
        /// data and you do not have to release it when you are done with it.
        /// </summary>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ref readonly git_diff_delta git_patch_get_delta(git_patch patch);
        
        /// <summary>
        /// Get the number of hunks in a patch
        /// </summary>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern size_t git_patch_num_hunks(git_patch patch);
        
        /// <summary>
        /// Get line counts of each type in a patch.
        /// </summary>
        /// <param name="total_context">Count of context lines in output, can be NULL.</param>
        /// <param name="total_additions">Count of addition lines in output, can be NULL.</param>
        /// <param name="total_deletions">Count of deletion lines in output, can be NULL.</param>
        /// <param name="patch">The git_patch object</param>
        /// <returns>0 on success, 
        /// &lt;
        /// 0 on error</returns>
        /// <remarks>
        /// This helps imitate a diff --numstat type of output.  For that purpose,
        /// you only need the `total_additions` and `total_deletions` values, but we
        /// include the `total_context` line count in case you want the total number
        /// of lines of diff output that will be generated.All outputs are optional. Pass NULL if you don't need a particular count.
        /// </remarks>
        public static git_result git_patch_line_stats(ref size_t total_context, ref size_t total_additions, ref size_t total_deletions, git_patch patch)
        {
            var __result__ = git_patch_line_stats__(ref total_context, ref total_additions, ref total_deletions, patch).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_patch_line_stats", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_patch_line_stats__(ref size_t total_context, ref size_t total_additions, ref size_t total_deletions, git_patch patch);
        
        /// <summary>
        /// Get the information about a hunk in a patch
        /// </summary>
        /// <param name="out">Output pointer to git_diff_hunk of hunk</param>
        /// <param name="lines_in_hunk">Output count of total lines in this hunk</param>
        /// <param name="patch">Input pointer to patch object</param>
        /// <param name="hunk_idx">Input index of hunk to get information about</param>
        /// <returns>0 on success, GIT_ENOTFOUND if hunk_idx out of range, 
        /// &lt;
        /// 0 on error</returns>
        /// <remarks>
        /// Given a patch and a hunk index into the patch, this returns detailed
        /// information about that hunk.  Any of the output pointers can be passed
        /// as NULL if you don't care about that particular piece of information.
        /// </remarks>
        public static git_result git_patch_get_hunk(out IntPtr @out, ref size_t lines_in_hunk, git_patch patch, size_t hunk_idx)
        {
            var __result__ = git_patch_get_hunk__(out @out, ref lines_in_hunk, patch, hunk_idx).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_patch_get_hunk", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_patch_get_hunk__(out IntPtr @out, ref size_t lines_in_hunk, git_patch patch, size_t hunk_idx);
        
        /// <summary>
        /// Get the number of lines in a hunk.
        /// </summary>
        /// <param name="patch">The git_patch object</param>
        /// <param name="hunk_idx">Index of the hunk</param>
        /// <returns>Number of lines in hunk or GIT_ENOTFOUND if invalid hunk index</returns>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int git_patch_num_lines_in_hunk(git_patch patch, size_t hunk_idx);
        
        /// <summary>
        /// Get data about a line in a hunk of a patch.
        /// </summary>
        /// <param name="out">The git_diff_line data for this line</param>
        /// <param name="patch">The patch to look in</param>
        /// <param name="hunk_idx">The index of the hunk</param>
        /// <param name="line_of_hunk">The index of the line in the hunk</param>
        /// <returns>0 on success, 
        /// &lt;
        /// 0 on failure</returns>
        /// <remarks>
        /// Given a patch, a hunk index, and a line index in the hunk, this
        /// will return a lot of details about that line.  If you pass a hunk
        /// index larger than the number of hunks or a line index larger than
        /// the number of lines in the hunk, this will return -1.
        /// </remarks>
        public static git_result git_patch_get_line_in_hunk(out IntPtr @out, git_patch patch, size_t hunk_idx, size_t line_of_hunk)
        {
            var __result__ = git_patch_get_line_in_hunk__(out @out, patch, hunk_idx, line_of_hunk).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_patch_get_line_in_hunk", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_patch_get_line_in_hunk__(out IntPtr @out, git_patch patch, size_t hunk_idx, size_t line_of_hunk);
        
        /// <summary>
        /// Look up size of patch diff data in bytes
        /// </summary>
        /// <param name="patch">A git_patch representing changes to one file</param>
        /// <param name="include_context">Include context lines in size if non-zero</param>
        /// <param name="include_hunk_headers">Include hunk header lines if non-zero</param>
        /// <param name="include_file_headers">Include file header lines if non-zero</param>
        /// <returns>The number of bytes of data</returns>
        /// <remarks>
        /// This returns the raw size of the patch data.  This only includes the
        /// actual data from the lines of the diff, not the file or hunk headers.If you pass `include_context` as true (non-zero), this will be the size
        /// of all of the diff output; if you pass it as false (zero), this will
        /// only include the actual changed lines (as if `context_lines` was 0).
        /// </remarks>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern size_t git_patch_size(git_patch patch, int include_context, int include_hunk_headers, int include_file_headers);
        
        /// <summary>
        /// Serialize the patch to text via callback.
        /// </summary>
        /// <param name="patch">A git_patch representing changes to one file</param>
        /// <param name="print_cb">Callback function to output lines of the patch.  Will be
        /// called for file headers, hunk headers, and diff lines.</param>
        /// <param name="payload">Reference pointer that will be passed to your callbacks.</param>
        /// <returns>0 on success, non-zero callback return value, or error code</returns>
        /// <remarks>
        /// Returning a non-zero value from the callback will terminate the iteration
        /// and return that value to the caller.
        /// </remarks>
        public static git_result git_patch_print(git_patch patch, git_diff_line_cb print_cb, IntPtr payload)
        {
            var __result__ = git_patch_print__(patch, print_cb, payload).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_patch_print", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_patch_print__(git_patch patch, git_diff_line_cb print_cb, IntPtr payload);
        
        /// <summary>
        /// Get the content of a patch as a single diff text.
        /// </summary>
        /// <param name="out">The git_buf to be filled in</param>
        /// <param name="patch">A git_patch representing changes to one file</param>
        /// <returns>0 on success, 
        /// &lt;
        /// 0 on failure.</returns>
        public static git_result git_patch_to_buf(out git_buf @out, git_patch patch)
        {
            var __result__ = git_patch_to_buf__(out @out, patch).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_patch_to_buf", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_patch_to_buf__(out git_buf @out, git_patch patch);
    }
}
