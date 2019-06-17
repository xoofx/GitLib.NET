using System;

using System.IO;

using NUnit.Framework;

namespace GitLib.Tests
{
    using static libgit2;
    
    public partial class RepositoryTests
    {
        [Test]
        public void Test_git_repository_open()
        {
            git_repository_open(out var repo, RootPathOfThisRepository);
            git_repository_free(repo);
        }
        
        [Test]
        public void Test_git_repository_open_from_worktree()
        {
            Assert.Fail($"Tests for method `{nameof(git_repository_open_from_worktree)}` are not yet implemented");
        }
        
        [Test]
        public void Test_git_repository_wrap_odb()
        {
            Assert.Fail($"Tests for method `{nameof(git_repository_wrap_odb)}` are not yet implemented");
        }
        
        [Test]
        public void Test_git_repository_discover()
        {
            Assert.Fail($"Tests for method `{nameof(git_repository_discover)}` are not yet implemented");
        }
        
        [Test]
        public void Test_git_repository_open_ext()
        {
            git_repository_open_ext(out var repo, Environment.CurrentDirectory, 0, "");
            git_repository_free(repo);
        }
        
        [Test]
        public void Test_git_repository_open_bare()
        {
            Assert.Fail($"Tests for method `{nameof(git_repository_open_bare)}` are not yet implemented");
        }
        
        [Test]
        public void Test_git_repository_free()
        {
            Assert.Fail($"Tests for method `{nameof(git_repository_free)}` are not yet implemented");
        }
        
        [Test]
        public void Test_git_repository_init()
        {
            Assert.Fail($"Tests for method `{nameof(git_repository_init)}` are not yet implemented");
        }
        
        [Test]
        public void Test_git_repository_init_init_options()
        {
            Assert.Fail($"Tests for method `{nameof(git_repository_init_init_options)}` are not yet implemented");
        }
        
        [Test]
        public void Test_git_repository_init_ext()
        {
            Assert.Fail($"Tests for method `{nameof(git_repository_init_ext)}` are not yet implemented");
        }
        
        [Test]
        public void Test_git_repository_head()
        {
            Assert.Fail($"Tests for method `{nameof(git_repository_head)}` are not yet implemented");
        }
        
        [Test]
        public void Test_git_repository_head_for_worktree()
        {
            Assert.Fail($"Tests for method `{nameof(git_repository_head_for_worktree)}` are not yet implemented");
        }
        
        [Test]
        public void Test_git_repository_head_detached()
        {
            Assert.Fail($"Tests for method `{nameof(git_repository_head_detached)}` are not yet implemented");
        }
        
        [Test]
        public void Test_git_repository_head_detached_for_worktree()
        {
            Assert.Fail($"Tests for method `{nameof(git_repository_head_detached_for_worktree)}` are not yet implemented");
        }
        
        [Test]
        public void Test_git_repository_head_unborn()
        {
            Assert.Fail($"Tests for method `{nameof(git_repository_head_unborn)}` are not yet implemented");
        }
        
        [Test]
        public void Test_git_repository_is_empty()
        {
            git_repository_open(out var repo, RootPathOfThisRepository);
            Assert.False(git_repository_is_empty(repo));
            git_repository_free(repo);
        }
        
        [Test]
        public void Test_git_repository_item_path()
        {
            Assert.Fail($"Tests for method `{nameof(git_repository_item_path)}` are not yet implemented");
        }
        
        [Test]
        public void Test_git_repository_path()
        {
            Assert.Fail($"Tests for method `{nameof(git_repository_path)}` are not yet implemented");
        }
        
        [Test]
        public void Test_git_repository_workdir()
        {
            Assert.Fail($"Tests for method `{nameof(git_repository_workdir)}` are not yet implemented");
        }
        
        [Test]
        public void Test_git_repository_commondir()
        {
            Assert.Fail($"Tests for method `{nameof(git_repository_commondir)}` are not yet implemented");
        }
        
        [Test]
        public void Test_git_repository_set_workdir()
        {
            Assert.Fail($"Tests for method `{nameof(git_repository_set_workdir)}` are not yet implemented");
        }
        
        [Test]
        public void Test_git_repository_is_bare()
        {
            git_repository_open(out var repo, RootPathOfThisRepository);
            Assert.False(git_repository_is_bare(repo));
            git_repository_free(repo);
        }
        
