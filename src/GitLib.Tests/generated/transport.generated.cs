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
    public partial class TransportTests : GitLibTestsBase
    {
        public TransportTests() : base("transport") {}
        
        private void Check()
        {
            Test_git_cred_has_username();
            Test_git_cred_userpass_plaintext_new();
            Test_git_cred_ssh_key_new();
            Test_git_cred_ssh_interactive_new();
            Test_git_cred_ssh_key_from_agent();
            Test_git_cred_ssh_custom_new();
            Test_git_cred_default_new();
            Test_git_cred_username_new();
            Test_git_cred_ssh_key_memory_new();
            Test_git_cred_free();
        }
    }
}
