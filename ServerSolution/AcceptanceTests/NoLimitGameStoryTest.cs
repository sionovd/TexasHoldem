using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AcceptanceTests
{
    [TestClass]
    public class NoLimitGameStoryTest : GameSystemTest
    {
        private int game1;
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
            
            List<KeyValuePair<string, int>> preferenceList = new List<KeyValuePair<string, int>>
            {
                new KeyValuePair<string, int>("gameType", 1),
                new KeyValuePair<string, int>("buyIn", 0),
                new KeyValuePair<string, int>("chipPolicy", 100),
                new KeyValuePair<string, int>("minBet", 10),
                new KeyValuePair<string, int>("minPlayers", 2),
                new KeyValuePair<string, int>("maxPlayers", 9),
                new KeyValuePair<string, int>("spectateGame", 1)
            };

            game1 = CreateGame(username, preferenceList);
            Assert.IsTrue(game1 > 0);
            player1 = 1;
            player2 = JoinGame("tamir", game1);
            Assert.IsTrue(player2 > 0);
            player3 = JoinGame("avner", game1);
            Assert.IsTrue(player3 > 0);
            player4 = JoinGame("leon", game1);
            Assert.IsTrue(player4 > 0);
            player5 = JoinGame("shavit", game1);
            Assert.IsTrue(player5 > 0);

            Assert.IsFalse(StartGame("doron", game1));
            Assert.IsFalse(StartGame("tamir", game1));
            Assert.IsFalse(StartGame("shavit", game1));
            Assert.IsFalse(StartGame("leon", game1));
            Assert.IsTrue(StartGame("avner", game1));
        }

        [TestMethod]
        public void NoLimitFullGame()
        {
            Assert.IsFalse(Bet(player1, game1, 25));
            Assert.IsFalse(Call(player2, game1));
            Assert.IsTrue(Call(player3, game1));
            Assert.IsTrue(Call(player4, game1));
            Assert.IsTrue(Fold(player5, game1));
            Assert.IsTrue(Call(player1, game1));

            Assert.IsTrue(Bet(player1, game1, 50));
            Assert.IsTrue(Bet(player2, game1, 75));
            Assert.IsTrue(Call(player3, game1));
            Assert.IsTrue(Call(player4, game1));
            Assert.IsTrue(Call(player1, game1));

            Assert.IsTrue(Check(player1, game1));
            Assert.IsTrue(Check(player2, game1));
            Assert.IsTrue(Check(player3, game1));
            Assert.IsTrue(Check(player4, game1));

            Assert.IsTrue(Check(player1, game1));
            Assert.IsTrue(Check(player2, game1));
            Assert.IsTrue(Check(player3, game1));
            Assert.IsTrue(Check(player4, game1));
        }

        [TestMethod]
        public void NoLimitEarlyFinish()
        {
            Assert.IsFalse(Bet(player1, game1, 25));
            Assert.IsFalse(Call(player2, game1));
            Assert.IsTrue(Call(player3, game1));
            Assert.IsTrue(Call(player4, game1));
            Assert.IsTrue(Fold(player5, game1));
            Assert.IsTrue(Call(player1, game1));

            Assert.IsTrue(Bet(player1, game1, 50));
            Assert.IsTrue(Bet(player2, game1, 75));
            Assert.IsTrue(Call(player3, game1));
            Assert.IsTrue(Call(player4, game1));
            Assert.IsTrue(Call(player1, game1));

            Assert.IsTrue(Check(player1, game1));
            Assert.IsTrue(Check(player2, game1));
            Assert.IsTrue(Check(player3, game1));
            Assert.IsTrue(Bet(player4, game1, 10));
            Assert.IsTrue(Fold(player1, game1));
            Assert.IsTrue(Fold(player2, game1));
            Assert.IsTrue(Fold(player3, game1));


        }

        [TestMethod]
        public void NoLimitBad()
        {
            Assert.IsFalse(Bet(player1, game1, -1));
            Assert.IsFalse(Bet(player1, game1, 101));
        }

        [TestMethod]
        public void NoLimitSad()
        {
            Assert.IsFalse(Bet(player1, game1, 3));
        }

        [TestCleanup]
        public void TearDown()
        {
            //delete objects from setup...
        }

    }
}
