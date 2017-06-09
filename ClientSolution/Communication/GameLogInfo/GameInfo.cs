using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communication.GameLogInfo
{
    public class GameInfo 
    {
        private int GameID { get; }
        private int PotSize { get; }
        private int CurrentStake { get; }
        private int PlayerTurnID { get; }
        private List<PlayerInfo> PlayersInfo { get; }

        public GameInfo()
        {
            
        }
        public GameInfo(int gameID, int potSize, int currentStake, int playerTurnID, List<PlayerInfo> playersInfo)
        {
            this.GameID = gameID;
            this.PotSize = potSize;
            this.CurrentStake = currentStake;
            this.PlayerTurnID = PlayerTurnID;
            this.PlayersInfo = playersInfo;

        }

        public GameInfo Parse(string content)
        {
            return this;
        }
    }
}
