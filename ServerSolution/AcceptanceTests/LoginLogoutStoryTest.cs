﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AcceptanceTests
{
    [TestClass]
    public class LoginLogoutStoryTest : GameSystemTest
    {
        [TestMethod]
        public void TestTheGood()
        {
            Assert.IsTrue(Register("doron", "password", "doron@email.com"));
            Assert.IsTrue(Login("doron", "password"));
            Assert.IsTrue(Register("yossi", "pass2", "yossi@gmail.com"));
            Assert.IsTrue(Login("yossi", "pass2"));
            Assert.IsTrue(Logout("yossi"));
            Assert.IsTrue(Logout("doron"));
            //deleteUser("doron");
            //deleteUser("yossi");
        }

        [TestMethod]
        public void TestTheBad()
        {
            Assert.IsFalse(Login("nonexistinguser", "password"));
            Assert.IsFalse(Login("innocentuser", "wrongpassword"));
            Assert.IsFalse(Logout("nonexistinguser"));
        }

        [TestMethod]
        public void TestTheSad()
        {
            Assert.IsTrue(Register("doron1", "password", "doron@gmail.com"));
            Assert.IsFalse(Login("doron1", "wrongpassword"));
            Assert.IsFalse(Login("doron1", "Password"));
            Assert.IsFalse(Logout("doron1"));
            //deleteUser("doron");
        }
    }
}