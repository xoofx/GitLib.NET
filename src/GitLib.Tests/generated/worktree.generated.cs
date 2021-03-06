//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;

namespace GitLib.Tests
{
    public partial class WorktreeTests : GitLibTestsBase
    {
        public WorktreeTests() : base("worktree") {}
        
        private void Check()
        {
            Test_git_worktree_list();
            Test_git_worktree_lookup();
            Test_git_worktree_open_from_repository();
            Test_git_worktree_free();
            Test_git_worktree_validate();
            Test_git_worktree_add_init_options();
            Test_git_worktree_add();
            Test_git_worktree_lock();
            Test_git_worktree_unlock();
            Test_git_worktree_is_locked();
            Test_git_worktree_name();
            Test_git_worktree_path();
            Test_git_worktree_prune_init_options();
            Test_git_worktree_is_prunable();
            Test_git_worktree_prune();
        }
    }
}
