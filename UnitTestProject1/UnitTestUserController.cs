﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TexasHoldem;
using TexasHoldem.UserModule;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTestUserController
    {
        UserController uc = new UserController();

        [TestMethod]
        public void RegisterTest1()
        {
            Assert.IsNotNull(uc.Register("David", "soda", "david4325@gmail.com"));
        }

        [TestMethod]
        [ExpectedException(typeof(AlreadyHasNameException))]
        public void RegisterTest2()
        {
            uc.Register("Avi", "Iva", "ai847562@gmail.com");
            uc.Register("Avi", "Iva", "ai847562@gmail.com");
        }

        [TestMethod]
        public void RegisterTest3()
        {
            uc.Register("Mair", "wow", "ska45@gmail.com");
            Assert.IsFalse(uc.GetUserByName("Mair").getAdmin());
        }

        [TestMethod]
        public void EditProfileTest1()
        {
            uc.Register("Shlom", "q2w", "loas@gmail.com");
            Assert.IsTrue(uc.EditProfile("Shlom", "q2w", "mak@walla.com"));
        }

        [TestMethod]
        [ExpectedException(typeof(NoUserNameException))]
        public void EditProfileTest2()
        {
            Assert.IsTrue(uc.EditProfile("Forman", "qw", "lop@gmail.com"));
        }

        [TestMethod]
        public void LoginTest1()
        {
            uc.Register("Tom", "beer", "Tommy@gmail.com");
            Assert.IsTrue(uc.Login("Tom", "beer"));
        }

        [TestMethod]
        [ExpectedException(typeof(NoUserNameException))]
        public void LoginTest2()
        {
            uc.Login("Bug", "1234");
        }

        [TestMethod]
        [ExpectedException(typeof(NotAPasswordException))]
        public void LoginTest3()
        {
            uc.Register("Forgetit", "4321", "for@gmail.com");
            uc.Login("Forgetit", "1234");
        }

        [TestMethod]
        public void LogoutTest1()
        {
            uc.Register("Mor", "got", "msn@gmail.com");
            uc.Login("Mor", "got");
            Assert.IsTrue(uc.Logout("Mor"));
        }

        [TestMethod]
        [ExpectedException(typeof(NoUserNameException))]
        public void LogoutTest2()
        {
            uc.Logout("Bug");
        }

        [TestMethod]
        [ExpectedException(typeof(NoUserNameException))]
        public void LogoutTest3()
        {
            uc.Register("Bug2", "1234", "bandb@gmail.com");
            uc.Logout("Bug2");
        }
    }
}
