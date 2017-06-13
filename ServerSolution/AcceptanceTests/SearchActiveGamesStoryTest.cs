using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AcceptanceTests
{
    [TestClass]
    public class SearchActiveGamesStoryTest : GameSystemTest
    {
        private int game1;
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

            List<KeyValuePair<string, int>> preferenceList = new List<KeyValuePair<string, int>>
            {
                new KeyValuePair<string, int>("gameType", 1),
                new KeyValuePair<string, int>("buyIn", 0),
                new KeyValuePair<string, int>("chipPolicy", 100),
                new KeyValuePair<string, int>("minBet", 10),
                new KeyValuePair<string, int>("minPlayers", 2),
                new KeyValuePair<string, int>("maxPlayers", 5),
            };
            game1 = CreateGame("doron", preferenceList);

            Assert.IsTrue(game1 > 0);
            player2 = JoinGame("tamir", game1);
            Assert.IsTrue(player2 > 0);
            player3 = JoinGame("avner", game1);
            Assert.IsTrue(player3 > 0);
            player4 = JoinGame("leon", game1);
            Assert.IsTrue(player4 > 0);
            player5 = JoinGame("shavit", game1);
            Assert.IsTrue(player5 > 0);

            Assert.IsTrue(StartGame("doron", game1));
            Assert.IsTrue(StartGame("tamir", game1));
            Assert.IsTrue(StartGame("shavit", game1));
            Assert.IsTrue(StartGame("leon", game1));
            Assert.IsTrue(StartGame("avner", game1));

            // Assert.IsTrue(Bet(player1, game1, 25));
            //   Assert.IsTrue(Call(player2, game1));
            Assert.IsTrue(Call(player3, game1));
            Assert.IsTrue(Call(player4, game1));
            Assert.IsTrue(Fold(player5, game1));

        }

        [TestMethod]
        public void SearchGood()
        {
          //  Assert.IsTrue(SearchAciveGamesByPot(100));
            Assert.IsTrue(SearchActiveGamesByPlayerName("doron"));
            Assert.IsTrue(SearchActiveGamesByPlayerName("tamir"));
            Assert.IsTrue(SearchActiveGamesByPreferences(1, 0, 100, 10, 2, 5, 1));
        }

        [TestMethod]
        public void SearchBad()
        {
            Assert.IsFalse(SearchAciveGamesByPot(-500));
            Assert.IsFalse(SearchActiveGamesByPreferences(10, 10, 10, 10, 10, 10, 10));
        }

        [TestMethod]
        public void SearchSad()
        {
            Assert.IsFalse(SearchAciveGamesByPot(200));
            Assert.IsFalse(SearchActiveGamesByPlayerName("nobody"));
        }

        [TestCleanup]
        public void TearDown()
        {
            Assert.IsTrue(DeleteAccount("doron"));
            Assert.IsTrue(DeleteAccount("shavit"));
            Assert.IsTrue(DeleteAccount("tamir"));
            Assert.IsTrue(DeleteAccount("leon"));
            Assert.IsTrue(DeleteAccount("avner"));
        }
    }
}
