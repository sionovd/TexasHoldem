﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Communication.GameLogInfo;
using Newtonsoft.Json;

namespace Communication.Replies
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

        public ReplayInfo(string content)
        {
            ReplayInfo replayInfo = new JavaScriptSerializer().Deserialize<ReplayInfo>(content);
            GameID = replayInfo.GameID;
            GameInfoList = replayInfo.GameInfoList;
            EndGameInfo = replayInfo.EndGameInfo;
        }

        public static string ConvertToString(ReplayInfo replayInfo)
        {
            return new JavaScriptSerializer().Serialize(replayInfo);
        }
    }
}
