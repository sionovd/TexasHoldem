using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;

namespace Communication.GameLogInfo
{ 
   public class PlayerInfo 
    {
        public int PlayerID { get; set; }
        public string Username { get; set;}
        public int MoneyBalance { get; set;}
        public int AmountBetOnCurrentRound { get; set; }
        public bool IsFold { get; set; }

        public PlayerInfo()
        {
            
        }
        public PlayerInfo(string content)
        {
            PlayerInfo playerInfo = new JavaScriptSerializer().Deserialize<PlayerInfo>(content);
            this.PlayerID = playerInfo.PlayerID;
            this.Username = playerInfo.Username;
            this.MoneyBalance = playerInfo.MoneyBalance;
            this.AmountBetOnCurrentRound = playerInfo.AmountBetOnCurrentRound;
            this.IsFold = playerInfo.IsFold;
        }
        public PlayerInfo(int playerID, string username, int moneyBalance , int amountBetOnCurrentRound, bool isFold)
        {
            this.PlayerID = playerID;
            this.Username = username;
            this.MoneyBalance = moneyBalance;
            this.AmountBetOnCurrentRound = amountBetOnCurrentRound;
            this.IsFold = isFold;
        }

        public static string ConvertToString(PlayerInfo playerInfo)
        {
            return new JavaScriptSerializer().Serialize(playerInfo);
        }

    }

}
