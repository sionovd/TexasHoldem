using System;
using System.Collections.Generic;
using TexasHoldem.UserModule;

namespace TexasHoldem.GameModule
{
    public interface IGame
    {
        Player AddPlayer(User user);
        void Start();
        Player EvaluateWinner();
        bool RemovePlayer(Player player);
        Spectator AddSpectatingPlayer(User user);
        bool RemoveSpectatingPlayer(Spectator spectator);
        bool Bet(Player player, int amount);
        bool Check(Player player);
        bool Fold(Player player);
        bool Call(Player player);
        bool IsPlayerExist(string name);
        Player GetPlayerByUsername(string username);
        Player GetPlayerById(int playerId);

        GamePreferences Pref { get; set; }
        List<Player> Seats { get; }
        int Id { get; }
        int Pot { get; set; }
        int RoundNumber { get; }
        int BigBlind { get; }
        int CurrentStake { get; }
        int StartCounter { get; set; }
        League League { get; set; }
    }

    public class Game : IGame
    {
        private static int counter = 0;
        private List<Spectator> spectators;
        private Card[] tableCards;
        public int Id { get; }
        public GamePreferences Pref { get; set; }
        public List<Player> Seats { get; }
        public Deck Cards { get; set; }
        public int RoundNumber { get; private set; }
        public int Pot { get; set; }
        public int CurrentStake { get; private set; }
        public int SmallBlind { get; }
        public int BigBlind { get; }
        public bool IsActive { get; }
        public int StartCounter { get; set; }
        public League League { get; set; }
        public Player PreviousPlayer { get; set; }
        public Game(GamePreferences pref)
        {
            counter++;
            Id = counter;
            Pref = pref;
            Seats = new List<Player>();
            spectators = new List<Spectator>();
            tableCards = new Card[5];
            Cards = new Deck();
            Pot = 0;
            BigBlind = Pref.MinBet;
            SmallBlind = BigBlind / 2;
            CurrentStake = 0;
            RoundNumber = 0;
            StartCounter = 0;
            IsActive = false;
        }

        private void DealCards()
        {
            //add cards to players
            for (int i = 0; i < Seats.Count; i++)
            {
                if (Seats[i] != null)
                    Seats[i].AddHand(Cards.GetCard(), Cards.GetCard());
            }
        }
        private void AddCardToTable()
        {
            if (RoundNumber == 2)
            {
                tableCards[0] = Cards.GetCard();
                tableCards[1] = Cards.GetCard();
                tableCards[2] = Cards.GetCard();
            }
            else if (RoundNumber >= 3)
            {
                tableCards[RoundNumber] = Cards.GetCard();
            }
        }

        public void Start()
        {
            DealCards(); // deal 2 cards for each player, take money from each
            PlaceSmallBlind(Seats[0]);
            PlaceBigBlind(Seats[1]);
            PreviousPlayer = Seats[1];
            RoundNumber = 1;
        }

        public void UpdateState()
        {
            if (RoundNumber > 4) // should not happen, game must notify players when it ends......
                return;
            Player winner = null;
            int foldedCount = 0;
            foreach (Player p in Seats)
            {
                if (p.Folded)
                    foldedCount++;
                else
                    winner = p;
            }
            if (foldedCount == Seats.Count - 1 && winner != null)
            {
                Console.WriteLine("The winner is (because everyone folded): " + winner.Username);
                return;
            }


            int finishRoundCounter = 0;
            for (int i = 0; i < Seats.Count; i++)
            {
                if (!Seats[i].MadeMove && !Seats[i].Folded)
                    return;
                if (Seats[i].ChipBalance == 0 || Seats[i].Folded)
                {
                    finishRoundCounter++;
                }
                else
                {
                    bool finished = true;
                    for (int j = 0; j < Seats.Count && finished; j++)
                    {
                        if (Seats[i].AmountBetOnCurrentRound < Seats[j].AmountBetOnCurrentRound)
                        {
                            finished = false;
                        }
                    }
                    if (finished)
                        finishRoundCounter++;
                }
            }

            if (finishRoundCounter == Seats.Count)
            {
                RoundNumber++;
                
                if (RoundNumber > 4)
                {
                    winner = EvaluateWinner();

                    // should notify players that the game has ended...... and something about the winner
                    return;
                }
                

                CurrentStake = 0;
                AddCardToTable();
                foreach (Player p in Seats)
                {
                    p.MadeMove = false;
                    p.AmountBetOnCurrentRound = 0;
                }
                PreviousPlayer = Seats[Seats.Count - 1];
            }
        }


