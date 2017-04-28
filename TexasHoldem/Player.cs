using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexasHoldem
{
    class Player
    {
        private static int playerId = 0;
        private int moneyBalance;
        private string name;
        private Card[] cards;

        public Player(int moneyBalance, string name)
        {
            playerId++;
            this.moneyBalance = moneyBalance;
            this.name = name;
            this.cards = new Card[2];
        }

        public int getPlayerId()
        {
            return playerId;
        }

        public int MoneyBalance
        {
            get
            {
                return moneyBalance;
            }

            set
            {
                moneyBalance = value;
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
