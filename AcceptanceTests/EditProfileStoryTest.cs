using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AcceptanceTests
{
    [TestClass]
    public class EditProfileStoryTest : GameSystemTest
    {
        [TestMethod]
        public void TestTheGood()
        {
            Assert.IsTrue(Register("Doron123", "009password", "user@gmail.com"));
            Assert.IsTrue(EditProfile("Doron123", "password", "yossi@post.bgu.ac.il"));
            Assert.IsTrue(EditProfile("Doron123", "bldnsaldasl544324", "yossi@post.bgu.ac.il"));
            Assert.IsTrue(EditProfile("Doron123", "009password", "user@gmail.com"));
            //deleteUser("Doron123");

        }

        [TestMethod]
        public void TestTheBad()
        {
            Assert.IsTrue(Register("Doron123", "009password", "user@gmail.com"));
            Assert.IsFalse(EditProfile("Doron", "009password", "user@gmail.com"));
            Assert.IsTrue(EditProfile("Doron123", "bldnsaldasl544324", "yossi@post.bgu.ac.il"));
            Assert.IsTrue(EditProfile("Doron123", "009password", "user@gmail.com"));


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
