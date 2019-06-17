//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;

namespace LibGit2.Tests
{
    public partial class RepositoryTests : LibGit2TestsBase
    {
        private void Check()
        {
            Test_git_repository_open();
            Test_git_repository_open_from_worktree();
            Test_git_repository_wrap_odb();
            Test_git_repository_discover();
            Test_git_repository_open_ext();
            Test_git_repository_open_bare();
            Test_git_repository_free();
            Test_git_repository_init();
            Test_git_repository_init_init_options();
            Test_git_repository_init_ext();
            Test_git_repository_head();
            Test_git_repository_head_for_worktree();
            Test_git_repository_head_detached();
            Test_git_repository_head_detached_for_worktree();
            Test_git_repository_head_unborn();
            Test_git_repository_is_empty();
            Test_git_repository_item_path();
            Test_git_repository_path();
            Test_git_repository_workdir();
            Test_git_repository_commondir();
            Test_git_repository_set_workdir();
            Test_git_repository_is_bare();
            Test_git_repository_is_worktree();
            Test_git_repository_config();
            Test_git_repository_config_snapshot();
            Test_git_repository_odb();
            Test_git_repository_refdb();
            Test_git_repository_index();
            Test_git_repository_message();
            Test_git_repository_message_remove();
            Test_git_repository_state_cleanup();
            Test_git_repository_fetchhead_foreach();
            Test_git_repository_mergehead_foreach();
            Test_git_repository_hashfile();
            Test_git_repository_set_head();
            Test_git_repository_set_head_detached();
            Test_git_repository_set_head_detached_from_annotated();
            Test_git_repository_detach_head();
            Test_git_repository_state();
            Test_git_repository_set_namespace();
            Test_git_repository_get_namespace();
            Test_git_repository_is_shallow();
            Test_git_repository_ident();
            Test_git_repository_set_ident();
        }
    }
}