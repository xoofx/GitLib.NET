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
    public partial class GlobalTests : GitLibTestsBase
    {
        public GlobalTests() : base("global") {}
        
        private void Check()
        {
            Test_git_libgit2_init();
            Test_git_libgit2_shutdown();
        }
    }
}
