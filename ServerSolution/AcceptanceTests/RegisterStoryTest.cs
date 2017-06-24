using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AcceptanceTests
{
    [TestClass]
    public class RegisterStoryTest : GameSystemTest
    {
       
        [TestMethod]
        public void RegisterGood()
        {
            Assert.IsTrue(Register("Doron123", "009password", "user@gmail.com"));
            Assert.IsTrue(Register("Yossi", "password", "yossi@post.bgu.ac.il"));
            Assert.IsTrue(Register("michaEl", "PaSsWord", "MichaEL987@gmail.com"));
            Assert.IsTrue(DeleteAccount("Doron123"));
            Assert.IsTrue(DeleteAccount("Yossi"));
            Assert.IsTrue(DeleteAccount("michaEl"));
        }

        [TestMethod]
        public void RegisterBad()
        {
            Assert.IsTrue(Register("Doron", "pass", "user@gmail.com"));
            Assert.IsFalse(Register("Doron", "pass123", "name@gmail.com"));
            Assert.IsTrue(DeleteAccount("Doron"));
            Assert.IsFalse(Register("", "password", "email@gmail.com"));
            Assert.IsFalse(Register("user", "", "email@gmail.com"));
            Assert.IsFalse(Register("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb",
                "ccccccccccccccccccccccccccccccccccccccccccccccc"));
        }

        [TestMethod]
        public void RegisterSad()
        {
            Assert.IsFalse(Register("user,name", "password", "user@gmail.com"));
            Assert.IsFalse(Register("user name", "password", "user@gmail.com"));
            Assert.IsFalse(Register("user:name", "password", "user@gmail.com"));
            Assert.IsFalse(Register("user;name", "password", "user@gmail.com"));
            Assert.IsFalse(Register("user_name", "password", "user@gmail.com"));
        }
    }
}
