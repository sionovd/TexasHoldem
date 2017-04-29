using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AcceptanceTests
{
    [TestClass]
    public class SearchActiveGamesStoryTest : GameSystemTest
    {
        private int game1;
        private int game2;

        [TestInitialize]
        public void SetUp()
        {
            Assert.IsTrue(RegisterWithMoney("doron", "password1", "doron@gmail.com", 100));
            Assert.IsTrue(RegisterWithMoney("tamir", "password2", "tamir@gmail.com", 100));
            Assert.IsTrue(RegisterWithMoney("shavit", "password3", "shavit@gmail.com", 100));
            Assert.IsTrue(RegisterWithMoney("leon", "password4", "leon@gmail.com", 100));
            Assert.IsTrue(RegisterWithMoney("avner", "password5", "avner@gmail.com", 100));
            Assert.IsTrue(RegisterWithMoney("someone", "password6", "someone@gmail.com", 100));
            string username = "doron";
            int gameTypePolicy = 0;
            int buyInPolicy = 0;
            int chipPolicy = 100;
            int minBet = 5;
            int minPlayerCount = 2;
            int maxPlayerCount = 5;
            bool isSpectatable = true;
            game1 = CreateGame(username, gameTypePolicy, buyInPolicy, chipPolicy, minBet, minPlayerCount, maxPlayerCount,
                isSpectatable);
            game2 = CreateGame(username, gameTypePolicy, buyInPolicy, chipPolicy, minBet, minPlayerCount, maxPlayerCount,
                isSpectatable);
            Assert.IsTrue(game1 > 0);
            Assert.IsTrue(game2 > 0);
            Assert.AreNotEqual(game1, game2);
        }

        [TestMethod]
        public void TestSearchByPotSize()
        {
            Assert.IsTrue(SearchAciveGamesByPot(100));
            Assert.IsFalse(SearchAciveGamesByPot(100));
        }

    }
}
