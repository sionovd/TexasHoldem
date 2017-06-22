using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersistenceLayer;

namespace UnitTestProject1
{
    [TestClass]
    public class DBTests
    {
        private DBHelper db;

        [TestInitialize]
        public void BeforeTest()
        {
            db = new DBHelper();
            db.AddUser("admin", "1234", "afsaf@afsasaf.com", 100, 2);
            db.AddUser("hello", "111", "afsafsaf@afsasaf.com", 23, 2);
            db.AddUser("world", "333", "afs2314af@afsasaf.com", 2222, 2);
        }

        [TestMethod]
        public void getHelloUser()
        {
            UserEntity user = db.GetUser("hello");
            Assert.IsTrue(user.Money == 23);
        }
        [TestMethod]
        public void getAllUsers()
        {
            List<UserEntity> users = db.GetRegisteredUsers();
            Assert.IsTrue(users.Count == 3);
        }
        [TestMethod]
        public void addUser()
        {
            List<UserEntity> users = db.GetRegisteredUsers();
            Assert.IsTrue(users.Count == 3);
            db.AddUser("newUser", "fsafsa", "Fafs", 221, 3);
            users = db.GetRegisteredUsers();
            Assert.IsTrue(users.Count == 4);
            Assert.IsTrue(db.DeleteUser("newUser"));
        }
        [TestMethod]
        public void editUser()
        {
            UserEntity user = db.GetUser("hello");
            Assert.IsTrue(user.Money == 23);
            db.EditUser(user.Username, user.Password, user.Email, user.Money + 5);
            user = db.GetUser("hello");
            Assert.IsTrue(user.Money - 5 == 23);
        }
        [TestMethod]
        public void updateUserLeague()
        {
            UserEntity user = db.GetUser("hello");
            Assert.IsTrue(user.LeagueId == 2);
            db.UpdateUserLeague(user.Username, user.LeagueId + 1);
            user = db.GetUser("hello");
            Assert.IsTrue(user.LeagueId == 3);
        }

        [TestCleanup]
        public void TearDown()
        {
            db.DeleteUser("admin");
            db.DeleteUser("hello");
            db.DeleteUser("world");
        }
        
        
    }
}
