using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TexasHoldem;
using TexasHoldem.GameModule;
using TexasHoldem.UserModule;

namespace UnitTestProject1
{
    
    [TestClass]
    public class GameUnitTest
    {
        GamePreferences pref;
        Game game;
        [TestInitialize]
        public void BeforeTest()
        {
            pref = new GamePreferences(0,0,357,30,4,2,true);
            game = new Game(pref);
        }

        [TestMethod]
        public void GameIdTest()
        {
            Assert.IsTrue(game.Id == 1);
            Assert.IsTrue(new Game(pref).Id == 2);
        }

        [TestMethod]
        public void AddPlayerChipGameTest()
        {
            User user = new User("roni","4363","roni55@gmail.com",false,233);
            Player player = game.AddPlayer(user);
            Assert.IsTrue(game.IsPlayerExist(player));
        }

        [TestMethod]
        [ExpectedException(typeof(notEnoughMoneyException))]
        public void AddPlayerMoneyGameTest()
        {
            game.Pref.ChipPolicy = 0;
            game.Pref.BuyIn = 204;
            User user = new User("roni", "4363", "roni55@gmail.com", false, 233);
            Player player = game.AddPlayer(user);
        }

        [TestMethod]
        public void IsSpectatorExistWhenNotExistById()
        {
            Spectator s = new Spectator("guri");
            Assert.IsFalse(game.IsSpectatorExist(s));
        }

        [TestMethod]
        public void IsSpectatorExistWhenExistById()
        {
            User user = new User("ni", "4363", "ro5@gmail.com", false, 233);
            Spectator spec = game.AddSpectatingPlayer(user);
            Assert.IsTrue(game.IsSpectatorExist(spec));
        }

        [TestMethod]
        public void IsSpectatorExistWhenNotExistByName()
        {
            Spectator s = new Spectator("guri");
            Assert.IsFalse(game.IsSpectatorExist(s.Name));
        }

        [TestMethod]
        public void IsSpectatorExistWhenExistByName()
        {
            User user = new User("ni", "4363", "ro5@gmail.com", false, 233);
            Spectator spec = game.AddSpectatingPlayer(user);
            Assert.IsTrue(game.IsSpectatorExist(spec.Name));
        }

        [TestMethod]
        public void IsPlayerExistWhenNotExistByName()
        {
            Player p = new Player(234, "guri");
            Assert.IsFalse(game.IsPlayerExist(p.Username));
        }

        [TestMethod]
        public void IsPlayerExistWhenExistByName()
        {
            User user = new User("roni", "4363", "roni55@gmail.com", false, 233);
            Player player = game.AddPlayer(user);
            Assert.IsTrue(game.IsPlayerExist(player.Username));
        }


        [TestMethod]
        public void IsPlayerExistWhenNotExistById()
        {
            Player p = new Player(234, "guri");
            Assert.IsFalse(game.IsPlayerExist(p));
        }

        [TestMethod]
        public void IsPlayerExistWhenExistById()
        {
            User user = new User("roni", "4363", "roni55@gmail.com", false, 233);
            Player player = game.AddPlayer(user);
            Assert.IsTrue(game.IsPlayerExist(player));
        }

        [TestMethod]
        [ExpectedException(typeof(FullTableException))]
        public void MaxPlayerInGameTest()
        {
            game.AddPlayer(new User("roni", "4363", "roni55@gmail.com", false, 233));
            game.AddPlayer(new User("dana", "4133", "dana55@gmail.com", false, 270));
            game.AddPlayer(new User("yaron", "431363", "yaron@gmail.com", false, 233));
            game.AddPlayer(new User("clara", "12314", "clarita@gmail.com", false, 23));
            game.AddPlayer(new User("pini", "754231", "pinini@gmail.com", true, 23));
        }

        [TestMethod]
        public void IsPlayerPlayTest()
        {
            User user = new User("roni", "4363", "roni55@gmail.com", false);
            Player player = game.AddPlayer(user);
            Assert.IsTrue(game.IsPlayerExist(player));
        }

        [TestMethod]
        public void AddSpectatingTest()
        {
            User user = new User("roni", "4363", "roni55@gmail.com", false);
            Spectator spec = game.AddSpectatingPlayer(user);
            Assert.IsTrue(game.IsSpectatorExist(spec));
        }


        [TestMethod]
        public void RemovePlayerTest()
        {
            User user = new User("roni", "4363", "roni55@gmail.com", false);
            Player player = game.AddPlayer(user);
            game.RemovePlayer(player);
            Assert.IsFalse(game.IsPlayerExist(player));
        }

    }
}
