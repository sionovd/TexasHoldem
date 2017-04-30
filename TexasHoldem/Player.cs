using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexasHoldem
{
    public class Player
    {
        public Player(int playerID)
        {
            // this = game.getPlayer(playerID);
        }

        private static int counter = 0;
        private int playerID;
        private int moneyBalance;
        private string name;
        private Card[] cards;
        private int position;

        public Player(int moneyBalance, string name)
        {
            counter++;
            playerID = counter;
            this.moneyBalance = moneyBalance;
            this.name = name;
            this.cards = new Card[2];
            this.AlreadyPayed = 0;
            position = -1;
        }

        public Player(string name)//???
        {
            counter++;
            playerID = counter;
            this.name = name;
            position = -1;
        }
        
        public void GetUp()
        {
            this.position = -1;
        }

        public void TakeSit(int pos)
        {
            this.position = pos;
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

        public int Position
        {
            get
            {
                return position;
            }

            set
            {
                position = value;
            }
        }

        public int PlayerId
        {
            get
            {
                return playerID;
            }

            set
            {
                playerID = value;
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

        public int AlreadyPayed
        {
            get
            {
                return AlreadyPayed;
            }

            set
            {
                AlreadyPayed = value;
            }
        }
    }
}