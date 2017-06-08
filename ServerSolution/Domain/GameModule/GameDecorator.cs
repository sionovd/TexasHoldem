using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ObserverFramework;
using Domain.ServiceLayer;
using Domain.UserModule;

namespace Domain.GameModule
{

    public abstract class GameDecorator : IGame
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

        public virtual bool Bet(Player player, int amount)
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
            set { MyGame.Id = value; }
        }

        public GameState State
        {
            get { return MyGame.State; }
            set { MyGame.State = value; }
        }

        public int BigBlind
        {
            get { return MyGame.BigBlind; }
            set { MyGame.BigBlind = value; }
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

        public GameLog Logger
        {
            get { return MyGame.Logger; }
            set { MyGame.Logger = value; }
        }

        public Subject Subject {
            get { return MyGame.Subject; }
            set { MyGame.Subject = value; }
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

        public override bool Bet(Player player, int amount)
        {
            if (MyGame.Pref.MinBet <= amount)
                return base.Bet(player, amount);
            throw new DomainException(player.Username + " tried to bet " + amount + " but the min bet is " + MyGame.Pref.MinBet);
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

        public override bool Bet(Player player, int amount)
        {
            if (this.MyGame.State.RoundNumber <= 2 && amount == this.MyGame.BigBlind)
            {
                return base.Bet(player, amount);
            }
            if (this.MyGame.State.RoundNumber > 2 && amount == 2 * this.MyGame.BigBlind)
            {
                return base.Bet(player, amount);
            }
            throw new DomainException(player.Username + " tried to bet " + amount +
                                      " during round " + MyGame.State.RoundNumber + " which is illegal");

        }
    }

    class PotLimitHoldemDecorator : GameDecorator
    {
        public PotLimitHoldemDecorator(IGame gameToBeDecorated) : base(gameToBeDecorated)
        {
            this.MyGame.Pref.GameType = 2;
        }

        public override bool Bet(Player player, int amount)
        {
            if (amount >= this.MyGame.State.CurrentStake && amount <= this.MyGame.State.Pot + 2 * this.MyGame.State.CurrentStake)
                return base.Bet(player, amount);
            throw new DomainException("the bet amount: " + amount + " is not legal according to PotLimit rules");
        }
    }
}
