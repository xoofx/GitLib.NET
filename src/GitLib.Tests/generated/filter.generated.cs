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
    public partial class FilterTests : GitLibTestsBase
    {
        public FilterTests() : base("filter") {}
        
        private void Check()
        {
            Test_git_filter_list_load();
            Test_git_filter_list_contains();
            Test_git_filter_list_apply_to_data();
            Test_git_filter_list_apply_to_file();
            Test_git_filter_list_apply_to_blob();
            Test_git_filter_list_stream_data();
            Test_git_filter_list_stream_file();
            Test_git_filter_list_stream_blob();
            Test_git_filter_list_free();
        }
    }
}
