using System;

using System.IO;

using NUnit.Framework;

namespace LibGit2.Tests
{
    using static libgit2;
    
    public partial class ErrorsTests
    {
        [Test]
        public void Test_git_error_last()
        {
            Assert.Fail($"Tests for method `{nameof(git_error_last)}` are not yet implemented");
        }
        
        [Test]
        public void Test_git_error_clear()
        {
            Assert.Fail($"Tests for method `{nameof(git_error_clear)}` are not yet implemented");
        }
        
        [Test]
        public void Test_git_error_set_str()
        {
            Assert.Fail($"Tests for method `{nameof(git_error_set_str)}` are not yet implemented");
        }
        
        [Test]
        public void Test_git_error_set_oom()
        {
            Assert.Fail($"Tests for method `{nameof(git_error_set_oom)}` are not yet implemented");
        }
    }
}
