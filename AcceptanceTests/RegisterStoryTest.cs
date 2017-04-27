using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AcceptanceTests
{
    [TestClass]
    public class RegisterStoryTest : GameSystemTest
    {
       
        [TestMethod]
        public void TestTheGood()
        {
            Assert.IsTrue(Register("Doron123", "009password", "user@gmail.com"));
            Assert.IsTrue(Register("Yossi", "password", "yossi@post.bgu.ac.il"));
            Assert.IsTrue(Register("michaEl", "PaSsWord", "MichaEL987@gmail.com"));
            //deleteUser("Doron_123");
            //deleteUser("Yossi");
            //deleteUser("michaEl");
            
        }

        [TestMethod]
        public void TestTheBad()
        {
            Assert.IsFalse(Register("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb",
                "ccccccccccccccccccccccccccccccccccccccccccccccc"));
            Register("Doron", "pass", "user@gmail.com");
            Assert.IsFalse(Register("Doron", "pass123", "name@gmail.com"));
            //deleteUser("Doron");
            Assert.IsFalse(Register("", "password", "email@gmail.com"));
            Assert.IsFalse(Register("user", "", "email@gmail.com"));
            Assert.IsFalse(Register("user", "password", ""));
            Assert.IsFalse(Register("user", "pass", "blahblah"));

        }

        [TestMethod]
        public void TestTheSad()
        {
            Assert.IsFalse(Register("user,name", "password", "user@gmail.com"));
            Assert.IsFalse(Register("user name", "password", "user@gmail.com"));
            Assert.IsFalse(Register("user:name", "password", "user@gmail.com"));
            Assert.IsFalse(Register("user;name", "password", "user@gmail.com"));
            Assert.IsFalse(Register("user_name", "password", "user@gmail.com"));
        }
    }
}
