using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AcceptanceTests
{
    [TestClass]
    public class LoginLogoutStoryTest : GameSystemTest
    {
        [TestMethod]
        public void LoginLogoutGood()
        {
            Assert.IsTrue(Register("doron", "password", "doron@email.com"));
            Assert.IsTrue(Login("doron", "password"));
            Assert.IsTrue(Register("yossi", "pass2", "yossi@gmail.com"));
            Assert.IsTrue(Login("yossi", "pass2"));
            Assert.IsTrue(Logout("yossi"));
            Assert.IsTrue(Logout("doron"));
            Assert.IsTrue(DeleteAccount("doron"));
            Assert.IsTrue(DeleteAccount("yossi"));
        }

        [TestMethod]
        public void LoginLogoutBad()
        {
            Assert.IsFalse(Login("nonexistinguser", "password"));
            Assert.IsFalse(Login("innocentuser", "wrongpassword"));
            Assert.IsFalse(Logout("nonexistinguser"));
        }

        [TestMethod]
        public void LoginLogoutSad()
        {
            Assert.IsTrue(Register("doron", "password", "doron@gmail.com"));
            Assert.IsFalse(Login("doron", "wrongpassword"));
            Assert.IsFalse(Login("doron", "Password"));
            Assert.IsFalse(Logout("doron"));
            Assert.IsTrue(DeleteAccount("doron"));
        }
    }
}
