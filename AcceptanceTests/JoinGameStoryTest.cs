using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AcceptanceTests
{
    [TestClass]
    public class JoinGameStoryTest : GameSystemTest
    {
        [TestMethod]
        public void TestTheGood()
        {
            Assert.IsTrue(Register("doron", "password", "doron@gmail.com"));
            string username = "doron";
            int gameTypePolicy = 0;
            int buyInPolicy = 0;
            int chipPolicy = 100;
            int minBet = 5;
            int minPlayerCount = 2;
            int maxPlayerCount = 5;
            bool isSpectatable = true;
            int game = CreateGame(username, gameTypePolicy, buyInPolicy, chipPolicy, minBet, minPlayerCount, maxPlayerCount,
                isSpectatable);
            Assert.IsTrue(game > 0);

            int playerID = JoinGame(username, game);
        }

        [TestMethod]
        public void TestTheBad()
        {

        }

        [TestMethod]
        public void TestTheSad()
        {

        }
    }
}
