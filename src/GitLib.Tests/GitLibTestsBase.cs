using System;
using System.IO;
using NUnit.Framework;

namespace GitLib.Tests
{
    using static libgit2;
    
    [TestFixture]
    public abstract class GitLibTestsBase
    {
        public static readonly string RootPathOfThisRepository = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "..", "..", "..", "..", ".."));


        protected GitLibTestsBase(string category)
        {
            Category = category;
        }
        
        public string Category { get; }
       
        [OneTimeSetUp]
        public void Init()
        {
            git_libgit2_init();

            var checkFolder = Path.Combine(RootPathOfThisRepository, "src", "GitLib");
            if (!Directory.Exists(checkFolder))
            {
                Assert.Fail($"The root folder `{RootPathOfThisRepository}` is invalid. Are you really running the tests from the binary folder?");
            }
        }

        protected string GetOrCreateTestFolder()
        {
            var baseFolder = Path.GetDirectoryName(typeof(GitLibTestsBase).Assembly.Location);
            var testName = TestContext.CurrentContext.Test.Name;
            const string testNamePrefix = "Test_";
            if (testName.StartsWith(testNamePrefix))
            {
                testName = testName.Substring(testNamePrefix.Length);
            }
            var testFolder = Path.Combine(baseFolder, "tests", Category, testName);
            if (Directory.Exists(testFolder))
            {
                try
                {
                    Directory.Delete(testFolder, true);
                }
                catch
                {
                    // ignored
                }
            }
            Directory.CreateDirectory(testFolder);

            return testFolder;
        }

        [OneTimeTearDown]
        public void Shutdown()
        {
            git_libgit2_shutdown();
        }
    }
}