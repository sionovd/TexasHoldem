using System;
using Domain.DomainLayerExceptions;

namespace Domain.GameModule
{
    public class Player
    {
        internal static int counter;

        public Player(IGame game, int chipBalance, string username)
        {
            counter++;
            PlayerId = counter;
            ChipBalance = chipBalance;
            Username = username;
            Cards = new Card[2];
            AmountBetOnCurrentRound = 0;
            Folded = false;
            Game = game;
        }

        public int GetBestHand(Card[] tableCards)
        {
            Card[] unionCards = new Card[7];
            for (int i = 0; i < tableCards.Length; i++)
            {
                unionCards[i] = tableCards[i];
            }
            unionCards[5] = Cards[0];
            unionCards[6] = Cards[1];
            // need to evaluate Hand
            HandEvaluator handEval = new HandEvaluator(unionCards);
            Console.Write(Username + "'s best hand is: ");
            BestHandValue = handEval.Evaluate();
            
            return BestHandValue;
        }

        public bool IsHandCommunity(Card[] tableCards)
        {
            HandEvaluator communityEval = new HandEvaluator(tableCards);
            int commVal = communityEval.Evaluate();
            if (BestHandValue == commVal)
            {
                return true;
            }
            return false;
        }

        public void AddHand(Card c1, Card c2)
        {
            Cards = new[] { c1, c2 };
        }

        public int BestHandValue { get; set; }

        public bool ReadyToStart { get; set; }

        public int ChipBalance { get; set; }

        public int OriginalBalance { get; set; }

        public int AmountBetOnCurrentRound { get; set; }

        public bool Folded { get; set; }

        public bool MadeMove { get; set; }

        public string Username { get; set; }

        public int PlayerId { get; set; }

        public Card[] Cards { get; set; }

        public IGame Game { get; }

        public bool Bet(int amount)
        {
            if (Game.GetCurrentPlayer().PlayerId != PlayerId)
                throw new NotCurrentPlayerException("It is not " + Username + "'s turn yet.");
            if (Game.IsBetValid(ChipBalance, amount))
            {
                Game.State.CurrentStake = amount;
                Game.State.Pot += amount;
                ChipBalance -= amount;
                AmountBetOnCurrentRound += amount;
                Game.PreviousPlayer = this;
                MadeMove = true;
                Game.UpdateState();
                return true;
            }
            throw new BetFailedException("Player " + Username + " failed to make bet of amount " + amount);
        }

        public bool Call()
        {
            if (Game.GetCurrentPlayer().PlayerId != PlayerId)
                throw new NotCurrentPlayerException("It is not " + Username + "'s turn yet.");
            if (Game.State.CurrentStake == 0)
            {
                throw new NoBetToCallException("The player " + Username +
                                               " can't call because the current stake is 0.");
            }
            int amount = Game.State.CurrentStake - AmountBetOnCurrentRound;
            if (ChipBalance == 0)
                throw new NoMoreChipsException("The player " + Username +
                                               " can't call b/c he has no chips left");
            if (ChipBalance < amount)
                amount = ChipBalance;
            Game.State.Pot += amount;
            ChipBalance -= amount;
            AmountBetOnCurrentRound += amount;
            Game.PreviousPlayer = this;
            MadeMove = true;
            Game.UpdateState();
            return true;
        }

        public bool Check()
        {
            if (Game.GetCurrentPlayer().PlayerId != PlayerId)
                throw new NotCurrentPlayerException("It is not " + Username + "'s turn yet.");
            if(Game.State.CurrentStake > 0)
                throw new DomainException("can't check because the current stake is greater than 0");
            if (Game.State.RoundNumber == 1)
            {
                return Call();
            }
            Game.PreviousPlayer = this;
            MadeMove = true;
            Game.UpdateState();
            return true;
        }

        public bool Fold()
        {
            if (Game.GetCurrentPlayer().PlayerId != PlayerId)
                throw new NotCurrentPlayerException("It is not " + Username + "'s turn yet.");
            Folded = true;
            Game.PreviousPlayer = this;
            MadeMove = true;
            Game.UpdateState();
            return true;
        }
    }
}