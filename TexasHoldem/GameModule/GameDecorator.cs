using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexasHoldem.UserModule;

namespace TexasHoldem.GameModule
{

    abstract public class GameDecorator : IGame
    {
        protected IGame gameToBeDecorated;

        public GameDecorator(IGame gameToBeDecorated)
        {
            this.gameToBeDecorated = gameToBeDecorated;
        }

        public Player AddPlayer(User user)
        {
            return gameToBeDecorated.AddPlayer(user);
        }

        public bool RemovePlayer(Player player)
        {
            return gameToBeDecorated.RemovePlayer(player);
        }

        public Spectator AddSpectatingPlayer(User user)
        {
            return gameToBeDecorated.AddSpectatingPlayer(user);
        }

        public bool RemoveSpectatingPlayer(Spectator spectator)
        {
            return gameToBeDecorated.RemoveSpectatingPlayer(spectator);
        }

        public bool Bet(Player player, int amount)
        {
            return gameToBeDecorated.Bet(player, amount);
        }

        public bool Check(Player player)
        {
            return gameToBeDecorated.Check(player);
        }

        public bool Fold(Player player)
        {
            return gameToBeDecorated.Fold(player);
        }

        public bool Call(Player player)
        {
            return gameToBeDecorated.Call(player);
        }

        public bool IsPlayerExist(string name)
        {
            return gameToBeDecorated.IsPlayerExist(name);
        }

        public Player GetPlayerByUsername(string username)
        {
            return gameToBeDecorated.GetPlayerByUsername(username);
        }

        public Player GetPlayerById(int playerId)
        {
            return gameToBeDecorated.GetPlayerById(playerId);
        }

        public GamePreferences Pref { get; set; }
        public int Id { get; set; }
        public int Pot { get; set; }
    }

    class BuyInDecorator : GameDecorator
    {
        public BuyInDecorator(IGame gameToBeDecorated, int buyIn) : base(gameToBeDecorated)
        {
            gameToBeDecorated.Pref.BuyIn = buyIn;
        }
    }

    class MaxPlayersDecorator : GameDecorator
    {
        public MaxPlayersDecorator(IGame gameToBeDecorated, int maxPlayers) : base(gameToBeDecorated)
        {
            gameToBeDecorated.Pref.MaxPlayers = maxPlayers;
        }
    }
}