        public Player EvaluateWinner()
        {
            Player bestHand = null;
            int bestHandScore = 0;
            int currHandScore = 0;

            Console.WriteLine("Table cards: " + tableCards[0].getCardId() + " " + tableCards[1].getCardId() + " " +
                              tableCards[2].getCardId() + " " + tableCards[3].getCardId() + " " +
                              tableCards[4].getCardId());
            Console.WriteLine();
            foreach (var player in Seats)
            {
                if (!player.Folded)
                    Console.WriteLine(player.Username + " had the following hand:  " + player.Cards[0].getCardId() + " " + player.Cards[1].getCardId());
            }
            Console.WriteLine();
            for (int i = 0; i < Seats.Count; i++)
            {
                if (!Seats[i].Folded)
                {
                    currHandScore = Seats[i].GetBestHand(tableCards);
                    if (currHandScore > bestHandScore)
                    {
                        bestHandScore = currHandScore;
                        bestHand = Seats[i];
                    }
                }
            }
            bestHand.ChipBalance = Pot;
            Console.WriteLine("\nThe winner is: " + bestHand.Username);
            return bestHand;
        }

        public Player GetPlayerById(int playerID)
        {
            foreach (Player player in Seats)
            {
                if (player != null && player.PlayerId == playerID)
                    return player;
            }
            return null;
        }

        public Player GetPlayerByUsername(string username)
        {
            foreach (Player player in Seats)
            {
                if (player != null && player.Username == username)
                    return player;
            }
            return null;
        }

        public bool RemovePlayer(Player player)
        {
            Player p;
            for (int i = 0; i < Seats.Count; i++)
            {
                p = Seats[i];
                if (p != null && p.PlayerId == player.PlayerId)
                {
                    Seats.Remove(p);
                    return true;
                }
            }
            return false;
        }

        public Player AddPlayer(User user)
        {
            if (user.Rank.NumOfCalibrationsLeft == 0 && user.League.Id != this.League.Id)
                throw new LeagueMismatchException("The user " + user.Username + " is in league \"" + user.League.Name + "\" but the game is in league \"" + this.League.Name + "\".");
            if (IsActive)
                throw new GameAlreadyStartedException("The user " + user.Username + " tried to join game #" + Id + " but the game has already started.");
            if (Seats.Count == Pref.MaxPlayers)
                throw new FullTableException();
            if (IsPlayerExist(user.Username))
                throw new AlreadyJoinedGameException("The user " + user.Username + " has already joined game #" + Id);
            Player p;
            if (Pref.ChipPolicy == 0)
            {
                if (user.MoneyBalance < Pref.BuyIn + Pref.MinBet)
                    throw new notEnoughMoneyException(user.MoneyBalance.ToString(), Pref.BuyIn.ToString());
                int m = user.DecreaseMoney(Pref.BuyIn);
                p = new Player(m, user.Username);
                AddPlayerToSeat(p);
                return p;
            }
            p = new Player(Pref.ChipPolicy, user.Username);
            AddPlayerToSeat(p);
            return p;
        }

        private int AddPlayerToSeat(Player player)
        {
            if (Seats.Count < Pref.MaxPlayers)
                Seats.Add(player);
            return -1;
        }

