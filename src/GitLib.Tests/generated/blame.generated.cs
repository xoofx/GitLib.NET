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
    public partial class BlameTests : GitLibTestsBase
    {
        private void Check()
        {
            Test_git_blame_init_options();
            Test_git_blame_get_hunk_count();
            Test_git_blame_get_hunk_byindex();
            Test_git_blame_get_hunk_byline();
            Test_git_blame_file();
            Test_git_blame_buffer();
            Test_git_blame_free();
        }
    }
}