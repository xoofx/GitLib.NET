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
        /// The information about object IDs to query in `git_odb_expand_ids`,
        /// which will be populated upon return.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public partial struct git_odb_expand_id
        {
            /// <summary>
            /// The object ID to expand
            /// </summary>
            public git_oid id;
            
            /// <summary>
            /// The length of the object ID (in nibbles, or packets of 4 bits; the
            /// number of hex characters)
            /// </summary>
            public ushort length;
            
            /// <summary>
            /// The (optional) type of the object to search for; leave as `0` or set
            /// to `GIT_OBJECT_ANY` to query for any object matching the ID.
            /// </summary>
            public git_object_t type;
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int git_odb_foreach_cb(in git_oid id, IntPtr payload);
        
        /// <summary>
        /// Create a new object database with no backends.
        /// </summary>
        /// <param name="out">location to store the database pointer, if opened.
        /// Set to NULL if the open failed.</param>
        /// <returns>0 or an error code</returns>
        /// <remarks>
        /// Before the ODB can be used for read/writing, a custom database
        /// backend must be manually added using `git_odb_add_backend()`
        /// </remarks>
        public static git_result git_odb_new(out git_odb @out)
        {
            var __result__ = git_odb_new__(out @out).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_odb_new", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_odb_new__(out git_odb @out);
        
        /// <summary>
        /// Create a new object database and automatically add
        /// the two default backends:
        /// </summary>
        /// <param name="out">location to store the database pointer, if opened.
        /// Set to NULL if the open failed.</param>
        /// <param name="objects_dir">path of the backends' "objects" directory.</param>
        /// <returns>0 or an error code</returns>
        /// <remarks>
        /// - git_odb_backend_loose: read and write loose object files
        /// from disk, assuming `objects_dir` as the Objects folder- git_odb_backend_pack: read objects from packfiles,
        /// assuming `objects_dir` as the Objects folder which
        /// contains a 'pack/' folder with the corresponding data
        /// </remarks>
        public static git_result git_odb_open(out git_odb @out, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8MarshallerStrict))] string objects_dir)
        {
            var __result__ = git_odb_open__(out @out, objects_dir).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_odb_open", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_odb_open__(out git_odb @out, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8MarshallerStrict))] string objects_dir);
        
        /// <summary>
        /// Add an on-disk alternate to an existing Object DB.
        /// </summary>
        /// <param name="odb">database to add the backend to</param>
        /// <param name="path">path to the objects folder for the alternate</param>
        /// <returns>0 on success; error code otherwise</returns>
        /// <remarks>
        /// Note that the added path must point to an `objects`, not
        /// to a full repository, to use it as an alternate store.Alternate backends are always checked for objects *after*
        /// all the main backends have been exhausted.Writing is disabled on alternate backends.
        /// </remarks>
        public static git_result git_odb_add_disk_alternate(git_odb odb, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8MarshallerStrict))] string path)
        {
            var __result__ = git_odb_add_disk_alternate__(odb, path).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_odb_add_disk_alternate", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_odb_add_disk_alternate__(git_odb odb, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8MarshallerStrict))] string path);
        
        /// <summary>
        /// Close an open object database.
        /// </summary>
        /// <param name="db">database pointer to close. If NULL no action is taken.</param>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void git_odb_free(git_odb db);
        
        /// <summary>
        /// Read an object from the database.
        /// </summary>
        /// <param name="out">pointer where to store the read object</param>
        /// <param name="db">database to search for the object in.</param>
        /// <param name="id">identity of the object to read.</param>
        /// <returns>- 0 if the object was read;
        /// - GIT_ENOTFOUND if the object is not in the database.</returns>
        /// <remarks>
        /// This method queries all available ODB backends
        /// trying to read the given OID.The returned object is reference counted and
        /// internally cached, so it should be closed
        /// by the user once it's no longer in use.
        /// </remarks>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int git_odb_read(out git_odb_object @out, git_odb db, in git_oid id);
        
        /// <summary>
        /// Read an object from the database, given a prefix
        /// of its identifier.
        /// </summary>
        /// <param name="out">pointer where to store the read object</param>
        /// <param name="db">database to search for the object in.</param>
        /// <param name="short_id">a prefix of the id of the object to read.</param>
        /// <param name="len">the length of the prefix</param>
        /// <returns>- 0 if the object was read;
        /// - GIT_ENOTFOUND if the object is not in the database.
        /// - GIT_EAMBIGUOUS if the prefix is ambiguous (several objects match the prefix)</returns>
        /// <remarks>
        /// This method queries all available ODB backends
        /// trying to match the 'len' first hexadecimal
        /// characters of the 'short_id'.
        /// The remaining (GIT_OID_HEXSZ-len)*4 bits of
        /// 'short_id' must be 0s.
        /// 'len' must be at least GIT_OID_MINPREFIXLEN,
        /// and the prefix must be long enough to identify
        /// a unique object in all the backends; the
        /// method will fail otherwise.The returned object is reference counted and
        /// internally cached, so it should be closed
        /// by the user once it's no longer in use.
        /// </remarks>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int git_odb_read_prefix(out git_odb_object @out, git_odb db, in git_oid short_id, size_t len);
        
        /// <summary>
        /// Read the header of an object from the database, without
        /// reading its full contents.
        /// </summary>
        /// <param name="len_out">pointer where to store the length</param>
        /// <param name="type_out">pointer where to store the type</param>
        /// <param name="db">database to search for the object in.</param>
        /// <param name="id">identity of the object to read.</param>
        /// <returns>- 0 if the object was read;
        /// - GIT_ENOTFOUND if the object is not in the database.</returns>
        /// <remarks>
        /// The header includes the length and the type of an object.Note that most backends do not support reading only the header
        /// of an object, so the whole object will be read and then the
        /// header will be returned.
        /// </remarks>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int git_odb_read_header(ref size_t len_out, ref git_object_t type_out, git_odb db, in git_oid id);
        
        /// <summary>
        /// Determine if the given object can be found in the object database.
        /// </summary>
        /// <param name="db">database to be searched for the given object.</param>
        /// <param name="id">the object to search for.</param>
        /// <returns>- 1, if the object was found
        /// - 0, otherwise</returns>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int git_odb_exists(git_odb db, in git_oid id);
        
        /// <summary>
        /// Determine if an object can be found in the object database by an
        /// abbreviated object ID.
        /// </summary>
        /// <param name="out">The full OID of the found object if just one is found.</param>
        /// <param name="db">The database to be searched for the given object.</param>
        /// <param name="short_id">A prefix of the id of the object to read.</param>
        /// <param name="len">The length of the prefix.</param>
        /// <returns>0 if found, GIT_ENOTFOUND if not found, GIT_EAMBIGUOUS if multiple
        /// matches were found, other value 
        /// &lt;
        /// 0 if there was a read error.</returns>
        public static git_result git_odb_exists_prefix(out git_oid @out, git_odb db, in git_oid short_id, size_t len)
        {
            var __result__ = git_odb_exists_prefix__(out @out, db, short_id, len).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_odb_exists_prefix", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_odb_exists_prefix__(out git_oid @out, git_odb db, in git_oid short_id, size_t len);
        
        /// <summary>
        /// Determine if one or more objects can be found in the object database
        /// by their abbreviated object ID and type.  The given array will be
        /// updated in place:  for each abbreviated ID that is unique in the
        /// database, and of the given type (if specified), the full object ID,
        /// object ID length (`GIT_OID_HEXSZ`) and type will be written back to
        /// the array.  For IDs that are not found (or are ambiguous), the
        /// array entry will be zeroed.
        /// </summary>
        /// <param name="db">The database to be searched for the given objects.</param>
        /// <param name="ids">An array of short object IDs to search for</param>
        /// <param name="count">The length of the `ids` array</param>
        /// <returns>0 on success or an error code on failure</returns>
        /// <remarks>
        /// Note that since this function operates on multiple objects, the
        /// underlying database will not be asked to be reloaded if an object is
        /// not found (which is unlike other object database operations.)
        /// </remarks>
        public static git_result git_odb_expand_ids(git_odb db, ref git_odb_expand_id ids, size_t count)
        {
            var __result__ = git_odb_expand_ids__(db, ref ids, count).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_odb_expand_ids", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_odb_expand_ids__(git_odb db, ref git_odb_expand_id ids, size_t count);
        
        /// <summary>
        /// Refresh the object database to load newly added files.
        /// </summary>
        /// <param name="db">database to refresh</param>
        /// <returns>0 on success, error code otherwise</returns>
        /// <remarks>
        /// If the object databases have changed on disk while the library
        /// is running, this function will force a reload of the underlying
        /// indexes.Use this function when you're confident that an external
        /// application has tampered with the ODB.NOTE that it is not necessary to call this function at all. The
        /// library will automatically attempt to refresh the ODB
        /// when a lookup fails, to see if the looked up object exists
        /// on disk but hasn't been loaded yet.
        /// </remarks>
        public static git_result git_odb_refresh(git_odb db)
        {
            var __result__ = git_odb_refresh__(db).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_odb_refresh", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_odb_refresh__(git_odb db);
        
        /// <summary>
        /// List all objects available in the database
        /// </summary>
        /// <param name="db">database to use</param>
        /// <param name="cb">the callback to call for each object</param>
        /// <param name="payload">data to pass to the callback</param>
        /// <returns>0 on success, non-zero callback return value, or error code</returns>
        /// <remarks>
        /// The callback will be called for each object available in the
        /// database. Note that the objects are likely to be returned in the index
        /// order, which would make accessing the objects in that order inefficient.
        /// Return a non-zero value from the callback to stop looping.
        /// </remarks>
        public static git_result git_odb_foreach(git_odb db, git_odb_foreach_cb cb, IntPtr payload)
        {
            var __result__ = git_odb_foreach__(db, cb, payload).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_odb_foreach", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_odb_foreach__(git_odb db, git_odb_foreach_cb cb, IntPtr payload);
        
        /// <summary>
        /// Write an object directly into the ODB
        /// </summary>
        /// <param name="out">pointer to store the OID result of the write</param>
        /// <param name="odb">object database where to store the object</param>
        /// <param name="data">buffer with the data to store</param>
        /// <param name="len">size of the buffer</param>
        /// <param name="type">type of the data to store</param>
        /// <returns>0 or an error code</returns>
        /// <remarks>
        /// This method writes a full object straight into the ODB.
        /// For most cases, it is preferred to write objects through a write
        /// stream, which is both faster and less memory intensive, specially
        /// for big objects.This method is provided for compatibility with custom backends
        /// which are not able to support streaming writes
        /// </remarks>
        public static git_result git_odb_write(out git_oid @out, git_odb odb, IntPtr data, size_t len, git_object_t type)
        {
            var __result__ = git_odb_write__(out @out, odb, data, len, type).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_odb_write", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_odb_write__(out git_oid @out, git_odb odb, IntPtr data, size_t len, git_object_t type);
        
        /// <summary>
        /// Open a stream to write an object into the ODB
        /// </summary>
        /// <seealso cref="git_odb_stream"/>
        /// 
        /// <param name="out">pointer where to store the stream</param>
        /// <param name="db">object database where the stream will write</param>
        /// <param name="size">final size of the object that will be written</param>
        /// <param name="type">type of the object that will be written</param>
        /// <returns>0 if the stream was created; error code otherwise</returns>
        /// <remarks>
        /// The type and final length of the object must be specified
        /// when opening the stream.The returned stream will be of type `GIT_STREAM_WRONLY`, and it
        /// won't be effective until `git_odb_stream_finalize_write` is called
        /// and returns without an errorThe stream must always be freed when done with `git_odb_stream_free` or
        /// will leak memory.
        /// </remarks>
        public static git_result git_odb_open_wstream(out IntPtr @out, git_odb db, git_off_t size, git_object_t type)
        {
            var __result__ = git_odb_open_wstream__(out @out, db, size, type).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_odb_open_wstream", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_odb_open_wstream__(out IntPtr @out, git_odb db, git_off_t size, git_object_t type);
        
        /// <summary>
        /// Write to an odb stream
        /// </summary>
        /// <param name="stream">the stream</param>
        /// <param name="buffer">the data to write</param>
        /// <param name="len">the buffer's length</param>
        /// <returns>0 if the write succeeded; error code otherwise</returns>
        /// <remarks>
        /// This method will fail if the total number of received bytes exceeds the
        /// size declared with `git_odb_open_wstream()`
        /// </remarks>
        public static git_result git_odb_stream_write(ref git_odb_stream stream, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8MarshallerStrict))] string buffer, size_t len)
        {
            var __result__ = git_odb_stream_write__(ref stream, buffer, len).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_odb_stream_write", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_odb_stream_write__(ref git_odb_stream stream, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8MarshallerStrict))] string buffer, size_t len);
        
        /// <summary>
        /// Finish writing to an odb stream
        /// </summary>
        /// <param name="out">pointer to store the resulting object's id</param>
        /// <param name="stream">the stream</param>
        /// <returns>0 on success; an error code otherwise</returns>
        /// <remarks>
        /// The object will take its final name and will be available to the
        /// odb.This method will fail if the total number of received bytes
        /// differs from the size declared with `git_odb_open_wstream()`
        /// </remarks>
        public static git_result git_odb_stream_finalize_write(out git_oid @out, ref git_odb_stream stream)
        {
            var __result__ = git_odb_stream_finalize_write__(out @out, ref stream).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_odb_stream_finalize_write", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_odb_stream_finalize_write__(out git_oid @out, ref git_odb_stream stream);
        
        /// <summary>
        /// Read from an odb stream
        /// </summary>
        /// <remarks>
        /// Most backends don't implement streaming reads
        /// </remarks>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int git_odb_stream_read(ref git_odb_stream stream, IntPtr buffer, size_t len);
        
        /// <summary>
        /// Free an odb stream
        /// </summary>
        /// <param name="stream">the stream to free</param>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void git_odb_stream_free(ref git_odb_stream stream);
        
        /// <summary>
        /// Open a stream to read an object from the ODB
        /// </summary>
        /// <seealso cref="git_odb_stream"/>
        /// 
        /// <param name="out">pointer where to store the stream</param>
        /// <param name="len">pointer where to store the length of the object</param>
        /// <param name="type">pointer where to store the type of the object</param>
        /// <param name="db">object database where the stream will read from</param>
        /// <param name="oid">oid of the object the stream will read from</param>
        /// <returns>0 if the stream was created; error code otherwise</returns>
        /// <remarks>
        /// Note that most backends do *not* support streaming reads
        /// because they store their objects as compressed/delta'ed blobs.It's recommended to use `git_odb_read` instead, which is
        /// assured to work on all backends.The returned stream will be of type `GIT_STREAM_RDONLY` and
        /// will have the following methods:- stream-&gt;read: read `n` bytes from the stream
        /// - stream-&gt;free: free the streamThe stream must always be free'd or will leak memory.
        /// </remarks>
        public static git_result git_odb_open_rstream(out IntPtr @out, ref size_t len, ref git_object_t type, git_odb db, in git_oid oid)
        {
            var __result__ = git_odb_open_rstream__(out @out, ref len, ref type, db, oid).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_odb_open_rstream", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_odb_open_rstream__(out IntPtr @out, ref size_t len, ref git_object_t type, git_odb db, in git_oid oid);
        
        /// <summary>
        /// Open a stream for writing a pack file to the ODB.
        /// </summary>
        /// <seealso cref="git_odb_writepack"/>
        /// 
        /// <param name="out">pointer to the writepack functions</param>
        /// <param name="db">object database where the stream will read from</param>
        /// <param name="progress_cb">function to call with progress information.
        /// Be aware that this is called inline with network and indexing operations,
        /// so performance may be affected.</param>
        /// <param name="progress_payload">payload for the progress callback</param>
        /// <remarks>
        /// If the ODB layer understands pack files, then the given
        /// packfile will likely be streamed directly to disk (and a
        /// corresponding index created).  If the ODB layer does not
        /// understand pack files, the objects will be stored in whatever
        /// format the ODB layer uses.
        /// </remarks>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int git_odb_write_pack(out IntPtr @out, git_odb db, git_transfer_progress_cb progress_cb, IntPtr progress_payload);
        
        /// <summary>
        /// Determine the object-ID (sha1 hash) of a data buffer
        /// </summary>
        /// <param name="out">the resulting object-ID.</param>
        /// <param name="data">data to hash</param>
        /// <param name="len">size of the data</param>
        /// <param name="type">of the data to hash</param>
        /// <returns>0 or an error code</returns>
        /// <remarks>
        /// The resulting SHA-1 OID will be the identifier for the data
        /// buffer as if the data buffer it were to written to the ODB.
        /// </remarks>
        public static git_result git_odb_hash(out git_oid @out, IntPtr data, size_t len, git_object_t type)
        {
            var __result__ = git_odb_hash__(out @out, data, len, type).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_odb_hash", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_odb_hash__(out git_oid @out, IntPtr data, size_t len, git_object_t type);
        
        /// <summary>
        /// Read a file from disk and fill a git_oid with the object id
        /// that the file would have if it were written to the Object
        /// Database as an object of the given type (w/o applying filters).
        /// Similar functionality to git.git's `git hash-object` without
        /// the `-w` flag, however, with the --no-filters flag.
        /// If you need filters, see git_repository_hashfile.
        /// </summary>
        /// <param name="out">oid structure the result is written into.</param>
        /// <param name="path">file to read and determine object id for</param>
        /// <param name="type">the type of the object that will be hashed</param>
        /// <returns>0 or an error code</returns>
        public static git_result git_odb_hashfile(out git_oid @out, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8MarshallerStrict))] string path, git_object_t type)
        {
            var __result__ = git_odb_hashfile__(out @out, path, type).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_odb_hashfile", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_odb_hashfile__(out git_oid @out, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8MarshallerStrict))] string path, git_object_t type);
        
        /// <summary>
        /// Create a copy of an odb_object
        /// </summary>
        /// <param name="dest">pointer where to store the copy</param>
        /// <param name="source">object to copy</param>
        /// <returns>0 or an error code</returns>
        /// <remarks>
        /// The returned copy must be manually freed with `git_odb_object_free`.
        /// Note that because of an implementation detail, the returned copy will be
        /// the same pointer as `source`: the object is internally refcounted, so the
        /// copy still needs to be freed twice.
        /// </remarks>
        public static git_result git_odb_object_dup(out git_odb_object dest, git_odb_object source)
        {
            var __result__ = git_odb_object_dup__(out dest, source).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_odb_object_dup", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_odb_object_dup__(out git_odb_object dest, git_odb_object source);
        
        /// <summary>
        /// Close an ODB object
        /// </summary>
        /// <param name="object">object to close</param>
        /// <remarks>
        /// This method must always be called once a `git_odb_object` is no
        /// longer needed, otherwise memory will leak.
        /// </remarks>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void git_odb_object_free(git_odb_object @object);
        
        /// <summary>
        /// Return the OID of an ODB object
        /// </summary>
        /// <param name="object">the object</param>
        /// <returns>a pointer to the OID</returns>
        /// <remarks>
        /// This is the OID from which the object was read from
        /// </remarks>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ref readonly git_oid git_odb_object_id(git_odb_object @object);
        
        /// <summary>
        /// Return the data of an ODB object
        /// </summary>
        /// <param name="object">the object</param>
        /// <returns>a pointer to the data</returns>
        /// <remarks>
        /// This is the uncompressed, raw data as read from the ODB,
        /// without the leading header.This pointer is owned by the object and shall not be free'd.
        /// </remarks>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr git_odb_object_data(git_odb_object @object);
        
        /// <summary>
        /// Return the size of an ODB object
        /// </summary>
        /// <param name="object">the object</param>
        /// <returns>the size</returns>
        /// <remarks>
        /// This is the real size of the `data` buffer, not the
        /// actual size of the object.
        /// </remarks>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern size_t git_odb_object_size(git_odb_object @object);
        
        /// <summary>
        /// Return the type of an ODB object
        /// </summary>
        /// <param name="object">the object</param>
        /// <returns>the type</returns>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern git_object_t git_odb_object_type(git_odb_object @object);
        
        /// <summary>
        /// Add a custom backend to an existing Object DB
        /// </summary>
        /// <param name="odb">database to add the backend to</param>
        /// <param name="backend">pointer to a git_odb_backend instance</param>
        /// <param name="priority">Value for ordering the backends queue</param>
        /// <returns>0 on success; error code otherwise</returns>
        /// <remarks>
        /// The backends are checked in relative ordering, based on the
        /// value of the `priority` parameter.Read 
        /// &lt;sys
        /// /odb_backend.h&gt; for more information.
        /// </remarks>
        public static git_result git_odb_add_backend(git_odb odb, git_odb_backend backend, int priority)
        {
            var __result__ = git_odb_add_backend__(odb, backend, priority).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_odb_add_backend", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_odb_add_backend__(git_odb odb, git_odb_backend backend, int priority);
        
        /// <summary>
        /// Add a custom backend to an existing Object DB; this
        /// backend will work as an alternate.
        /// </summary>
        /// <param name="odb">database to add the backend to</param>
        /// <param name="backend">pointer to a git_odb_backend instance</param>
        /// <param name="priority">Value for ordering the backends queue</param>
        /// <returns>0 on success; error code otherwise</returns>
        /// <remarks>
        /// Alternate backends are always checked for objects *after*
        /// all the main backends have been exhausted.The backends are checked in relative ordering, based on the
        /// value of the `priority` parameter.Writing is disabled on alternate backends.Read 
        /// &lt;sys
        /// /odb_backend.h&gt; for more information.
        /// </remarks>
        public static git_result git_odb_add_alternate(git_odb odb, git_odb_backend backend, int priority)
        {
            var __result__ = git_odb_add_alternate__(odb, backend, priority).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_odb_add_alternate", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_odb_add_alternate__(git_odb odb, git_odb_backend backend, int priority);
        
        /// <summary>
        /// Get the number of ODB backend objects
        /// </summary>
        /// <param name="odb">object database</param>
        /// <returns>number of backends in the ODB</returns>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern size_t git_odb_num_backends(git_odb odb);
        
        /// <summary>
        /// Lookup an ODB backend object by index
        /// </summary>
        /// <param name="out">output pointer to ODB backend at pos</param>
        /// <param name="odb">object database</param>
        /// <param name="pos">index into object database backend list</param>
        /// <returns>0 on success; GIT_ENOTFOUND if pos is invalid; other errors 
        /// &lt;
        /// 0</returns>
        public static git_result git_odb_get_backend(out git_odb_backend @out, git_odb odb, size_t pos)
        {
            var __result__ = git_odb_get_backend__(out @out, odb, pos).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_odb_get_backend", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_odb_get_backend__(out git_odb_backend @out, git_odb odb, size_t pos);
    }
}
