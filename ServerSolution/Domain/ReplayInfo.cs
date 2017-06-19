using System.Collections.Generic;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace Domain
{
    public class ReplayInfo
    {
        [JsonProperty("GameID")]
        public int GameID { get; set; }
        [JsonProperty("GameInfoList")]
        public List<string> GameInfoList { get; set; }
        [JsonProperty("EndGameInfo")]
        public string EndGameInfo { get; set; }

        public ReplayInfo()
        {
            
        }

        public ReplayInfo(int gameID, List<string> gameInfoList, string endGameInfo)
        {
            GameID = gameID;
            GameInfoList = gameInfoList;
            EndGameInfo = endGameInfo;
        }

        public static string ConvertToString(ReplayInfo replayInfo)
        {
            return new JavaScriptSerializer().Serialize(replayInfo);
        }
    }
}