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

        public Player(int moneyBalance, string name)
        {
            counter++;
            PlayerId = counter;
            this.MoneyBalance = moneyBalance;
            this.Name = name;
            this.Cards = new Card[2];
            this.AlreadyPayed = 0;
            Position = -1;
        }

        public Player(string name)//???
        {
            counter++;
            PlayerId = counter;
            this.Name = name;
            Position = -1;
        }
        
        public void GetUp()
        {
            this.Position = -1;
        }

        public void TakeSit(int pos)
        {
            this.Position = pos;
        }

        public int MoneyBalance { get; set; }

        public string Name { get; set; }

        public int Position { get; set; }

        public int PlayerId { get; set; }

        public Card[] Cards { get; set; }

        public int AlreadyPayed { get; set; }
    }
}