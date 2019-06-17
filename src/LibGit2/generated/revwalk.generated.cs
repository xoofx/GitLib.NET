//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;

namespace LibGit2
{
    using System.Runtime.InteropServices;
    
    public static partial class libgit2
    {
        /// <summary>
        /// Flags to specify the sorting which a revwalk should perform.
        /// </summary>
        [Flags]
        public enum git_sort_t : int
        {
            /// <summary>
            /// Sort the output with the same default method from `git`: reverse
            /// chronological order. This is the default sorting for new walkers.
            /// </summary>
            GIT_SORT_NONE = (int)0,
            
            /// <summary>
            /// Sort the repository contents in topological order (no parents before
            /// all of its children are shown); this sorting mode can be combined
            /// with time sorting to produce `git`'s `--date-order``.
            /// </summary>
            GIT_SORT_TOPOLOGICAL = (int)1 << 0,
            
            /// <summary>
            /// Sort the repository contents by commit time;
            /// this sorting mode can be combined with
            /// topological sorting.
            /// </summary>
            GIT_SORT_TIME = (int)1 << 1,
            
            /// <summary>
            /// Iterate through the repository contents in reverse
            /// order; this sorting mode can be combined with
            /// any of the above.
            /// </summary>
            GIT_SORT_REVERSE = (int)1 << 2,
        }
        
        /// <summary>
        /// Sort the output with the same default method from `git`: reverse
        /// chronological order. This is the default sorting for new walkers.
        /// </summary>
        public const git_sort_t GIT_SORT_NONE = git_sort_t.GIT_SORT_NONE;
        
        /// <summary>
        /// Sort the repository contents in topological order (no parents before
        /// all of its children are shown); this sorting mode can be combined
        /// with time sorting to produce `git`'s `--date-order``.
        /// </summary>
        public const git_sort_t GIT_SORT_TOPOLOGICAL = git_sort_t.GIT_SORT_TOPOLOGICAL;
        
        /// <summary>
        /// Sort the repository contents by commit time;
        /// this sorting mode can be combined with
        /// topological sorting.
        /// </summary>
        public const git_sort_t GIT_SORT_TIME = git_sort_t.GIT_SORT_TIME;
        
        /// <summary>
        /// Iterate through the repository contents in reverse
        /// order; this sorting mode can be combined with
        /// any of the above.
        /// </summary>
        public const git_sort_t GIT_SORT_REVERSE = git_sort_t.GIT_SORT_REVERSE;
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int git_revwalk_hide_cb(in git_oid commit_id, IntPtr payload);
        
        /// <summary>
        /// Allocate a new revision walker to iterate through a repo.
        /// </summary>
        /// <param name="out">pointer to the new revision walker</param>
        /// <param name="repo">the repo to walk through</param>
        /// <returns>0 or an error code</returns>
        /// <remarks>
        /// This revision walker uses a custom memory pool and an internal
        /// commit cache, so it is relatively expensive to allocate.For maximum performance, this revision walker should be
        /// reused for different walks.This revision walker is *not* thread safe: it may only be
        /// used to walk a repository on a single thread; however,
        /// it is possible to have several revision walkers in
        /// several different threads walking the same repository.
        /// </remarks>
        public static git_result git_revwalk_new(out git_revwalk @out, git_repository repo)
        {
            var __result__ = git_revwalk_new__(out @out, repo).Check();
            return __result__;
        }
        
