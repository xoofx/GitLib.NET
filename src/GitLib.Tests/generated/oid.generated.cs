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
    public partial class OidTests : GitLibTestsBase
    {
        private void Check()
        {
            Test_git_oid_fromstr();
            Test_git_oid_fromstrp();
            Test_git_oid_fromstrn();
            Test_git_oid_fromraw();
            Test_git_oid_fmt();
            Test_git_oid_nfmt();
            Test_git_oid_pathfmt();
            Test_git_oid_tostr_s();
            Test_git_oid_tostr();
            Test_git_oid_cpy();
            Test_git_oid_cmp();
            Test_git_oid_equal();
            Test_git_oid_ncmp();
            Test_git_oid_streq();
            Test_git_oid_strcmp();
            Test_git_oid_iszero();
            Test_git_oid_shorten_new();
            Test_git_oid_shorten_add();
            Test_git_oid_shorten_free();
        }
    }
}