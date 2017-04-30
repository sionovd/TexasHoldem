using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexasHoldem
{
    public enum TypeOfGame { LimitHoldem, NoLimitHoldem, PotLimitHoldem };
    public class Game
    {
        public Game(int gameID)
        {
            //this = gameCenter.getGame(gameID);
        }

        private static int counter = 0;
        private Player[] sits;
        private List<Spectator> spectators;
        private Card[] tableCards;
        private System.Object lockThis = new System.Object();
        private int numOfPlayers;    // players that sits
        private bool isActive;

        public Game(GamePreferences pref)
        {
            counter++;
            Id = counter;
            this.Pref = pref;
            sits = new Player[pref.MaxPlayers];
            spectators = new List<Spectator>();
            tableCards = new Card[5];
            Cards = new Deck();
            Pot = 0;
            numOfPlayers = 0;
            MinStake = 100; //this field needs to hold the minimal stake
            isActive = false;
        }

        public void Play()
        {
            Player winner = null;
            switch (GameType)
            {
                case (TypeOfGame.LimitHoldem):
                case (TypeOfGame.PotLimitHoldem):
                case (TypeOfGame.NoLimitHoldem):
                    winner = PlayNoLimitHoldem();
                    break;
                default:
                    Console.WriteLine("bugbugbgu");
                    break;

            }
        }
        private Player PlayNoLimitHoldem()
        {
            Player winner = null;
            int sitIndex = 0;
            Player currentPlayer = null;
            bool gameOver = false;
            int roundStarted = 0;
            int nextCard = 0;
            while (!gameOver)
            {
                currentPlayer = Sits[sitIndex % Sits.Length];
                currentPlayer.PlayMove();
                if (sitIndex % Sits.Length == 0 && roundStarted > 0) //check if round has been made
                {
                    if (BettingPlayer == FirstInRoundPlayer)
                    {
                        //done round of bets, flip
                        if (nextCard++ == 6)
                        {
                            gameOver = true;
                            break;
                        }
                        tableCards[nextCard] = cards.GetCard();
                    }
                    else
                    {
                        FirstInRoundPlayer = BettingPlayer;
                        //continue iterations
                    }
                }
                else
                {
                    roundStarted++;
                }
                //do whatever functionality
                sitIndex++;
            }
            winner = currentPlayer;
            return winner;
        }
        private Player PlayLimitHoldem()
        {
            return null;
        }
        private Player PlayPotLimitHoldem()
        {
            return null;
        }

        public Player GetPlayerById(int playerID)
        {
            foreach (Player player in sits)
            {
                if (player != null && player.PlayerId == playerID)
                    return player;
            }
            return null;
        }

        public bool RemovePlayer(Player player)
        {
            for (int i = 0; i < sits.Length; i++)
                if (sits[i] != null && sits[i].PlayerId == player.PlayerId)
                {
                    sits[i] = null;
                    player.GetUp();
                    return true;
                }
            return false;
        }

        public Player AddPlayer(User user)
        {
            if (numOfPlayers == Pref.MaxPlayers)
                throw new FullTableException();
            Player p;
            if (Pref.ChipPolicy == 0)
            {
                if (user.getmoneyBalance() < Pref.BuyIn + Pref.MinBet)
                    throw new notEnoughMoneyException(user.getmoneyBalance().ToString(), Pref.BuyIn.ToString());
                int m = user.decreaseMoney(Pref.BuyIn);
                p = new Player(m, user.getUsername());
                p.TakeSit(AddPlayerToSit(p));
                numOfPlayers++;
                return p;
            }
            p = new Player(Pref.ChipPolicy, user.getUsername());
            p.TakeSit(AddPlayerToSit(p));
            numOfPlayers++;
            if (numOfPlayers == Pref.MinPlayers)
                isActive = true;
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
            if(!Pref.SpectateGame)
                throw new DomainException("game not spectatable");
            if(IsSpectatorExist(user.getUsername()))
                throw new DomainException("the user " + user + " is already watching this game");
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

        public int Id { get; set; }

        public GamePreferences Pref { get; set; }

        public Player[] Sits
        {
            get
            {
                return sits;
            }
        }

        public Deck Cards { get; set; }

        public int Pot { get; set; }

        public int TemporaryPot { get; set; }
        public int CurrentStake { get; set; }
    
        public Player FirstInRoundPlayer { get; set; }
      
        public Player BettingPlayer { get; set; }

        public int FinishedRound { get; set; }

        public int MinStake { get; set; }
     
        public int SmallBlind { get; set; }
        
        public int BigBlind { get; set; }
     
        public TypeOfGame GameType { get; set; }
      
    }
}
