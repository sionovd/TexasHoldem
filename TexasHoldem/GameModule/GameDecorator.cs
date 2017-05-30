﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexasHoldem.UserModule;

namespace TexasHoldem.GameModule
{

    abstract public class GameDecorator : IGame
    {
        protected IGame MyGame;

        public GameDecorator(IGame gameToBeDecorated)
        {
            this.MyGame = gameToBeDecorated;
        }

        public Player AddPlayer(User user)
        {
            return MyGame.AddPlayer(user);
        }

        public void Start()
        {
            MyGame.Start();
        }

        public Player EvaluateWinner()
        {
            return MyGame.EvaluateWinner();
        }

        public bool RemovePlayer(Player player)
        {
            return MyGame.RemovePlayer(player);
        }

        public Spectator AddSpectatingPlayer(User user)
        {
            return MyGame.AddSpectatingPlayer(user);
        }

        public bool RemoveSpectatingPlayer(Spectator spectator)
        {
            return MyGame.RemoveSpectatingPlayer(spectator);
        }

        public bool Bet(Player player, int amount)
        {
            return MyGame.Bet(player, amount);
        }

        public bool Check(Player player)
        {
            return MyGame.Check(player);
        }

        public bool Fold(Player player)
        {
            return MyGame.Fold(player);
        }

        public bool Call(Player player)
        {
            return MyGame.Call(player);
        }

        public bool IsPlayerExist(string name)
        {
            return MyGame.IsPlayerExist(name);
        }

        public Player GetPlayerByUsername(string username)
        {
            return MyGame.GetPlayerByUsername(username);
        }

        public Player GetPlayerById(int playerId)
        {
            return MyGame.GetPlayerById(playerId);
        }

        public GamePreferences Pref
        {
            get { return MyGame.Pref; }
            set { MyGame.Pref = value; }
        }

        public List<Player> Seats
        {
            get { return MyGame.Seats; }
        }

        public int Id
        {
            get { return MyGame.Id; }
        }

        public int Pot
        {
            get { return MyGame.Pot; }
            set { MyGame.Pot = value; }
        }

        public int RoundNumber
        {
            get { return MyGame.RoundNumber; }
        }

        public int BigBlind
        {
            get { return MyGame.BigBlind; }
        }

        public int CurrentStake
        {
            get { return MyGame.CurrentStake; }
        }

        public int StartCounter
        {
            get { return MyGame.StartCounter; }
            set { MyGame.StartCounter = value; }
        }

        public League League
        {
            get { return MyGame.League; }
            set { MyGame.League = value; }
        }
    }

    class BuyInDecorator : GameDecorator
    {
        public BuyInDecorator(IGame gameToBeDecorated, int buyIn) : base(gameToBeDecorated)
        {
            this.MyGame.Pref.BuyIn = buyIn;
        }
    }

    class MinBetDecorator : GameDecorator
    {
        public MinBetDecorator(IGame gameToBeDecorated, int minBet) : base(gameToBeDecorated)
        {
            this.MyGame.Pref.MinBet = minBet;
        }
    }

    class MinPlayersDecorator : GameDecorator
    {
        public MinPlayersDecorator(IGame gameToBeDecorated, int minPlayers) : base(gameToBeDecorated)
        {
            this.MyGame.Pref.MinPlayers = minPlayers;
        }
    }

    class MaxPlayersDecorator : GameDecorator
    {
        public MaxPlayersDecorator(IGame gameToBeDecorated, int maxPlayers) : base(gameToBeDecorated)
        {
            this.MyGame.Pref.MaxPlayers = maxPlayers;
        }
    }

    class ChipPolicyDecorator : GameDecorator
    {
        public ChipPolicyDecorator(IGame gameToBeDecorated, int chipPolicy) : base(gameToBeDecorated)
        {
            this.MyGame.Pref.ChipPolicy = chipPolicy;
        }
    }

    class SpectateGameDecorator : GameDecorator
    {
        public SpectateGameDecorator(IGame gameToBeDecorated, bool isSpectatable) : base(gameToBeDecorated)
        {
            this.MyGame.Pref.SpectateGame = isSpectatable;
        }
    }

    class LimitHoldemDecorator : GameDecorator
    {
        public LimitHoldemDecorator(IGame gameToBeDecorated) : base(gameToBeDecorated)
        {
            this.MyGame.Pref.GameType = 0;
        }

        public new bool Bet(Player player, int amount)
        {
            if (this.MyGame.RoundNumber <= 2 && amount == this.MyGame.BigBlind)
            {
                return base.Bet(player, amount);
            }
            if (this.MyGame.RoundNumber > 2 && amount == 2 * this.MyGame.BigBlind)
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
            this.MyGame.Pref.GameType = 2;
        }

        public new bool Bet(Player player, int amount)
        {
            if (amount >= this.MyGame.CurrentStake && amount <= this.MyGame.Pot + 2 * this.MyGame.CurrentStake)
                return base.Bet(player, amount);
            return false;
        }
    }
}
