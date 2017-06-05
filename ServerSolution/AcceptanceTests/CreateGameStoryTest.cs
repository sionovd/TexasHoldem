using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AcceptanceTests
{
    [TestClass]
    public class CreateGameStoryTest : GameSystemTest
    {

        [TestMethod]
        public void CreateGameGood()
        {
            Assert.IsTrue(Register("doron", "password", "doron@gmail.com"));
            string username = "doron";

            List<KeyValuePair<string, int>> preferenceList1 = new List<KeyValuePair<string, int>>();
            List<KeyValuePair<string, int>> preferenceList2 = new List<KeyValuePair<string, int>>();
            int game1 = CreateGame(username, preferenceList1);
            Assert.IsTrue(game1 > 0);
            int game2 = CreateGame(username, preferenceList2);
            Assert.IsTrue(game2 > 0);
            Assert.AreNotEqual(game1, game2);

            preferenceList1.Add(new KeyValuePair<string, int>("gameType", 0));
            preferenceList1.Add(new KeyValuePair<string, int>("buyIn", 200));
            preferenceList1.Add(new KeyValuePair<string, int>("chipPolicy", 300));
            preferenceList1.Add(new KeyValuePair<string, int>("minBet", 10));
            preferenceList1.Add(new KeyValuePair<string, int>("minPlayers", 4));
            int game = CreateGame(username, preferenceList1);
            Assert.IsTrue(game > 0);

            preferenceList1 = new List<KeyValuePair<string, int>>
            {
                new KeyValuePair<string, int>("gameType", 0),
                new KeyValuePair<string, int>("buyIn", 200),
                new KeyValuePair<string, int>("chipPolicy", 0),
                new KeyValuePair<string, int>("minBet", 10),
                new KeyValuePair<string, int>("minPlayers", 3),
                new KeyValuePair<string, int>("maxPlayers", 6),
                new KeyValuePair<string, int>("spectateGame", 0)
            };
            game = CreateGame(username, preferenceList1);
            Assert.IsTrue(game > 0);

            preferenceList1 = new List<KeyValuePair<string, int>>
            {
                new KeyValuePair<string, int>("gameType", 1),
                new KeyValuePair<string, int>("buyIn", 200),
                new KeyValuePair<string, int>("chipPolicy", 300),
                new KeyValuePair<string, int>("minBet", 10),
                new KeyValuePair<string, int>("minPlayers", 4),
                new KeyValuePair<string, int>("maxPlayers", 9),
                new KeyValuePair<string, int>("spectateGame", 1)
            };
            game = CreateGame(username, preferenceList1);
            Assert.IsTrue(game > 0);

            preferenceList1 = new List<KeyValuePair<string, int>>
            {
                new KeyValuePair<string, int>("gameType", 2),
                new KeyValuePair<string, int>("buyIn", 200),
                new KeyValuePair<string, int>("chipPolicy", 300),
                new KeyValuePair<string, int>("minBet", 10),
                new KeyValuePair<string, int>("minPlayers", 4),
                new KeyValuePair<string, int>("maxPlayers", 9),
                new KeyValuePair<string, int>("spectateGame", 0)
            };
            game = CreateGame(username, preferenceList1);
            Assert.IsTrue(game > 0);
            
        }

        [TestMethod]
        public void CreateGameBad()
        {
            Assert.IsTrue(Register("doronBad", "password", "doron@gmail.com"));
            string username = "doronBad";
            List<KeyValuePair<string, int>> preferenceList = new List<KeyValuePair<string, int>>
            {
                new KeyValuePair<string, int>("gameType", -1),
                new KeyValuePair<string, int>("buyIn", 0),
                new KeyValuePair<string, int>("chipPolicy", 100),
                new KeyValuePair<string, int>("minBet", 5),
                new KeyValuePair<string, int>("minPlayers", 2),
                new KeyValuePair<string, int>("maxPlayers", 5),
                new KeyValuePair<string, int>("spectateGame", 1)
            };
            int game = CreateGame(username, preferenceList);
            Assert.IsTrue(game < 0);

           
            preferenceList = new List<KeyValuePair<string, int>>
            {
                new KeyValuePair<string, int>("gameType", 1),
                new KeyValuePair<string, int>("buyIn", -100),
                new KeyValuePair<string, int>("chipPolicy", 100),
                new KeyValuePair<string, int>("minBet", 5),
                new KeyValuePair<string, int>("minPlayers", 2),
                new KeyValuePair<string, int>("maxPlayers", 5),
            };
            game = CreateGame(username, preferenceList);
            Assert.IsTrue(game < 0);

            
            preferenceList = new List<KeyValuePair<string, int>>
            {
                new KeyValuePair<string, int>("gameType", 1),
                new KeyValuePair<string, int>("buyIn", 100),
                new KeyValuePair<string, int>("chipPolicy", -100),
                new KeyValuePair<string, int>("minBet", 5),
                new KeyValuePair<string, int>("minPlayers", 2),
                new KeyValuePair<string, int>("maxPlayers", 5),
                new KeyValuePair<string, int>("spectateGame", 1)
            };
            game = CreateGame(username, preferenceList);
            Assert.IsTrue(game < 0);

            preferenceList = new List<KeyValuePair<string, int>>
            {
                new KeyValuePair<string, int>("gameType", 1),
                new KeyValuePair<string, int>("buyIn", 100),
                new KeyValuePair<string, int>("chipPolicy", 100),
                new KeyValuePair<string, int>("minBet", -5),
                new KeyValuePair<string, int>("minPlayers", 2),
                new KeyValuePair<string, int>("maxPlayers", 5),
            };
            game = CreateGame(username, preferenceList);
            Assert.IsTrue(game < 0);

            preferenceList = new List<KeyValuePair<string, int>>
            {
                new KeyValuePair<string, int>("gameType", 1),
                new KeyValuePair<string, int>("buyIn", 100),
                new KeyValuePair<string, int>("chipPolicy", 100),
                new KeyValuePair<string, int>("minBet", 10),
                new KeyValuePair<string, int>("minPlayers", 0),
                new KeyValuePair<string, int>("maxPlayers", 2),
            };
            game = CreateGame(username, preferenceList);
            Assert.IsTrue(game < 0);
            
            preferenceList = new List<KeyValuePair<string, int>>
            {
                new KeyValuePair<string, int>("gameType", 2),
                new KeyValuePair<string, int>("buyIn", 100),
                new KeyValuePair<string, int>("chipPolicy", 100),
                new KeyValuePair<string, int>("minBet", 10),
                new KeyValuePair<string, int>("minPlayers", 1),
                new KeyValuePair<string, int>("maxPlayers", 2),
            };
            game = CreateGame(username, preferenceList);
            Assert.IsTrue(game < 0);

            preferenceList = new List<KeyValuePair<string, int>>
            {
                new KeyValuePair<string, int>("gameType", 2),
                new KeyValuePair<string, int>("buyIn", 100),
                new KeyValuePair<string, int>("chipPolicy", 100),
                new KeyValuePair<string, int>("minBet", 10),
                new KeyValuePair<string, int>("minPlayers", 5),
                new KeyValuePair<string, int>("maxPlayers", 2),
            };
            game = CreateGame(username, preferenceList);
            Assert.IsTrue(game < 0);
        }

        [TestMethod]
        public void CreateGameSad()
        {
            Assert.IsTrue(Register("yossi", "pass", "yos@gmail.com"));
            string username = "yossi";
            List<KeyValuePair<string, int>> preferenceList = new List<KeyValuePair<string, int>>
            {
                new KeyValuePair<string, int>("gameType", 1),
                new KeyValuePair<string, int>("buyIn", 100),
                new KeyValuePair<string, int>("chipPolicy", 100),
                new KeyValuePair<string, int>("minBet", 0),
                new KeyValuePair<string, int>("minPlayers", 2),
                new KeyValuePair<string, int>("maxPlayers", 5),
                new KeyValuePair<string, int>("spectateGame", 0)
            };
            int game = CreateGame(username, preferenceList);
            Assert.IsTrue(game < 0);

            preferenceList = new List<KeyValuePair<string, int>>
            {
                new KeyValuePair<string, int>("gameType", 1),
                new KeyValuePair<string, int>("buyIn", 100),
                new KeyValuePair<string, int>("chipPolicy", 100),
                new KeyValuePair<string, int>("minBet", 5),
                new KeyValuePair<string, int>("minPlayers", 2),
                new KeyValuePair<string, int>("maxPlayers", 10),
            };
            game = CreateGame(username, preferenceList);
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
