using System;
using System.Collections.Generic;
using Domain.DomainLayerExceptions;
using Domain.ObserverFramework;
using Domain.UserModule;

namespace Domain.GameModule
{
    public interface IGame
    {
        Player AddPlayer(User user);
        void Start();
        void EvaluateWinner();
        bool RemovePlayer(Player player);
        Spectator AddSpectatingPlayer(User user);
        bool RemoveSpectatingPlayer(Spectator spectator);
        bool Bet(Player player, int amount);
        bool Check(Player player);
        bool Fold(Player player);
        bool Call(Player player);
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
        private static int _counter;
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
        public Game(GamePreferences pref)
        {
            _counter++;
            Id = _counter;
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
                    /*Logger.LogTurn(null,
                        "Deal: " + player.PlayerId + " , Hand: " + player.Cards[0].getCardId() + " " +
                        player.Cards[1].getCardId());*/
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
                Logger.LogTurn(null, "Table: " + State.TableCards[0].getCardId() + " " + State.TableCards[1].getCardId() + " " + State.TableCards[2].getCardId());
            }
            else if (State.RoundNumber >= 3)
            {
                State.TableCards[State.RoundNumber] = Cards.GetCard();
                Logger.LogTurn(null, "Add Table: " + State.TableCards[State.RoundNumber].getCardId());
            }
        }

        public void Start()
        {
            DealCards(); // deal 2 cards for each player, take money from each
            State.RoundNumber = 1;
            PlaceSmallBlind(Seats[0]);
            PlaceBigBlind(Seats[1]);
            PreviousPlayer = Seats[1];
            this.State.CurrentPlayer = GetCurrentPlayer();
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
                winner.ChipBalance = State.Pot;
                Winner = winner;
                Logger.LogEndGame(true);
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
                    EvaluateWinner();
                    Logger.LogEndGame(false);
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


        public void EvaluateWinner()
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
            bestHand.IsHandCommunity(State.TableCards);
            bestHand.ChipBalance = State.Pot;
            Console.WriteLine("\nThe winner is: " + bestHand.Username);
            Winner = bestHand;
            Logger.LogTurn(null, "Winner: " + bestHand.PlayerId);
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
                        Logger.LogEndGame(true);
                        State.Over = true;
                    }
                    return true;
                }
            }
            return false;
        }

        public Player AddPlayer(User user)
        {
            if (user.Stats.NumOfGames > 10 && user.League.Id != League.Id)
                throw new LeagueMismatchException("The user " + user.Username + " is in league \"" + user.League.Name + "\" but the game is in league \"" + League.Name + "\".");
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
                Logger.LogTurn(player, "Smallblind: " + SmallBlind);
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
                Logger.LogTurn(player, "Bigblind: " + BigBlind);
            }
        }

        public bool Bet(Player player, int amount)
        {
            if (GetCurrentPlayer().PlayerId != player.PlayerId)
                throw new NotCurrentPlayerException("It is not " + player.Username + "'s turn yet.");
            int balance = player.ChipBalance;
            if (balance >= amount && amount >= State.CurrentStake)
            {
                State.CurrentStake = amount;
                State.Pot += amount;
                player.ChipBalance -= amount;
                player.AmountBetOnCurrentRound += amount;
                PreviousPlayer = player;
                player.MadeMove = true;
                UpdateState();
                Logger.LogTurn(player, "Bet: " + amount);
                return true;
            }
            throw new BetFailedException("Player " + player.Username + " failed to make bet of amount " + amount);
        }

        public bool Call(Player player)
        {
            if (GetCurrentPlayer().PlayerId != player.PlayerId)
                throw new NotCurrentPlayerException("It is not " + player.Username + "'s turn yet.");
            if (State.CurrentStake == 0)
            {
                throw new NoBetToCallException("The player " + player.Username +
                                               " can't call because the current stake is 0.");
            }
            int amount = State.CurrentStake - player.AmountBetOnCurrentRound;
            if (player.ChipBalance == 0)
                throw new NoMoreChipsException("The player " + player.Username +
                                                  " can't call b/c he has no chips left");
            if (player.ChipBalance < amount)
                amount = player.ChipBalance;
            State.Pot += amount;
            player.ChipBalance -= amount;
            player.AmountBetOnCurrentRound += amount;
            PreviousPlayer = player;
            player.MadeMove = true;
            UpdateState();
            Logger.LogTurn(player, "Call: " + State.CurrentStake);
            return true;
        }
        public bool Check(Player player)
        {
            if (GetCurrentPlayer().PlayerId != player.PlayerId)
                throw new NotCurrentPlayerException("It is not " + player.Username + "'s turn yet.");
            if(State.CurrentStake > 0)
                throw new DomainException("can't check because the current stake is greater than 0");
            if (State.RoundNumber == 1)
            {
                return Call(player);
            }
            PreviousPlayer = player;
            player.MadeMove = true;
            UpdateState();
            Logger.LogTurn(player, "Check: ");
            return true;
        }

        public bool Fold(Player player)
        {
            if (GetCurrentPlayer().PlayerId != player.PlayerId)
                throw new NotCurrentPlayerException("It is not " + player.Username + "'s turn yet.");
            player.Folded = true;
            PreviousPlayer = player;
            player.MadeMove = true;
            UpdateState();
            Logger.LogTurn(player, "Fold: ");
            return true;
        }

        private Player GetCurrentPlayer()
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
