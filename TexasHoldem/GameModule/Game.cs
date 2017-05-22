using System;
using System.Collections.Generic;
using TexasHoldem.UserModule;

namespace TexasHoldem.GameModule
{
    public interface IGame
    {
        Player AddPlayer(User user);
        Player Play();
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
        Player[] Seats { get; }
        int Id { get; }
        int Pot { get; }
        int NumOfPlayers { get; }
        int RoundNumber { get; }
        int BigBlind { get; }
        int CurrentStake { get; }
        League League { get; set; }
    }

    public class Game : IGame
    {
        private static int counter = 0;
        private List<Spectator> spectators;
        private Card[] tableCards;
        public int NumOfPlayers { get; private set; }
        public int Id { get; }
        public GamePreferences Pref { get; set; }
        public Player[] Seats { get; }
        public Deck Cards { get; set; }
        public int RoundNumber { get; private set; }
        public int Pot { get; private set; }
        public int CurrentStake { get; private set; }
        public int SmallBlind { get; }
        public int BigBlind { get; }
        public bool IsActive { get; private set; }
        public League League { get; set; }
        public Game(GamePreferences pref)
        {
            counter++;
            Id = counter;
            Pref = pref;
            Seats = new Player[pref.MaxPlayers];
            spectators = new List<Spectator>();
            tableCards = new Card[5];
            Cards = new Deck();
            Pot = 0;
            NumOfPlayers = 0;
            BigBlind = Pref.MinBet;
            SmallBlind = BigBlind / 2;
            CurrentStake = 0;
            RoundNumber = 0;
            IsActive = false;
        }

        private void DealCards()
        {
            //add cards to players
            for (int i = 0; i < Seats.Length; i++)
            {
                Seats[i].AddHand(Id, Cards.GetCard(), Cards.GetCard());
            }
        }
        private void AddCardToTable(int cardNum)
        {
            if (cardNum == 3)
            {
                tableCards[0] = Cards.GetCard();
                tableCards[1] = Cards.GetCard();
                tableCards[2] = Cards.GetCard();
            }
            else if (cardNum >= 4)
            {
                tableCards[cardNum] = Cards.GetCard();
            }
        }
        public Player Play()
        {
            bool finishedRound = false;
            int numOfCardsToShow = 3;
            int seatIndex = 2;
            int finishCounter = 0;

            DealCards(); // deal 2 cards for each player, take money from each
            PlaceSmallBlind(Seats[0]);
            PlaceBigBlind(Seats[1]);
            for (RoundNumber = 1; RoundNumber <= 4; RoundNumber++)
            {
                while (!finishedRound)
                {
                    Player currentPlayer = Seats[seatIndex % Seats.Length];
                    if (currentPlayer != null)
                    {
                        currentPlayer.PlayMove();
                    }
                    seatIndex++;
                    if (seatIndex >= Seats.Length) //check if done round after bets or everybody called/folded/checked and we done round
                    {
                        for (int i = 0; i < Seats.Length; i++)
                        {
                            if (Seats[i] != null && (Seats[i].ChipBalance == 0 ||
                                                     Seats[i].Folded))
                            {
                                finishCounter++;
                            }
                            else if (Seats[i] == null)
                            {
                                finishCounter++;
                            }
                            else
                            {
                                bool finished = true;
                                for (int j = 0; j < Seats.Length && finished; j++)
                                {
                                    if (Seats[j] != null && Seats[i].AmountBetOnCurrentRound < Seats[j].AmountBetOnCurrentRound)
                                    {
                                        finished = false;
                                    }
                                }
                                if (finished)
                                    finishCounter++;
                            }
                        }
                        if (finishCounter == Seats.Length)
                        {
                            finishedRound = true;
                        }
                    }

                }
                seatIndex = 0;
                CurrentStake = 0;
                AddCardToTable(numOfCardsToShow);
                numOfCardsToShow++;
                foreach (Player p in Seats)
                    if (p != null)
                        p.AmountBetOnCurrentRound = 0;
            }

            Player winner = EvaluateWinner();
            return winner;
        }

        private Player EvaluateWinner()
        {
            Player bestHand = null;
            int bestHandScore = 0;
            int currHandScore = 0;
            for (int i = 0; i < Seats.Length; i++)
            {
                if (Seats[i] != null)
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
            for (int i = 0; i < Seats.Length; i++)
            {
                p = Seats[i];
                if (p != null && p.PlayerId == player.PlayerId)
                {
                    Seats[i] = null;
                    player.GetUp();
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
            if (NumOfPlayers == Pref.MaxPlayers)
                throw new FullTableException();
            Player p;
            if (Pref.ChipPolicy == 0)
            {
                if (user.MoneyBalance < Pref.BuyIn + Pref.MinBet)
                    throw new notEnoughMoneyException(user.MoneyBalance.ToString(), Pref.BuyIn.ToString());
                int m = user.DecreaseMoney(Pref.BuyIn);
                p = new Player(m, user.Username);
                p.TakeSeat(AddPlayerToSeat(p));
                NumOfPlayers++;
                return p;
            }
            p = new Player(Pref.ChipPolicy, user.Username);
            p.TakeSeat(AddPlayerToSeat(p));
            NumOfPlayers++;
            return p;
        }

        private int AddPlayerToSeat(Player player)
        {
            for (int i = 0; i < Seats.Length; i++)
                if (Seats[i] == null)
                {
                    Seats[i] = player;
                    return i;
                }
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
            foreach (Player p in Seats)
                if (p != null && p.PlayerId == player.PlayerId)
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
            }
        }

        public bool Bet(Player player, int amount)
        {
            int balance = player.ChipBalance;
            if (balance >= amount && amount >= CurrentStake || amount == balance)
            {
                CurrentStake = amount;
                Pot += amount;
                player.ChipBalance -= amount;
                player.AmountBetOnCurrentRound += amount;
                return true;
            }
            return false;
        }

        public bool Call(Player player)
        {
            if (CurrentStake == 0) // no bet was made yet
                return false;
            if (player.ChipBalance < CurrentStake) // not enough money
                return false;
            Pot += CurrentStake;
            player.ChipBalance -= CurrentStake;
            player.AmountBetOnCurrentRound += CurrentStake;
            return true;
        }
        public bool Check(Player player)
        {
            if (RoundNumber == 1)
            {
                return Call(player);
            }
            return true;
        }

        public bool Fold(Player player)
        {
            player.Folded = true;
            return true;
        }
    }
}
