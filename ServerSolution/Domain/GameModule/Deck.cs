using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.GameModule
{
    public class Deck
    {
        private List<Card> deckOfCards;
        public Deck()
        {
            deckOfCards = new List<Card>();
            InitDeck();
            ShuffleDeck();
        }

        private void InitDeck()
        {
            foreach (CardType card in Enum.GetValues(typeof(CardType)))
            {
                deckOfCards.Add(new Card(card));
            }
        }
        public Card GetCard()
        {
            Card card = deckOfCards[0];
            deckOfCards.RemoveAt(0);
            return card;
        }
        public int GetSize()
        {
            return deckOfCards.Count();
        }
        public List<Card> GetEnumeratableDeck()
        {
            return deckOfCards;
        }
        private void ShuffleDeck()
        {
            Random rng = new Random();
            int temp;
            int temp2;
            Card tempCard;
            int maxDeckSize = 52;
            for (int i = 0; i < 0x100; i++)
            {
                temp = rng.Next(maxDeckSize - 1);
                temp2 = rng.Next(maxDeckSize - 1);
                tempCard = deckOfCards.ElementAt(temp);
                deckOfCards[temp] = deckOfCards[temp2];
                deckOfCards[temp2] = tempCard;
            }
        }
    }
}