        public Spectator AddSpectatingPlayer(User user)
        {
            if (!Pref.SpectateGame)
                throw new DomainException("game not spectatable");
            if (IsSpectatorExist(user.Username))
                throw new DomainException("the user " + user + " is already watching this game");
            Spectator spec = new Spectator(user.Username);
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

        public bool IsSpectatorExist(string name)
        {
            foreach (Spectator s in spectators)
                if (s.Name.Equals(name))
                    return true;
            return false;
        }

        public bool IsPlayerExist(string name)
        {
            foreach (Player p in Seats)
                if (p != null && p.Username.Equals(name))
                    return true;
            return false;
        }

        public void PlaceSmallBlind(Player player)
        {
            int balance = player.ChipBalance;
            if (balance >= SmallBlind && SmallBlind >= CurrentStake || SmallBlind == balance)
            {
                CurrentStake = SmallBlind;
                Pot += SmallBlind;
                player.ChipBalance -= SmallBlind;
                player.AmountBetOnCurrentRound += SmallBlind;
            }
        }

        public void PlaceBigBlind(Player player)
        {
            int balance = player.ChipBalance;
            if (balance >= BigBlind && BigBlind >= CurrentStake || BigBlind == balance)
            {
                CurrentStake = BigBlind;
                Pot += BigBlind;
                player.ChipBalance -= BigBlind;
                player.AmountBetOnCurrentRound += BigBlind;
                player.MadeMove = true;
            }
        }

        public bool Bet(Player player, int amount)
        {
            if (!IsCurrentPlayer(player))
                throw new NotCurrentPlayerException("It is not " + player.Username + "'s turn yet.");
            int balance = player.ChipBalance;
            if (balance >= amount && amount >= CurrentStake || amount == balance)
            {
                CurrentStake = amount;
                Pot += amount;
                player.ChipBalance -= amount;
                player.AmountBetOnCurrentRound += amount;
                PreviousPlayer = player;
                player.MadeMove = true;
                UpdateState();
                return true;
            }
            throw new BetFailedException("Player " + player.Username + " failed to make bet of amount " + amount);
        }

        public bool Call(Player player)
        {
            if (!IsCurrentPlayer(player))
                throw new NotCurrentPlayerException("It is not " + player.Username + "'s turn yet.");
            if (CurrentStake == 0)
            {
                // no bet was made yet
                throw new NoBetToCallException("The player " + player.Username +
                                               " can't call because the current stake is 0.");
            }
            int amount = CurrentStake - player.AmountBetOnCurrentRound;
            if (player.ChipBalance < amount) // not enough money
                throw new NotEnoughChipsException("The player " + player.Username + " can't call b/c he has " +
                                                  player.ChipBalance + " chips, and the current stake is " +
                                                  CurrentStake + ".");

            Pot += amount;
            player.ChipBalance -= amount;
            player.AmountBetOnCurrentRound += amount;
            PreviousPlayer = player;
            player.MadeMove = true;
            UpdateState();
            return true;
        }
        public bool Check(Player player)
        {
            if (!IsCurrentPlayer(player))
                throw new NotCurrentPlayerException("It is not " + player.Username + "'s turn yet.");
            if (RoundNumber == 1)
            {
                return Call(player);
            }
            PreviousPlayer = player;
            player.MadeMove = true;
            UpdateState();
            return true;
        }

        public bool Fold(Player player)
        {
            if (!IsCurrentPlayer(player))
                throw new NotCurrentPlayerException("It is not " + player.Username + "'s turn yet.");
            player.Folded = true;
            PreviousPlayer = player;
            player.MadeMove = true;
            UpdateState();
            return true;
        }

        private bool IsCurrentPlayer(Player player)
        {
            Player currentPlayer = Seats[(Seats.IndexOf(PreviousPlayer) + 1) % Seats.Count];
            while (currentPlayer.Folded)
            {
                PreviousPlayer = currentPlayer;
                currentPlayer = Seats[(Seats.IndexOf(PreviousPlayer) + 1) % Seats.Count];
            }
            if (player.PlayerId != currentPlayer.PlayerId)
                return false;
            return true;
        }
    }
}
