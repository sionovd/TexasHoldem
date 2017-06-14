using System.Web.Script.Serialization;

namespace Domain.GameLogInfo
{
    public class PlayerInfo
    {
        public int PlayerID { get; set; }
        public string Username { get; set; }
        public int MoneyBalance { get; set; }
        public int AmountBetOnCurrentRound { get; set; }
        public bool IsFold { get; set; }

        public PlayerInfo()
        {

        }
        public PlayerInfo(string content)
        {
            PlayerInfo playerInfo = new JavaScriptSerializer().Deserialize<PlayerInfo>(content);
            PlayerID = playerInfo.PlayerID;
            Username = playerInfo.Username;
            MoneyBalance = playerInfo.MoneyBalance;
            AmountBetOnCurrentRound = playerInfo.AmountBetOnCurrentRound;
            IsFold = playerInfo.IsFold;
        }
        public PlayerInfo(int playerID, string username, int moneyBalance, int amountBetOnCurrentRound, bool isFold)
        {
            PlayerID = playerID;
            Username = username;
            MoneyBalance = moneyBalance;
            AmountBetOnCurrentRound = amountBetOnCurrentRound;
            IsFold = isFold;
        }

    }

}
