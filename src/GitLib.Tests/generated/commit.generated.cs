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
    public partial class CommitTests : GitLibTestsBase
    {
        public CommitTests() : base("commit") {}
        
        private void Check()
        {
            Test_git_commit_lookup();
            Test_git_commit_lookup_prefix();
            Test_git_commit_free();
            Test_git_commit_id();
            Test_git_commit_owner();
            Test_git_commit_message_encoding();
            Test_git_commit_message();
            Test_git_commit_message_raw();
            Test_git_commit_summary();
            Test_git_commit_body();
            Test_git_commit_time();
            Test_git_commit_time_offset();
            Test_git_commit_committer();
            Test_git_commit_author();
            Test_git_commit_committer_with_mailmap();
            Test_git_commit_author_with_mailmap();
            Test_git_commit_raw_header();
            Test_git_commit_tree();
            Test_git_commit_tree_id();
            Test_git_commit_parentcount();
            Test_git_commit_parent();
            Test_git_commit_parent_id();
            Test_git_commit_nth_gen_ancestor();
            Test_git_commit_header_field();
            Test_git_commit_extract_signature();
            Test_git_commit_create();
            Test_git_commit_create_v();
            Test_git_commit_amend();
            Test_git_commit_create_buffer();
            Test_git_commit_create_with_signature();
            Test_git_commit_dup();
        }
    }
}
