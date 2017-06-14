using Domain.DomainLayerExceptions;
using Domain.GameModule;
using Domain.UserModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            User user = new User("roni","4363","roni55@gmail.com",233);
            Player player = new Player(game, 0, "roni");
            game.AddPlayer(user, player);
            Assert.IsTrue(game.IsPlayerExist(player.Username));
        }

        [TestMethod]
        [ExpectedException(typeof(notEnoughMoneyException))]
        public void AddPlayerMoneyGameTest()
        {
            game.Pref.ChipPolicy = 0;
            game.Pref.BuyIn = 204;
            User user = new User("roni", "4363", "roni55@gmail.com", 233);
            Player player = new Player(game, 0, user.Username);
            game.AddPlayer(user, player);
        }

        [TestMethod]
        public void IsSpectatorExistWhenNotExistById()
        {
            Spectator s = new Spectator("guri");
            Assert.IsFalse(game.IsSpectatorExist(s.Username));
        }

        [TestMethod]
        public void IsSpectatorExistWhenExistById()
        {
            User user = new User("ni", "4363", "ro5@gmail.com", 233);
            Spectator spec = game.AddSpectatingPlayer(user);
            Assert.IsTrue(game.IsSpectatorExist(spec.Username));
        }

        [TestMethod]
        public void IsSpectatorExistWhenNotExistByName()
        {
            Spectator s = new Spectator("guri");
            Assert.IsFalse(game.IsSpectatorExist(s.Username));
        }

        [TestMethod]
        public void IsSpectatorExistWhenExistByName()
        {
            User user = new User("ni", "4363", "ro5@gmail.com", 233);
            Spectator spec = game.AddSpectatingPlayer(user);
            Assert.IsTrue(game.IsSpectatorExist(spec.Username));
        }

        [TestMethod]
        public void IsPlayerExistWhenNotExistByName()
        {
            Player p = new Player(game, 234, "guri");
            Assert.IsFalse(game.IsPlayerExist(p.Username));
        }

        [TestMethod]
        public void IsPlayerExistWhenExistByName()
        {
            User user = new User("roni", "4363", "roni55@gmail.com", 233);
            Player player = new Player(game, 0, user.Username);
            game.AddPlayer(user, player);
            Assert.IsTrue(game.IsPlayerExist(player.Username));
        }


        [TestMethod]
        public void IsPlayerExistWhenNotExistById()
        {
            Player p = new Player(game, 234, "guri");
            Assert.IsFalse(game.IsPlayerExist(p.Username));
        }

        [TestMethod]
        public void IsPlayerExistWhenExistById()
        {
            User user = new User("roni", "4363", "roni55@gmail.com", 233);
            Player player = new Player(game, 0, user.Username);
            game.AddPlayer(user, player);
            Assert.IsTrue(game.IsPlayerExist(player.Username));
        }

        [TestMethod]
        [ExpectedException(typeof(FullTableException))]
        public void MaxPlayerInGameTest()
        {
            game.AddPlayer(new User("roni", "4363", "roni55@gmail.com", 233), new Player(game, 0, "roni"));
            game.AddPlayer(new User("dana", "4133", "dana55@gmail.com", 270), new Player(game, 0, "dana"));
            game.AddPlayer(new User("yaron", "431363", "yaron@gmail.com", 233), new Player(game, 0, "yaron"));
            game.AddPlayer(new User("clara", "12314", "clarita@gmail.com", 23), new Player(game, 0, "clara"));
            game.AddPlayer(new User("pini", "754231", "pinini@gmail.com", 23), new Player(game, 0, "pini"));
        }

        [TestMethod]
        public void IsPlayerPlayTest()
        {
            User user = new User("roni", "4363", "roni55@gmail.com");
            Player player = new Player(game, 0, user.Username);
            game.AddPlayer(user, player);
            Assert.IsTrue(game.IsPlayerExist(player.Username));
        }

        [TestMethod]
        public void AddSpectatingTest()
        {
            User user = new User("roni", "4363", "roni55@gmail.com");
            Spectator spec = game.AddSpectatingPlayer(user);
            Assert.IsTrue(game.IsSpectatorExist(spec.Username));
        }


        [TestMethod]
        public void RemovePlayerTest()
        {
            User user = new User("roni", "4363", "roni55@gmail.com");
            Player player = new Player(game, 0, user.Username);
            game.AddPlayer(user, player);
            game.RemovePlayer(player);
            Assert.IsFalse(game.IsPlayerExist(player.Username));
        }

    }
}
