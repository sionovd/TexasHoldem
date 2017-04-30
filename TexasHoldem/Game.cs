using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexasHoldem
{
    public class Game
    {
        public Game(int gameID)
        {
            //this = gameCenter.getGame(gameID);
        }

        private static int counter = 0;
        private int id;
        private GamePreferences pref;
        private Player[] sits;
        private List<Spectator> spectators;
        private Deck cards;
        private int pot;
        private Card[] tableCards;
        private System.Object lockThis = new System.Object();
        private int numOfPlayers;    // players that sits

        public Game(GamePreferences pref)
        {
            counter++;
            id = counter;
            this.pref = pref;
            sits = new Player[pref.MaxPlayers];
            spectators = new List<Spectator>();
            tableCards = new Card[5];
            cards = new Deck();
            pot = 0;
            numOfPlayers = 0;
            MinStake = 100; //this field needs to hold the minimal stake
        }

        public Player GetPlayerById(int playerID)
        {
            foreach (Player player in sits)
            {
                if (player.PlayerId == playerID)
                    return player;
            }
            return null;
        }

        public bool RemovePlayer(Player player)
        {
            for (int i = 0; i < sits.Length; i++)
                if (sits[i].PlayerId == player.PlayerId)
                {
                    sits[i] = null;
                    player.GetUp();
                    return true;
                }
            return false;
        }

        public Player AddPlayer(User user)
        {
            if (numOfPlayers == pref.MaxPlayers)
                throw new FullTableException();
            Player p;
            if (pref.ChipPolicy == 0)
            {
                if (user.getmoneyBalance() < pref.BuyIn + pref.MinBet)
                    throw new notEnoughMoneyException(user.getmoneyBalance().ToString(), pref.BuyIn.ToString());
                int m = user.decreaseMoney(pref.BuyIn);
                user.decreaseMoney(m);
                p = new Player(m, user.getUsername());
                p.TakeSit(AddPlayerToSit(p));
                numOfPlayers++;
                return p;
            }
            p = new Player(pref.ChipPolicy, user.getUsername());
            p.TakeSit(AddPlayerToSit(p));
            numOfPlayers++;
            return p;
        }

        private int AddPlayerToSit(Player player)
        {
            for (int i = 0; i < sits.Length; i++)
                if (sits[i] == null)
                {
                    sits[i] = player;
                    return i;
                }
            return -1;
        }

        public Spectator AddSpectatingPlayer(User user)
        {
            Spectator spec = new Spectator(user.getUsername());
            spectators.Add(spec);
            return spec;
        }


        public bool RemoveSpectatingPlayer(Spectator spectator)
        {
            foreach (Spectator spec in spectators)
                if (spec.Id == spectator.Id)
                {
                    spectators.Remove(spec);
                    return true;
                }
            return false;
        }


        public bool IsSpectatorExist(Spectator spec)
        {
            foreach (Spectator s in spectators)
                if (s.Id == spec.Id)
                    return true;
            return false;
        }

        public bool IsSpectatorExist(string name)
        {
            foreach (Spectator s in spectators)
                if (s.Name.Equals(name))
                    return true;
            return false;
        }

        public bool IsPlayerExist(Player player)
        {
            foreach (Player p in sits)
                if (p != null && p.PlayerId == player.PlayerId)
                    return true;
            return false;
        }


        public bool IsPlayerExist(string name)
        {
            foreach (Player p in sits)
                if (p != null && p.Name.Equals(name))
                    return true;
            return false;
        }
        public void FinishStaking()
        {
            Pot += TemporaryPot;
            TemporaryPot = 0;
            CurrentStake = MinStake;
        }
        public bool Bet(Player player, int amount)
        {
            if (player.MoneyBalance < CurrentStake + amount)
                return false;
            CurrentStake += amount;
            TemporaryPot += CurrentStake;
            BettingPlayer = player;
            return true;
        }
        public bool Call(Player player)
        {
            if (player.MoneyBalance < CurrentStake - player.AlreadyPayed)
                return false; //not enough money
            TemporaryPot += CurrentStake;
            player.MoneyBalance -= CurrentStake;
            return true;
        }
        public bool Check(Player player)
        {
            //player checked
            return true;
        }

        public bool Fold(Player player)
        {
            //player folded
            return true;
        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public GamePreferences Pref
        {
            get
            {
                return pref;
            }

            set
            {
                pref = value;
            }
        }

        public Player[] Sits
        {
            get
            {
                return sits;
            }
        }

        public Deck Cards
        {
            get
            {
                return cards;
            }
            set
            {
                cards = value;
            }
        }

        public int Pot
        {
            get
            {
                return pot;
            }
            set
            {
                pot = value;
            }
        }
        public int TemporaryPot
        {
            get
            {
                return TemporaryPot;
            }
            set
            {
                TemporaryPot = value;
            }
        }
        public int CurrentStake
        {
            get
            {
                return CurrentStake;
            }
            set
            {
                CurrentStake = value;
            }
        }
        public Player FirstInRoundPlayer
        {
            get
            {
                return FirstInRoundPlayer;
            }
            set
            {
                FirstInRoundPlayer = value;
            }
        }
        public Player BettingPlayer
        {
            get
            {
                return BettingPlayer;
            }
            set
            {
                BettingPlayer = value;
            }
        }
        public int FinishedRound
        {
            get
            {
                return FinishedRound;
            }
            set
            {
                FinishedRound = value;
            }
        }

        public int MinStake
        {
            get
            {
                return MinStake;
            }
            set
            {
                MinStake = value;
            }
        }
    }
}
