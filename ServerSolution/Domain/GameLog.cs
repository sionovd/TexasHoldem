using System;
using System.Collections.Generic;
using Domain.GameModule;

namespace Domain
{
    public class GameLog
    {
        Dictionary<int, string> logOfMoves;
        private Game game;
        int loggerCounter;
        public string LatestAction { get; private set; }
        public GameLog(Game game)
        {
            //this = database.getGameLog(gameLogID);
            this.game = game;
            this.logOfMoves = new Dictionary<int, string>();
            this.loggerCounter = 0;
        }

        public void LogTurn(Player player, string Move)
        {
            if (player == null)
            {
                //means no player conducted move.
                //can be: add card to table, declare score
                LatestAction = Move;
                logOfMoves.Add(loggerCounter++, Move);
                game.Subject.Notify();
            }
            else
            {
                string line = "Player: " + player.PlayerId + " " + Move;
                LatestAction = line;
                logOfMoves.Add(loggerCounter++, line); //while parsing, check if first word is "Player:" then strip by spaces the ID
                game.Subject.Notify();
            }
        }
    }
}