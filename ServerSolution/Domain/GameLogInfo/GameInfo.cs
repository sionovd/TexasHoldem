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
            GameID = gameInfo.GameID;
            PotSize = gameInfo.PotSize;
            CurrentStake = gameInfo.CurrentStake;
            PlayerTurnID = gameInfo.PlayerTurnID;
            PlayersInfo = gameInfo.PlayersInfo;
            TableCards = gameInfo.TableCards;
            SmallBlindPlayerID = gameInfo.SmallBlindPlayerID;
            BigBlindPlayerID = gameInfo.BigBlindPlayerID;
        }
        public GameInfo(int gameID, int potSize, int currentStake, int roundNumber, int playerTurnID, List<PlayerInfo> playersInfo, CardType[] tableCards, int smallBlindPlayerID, int bigBlindPlayerID)
        {
            GameID = gameID;
            PotSize = potSize;
            CurrentStake = currentStake;
            RoundNumber = roundNumber;
            PlayerTurnID = playerTurnID;
            PlayersInfo = playersInfo;
            TableCards = tableCards;
            SmallBlindPlayerID = smallBlindPlayerID;
            BigBlindPlayerID = bigBlindPlayerID;

        }

        public static string ConvertToString(GameInfo gameInfo)
        {
            return new JavaScriptSerializer().Serialize(gameInfo);
        }

    }
}
