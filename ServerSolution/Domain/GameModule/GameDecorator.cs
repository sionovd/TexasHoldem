using System.Collections.Generic;
using Domain.DomainLayerExceptions;
using Domain.ObserverFramework;
using Domain.UserModule;

namespace Domain.GameModule
{

    public abstract class GameDecorator : IGame
    {
        protected IGame MyGame;

        public GameDecorator(IGame gameToBeDecorated)
        {
            MyGame = gameToBeDecorated;
        }

        public void AddPlayer(User user, Player player)
        {
            MyGame.AddPlayer(user, player);
        }

        public void Start()
        {
            MyGame.Start();
        }

        public void EvaluateWinner()
        {
            MyGame.EvaluateWinner();
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

        public virtual bool IsBetValid(int chipBalance, int amount)
        {
            return MyGame.IsBetValid(chipBalance, amount);
        }

        public bool IsPlayerExist(string name)
        {
            return MyGame.IsPlayerExist(name);
        }

        public bool IsSpectatorExist(string name)
        {
            return MyGame.IsSpectatorExist(name);
        }

        public Player GetPlayerByUsername(string username)
        {
            return MyGame.GetPlayerByUsername(username);
        }

        public Spectator GetSpectatorByUsername(string username)
        {
            return MyGame.GetSpectatorByUsername(username);
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

        public Player Winner {
            get { return MyGame.Winner; }
            set { MyGame.Winner = value; }
        }

        public Player PreviousPlayer {
            get { return MyGame.PreviousPlayer; }
            set { MyGame.PreviousPlayer = value; }
        }
        public void UpdateState()
        {
            MyGame.UpdateState();
        }

        public Player GetCurrentPlayer()
        {
            return MyGame.GetCurrentPlayer();
        }
    }

    class BuyInDecorator : GameDecorator
    {
        public BuyInDecorator(IGame gameToBeDecorated, int buyIn) : base(gameToBeDecorated)
        {
            MyGame.Pref.BuyIn = buyIn;
        }
    }

    class MinBetDecorator : GameDecorator
    {
        public MinBetDecorator(IGame gameToBeDecorated, int minBet) : base(gameToBeDecorated)
        {
            MyGame.Pref.MinBet = minBet;
        }

        public override bool IsBetValid(int chipBalance, int amount)
        {
            if (MyGame.Pref.MinBet <= amount)
                return base.IsBetValid(chipBalance, amount);
            throw new DomainException("tried to bet " + amount + " but the min bet is " + MyGame.Pref.MinBet);
        }
    }

    class MinPlayersDecorator : GameDecorator
    {
        public MinPlayersDecorator(IGame gameToBeDecorated, int minPlayers) : base(gameToBeDecorated)
        {
            MyGame.Pref.MinPlayers = minPlayers;
        }

    }

    class MaxPlayersDecorator : GameDecorator
    {
        public MaxPlayersDecorator(IGame gameToBeDecorated, int maxPlayers) : base(gameToBeDecorated)
        {
            MyGame.Pref.MaxPlayers = maxPlayers;
        }
    }

    class ChipPolicyDecorator : GameDecorator
    {
        public ChipPolicyDecorator(IGame gameToBeDecorated, int chipPolicy) : base(gameToBeDecorated)
        {
            MyGame.Pref.ChipPolicy = chipPolicy;
        }
    }

    class SpectateGameDecorator : GameDecorator
    {
        public SpectateGameDecorator(IGame gameToBeDecorated, bool isSpectatable) : base(gameToBeDecorated)
        {
            MyGame.Pref.SpectateGame = isSpectatable;
        }
    }

    class LimitHoldemDecorator : GameDecorator
    {
        public LimitHoldemDecorator(IGame gameToBeDecorated) : base(gameToBeDecorated)
        {
            MyGame.Pref.GameType = 0;
        }

        public override bool IsBetValid(int chipBalance, int amount)
        {
            if (MyGame.State.RoundNumber <= 2 && amount == MyGame.BigBlind)
            {
                return base.IsBetValid(chipBalance, amount);
            }
            if (MyGame.State.RoundNumber > 2 && amount == 2 * MyGame.BigBlind)
            {
                return base.IsBetValid(chipBalance, amount);
            }
            throw new DomainException("tried to bet " + amount +
                                      " during round " + MyGame.State.RoundNumber + " which is illegal");

        }
    }

    class PotLimitHoldemDecorator : GameDecorator
    {
        public PotLimitHoldemDecorator(IGame gameToBeDecorated) : base(gameToBeDecorated)
        {
            MyGame.Pref.GameType = 2;
        }

        public override bool IsBetValid(int chipBalance, int amount)
        {
            if (amount >= MyGame.State.CurrentStake && amount <= MyGame.State.Pot + 2 * MyGame.State.CurrentStake)
                return base.IsBetValid(chipBalance, amount);
            throw new DomainException("the bet amount: " + amount + " is not legal according to PotLimit rules");
        }
    }
}
