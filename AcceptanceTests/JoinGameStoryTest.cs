using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AcceptanceTests
{
    [TestClass]
    public class JoinGameStoryTest : GameSystemTest
    {
        private int game1;
        private int game2;

        [ClassInitialize]
        public void SetUp()
        {
            Assert.IsTrue(Register("doron", "password1", "doron@gmail.com"));
            Assert.IsTrue(Register("tamir", "password2", "tamir@gmail.com"));
            Assert.IsTrue(Register("shavit", "password3", "shavit@gmail.com"));
            Assert.IsTrue(Register("leon", "password4", "leon@gmail.com"));
            Assert.IsTrue(Register("avner", "password5", "avner@gmail.com"));
            Assert.IsTrue(Register("someone", "password6", "someone@gmail.com"));
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
        public void TestTheGood()
        {
            int player1 = JoinGame("doron", game1);
            Assert.IsTrue(player1 > 0);
            int player2 = JoinGame("tamir", game1);
            Assert.IsTrue(player2 > 0);
            int player3 = JoinGame("avner", game1);
            Assert.IsTrue(player3 > 0);
            int player4 = JoinGame("leon", game1);
            Assert.IsTrue(player4 > 0);
            int player5 = JoinGame("shavit", game1);
            Assert.IsTrue(player5 > 0);
            int player6 = JoinGame("doron", game2);
            Assert.IsTrue(player6 > 0);
            int player7 = JoinGame("tamir", game2);
            Assert.IsTrue(player7 > 0);
            int player8 = JoinGame("avner", game2);
            Assert.IsTrue(player8 > 0);
            int player9 = JoinGame("leon", game2);
            Assert.IsTrue(player9 > 0);
            int player10 = JoinGame("shavit", game2);
            Assert.IsTrue(player10 > 0);
            Assert.AreNotEqual(player1, player6);
            Assert.AreNotEqual(player2, player7);
            Assert.AreNotEqual(player3, player8);
            Assert.AreNotEqual(player4, player9);
            Assert.AreNotEqual(player5, player10);
            Assert.IsFalse(JoinGame("someone", game2) > 0);
        }

        [TestMethod]
        public void TestTheBad()
        {
            
        }

        [TestMethod]
        public void TestTheSad()
        {

        }

        [ClassCleanup]
        public void TearDown()
        {
            //deleteUsers....
        }
    }
}