        [DllImport(LibGit2Name, EntryPoint = "git_revwalk_new", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_revwalk_new__(out git_revwalk @out, git_repository repo);
        
        /// <summary>
        /// Reset the revision walker for reuse.
        /// </summary>
        /// <param name="walker">handle to reset.</param>
        /// <remarks>
        /// This will clear all the pushed and hidden commits, and
        /// leave the walker in a blank state (just like at
        /// creation) ready to receive new commit pushes and
        /// start a new walk.The revision walk is automatically reset when a walk
        /// is over.
        /// </remarks>
        [DllImport(LibGit2Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern void git_revwalk_reset(git_revwalk walker);
        
        /// <summary>
        /// Add a new root for the traversal
        /// </summary>
        /// <param name="walk">the walker being used for the traversal.</param>
        /// <param name="id">the oid of the commit to start from.</param>
        /// <returns>0 or an error code</returns>
        /// <remarks>
        /// The pushed commit will be marked as one of the roots from which to
        /// start the walk. This commit may not be walked if it or a child is
        /// hidden.At least one commit must be pushed onto the walker before a walk
        /// can be started.The given id must belong to a committish on the walked
        /// repository.
        /// </remarks>
        public static git_result git_revwalk_push(git_revwalk walk, in git_oid id)
        {
            var __result__ = git_revwalk_push__(walk, id).Check();
            return __result__;
        }
        
        [DllImport(LibGit2Name, EntryPoint = "git_revwalk_push", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_revwalk_push__(git_revwalk walk, in git_oid id);
        
        /// <summary>
        /// Push matching references
        /// </summary>
        /// <param name="walk">the walker being used for the traversal</param>
        /// <param name="glob">the glob pattern references should match</param>
        /// <returns>0 or an error code</returns>
        /// <remarks>
        /// The OIDs pointed to by the references that match the given glob
        /// pattern will be pushed to the revision walker.A leading 'refs/' is implied if not present as well as a trailing
        /// '/
        /// \
        /// *' if the glob lacks '?', '
        /// \
        /// *' or '['.Any references matching this glob which do not point to a
        /// committish will be ignored.
        /// </remarks>
        public static git_result git_revwalk_push_glob(git_revwalk walk, [MarshalAs(UnmanagedType.LPUTF8Str)] string glob)
        {
            var __result__ = git_revwalk_push_glob__(walk, glob).Check();
            return __result__;
        }
        
        [DllImport(LibGit2Name, EntryPoint = "git_revwalk_push_glob", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_revwalk_push_glob__(git_revwalk walk, [MarshalAs(UnmanagedType.LPUTF8Str)] string glob);
        
        /// <summary>
        /// Push the repository's HEAD
        /// </summary>
        /// <param name="walk">the walker being used for the traversal</param>
        /// <returns>0 or an error code</returns>
        public static git_result git_revwalk_push_head(git_revwalk walk)
        {
            var __result__ = git_revwalk_push_head__(walk).Check();
            return __result__;
        }
        
        [DllImport(LibGit2Name, EntryPoint = "git_revwalk_push_head", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_revwalk_push_head__(git_revwalk walk);
        
        /// <summary>
        /// Mark a commit (and its ancestors) uninteresting for the output.
        /// </summary>
        /// <param name="walk">the walker being used for the traversal.</param>
        /// <param name="commit_id">the oid of commit that will be ignored during the traversal</param>
        /// <returns>0 or an error code</returns>
        /// <remarks>
        /// The given id must belong to a committish on the walked
        /// repository.The resolved commit and all its parents will be hidden from the
        /// output on the revision walk.
        /// </remarks>
        public static git_result git_revwalk_hide(git_revwalk walk, in git_oid commit_id)
        {
            var __result__ = git_revwalk_hide__(walk, commit_id).Check();
            return __result__;
        }
        
        [DllImport(LibGit2Name, EntryPoint = "git_revwalk_hide", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_revwalk_hide__(git_revwalk walk, in git_oid commit_id);
        
        /// <summary>
        /// Hide matching references.
        /// </summary>
        /// <param name="walk">the walker being used for the traversal</param>
        /// <param name="glob">the glob pattern references should match</param>
        /// <returns>0 or an error code</returns>
        /// <remarks>
        /// The OIDs pointed to by the references that match the given glob
        /// pattern and their ancestors will be hidden from the output on the
        /// revision walk.A leading 'refs/' is implied if not present as well as a trailing
        /// '/
        /// \
        /// *' if the glob lacks '?', '
        /// \
        /// *' or '['.Any references matching this glob which do not point to a
        /// committish will be ignored.
        /// </remarks>
        public static git_result git_revwalk_hide_glob(git_revwalk walk, [MarshalAs(UnmanagedType.LPUTF8Str)] string glob)
        {
            var __result__ = git_revwalk_hide_glob__(walk, glob).Check();
            return __result__;
        }
        
        [DllImport(LibGit2Name, EntryPoint = "git_revwalk_hide_glob", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_revwalk_hide_glob__(git_revwalk walk, [MarshalAs(UnmanagedType.LPUTF8Str)] string glob);
        
        /// <summary>
        /// Hide the repository's HEAD
        /// </summary>
        /// <param name="walk">the walker being used for the traversal</param>
        /// <returns>0 or an error code</returns>
        public static git_result git_revwalk_hide_head(git_revwalk walk)
        {
            var __result__ = git_revwalk_hide_head__(walk).Check();
            return __result__;
        }
        
        [DllImport(LibGit2Name, EntryPoint = "git_revwalk_hide_head", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_revwalk_hide_head__(git_revwalk walk);
        
        /// <summary>
        /// Push the OID pointed to by a reference
        /// </summary>
        /// <param name="walk">the walker being used for the traversal</param>
        /// <param name="refname">the reference to push</param>
        /// <returns>0 or an error code</returns>
        /// <remarks>
        /// The reference must point to a committish.
        /// </remarks>
        public static git_result git_revwalk_push_ref(git_revwalk walk, [MarshalAs(UnmanagedType.LPUTF8Str)] string refname)
        {
            var __result__ = git_revwalk_push_ref__(walk, refname).Check();
            return __result__;
        }
        
        [DllImport(LibGit2Name, EntryPoint = "git_revwalk_push_ref", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_revwalk_push_ref__(git_revwalk walk, [MarshalAs(UnmanagedType.LPUTF8Str)] string refname);
        
        /// <summary>
        /// Hide the OID pointed to by a reference
        /// </summary>
        /// <param name="walk">the walker being used for the traversal</param>
        /// <param name="refname">the reference to hide</param>
        /// <returns>0 or an error code</returns>
        /// <remarks>
        /// The reference must point to a committish.
        /// </remarks>
        public static git_result git_revwalk_hide_ref(git_revwalk walk, [MarshalAs(UnmanagedType.LPUTF8Str)] string refname)
        {
            var __result__ = git_revwalk_hide_ref__(walk, refname).Check();
            return __result__;
        }
        
        [DllImport(LibGit2Name, EntryPoint = "git_revwalk_hide_ref", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_revwalk_hide_ref__(git_revwalk walk, [MarshalAs(UnmanagedType.LPUTF8Str)] string refname);
        
        /// <summary>
        /// Get the next commit from the revision walk.
        /// </summary>
        /// <param name="out">Pointer where to store the oid of the next commit</param>
        /// <param name="walk">the walker to pop the commit from.</param>
        /// <returns>0 if the next commit was found;
        /// GIT_ITEROVER if there are no commits left to iterate</returns>
        /// <remarks>
        /// The initial call to this method is *not* blocking when
        /// iterating through a repo with a time-sorting mode.Iterating with Topological or inverted modes makes the initial
        /// call blocking to preprocess the commit list, but this block should be
        /// mostly unnoticeable on most repositories (topological preprocessing
        /// times at 0.3s on the git.git repo).The revision walker is reset when the walk is over.
        /// </remarks>
        [DllImport(LibGit2Name, CallingConvention = CallingConvention.Cdecl)]
        [return:MarshalAs(UnmanagedType.Bool)]
        public static extern bool git_revwalk_next(out git_oid @out, git_revwalk walk);
        
        /// <summary>
        /// Change the sorting mode when iterating through the
        /// repository's contents.
        /// </summary>
        /// <param name="walk">the walker being used for the traversal.</param>
        /// <param name="sort_mode">combination of GIT_SORT_XXX flags</param>
        /// <remarks>
        /// Changing the sorting mode resets the walker.
        /// </remarks>
        [DllImport(LibGit2Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern void git_revwalk_sorting(git_revwalk walk, git_sort_t sort_mode);
        
        /// <summary>
        /// Push and hide the respective endpoints of the given range.
        /// </summary>
        /// <param name="walk">the walker being used for the traversal</param>
        /// <param name="range">the range</param>
        /// <returns>0 or an error code</returns>
        /// <remarks>
        /// The range should be of the form
        /// &lt;commit
        /// &gt;..
        /// &lt;commit
        /// &gt;
        /// where each 
        /// &lt;commit
        /// &gt; is in the form accepted by 'git_revparse_single'.
        /// The left-hand commit will be hidden and the right-hand commit pushed.
        /// </remarks>
        public static git_result git_revwalk_push_range(git_revwalk walk, [MarshalAs(UnmanagedType.LPUTF8Str)] string range)
        {
            var __result__ = git_revwalk_push_range__(walk, range).Check();
            return __result__;
        }
        
        [DllImport(LibGit2Name, EntryPoint = "git_revwalk_push_range", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_revwalk_push_range__(git_revwalk walk, [MarshalAs(UnmanagedType.LPUTF8Str)] string range);
        
        /// <summary>
        /// Simplify the history by first-parent
        /// </summary>
        /// <remarks>
        /// No parents other than the first for each commit will be enqueued.
        /// </remarks>
        [DllImport(LibGit2Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern void git_revwalk_simplify_first_parent(git_revwalk walk);
        
        /// <summary>
        /// Free a revision walker previously allocated.
        /// </summary>
        /// <param name="walk">traversal handle to close. If NULL nothing occurs.</param>
        [DllImport(LibGit2Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern void git_revwalk_free(git_revwalk walk);
        
        /// <summary>
        /// Return the repository on which this walker
        /// is operating.
        /// </summary>
        /// <param name="walk">the revision walker</param>
        /// <returns>the repository being walked</returns>
        [DllImport(LibGit2Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern git_repository git_revwalk_repository(git_revwalk walk);
        
        /// <summary>
        /// Adds, changes or removes a callback function to hide a commit and its parents
        /// </summary>
        /// <param name="walk">the revision walker</param>
        /// <param name="hide_cb">callback function to hide a commit and its parents</param>
        /// <param name="payload">data payload to be passed to callback function</param>
        [DllImport(LibGit2Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern int git_revwalk_add_hide_cb(git_revwalk walk, git_revwalk_hide_cb hide_cb, IntPtr payload);
    }
}
