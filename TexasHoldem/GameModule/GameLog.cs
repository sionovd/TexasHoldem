using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexasHoldem.UserModule;

namespace TexasHoldem.GameModule
{
    class GameLog
    {
        Dictionary<int, string> logOfMoves;
        int gameId;
        int loggerCounter;
        public GameLog(int gameId)
        {
            //this = database.getGameLog(gameLogID);
            this.gameId = gameId;
            this.logOfMoves = new Dictionary<int, string>();
            this.loggerCounter = 0;
        }

        public void LogTurn(Player player, string Move)
        {
            if (player == null)
            {
                //means no player conducted move.
                //can be: add card to table, declare score
                logOfMoves.Add(loggerCounter++, Move);
            }
            else
            {
                logOfMoves.Add(loggerCounter++, "Player: " + player.PlayerId + " " + Move); //while parsing, check if first word is "Player:" then strip by spaces the ID
            }
        }
    }
}
