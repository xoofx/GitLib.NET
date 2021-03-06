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
    public partial class RevwalkTests : GitLibTestsBase
    {
        public RevwalkTests() : base("revwalk") {}
        
        private void Check()
        {
            Test_git_revwalk_new();
            Test_git_revwalk_reset();
            Test_git_revwalk_push();
            Test_git_revwalk_push_glob();
            Test_git_revwalk_push_head();
            Test_git_revwalk_hide();
            Test_git_revwalk_hide_glob();
            Test_git_revwalk_hide_head();
            Test_git_revwalk_push_ref();
            Test_git_revwalk_hide_ref();
            Test_git_revwalk_next();
            Test_git_revwalk_sorting();
            Test_git_revwalk_push_range();
            Test_git_revwalk_simplify_first_parent();
            Test_git_revwalk_free();
            Test_git_revwalk_repository();
            Test_git_revwalk_add_hide_cb();
        }
    }
}
