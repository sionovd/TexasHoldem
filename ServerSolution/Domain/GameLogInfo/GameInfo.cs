using System.Collections.Generic;
using System.Web.Script.Serialization;
using Domain.GameModule;

namespace Domain.GameLogInfo
{
    public class GameInfo
    {
        public int GameID { get; set; }
        public int PotSize { get; set; }
        public int CurrentStake { get; set; }
        public int RoundNumber { get; set; }
        public int PlayerTurnID { get; set; }
        public int SmallBlindPlayerID { get; set; }
        public int BigBlindPlayerID { get; set; }
        public List<PlayerInfo> PlayersInfo { get; set; }
        public CardType[] TableCards { get; set; }




        public GameInfo()
        {

        }

        public GameInfo(string content)
        {
            GameInfo gameInfo = new JavaScriptSerializer().Deserialize<GameInfo>(content);
            this.GameID = gameInfo.GameID;
            this.PotSize = gameInfo.PotSize;
            this.CurrentStake = gameInfo.CurrentStake;
            this.PlayerTurnID = gameInfo.PlayerTurnID;
            this.PlayersInfo = gameInfo.PlayersInfo;
            this.TableCards = gameInfo.TableCards;
            this.SmallBlindPlayerID = gameInfo.SmallBlindPlayerID;
            this.BigBlindPlayerID = gameInfo.BigBlindPlayerID;
        }
        public GameInfo(int gameID, int potSize, int currentStake, int roundNumber, int playerTurnID, List<PlayerInfo> playersInfo, CardType[] tableCards, int smallBlindPlayerID, int bigBlindPlayerID)
        {
            this.GameID = gameID;
            this.PotSize = potSize;
            this.CurrentStake = currentStake;
            this.RoundNumber = roundNumber;
            this.PlayerTurnID = playerTurnID;
            this.PlayersInfo = playersInfo;
            this.TableCards = tableCards;
            this.SmallBlindPlayerID = smallBlindPlayerID;
            this.BigBlindPlayerID = bigBlindPlayerID;

        }

        public static string ConvertToString(GameInfo gameInfo)
        {
            return new JavaScriptSerializer().Serialize(gameInfo);
        }

    }
}
