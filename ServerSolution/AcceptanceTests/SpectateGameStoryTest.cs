using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AcceptanceTests
{
    [TestClass]
    public class SpectateGameStoryTest : GameSystemTest
    {

        private int game1;
        private int game2;
        private int player2;
        private int player3;
        private int player4;
        private int player5;

        [TestInitialize]
        public void SetUp()
        {
            Assert.IsTrue(Register("doron", "password1", "doron@gmail.com"));
            Assert.IsTrue(Register("tamir", "password2", "tamir@gmail.com"));
            Assert.IsTrue(Register("shavit", "password3", "shavit@gmail.com"));
            Assert.IsTrue(Register("leon", "password4", "leon@gmail.com"));
            Assert.IsTrue(Register("avner", "password5", "avner@gmail.com"));
            Assert.IsTrue(Register("someone", "password6", "someone@gmail.com"));
            string username = "doron";

            List<KeyValuePair<string, int>> preferenceList = new List<KeyValuePair<string, int>>
            {
                new KeyValuePair<string, int>("gameType", 0),
                new KeyValuePair<string, int>("buyIn", 10),
                new KeyValuePair<string, int>("chipPolicy", 0),
                new KeyValuePair<string, int>("minBet", 5),
                new KeyValuePair<string, int>("minPlayers", 2),
                new KeyValuePair<string, int>("maxPlayers", 5),
            };
            game1 = CreateGame(username, preferenceList);
            game2 = CreateGame(username, preferenceList);
            Assert.IsTrue(game1 > 0);
            Assert.IsTrue(game2 > 0);
            Assert.AreNotEqual(game1, game2);


            player2 = JoinGame("tamir", game1);
            Assert.IsTrue(player2 > 0);
            player3 = JoinGame("avner", game1);
            Assert.IsTrue(player3 > 0);
            player4 = JoinGame("leon", game1);
            Assert.IsTrue(player4 > 0);
            player5 = JoinGame("shavit", game1);
            Assert.IsTrue(player5 > 0);
            int player7 = JoinGame("tamir", game2);
            Assert.IsTrue(player7 > 0);
            int player8 = JoinGame("avner", game2);
            Assert.IsTrue(player8 > 0);
            int player9 = JoinGame("leon", game2);
            Assert.IsTrue(player9 > 0);
            int player10 = JoinGame("shavit", game2);
            Assert.IsTrue(player10 > 0);
        }

        [TestMethod]
        public void SpectateGood()
        {
            Assert.IsTrue(ViewSpectatableGames());
            Assert.IsTrue(SpectateGame("someone", game1) > 0); 
            Assert.IsTrue(SpectateGame("someone", game2) > 0);
        }

        [TestMethod]
        public void SpectateBad()
        {
            Assert.IsTrue(ViewSpectatableGames());
            //int game = CreateGame("doron", 1, 50, 100, 5, 2, 5,
           //     true);
          //  Assert.IsTrue(SpectateGame("doron", game) > 0);
          //  Assert.IsFalse(SpectateGame("doron", game) > 0);
        }

        [TestMethod]
        public void SpectateSad()
        {
            //end game1 and game2
           // int game = CreateGame("doron", 1, 50, 100, 5, 2, 5,
          //      false);
//            Assert.IsFalse(ViewSpectatableGames());
            //Assert.IsFalse(SpectateGame("doron", game) > 0);
        }

        [TestCleanup]
        public void TearDown()
        {
            Assert.IsTrue(DeleteAccount("doron"));
            Assert.IsTrue(DeleteAccount("shavit"));
            Assert.IsTrue(DeleteAccount("tamir"));
            Assert.IsTrue(DeleteAccount("leon"));
            Assert.IsTrue(DeleteAccount("avner"));
            Assert.IsTrue(DeleteAccount("someone"));
        }
    }
}
