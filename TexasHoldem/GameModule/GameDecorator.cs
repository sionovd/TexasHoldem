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

        public void Play()
        {
            gameToBeDecorated.Play();
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
        public Player[] Seats { get; }
        public int Id { get; set; }
        public int Pot { get; set; }
        public int NumOfPlayers { get; }
        public int RoundNumber { get; }
        public int BigBlind { get; }
        public int CurrentStake { get; }
    }

    class BuyInDecorator : GameDecorator
    {
        public BuyInDecorator(IGame gameToBeDecorated, int buyIn) : base(gameToBeDecorated)
        {
            Pref.BuyIn = buyIn;
        }
    }

    class MaxPlayersDecorator : GameDecorator
    {
        public MaxPlayersDecorator(IGame gameToBeDecorated, int maxPlayers) : base(gameToBeDecorated)
        {
            Pref.MaxPlayers = maxPlayers;
        }
    }

    class LimitHoldemDecorator : GameDecorator
    {
        public LimitHoldemDecorator(IGame gameToBeDecorated) : base(gameToBeDecorated)
        {
            Pref.GameType = 0;
        }

        public new bool Bet(Player player, int amount)
        {
            if (RoundNumber <= 2 && amount == BigBlind)
            {
                return base.Bet(player, amount);
            }
            if (RoundNumber > 2 && amount == 2 * BigBlind)
            {
                return base.Bet(player, amount);
            }
            return false;
        }
    }

    class PotLimitHoldemDecorator : GameDecorator
    {
        public PotLimitHoldemDecorator(IGame gameToBeDecorated) : base(gameToBeDecorated)
        {
            Pref.GameType = 2;
        }

        public new bool Bet(Player player, int amount)
        {
            if (amount >= CurrentStake && amount <= Pot + 2 * CurrentStake)
                return base.Bet(player, amount);
            return false;
        }
    }
}
