using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Communication.GameLogInfo
{
    public class GameInfo 
    {
        public int GameID { get; set; }
        public int PotSize { get; set; }
        public int CurrentStake { get; set; }
        public int PlayerTurnID { get; set; }
        public List<PlayerInfo> PlayersInfo { get; set; }
        public CardType[] TableCards { get; set; }

        public GameInfo(string content)
        {   GameInfo gameInfo = new JavaScriptSerializer().Deserialize<GameInfo>(content);
            this.GameID = gameInfo.GameID;
            this.PotSize = gameInfo.PotSize;
            this.CurrentStake = gameInfo.CurrentStake;
            this.PlayerTurnID = PlayerTurnID;
            this.PlayersInfo = PlayersInfo;
            this.TableCards = TableCards;
        }
        public GameInfo(int gameID, int potSize, int currentStake, int playerTurnID, List<PlayerInfo> playersInfo, CardType[] tableCards)
        {
            this.GameID = gameID;
            this.PotSize = potSize;
            this.CurrentStake = currentStake;
            this.PlayerTurnID = playerTurnID;
            this.PlayersInfo = playersInfo;
            this.TableCards = tableCards;

        }

    }
}
