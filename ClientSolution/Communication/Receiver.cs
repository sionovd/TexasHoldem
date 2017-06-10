using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Communication.GameLogInfo;

namespace Communication
{
    public class Receiver
    {
        private static Receiver RECEIVER = new Receiver();
        private List<GameListener> gameListeners;

        private Receiver()
        {
            gameListeners = new List<GameListener>();
        }

        public void UpdateGameInfo(string content)
        {
            GameInfo gameInfo = new GameInfo(content);
            foreach (GameListener gameListener in RECEIVER.gameListeners)
            {
                gameListener.Update(gameInfo);
            }
        }

        public void UpdatePlayerCardsInfo(string content)
        {
            PlayerCardsInfo playerCardsInfo = new PlayerCardsInfo(content);
            foreach (GameListener gameListener in RECEIVER.gameListeners)
            {
                gameListener.Update(playerCardsInfo);
            }
        }

        public void Attach(GameListener gameListener)
        {   if(!gameListeners.Contains(gameListener))
                 gameListeners.Add(gameListener);
        }

        public void Detach(GameListener gameListener)
        {
            gameListeners.Remove(gameListener);
        }

        public static Receiver GetReceiver()
        {
            return RECEIVER;
        }

    }
}
