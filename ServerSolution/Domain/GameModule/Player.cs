using System;
using System.Collections.Generic;

namespace TexasHoldem.GameModule
{
    public class Player
    {
        private static int counter = 0;

        public Player(int chipBalance, string username)
        {
            counter++;
            PlayerId = counter;
            ChipBalance = chipBalance;
            Username = username;
            Cards = new Card[2];
            AmountBetOnCurrentRound = 0;
            Folded = false;

        }

        public int GetBestHand(Card[] tableCards)
        {
            Card[] unionCards = new Card[7];
            for (int i = 0; i < tableCards.Length; i++)
            {
                unionCards[i] = tableCards[i];
            }
            unionCards[5] = this.Cards[0];
            unionCards[6] = this.Cards[1];
            // need to evaluate Hand
            HandEvaluator handEval = new HandEvaluator(unionCards);
            Console.Write(this.Username + "'s best hand is: ");
            return handEval.Evaluate();
        }

        public void AddHand(Card c1, Card c2)
        {
            Cards = new[] { c1, c2 };
        }

        public int ChipBalance { get; set; }

        public int AmountBetOnCurrentRound { get; set; }

        public bool Folded { get; set; }

        public bool MadeMove { get; set; }

        public string Username { get; set; }

        public int PlayerId { get; set; }

        public Card[] Cards { get; set; }
    }
}