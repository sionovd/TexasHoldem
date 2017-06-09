using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communication.GameLogInfo
{ 
   public class PlayerInfo 
    {
        private int PlayerID { get; }
        public string Username { get; set;}
        public int MoneyBalance { get; set;}
        public int AmountBetOnCurrentRound { get; set; }


        public PlayerInfo(int playerID, string username, int moneyBalance , int amountBetOnCurrentRound)
        {
            this.PlayerID = playerID;
            this.Username = username;
            this.MoneyBalance = moneyBalance;
            this.AmountBetOnCurrentRound = amountBetOnCurrentRound;
        }

        public PlayerInfo Parse(string content)
        {
            return this;
        }
    }

}
