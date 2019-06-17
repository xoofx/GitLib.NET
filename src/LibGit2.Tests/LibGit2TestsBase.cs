using System;
using System.IO;
using NUnit.Framework;

namespace LibGit2.Tests
{
    using static libgit2;
    
    [TestFixture]
    public abstract class LibGit2TestsBase
    {
        public static readonly string RootPathOfThisRepository = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "..", "..", "..", "..", ".."));
       
        [OneTimeSetUp]
        public void Init()
        {
            git_libgit2_init();

            var checkFolder = Path.Combine(RootPathOfThisRepository, "src", "LibGit2");
            if (!Directory.Exists(checkFolder))
            {
                Assert.Fail($"The root folder `{RootPathOfThisRepository}` is invalid. Are you really running the tests from the binary folder?");
            }
        }

        [OneTimeTearDown]
        public void Shutdown()
        {
            git_libgit2_shutdown();
        }
    }
}