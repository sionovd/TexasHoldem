using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AcceptanceTests
{
    [TestClass]
    public class SearchActiveGamesStoryTest : GameSystemTest
    {
        private int game1;
        private int player1;
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
            int gameTypePolicy = 1;
            int buyInPolicy = 0;
            int chipPolicy = 100; // played with chips
            int minBet = 5;
            int minPlayerCount = 2;
            int maxPlayerCount = 5;
            bool isSpectatable = true;
            game1 = CreateGame("doron", gameTypePolicy, buyInPolicy, chipPolicy, minBet, minPlayerCount, maxPlayerCount,
                isSpectatable);
            Assert.IsTrue(game1 > 0);
            player2 = JoinGame("tamir", game1);
            Assert.IsTrue(player2 > 0);
            player3 = JoinGame("avner", game1);
            Assert.IsTrue(player3 > 0);
            player4 = JoinGame("leon", game1);
            Assert.IsTrue(player4 > 0);
            player5 = JoinGame("shavit", game1);
            Assert.IsTrue(player5 > 0);
            Assert.IsTrue(Bet(player1, game1, 25));
            Assert.IsTrue(Call(player2, game1));
            Assert.IsTrue(Call(player3, game1));
            Assert.IsTrue(Call(player4, game1));
            Assert.IsTrue(Fold(player5, game1));

        }

        [TestMethod]
        public void TestSearchGood()
        {
            Assert.IsTrue(SearchAciveGamesByPot(100));
            Assert.IsTrue(SearchActiveGamesByPlayerName("doron"));
            Assert.IsTrue(SearchActiveGamesByPlayerName("tamir"));
            Assert.IsTrue(SearchActiveGamesByPreferences(1, 0, 100, 5, 2, 5, 1));
        }

        [TestMethod]
        public void TestSearchBad()
        {
            Assert.IsFalse(SearchAciveGamesByPot(-500));
            Assert.IsFalse(SearchActiveGamesByPreferences(10, 10, 10, 10, 10, 10, 10));
        }

        [TestMethod]
        public void TestSearchSad()
        {
            Assert.IsFalse(SearchAciveGamesByPot(200));
            Assert.IsFalse(SearchActiveGamesByPlayerName("nobody"));
        }

        [TestCleanup]
        public void TearDown()
        {
            // finish game
        }
    }
}
