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
    public partial class ConfigTests : GitLibTestsBase
    {
        private void Check()
        {
            Test_git_config_entry_free();
            Test_git_config_find_global();
            Test_git_config_find_xdg();
            Test_git_config_find_system();
            Test_git_config_find_programdata();
            Test_git_config_open_default();
            Test_git_config_new();
            Test_git_config_add_file_ondisk();
            Test_git_config_open_ondisk();
            Test_git_config_open_level();
            Test_git_config_open_global();
            Test_git_config_snapshot();
            Test_git_config_free();
            Test_git_config_get_entry();
            Test_git_config_get_int32();
            Test_git_config_get_int64();
            Test_git_config_get_bool();
            Test_git_config_get_path();
            Test_git_config_get_string();
            Test_git_config_get_string_buf();
            Test_git_config_get_multivar_foreach();
            Test_git_config_multivar_iterator_new();
            Test_git_config_next();
            Test_git_config_iterator_free();
            Test_git_config_set_int32();
            Test_git_config_set_int64();
            Test_git_config_set_bool();
            Test_git_config_set_string();
            Test_git_config_set_multivar();
            Test_git_config_delete_entry();
            Test_git_config_delete_multivar();
            Test_git_config_foreach();
            Test_git_config_iterator_new();
            Test_git_config_iterator_glob_new();
            Test_git_config_foreach_match();
            Test_git_config_get_mapped();
            Test_git_config_lookup_map_value();
            Test_git_config_parse_bool();
            Test_git_config_parse_int32();
            Test_git_config_parse_int64();
            Test_git_config_parse_path();
            Test_git_config_backend_foreach_match();
            Test_git_config_lock();
        }
    }
}