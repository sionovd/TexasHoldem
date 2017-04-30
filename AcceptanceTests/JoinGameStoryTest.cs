using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AcceptanceTests
{
    [TestClass]
    public class JoinGameStoryTest : GameSystemTest
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
            Assert.IsTrue(RegisterWithMoney("someone", "password6", "someone@gmail.com", 5));
            string username = "doron";
            int gameTypePolicy = 0;
            int buyInPolicy = 5;
            int chipPolicy = 100;
            int minBet = 5;
            int minPlayerCount = 2;
            int maxPlayerCount = 5;
            bool isSpectatable = true;
            game1 = CreateGame(username, gameTypePolicy, buyInPolicy, chipPolicy, minBet, minPlayerCount, maxPlayerCount,
                isSpectatable);
            game2 = CreateGame(username, gameTypePolicy, 200, chipPolicy, minBet, minPlayerCount, maxPlayerCount,
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

            Assert.IsTrue(LeaveGame("doron", game1));
            Assert.IsTrue(LeaveGame("doron", game2));
            Assert.IsTrue(LeaveGame("tamir", game1));
            Assert.IsTrue(LeaveGame("avner", game1));
            Assert.IsTrue(LeaveGame("shavit", game1));
            Assert.IsTrue(LeaveGame("leon", game1));
            Assert.IsTrue(LeaveGame("tamir", game2));
            Assert.IsTrue(LeaveGame("avner", game2));
            Assert.IsTrue(LeaveGame("shavit", game2));
            Assert.IsTrue(LeaveGame("leon", game2));
        }

        [TestMethod]
        public void TestTheSad()
        {
            int player1 = JoinGame("someone", game1);
            Assert.IsFalse(player1 > 0);
            Assert.IsTrue(ViewMoneyBalanceOfUser("someone") > 0);
        }

        [ClassCleanup]
        public void TearDown()
        {
            //deleteUsers....
        }
    }
}
