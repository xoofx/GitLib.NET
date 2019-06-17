using System;

using System.IO;

using NUnit.Framework;

namespace GitLib.Tests
{
    using static libgit2;
    
    public partial class DeprecatedTests
    {
        [Test]
        public void Test_git_buf_free()
        {
            Assert.Fail($"Tests for method `{nameof(git_buf_free)}` are not yet implemented");
        }
        
        [Test]
        public void Test_giterr_last()
        {
            Assert.Fail($"Tests for method `{nameof(giterr_last)}` are not yet implemented");
        }
        
        [Test]
        public void Test_giterr_clear()
        {
            Assert.Fail($"Tests for method `{nameof(giterr_clear)}` are not yet implemented");
        }
        
        [Test]
        public void Test_giterr_set_str()
        {
            Assert.Fail($"Tests for method `{nameof(giterr_set_str)}` are not yet implemented");
        }
        
        [Test]
        public void Test_giterr_set_oom()
        {
            Assert.Fail($"Tests for method `{nameof(giterr_set_oom)}` are not yet implemented");
        }
    }
}
