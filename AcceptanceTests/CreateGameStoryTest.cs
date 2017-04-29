using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AcceptanceTests
{
    [TestClass]
    public class CreateGameStoryTest : GameSystemTest
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
            int game1 = CreateGame(username, gameTypePolicy, buyInPolicy, chipPolicy, minBet, minPlayerCount, maxPlayerCount,
                isSpectatable);
            Assert.IsTrue(game1 > 0);
            int game2 = CreateGame(username, gameTypePolicy, buyInPolicy, chipPolicy, minBet, minPlayerCount, maxPlayerCount,
                isSpectatable);
            Assert.IsTrue(game2 > 0);
            Assert.AreNotEqual(game1, game2);

            gameTypePolicy = 0;
            buyInPolicy = 200;
            chipPolicy = 300;
            minBet = 10;
            minPlayerCount = 4;
            maxPlayerCount = 9;
            isSpectatable = true;
            int game = CreateGame(username, gameTypePolicy, buyInPolicy, chipPolicy, minBet, minPlayerCount, maxPlayerCount,
                isSpectatable);
            Assert.IsTrue(game > 0);

            gameTypePolicy = 0;
            buyInPolicy = 200;
            chipPolicy = 0;
            minBet = 10;
            minPlayerCount = 3;
            maxPlayerCount = 6;
            isSpectatable = false;
            game = CreateGame(username, gameTypePolicy, buyInPolicy, chipPolicy, minBet, minPlayerCount, maxPlayerCount,
                isSpectatable);
            Assert.IsTrue(game > 0);

            gameTypePolicy = 1;
            buyInPolicy = 200;
            chipPolicy = 300;
            minBet = 10;
            minPlayerCount = 4;
            maxPlayerCount = 9;
            isSpectatable = true;
            game = CreateGame(username, gameTypePolicy, buyInPolicy, chipPolicy, minBet, minPlayerCount, maxPlayerCount,
                isSpectatable);
            Assert.IsTrue(game > 0);

            gameTypePolicy = 2;
            buyInPolicy = 200;
            chipPolicy = 300;
            minBet = 10;
            minPlayerCount = 4;
            maxPlayerCount = 9;
            isSpectatable = false;
            game = CreateGame(username, gameTypePolicy, buyInPolicy, chipPolicy, minBet, minPlayerCount, maxPlayerCount,
                isSpectatable);
            Assert.IsTrue(game > 0);
            
        }

        [TestMethod]
        public void TestTheBad()
        {
            Assert.IsTrue(Register("doron", "password", "doron@gmail.com"));
            string username = "doron";
            int gameTypePolicy = -1;
            int buyInPolicy = 0;
            int chipPolicy = 100;
            int minBet = 5;
            int minPlayerCount = 2;
            int maxPlayerCount = 5;
            bool isSpectatable = true;
            int game = CreateGame(username, gameTypePolicy, buyInPolicy, chipPolicy, minBet, minPlayerCount, maxPlayerCount,
                isSpectatable);
            Assert.IsTrue(game < 0);

            gameTypePolicy = 1;
            buyInPolicy = -100;
            chipPolicy = 100;
            minBet = 5;
            minPlayerCount = 2;
            maxPlayerCount = 5;
            game = CreateGame(username, gameTypePolicy, buyInPolicy, chipPolicy, minBet, minPlayerCount, maxPlayerCount,
               isSpectatable);
            Assert.IsTrue(game < 0);

            gameTypePolicy = 1;
            buyInPolicy = 100;
            chipPolicy = -100;
            minBet = 5;
            minPlayerCount = 2;
            maxPlayerCount = 5;
            game = CreateGame(username, gameTypePolicy, buyInPolicy, chipPolicy, minBet, minPlayerCount, maxPlayerCount,
                isSpectatable);
            Assert.IsTrue(game < 0);

            gameTypePolicy = 1;
            buyInPolicy = 100;
            chipPolicy = 100;
            minBet = -5;
            minPlayerCount = 2;
            maxPlayerCount = 5;
            game = CreateGame(username, gameTypePolicy, buyInPolicy, chipPolicy, minBet, minPlayerCount, maxPlayerCount,
                isSpectatable);
            Assert.IsTrue(game < 0);

            gameTypePolicy = 1;
            buyInPolicy = 100;
            chipPolicy = 100;
            minBet = 10;
            minPlayerCount = 0;
            maxPlayerCount = 2;
            game = CreateGame(username, gameTypePolicy, buyInPolicy, chipPolicy, minBet, minPlayerCount, maxPlayerCount,
                isSpectatable);
            Assert.IsTrue(game < 0);

            gameTypePolicy = 2;
            buyInPolicy = 100;
            chipPolicy = 100;
            minBet = 10;
            minPlayerCount = 1;
            maxPlayerCount = 2;
            game = CreateGame(username, gameTypePolicy, buyInPolicy, chipPolicy, minBet, minPlayerCount, maxPlayerCount,
                isSpectatable);
            Assert.IsTrue(game < 0);

            gameTypePolicy = 2;
            buyInPolicy = 100;
            chipPolicy = 100;
            minBet = 10;
            minPlayerCount = 5;
            maxPlayerCount = 2;
            game = CreateGame(username, gameTypePolicy, buyInPolicy, chipPolicy, minBet, minPlayerCount, maxPlayerCount,
                isSpectatable);
            Assert.IsTrue(game < 0);
        }

        [TestMethod]
        public void TestTheSad()
        {
            Assert.IsTrue(Register("yossi", "pass", "yos@gmail.com"));
            string username = "yos";
            int gameTypePolicy = 1;
            int buyInPolicy = 100;
            int chipPolicy = 100;
            int minBet = 0;
            int minPlayerCount = 2;
            int maxPlayerCount = 5;
            int game = CreateGame(username, gameTypePolicy, buyInPolicy, chipPolicy, minBet, minPlayerCount, maxPlayerCount,
                false);
            Assert.IsTrue(game < 0);

            gameTypePolicy = 1;
            buyInPolicy = 100;
            chipPolicy = 100;
            minBet = 5;
            minPlayerCount = 2;
            maxPlayerCount = 10;
            game = CreateGame(username, gameTypePolicy, buyInPolicy, chipPolicy, minBet, minPlayerCount, maxPlayerCount,
                true);
            Assert.IsTrue(game < 0);
        }

        [TestCleanup]
        public void TearDown()
        {
            //deleteUser("doron");
            //deleteUser("yossi");
            //deleteGames(...);
        }
    }
}
