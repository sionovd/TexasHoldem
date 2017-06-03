using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.GameModule;
using Domain.UserModule;

namespace Domain
{
    class GameLog
    {
        public GameLog(int gameLogID)
        {
            //this = database.getGameLog(gameLogID);
        }

        public bool ShowReplay(User user)
        {
            //TODO
            return true;
        }
        public bool SaveTurns(User user, Game game, string turnDate)
        {
            //TODO
            return true;
        }
    }
}
