using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AcceptanceTests
{
    [TestClass]
    public class EditProfileStoryTest : GameSystemTest
    {
        [TestMethod]
        public void EditProfileGood()
        {
            Assert.IsTrue(Register("Doron123", "009password", "user@gmail.com"));
            Assert.IsTrue(EditProfile("Doron123", "password", "yossi@post.bgu.ac.il"));
            Assert.IsTrue(EditProfile("Doron123", "bldnsaldasl544324", "yossi@post.bgu.ac.il"));
            Assert.IsTrue(EditProfile("Doron123", "009password", "user@gmail.com"));
            //deleteUser("Doron123");

        }

        [TestMethod]
        public void EditProfileBad()
        {
            Assert.IsTrue(Register("user", "pass", "user@gmail.com"));
            Assert.IsFalse(EditProfile("user", "", "name@gmail.com"));
            Assert.IsFalse(EditProfile("user", "password", ""));
            Assert.IsFalse(EditProfile("user", "pass", "blahblah"));
            //deleteUser("Doron");
        }

        [TestMethod]
        public void EditProfileSad()
        {
            Assert.IsTrue(Register("Doron123", "009password", "user@gmail.com"));
            Assert.IsFalse(EditProfile("Doron", "pass", "user@gmail.com"));
            Assert.IsTrue(EditProfile("Doron123", "bldnsaldasl544324", "yossi@post.bgu.ac.il"));
            //deleteUser("Doron");
        }
    }
}
