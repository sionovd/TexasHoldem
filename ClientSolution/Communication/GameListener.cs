using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Communication.GameLogInfo;

namespace Communication
{
    public interface GameListener
    {
       void Update(GameInfo gameInfo);
       void Update(PlayerCardsInfo playerCardsInfo);
       void Update(EndGameInfo endGameInfo);
    }
}
