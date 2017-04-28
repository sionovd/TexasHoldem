using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AcceptanceTests
{
    [TestClass]
    public class BetStoryTest : GameSystemTest
    {
        private int game;
        private string username;
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
            username = "doron";
            int gameTypePolicy = 1;
            int buyInPolicy = 0;
            int chipPolicy = 100;
            int minBet = 5;
            int minPlayerCount = 2;
            int maxPlayerCount = 5;
            bool isSpectatable = true;
            game = CreateGame(username, gameTypePolicy, buyInPolicy, chipPolicy, minBet, minPlayerCount, maxPlayerCount,
                isSpectatable);
            Assert.IsTrue(game > 0);
            player1 = JoinGame("doron", game);
            Assert.IsTrue(player1 > 0);
            player2 = JoinGame("tamir", game);
            Assert.IsTrue(player2 > 0);
            player3 = JoinGame("avner", game);
            Assert.IsTrue(player3 > 0);
            player4 = JoinGame("leon", game);
            Assert.IsTrue(player4 > 0);
            player5 = JoinGame("shavit", game);
            Assert.IsTrue(player5 > 0);
        }

        [TestMethod]
        public void TestTheGood()
        {
            Assert.IsTrue(Bet(player1, game, 50));
            Assert.IsTrue(Bet(player2, game, 50));
            Assert.IsTrue(Bet(player3, game, 75));
            Assert.IsTrue(Bet(player4, game, 80));
            Assert.IsTrue(Bet(player5, game, 100));

        }

        [TestCleanup]
        public void TearDown()
        {
            //deleteUsers...
        }

    }
}
