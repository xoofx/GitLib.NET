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
        /// Kinds of reset operation
        /// </summary>
        public enum git_reset_t : int
        {
            /// <summary>
            /// Move the head to the given commit
            /// </summary>
            GIT_RESET_SOFT = (int)1,
            
            /// <summary>
            /// SOFT plus reset index to the commit
            /// </summary>
            GIT_RESET_MIXED = (int)2,
            
            /// <summary>
            /// MIXED plus changes in working tree discarded
            /// </summary>
            GIT_RESET_HARD = (int)3,
        }
        
        /// <summary>
        /// Move the head to the given commit
        /// </summary>
        public const git_reset_t GIT_RESET_SOFT = git_reset_t.GIT_RESET_SOFT;
        
        /// <summary>
        /// SOFT plus reset index to the commit
        /// </summary>
        public const git_reset_t GIT_RESET_MIXED = git_reset_t.GIT_RESET_MIXED;
        
        /// <summary>
        /// MIXED plus changes in working tree discarded
        /// </summary>
        public const git_reset_t GIT_RESET_HARD = git_reset_t.GIT_RESET_HARD;
        
        /// <summary>
        /// Sets the current head to the specified commit oid and optionally
        /// resets the index and working tree to match.
        /// </summary>
        /// <param name="repo">Repository where to perform the reset operation.</param>
        /// <param name="target">Committish to which the Head should be moved to. This object
        /// must belong to the given `repo` and can either be a git_commit or a
        /// git_tag. When a git_tag is being passed, it should be dereferencable
        /// to a git_commit which oid will be used as the target of the branch.</param>
        /// <param name="reset_type">Kind of reset operation to perform.</param>
        /// <param name="checkout_opts">Optional checkout options to be used for a HARD reset.
        /// The checkout_strategy field will be overridden (based on reset_type).
        /// This parameter can be used to propagate notify and progress callbacks.</param>
        /// <returns>0 on success or an error code</returns>
        /// <remarks>
        /// SOFT reset means the Head will be moved to the commit.MIXED reset will trigger a SOFT reset, plus the index will be replaced
        /// with the content of the commit tree.HARD reset will trigger a MIXED reset and the working directory will be
        /// replaced with the content of the index.  (Untracked and ignored files
        /// will be left alone, however.)TODO: Implement remaining kinds of resets.
        /// </remarks>
        public static git_result git_reset(git_repository repo, git_object target, git_reset_t reset_type, in git_checkout_options checkout_opts)
        {
            var __result__ = git_reset__(repo, target, reset_type, checkout_opts).Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_reset", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_reset__(git_repository repo, git_object target, git_reset_t reset_type, in git_checkout_options checkout_opts);
        
        /// <summary>
        /// Sets the current head to the specified commit oid and optionally
        /// resets the index and working tree to match.
        /// </summary>
        /// <seealso cref="git_reset"/>
        /// 
        /// <remarks>
        /// This behaves like `git_reset()` but takes an annotated commit,
        /// which lets you specify which extended sha syntax string was
        /// specified by a user, allowing for more exact reflog messages.See the documentation for `git_reset()`.
        /// </remarks>
        [DllImport(GitLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int git_reset_from_annotated(git_repository repo, git_annotated_commit commit, git_reset_t reset_type, in git_checkout_options checkout_opts);
        
        /// <summary>
        /// Updates some entries in the index from the target commit tree.
        /// </summary>
        /// <param name="repo">Repository where to perform the reset operation.</param>
        /// <param name="target">The committish which content will be used to reset the content
        /// of the index.</param>
        /// <param name="pathspecs">List of pathspecs to operate on.</param>
        /// <returns>0 on success or an error code 
        /// &lt;
        /// 0</returns>
        /// <remarks>
        /// The scope of the updated entries is determined by the paths
        /// being passed in the `pathspec` parameters.Passing a NULL `target` will result in removing
        /// entries in the index matching the provided pathspecs.
        /// </remarks>
        public static git_result git_reset_default(git_repository repo, git_object target, string[] pathspecs)
        {
            var pathspecs__ = git_strarray.Allocate(pathspecs);
            var __result__ = git_reset_default__(repo, target, in pathspecs__);
            pathspecs__.Free();
            __result__.Check();
            return __result__;
        }
        
        [DllImport(GitLibName, EntryPoint = "git_reset_default", CallingConvention = CallingConvention.Cdecl)]
        private static extern git_result git_reset_default__(git_repository repo, git_object target, in git_strarray pathspecs);
    }
}