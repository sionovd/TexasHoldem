﻿using System;
using System.Collections.Generic;
using Domain.DomainLayerExceptions;
using Domain.ObserverFramework;
using Domain.UserModule;

namespace Domain.GameModule
{
    public interface IGame
    {
        void AddPlayer(User user, Player player);
        void Start();
        bool EvaluateWinner();
        bool RemovePlayer(Player player);
        Spectator AddSpectatingPlayer(User user);
        bool RemoveSpectatingPlayer(Spectator spectator);
        bool IsBetValid(int chipBalance, int amount);
        
        bool IsPlayerExist(string name);
        bool IsSpectatorExist(string name);
        Player GetPlayerByUsername(string username);
        Spectator GetSpectatorByUsername(string username);
        Player GetPlayerById(int playerId);

        GamePreferences Pref { get; set; }
        List<Player> Seats { get; }
        int Id { get; set; }
        GameState State { get; set; }
        int BigBlind { get; set; }
        League League { get; set; }
        GameLog Logger { get; set; }
        Subject Subject { get; set; }
        Player Winner { get; set; }
        Player PreviousPlayer { get; set; }
        void UpdateState();
        Player GetCurrentPlayer();
    }

    public class GameState
    {
        public Card[] TableCards { get; }
        public Player CurrentPlayer { get; set; }
        public int RoundNumber { get; set; }
        public int Pot { get; set; }
        public int CurrentStake { get; set; }
        public Player BigBlind { get; set;}
        public Player SmallBlind { get; set; }
        public bool Over { get; set; }

        public GameState()
        {
            TableCards = new Card[5];
            RoundNumber = 1;
            Pot = 0;
            CurrentStake = 0;
            Over = false;
        }
    }

    public class Game : IGame
    {
        private List<Spectator> spectators;
        
        public int Id { get; set; }
        public GamePreferences Pref { get; set; }
        public List<Player> Seats { get; set; }
        public Deck Cards { get; set; }
        public GameState State { get; set; }
        public int SmallBlind { get; set; }
        public int BigBlind { get; set; }
        public bool IsActive { get; set; }
        public int StartCounter { get; set; }
        public League League { get; set; }
        public GameLog Logger { get; set; }
        public Subject Subject { get; set; }
        public Player Winner { get; set; }
        public Player PreviousPlayer { get; set; }
        public Game(int id, GamePreferences pref)
        {
            Id = id;
            Logger = new GameLog(this);
            Pref = pref;
            Seats = new List<Player>();
            Player.counter = 0;
            spectators = new List<Spectator>();
            Cards = new Deck();
            BigBlind = Pref.MinBet;
            SmallBlind = BigBlind / 2;
            State = new GameState();
            StartCounter = 0;
            IsActive = false;
            Subject = new Subject();
        }

        private void DealCards()
        {
            //add cards to players
            foreach (Player player in Seats)
            {
                if (player != null)
                {
                    player.AddHand(Cards.GetCard(), Cards.GetCard());
                    Logger.LogPlayerCards(player, player.Cards);
                }
            }
        }
        private void AddCardToTable()
        {
            if (State.RoundNumber == 2)
            {
                State.TableCards[0] = Cards.GetCard();
                State.TableCards[1] = Cards.GetCard();
                State.TableCards[2] = Cards.GetCard();
            }
            else if (State.RoundNumber >= 3)
            {
                State.TableCards[State.RoundNumber] = Cards.GetCard();
            }
        }

        public void Start()
        {
            DealCards(); // deal 2 cards for each player, take money from each
            State.RoundNumber = 1;
            PlaceSmallBlind(Seats[0]);
            PlaceBigBlind(Seats[1]);
            PreviousPlayer = Seats[1];
            State.CurrentPlayer = GetCurrentPlayer();
            IsActive = true;

            Logger.LogGameState();
        }

        public void UpdateState()
        {
            if (State.RoundNumber > 4) // should not happen, game must notify players when it ends......
                return;
            Player winner = null;
            int foldedCount = 0;
            State.CurrentPlayer = GetCurrentPlayer();
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
                winner.ChipBalance += State.Pot;
                Winner = winner;
                Logger.LogEndGame(true, false);
                State.Over = true;
                return;
            }


            int finishRoundCounter = 0;
            for (int i = 0; i < Seats.Count; i++)
            {
                if (!Seats[i].MadeMove && !Seats[i].Folded)
                {
                    Logger.LogGameState();
                    return;
                }
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
                State.RoundNumber++;
                if (State.RoundNumber > 4)
                {
                    bool isSplitPot = !EvaluateWinner();
                    Logger.LogEndGame(false, isSplitPot);
                    State.Over = true;
                    return;
                }
                State.CurrentStake = 0;
                AddCardToTable();
                foreach (Player p in Seats)
                {
                    p.MadeMove = false;
                    p.AmountBetOnCurrentRound = 0;
                }
                PreviousPlayer = Seats[Seats.Count - 1];
                State.CurrentPlayer = GetCurrentPlayer();
            }
            Logger.LogGameState();
        }