        [Test]
        public void Test_git_repository_is_worktree()
        {
            git_repository_open(out var repo, RootPathOfThisRepository);
            Assert.False(git_repository_is_worktree(repo));
            git_repository_free(repo);
        }
        
        [Test]
        public void Test_git_repository_config()
        {
            Assert.Fail($"Tests for method `{nameof(git_repository_config)}` are not yet implemented");
        }
        
        [Test]
        public void Test_git_repository_config_snapshot()
        {
            Assert.Fail($"Tests for method `{nameof(git_repository_config_snapshot)}` are not yet implemented");
        }
        
        [Test]
        public void Test_git_repository_odb()
        {
            Assert.Fail($"Tests for method `{nameof(git_repository_odb)}` are not yet implemented");
        }
        
        [Test]
        public void Test_git_repository_refdb()
        {
            Assert.Fail($"Tests for method `{nameof(git_repository_refdb)}` are not yet implemented");
        }
        
        [Test]
        public void Test_git_repository_index()
        {
            Assert.Fail($"Tests for method `{nameof(git_repository_index)}` are not yet implemented");
        }
        
        [Test]
        public void Test_git_repository_message()
        {
            Assert.Fail($"Tests for method `{nameof(git_repository_message)}` are not yet implemented");
        }
        
        [Test]
        public void Test_git_repository_message_remove()
        {
            Assert.Fail($"Tests for method `{nameof(git_repository_message_remove)}` are not yet implemented");
        }
        
        [Test]
        public void Test_git_repository_state_cleanup()
        {
            Assert.Fail($"Tests for method `{nameof(git_repository_state_cleanup)}` are not yet implemented");
        }
        
        [Test]
        public void Test_git_repository_fetchhead_foreach()
        {
            Assert.Fail($"Tests for method `{nameof(git_repository_fetchhead_foreach)}` are not yet implemented");
        }
        
        [Test]
        public void Test_git_repository_mergehead_foreach()
        {
            Assert.Fail($"Tests for method `{nameof(git_repository_mergehead_foreach)}` are not yet implemented");
        }
        
        [Test]
        public void Test_git_repository_hashfile()
        {
            Assert.Fail($"Tests for method `{nameof(git_repository_hashfile)}` are not yet implemented");
        }
        
        [Test]
        public void Test_git_repository_set_head()
        {
            Assert.Fail($"Tests for method `{nameof(git_repository_set_head)}` are not yet implemented");
        }
        
        [Test]
        public void Test_git_repository_set_head_detached()
        {
            Assert.Fail($"Tests for method `{nameof(git_repository_set_head_detached)}` are not yet implemented");
        }
        
        [Test]
        public void Test_git_repository_set_head_detached_from_annotated()
        {
            Assert.Fail($"Tests for method `{nameof(git_repository_set_head_detached_from_annotated)}` are not yet implemented");
        }
        
        [Test]
        public void Test_git_repository_detach_head()
        {
            Assert.Fail($"Tests for method `{nameof(git_repository_detach_head)}` are not yet implemented");
        }
        
        [Test]
        public void Test_git_repository_state()
        {
            Assert.Fail($"Tests for method `{nameof(git_repository_state)}` are not yet implemented");
        }
        
        [Test]
        public void Test_git_repository_set_namespace()
        {
            Assert.Fail($"Tests for method `{nameof(git_repository_set_namespace)}` are not yet implemented");
        }
        
        [Test]
        public void Test_git_repository_get_namespace()
        {
            Assert.Fail($"Tests for method `{nameof(git_repository_get_namespace)}` are not yet implemented");
        }
        
        [Test]
        public void Test_git_repository_is_shallow()
        {
            git_repository_open(out var repo, RootPathOfThisRepository);
            Assert.False(git_repository_is_shallow(repo));
            git_repository_free(repo);
        }
        
        [Test]
        public void Test_git_repository_ident()
        {
            Assert.Fail($"Tests for method `{nameof(git_repository_ident)}` are not yet implemented");
        }
        
        [Test]
        public void Test_git_repository_set_ident()
        {
            Assert.Fail($"Tests for method `{nameof(git_repository_set_ident)}` are not yet implemented");
        }
    }
}
