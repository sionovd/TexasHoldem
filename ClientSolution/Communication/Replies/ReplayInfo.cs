using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Communication.GameLogInfo;
using Newtonsoft.Json;

namespace Communication.Replies
{
    public class ReplayInfo
    {
        [JsonProperty("GameInfoList")]
        public List<string> GameInfoList { get; set; }
        [JsonProperty("EndGameInfo")]
        public string EndGameInfo { get; set; }

        public ReplayInfo(List<string> gameInfoList, string endGameInfo)
        {
            GameInfoList = gameInfoList;
            EndGameInfo = endGameInfo;
        }
    }
}
