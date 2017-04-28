using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexasHoldem
{
    class Player
    {
        private int chips;
        private string name;
        private Card[] cards;

        public Player(int chips, string name)
        {
            this.chips = chips;
            this.name = name;
            this.cards = new Card[2];
        }

        public int Chips
        {
            get
            {
                return chips;
            }

            set
            {
                chips = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public Card[] Cards
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
    }
}
