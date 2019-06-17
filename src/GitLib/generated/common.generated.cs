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
        /// Combinations of these values describe the features with which libgit2
        /// was compiled
        /// </summary>
        [Flags]
        public enum git_feature_t : int
        {
            /// <summary>
            /// If set, libgit2 was built thread-aware and can be safely used from multiple
            /// threads.
            /// </summary>
            GIT_FEATURE_THREADS = (int)(1 << 0),
            
            /// <summary>
            /// If set, libgit2 was built with and linked against a TLS implementation.
            /// Custom TLS streams may still be added by the user to support HTTPS
            /// regardless of this.
            /// </summary>
            GIT_FEATURE_HTTPS = (int)(1 << 1),
            
            /// <summary>
            /// If set, libgit2 was built with and linked against libssh2. A custom
            /// transport may still be added by the user to support libssh2 regardless of
            /// this.
            /// </summary>
            GIT_FEATURE_SSH = (int)(1 << 2),
            
            /// <summary>
            /// If set, libgit2 was built with support for sub-second resolution in file
            /// modification times.
            /// </summary>
            GIT_FEATURE_NSEC = (int)(1 << 3),
        }
        
        /// <summary>
        /// If set, libgit2 was built thread-aware and can be safely used from multiple
        /// threads.
        /// </summary>
        public const git_feature_t GIT_FEATURE_THREADS = git_feature_t.GIT_FEATURE_THREADS;
        
        /// <summary>
        /// If set, libgit2 was built with and linked against a TLS implementation.
        /// Custom TLS streams may still be added by the user to support HTTPS
        /// regardless of this.
        /// </summary>
        public const git_feature_t GIT_FEATURE_HTTPS = git_feature_t.GIT_FEATURE_HTTPS;
        
        /// <summary>
        /// If set, libgit2 was built with and linked against libssh2. A custom
        /// transport may still be added by the user to support libssh2 regardless of
        /// this.
        /// </summary>
        public const git_feature_t GIT_FEATURE_SSH = git_feature_t.GIT_FEATURE_SSH;
        
        /// <summary>
        /// If set, libgit2 was built with support for sub-second resolution in file
        /// modification times.
        /// </summary>
        public const git_feature_t GIT_FEATURE_NSEC = git_feature_t.GIT_FEATURE_NSEC;
        
        /// <summary>
        /// Global library options
        /// </summary>
        /// <remarks>
        /// These are used to select which global option to set or get and are
        /// used in `git_libgit2_opts()`.
        /// </remarks>
        public enum git_libgit2_opt_t : int
        {
            GIT_OPT_GET_MWINDOW_SIZE,
            
            GIT_OPT_SET_MWINDOW_SIZE,
            
            GIT_OPT_GET_MWINDOW_MAPPED_LIMIT,
            
            GIT_OPT_SET_MWINDOW_MAPPED_LIMIT,
            
            GIT_OPT_GET_SEARCH_PATH,
            
            GIT_OPT_SET_SEARCH_PATH,
            
            GIT_OPT_SET_CACHE_OBJECT_LIMIT,
            
            GIT_OPT_SET_CACHE_MAX_SIZE,
            
            GIT_OPT_ENABLE_CACHING,
            
            GIT_OPT_GET_CACHED_MEMORY,
            
            GIT_OPT_GET_TEMPLATE_PATH,
            
            GIT_OPT_SET_TEMPLATE_PATH,
            
            GIT_OPT_SET_SSL_CERT_LOCATIONS,
            
            GIT_OPT_SET_USER_AGENT,
            
            GIT_OPT_ENABLE_STRICT_OBJECT_CREATION,
            
            GIT_OPT_ENABLE_STRICT_SYMBOLIC_REF_CREATION,
            
            GIT_OPT_SET_SSL_CIPHERS,
            
            GIT_OPT_GET_USER_AGENT,
            
            GIT_OPT_ENABLE_OFS_DELTA,
            
            GIT_OPT_ENABLE_FSYNC_GITDIR,
            
            GIT_OPT_GET_WINDOWS_SHAREMODE,
            
            GIT_OPT_SET_WINDOWS_SHAREMODE,
            
            GIT_OPT_ENABLE_STRICT_HASH_VERIFICATION,
            
            GIT_OPT_SET_ALLOCATOR,
            
            GIT_OPT_ENABLE_UNSAVED_INDEX_SAFETY,
            
            GIT_OPT_GET_PACK_MAX_OBJECTS,
            
            GIT_OPT_SET_PACK_MAX_OBJECTS,
        }
        
        public const git_libgit2_opt_t GIT_OPT_GET_MWINDOW_SIZE = git_libgit2_opt_t.GIT_OPT_GET_MWINDOW_SIZE;
        
        public const git_libgit2_opt_t GIT_OPT_SET_MWINDOW_SIZE = git_libgit2_opt_t.GIT_OPT_SET_MWINDOW_SIZE;
        
        public const git_libgit2_opt_t GIT_OPT_GET_MWINDOW_MAPPED_LIMIT = git_libgit2_opt_t.GIT_OPT_GET_MWINDOW_MAPPED_LIMIT;
        
        public const git_libgit2_opt_t GIT_OPT_SET_MWINDOW_MAPPED_LIMIT = git_libgit2_opt_t.GIT_OPT_SET_MWINDOW_MAPPED_LIMIT;
        
        public const git_libgit2_opt_t GIT_OPT_GET_SEARCH_PATH = git_libgit2_opt_t.GIT_OPT_GET_SEARCH_PATH;
        
        public const git_libgit2_opt_t GIT_OPT_SET_SEARCH_PATH = git_libgit2_opt_t.GIT_OPT_SET_SEARCH_PATH;
        
        public const git_libgit2_opt_t GIT_OPT_SET_CACHE_OBJECT_LIMIT = git_libgit2_opt_t.GIT_OPT_SET_CACHE_OBJECT_LIMIT;
        
        public const git_libgit2_opt_t GIT_OPT_SET_CACHE_MAX_SIZE = git_libgit2_opt_t.GIT_OPT_SET_CACHE_MAX_SIZE;
        
        public const git_libgit2_opt_t GIT_OPT_ENABLE_CACHING = git_libgit2_opt_t.GIT_OPT_ENABLE_CACHING;
        
        public const git_libgit2_opt_t GIT_OPT_GET_CACHED_MEMORY = git_libgit2_opt_t.GIT_OPT_GET_CACHED_MEMORY;
        
        public const git_libgit2_opt_t GIT_OPT_GET_TEMPLATE_PATH = git_libgit2_opt_t.GIT_OPT_GET_TEMPLATE_PATH;
        
        public const git_libgit2_opt_t GIT_OPT_SET_TEMPLATE_PATH = git_libgit2_opt_t.GIT_OPT_SET_TEMPLATE_PATH;
        
        public const git_libgit2_opt_t GIT_OPT_SET_SSL_CERT_LOCATIONS = git_libgit2_opt_t.GIT_OPT_SET_SSL_CERT_LOCATIONS;
        
        public const git_libgit2_opt_t GIT_OPT_SET_USER_AGENT = git_libgit2_opt_t.GIT_OPT_SET_USER_AGENT;
        
        public const git_libgit2_opt_t GIT_OPT_ENABLE_STRICT_OBJECT_CREATION = git_libgit2_opt_t.GIT_OPT_ENABLE_STRICT_OBJECT_CREATION;
        
        public const git_libgit2_opt_t GIT_OPT_ENABLE_STRICT_SYMBOLIC_REF_CREATION = git_libgit2_opt_t.GIT_OPT_ENABLE_STRICT_SYMBOLIC_REF_CREATION;
        
        public const git_libgit2_opt_t GIT_OPT_SET_SSL_CIPHERS = git_libgit2_opt_t.GIT_OPT_SET_SSL_CIPHERS;
        
        public const git_libgit2_opt_t GIT_OPT_GET_USER_AGENT = git_libgit2_opt_t.GIT_OPT_GET_USER_AGENT;
        
        public const git_libgit2_opt_t GIT_OPT_ENABLE_OFS_DELTA = git_libgit2_opt_t.GIT_OPT_ENABLE_OFS_DELTA;
        
        public const git_libgit2_opt_t GIT_OPT_ENABLE_FSYNC_GITDIR = git_libgit2_opt_t.GIT_OPT_ENABLE_FSYNC_GITDIR;
        
        public const git_libgit2_opt_t GIT_OPT_GET_WINDOWS_SHAREMODE = git_libgit2_opt_t.GIT_OPT_GET_WINDOWS_SHAREMODE;
        
        public const git_libgit2_opt_t GIT_OPT_SET_WINDOWS_SHAREMODE = git_libgit2_opt_t.GIT_OPT_SET_WINDOWS_SHAREMODE;
        
        public const git_libgit2_opt_t GIT_OPT_ENABLE_STRICT_HASH_VERIFICATION = git_libgit2_opt_t.GIT_OPT_ENABLE_STRICT_HASH_VERIFICATION;
        
        public const git_libgit2_opt_t GIT_OPT_SET_ALLOCATOR = git_libgit2_opt_t.GIT_OPT_SET_ALLOCATOR;
        
        public const git_libgit2_opt_t GIT_OPT_ENABLE_UNSAVED_INDEX_SAFETY = git_libgit2_opt_t.GIT_OPT_ENABLE_UNSAVED_INDEX_SAFETY;
        
        public const git_libgit2_opt_t GIT_OPT_GET_PACK_MAX_OBJECTS = git_libgit2_opt_t.GIT_OPT_GET_PACK_MAX_OBJECTS;
        
        public const git_libgit2_opt_t GIT_OPT_SET_PACK_MAX_OBJECTS = git_libgit2_opt_t.GIT_OPT_SET_PACK_MAX_OBJECTS;
        
        /// <summary>
        /// Return the version of the libgit2 library
        /// being currently used.
        /// </summary>
        /// <param name="major">Store the major version number</param>
        /// <param name="minor">Store the minor version number</param>
        /// <param name="rev">Store the revision (patch) number</param>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void git_libgit2_version(ref int major, ref int minor, ref int rev);
        
        /// <summary>
        /// Query compile time options for libgit2.
        /// </summary>
        /// <returns>A combination of GIT_FEATURE_* values.</returns>
        /// <remarks>
        /// - GIT_FEATURE_THREADS
        /// Libgit2 was compiled with thread support. Note that thread support is
        /// still to be seen as a 'work in progress' - basic object lookups are
        /// believed to be threadsafe, but other operations may not be.- GIT_FEATURE_HTTPS
        /// Libgit2 supports the https:// protocol. This requires the openssl
        /// library to be found when compiling libgit2.- GIT_FEATURE_SSH
        /// Libgit2 supports the SSH protocol for network operations. This requires
        /// the libssh2 library to be found when compiling libgit2
        /// </remarks>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int git_libgit2_features();
    }
}