        public bool EvaluateWinner()
        {
            Player bestHand = null;
            int bestHandScore = 0;

            Console.Write("Table cards: ");
            for (int i = 0; i < State.TableCards.Length; i++)
            {
                if(State.TableCards[i] != null)
                    Console.Write(State.TableCards[i].getCardId() + " ");
            }
            Console.WriteLine();
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
                    int currHandScore = Seats[i].GetBestHand(State.TableCards);
                    if (currHandScore > bestHandScore)
                    {
                        bestHandScore = currHandScore;
                        bestHand = Seats[i];
                    }
                }
            }
            if (bestHand.IsHandCommunity(State.TableCards))
            {
                Winner = bestHand;
                return false;
            }
            bestHand.ChipBalance += State.Pot;
            Console.WriteLine("\nThe winner is: " + bestHand.Username);
            Winner = bestHand;
            return true;
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

        public Spectator GetSpectatorByUsername(string username)
        {
            foreach (var spectator in spectators)
            {
                if (spectator != null && spectator.Username == username)
                    return spectator;
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
                    if (Seats.Count > 1 && IsActive)
                    {
                            Logger.LogGameState();
                    }
                    if (Seats.Count == 1 && IsActive)
                    {
                        Winner = Seats[0];
                        Logger.LogEndGame(true, false);
                        State.Over = true;
                    }
                    return true;
                }
            }
            return false;
        }

        public void AddPlayer(User user, Player player)
        {
            if (user.Stats.NumOfGames > 10 && user.League.Id != League.Id)
                throw new LeagueMismatchException("The user " + user.Username + " is in league \"" + user.League.Name + "\" but the game is in league \"" + League.Name + "\".");
            if (IsActive)
                throw new GameAlreadyStartedException("The user " + user.Username + " tried to join game #" + Id + " but the game has already started.");
            if (Seats.Count == Pref.MaxPlayers)
                throw new FullTableException();
            if (IsPlayerExist(user.Username))
                throw new AlreadyJoinedGameException("The user " + user.Username + " has already joined game #" + Id);
            if (Pref.ChipPolicy == 0)
            {
                if (user.MoneyBalance < Pref.BuyIn + Pref.MinBet)
                    throw new notEnoughMoneyException(user.MoneyBalance.ToString(), Pref.BuyIn.ToString());
                user.MoneyBalance = user.MoneyBalance - Pref.BuyIn;
                player.ChipBalance = user.MoneyBalance;
                AddPlayerToSeat(player);
            }
            else
            {
                if (user.MoneyBalance < Pref.BuyIn + Pref.ChipPolicy)
                    throw new notEnoughMoneyException(user.MoneyBalance.ToString(), Pref.BuyIn.ToString());
                user.MoneyBalance = user.MoneyBalance - Pref.ChipPolicy;
                player.ChipBalance = Pref.ChipPolicy;
                player.OriginalBalance = Pref.ChipPolicy;
                AddPlayerToSeat(player);
            }
        }

        private void AddPlayerToSeat(Player player)
        {
            if (Seats.Count < Pref.MaxPlayers)
                Seats.Add(player);
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

        public bool IsBetValid(int chipBalance, int amount)
        {
            if (chipBalance >= amount && amount >= State.CurrentStake)
                return true;
            return false;
        }

        public bool IsSpectatorExist(string name)
        {
            foreach (Spectator s in spectators)
                if (s.Username.Equals(name))
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
            if (balance >= SmallBlind && SmallBlind >= State.CurrentStake || SmallBlind == balance)
            {
                State.CurrentStake = SmallBlind;
                State.Pot += SmallBlind;
                player.ChipBalance -= SmallBlind;
                player.AmountBetOnCurrentRound += SmallBlind;
                State.SmallBlind = player;
            }
        }

        public void PlaceBigBlind(Player player)
        {
           
            int balance = player.ChipBalance;
            if (balance >= BigBlind && BigBlind >= State.CurrentStake || BigBlind == balance)
            {
                State.CurrentStake = BigBlind;
                State.Pot += BigBlind;
                player.ChipBalance -= BigBlind;
                player.AmountBetOnCurrentRound += BigBlind;
                State.BigBlind = player;
                player.MadeMove = true;
            }
        }

        public Player GetCurrentPlayer()
        {
            Player currentPlayer = Seats[(Seats.IndexOf(PreviousPlayer) + 1) % Seats.Count];
            while (currentPlayer.Folded)
            {
                PreviousPlayer = currentPlayer;
                currentPlayer = Seats[(Seats.IndexOf(PreviousPlayer) + 1) % Seats.Count];
            }
            return currentPlayer;
        }
    }
}
