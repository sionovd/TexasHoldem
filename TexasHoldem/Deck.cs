using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexasHoldem
{
    public class Deck
    {
        private List<Card> deckOfCards = null;
        public Deck()
        {
            deckOfCards = new List<Card>();
            InitDeck();
            ShuffleDeck();
        }

        private void InitDeck()
        {
            foreach (Cards card in Enum.GetValues(typeof(Cards)))
            {
                this.deckOfCards.Add(new Card(card));
            }
        }
        public Card GetCard()
        {
            Card card = this.deckOfCards[0];
            this.deckOfCards.RemoveAt(0);
            return card;
        }
        public int GetSize()
        {
            return deckOfCards.Count<Card>();
        }
        public List<Card> GetEnumeratableDeck()
        {
            return this.deckOfCards;
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
                tempCard = this.deckOfCards.ElementAt(temp);
                this.deckOfCards[temp] = this.deckOfCards[temp2];
                this.deckOfCards[temp2] = tempCard;
            }
        }
    }
}
