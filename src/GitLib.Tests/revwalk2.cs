using System;
using NUnit.Framework;

namespace GitLib.Tests
{
    using static libgit2;
    
    public partial class RevwalkTests : GitLibTestsBase
    {
        [Test]
        public void Test_git_revwalk()
        {
            git_repository_open_ext(out var repo, Environment.CurrentDirectory, 0, "");
            
            git_repository_head(out var git_ref, repo);

            git_revwalk_new(out var revwalk, repo);
            git_revwalk_sorting(revwalk, GIT_SORT_TIME | GIT_SORT_REVERSE);
            git_revwalk_push_head(revwalk);
            Assert.False(git_revwalk_next(out var oid, revwalk));
            Assert.AreEqual("738a51529589efba8909d3ed3ffa980227443a62", oid.ToString());
            
            git_repository_free(repo);
        }
    }
}