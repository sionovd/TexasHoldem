using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AcceptanceTests
{
    [TestClass]
    public class ReplayGameStoryTest : GameSystemTest
    {
        [TestMethod]
        public void ReplayGood()
        {
            Assert.IsTrue(ReplayGame("doron", 1));
            Assert.IsTrue(ReplayGame("doron", 2));
            Assert.IsTrue(ReplayGame("tamir", 2));
            Assert.IsTrue(ReplayGame("tamir", 3));
        }

        [TestMethod]
        public void ReplayBad()
        {
            Assert.IsTrue(ReplayGame("doron", -1));
            Assert.IsTrue(ReplayGame("fakeuser", 1));
        }
    }
}
