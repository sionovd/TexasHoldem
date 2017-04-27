using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexasHoldem.ServiceLayer;

namespace AcceptanceTests
{
    public class GameSystemTest
    {
        private IService bridge;

        public GameSystemTest()
        {
            bridge = new ProxyService();
        }

        public bool Register(string username, string password, string email)
        {
            try
            {
                bridge.Register(username, password, email);
                return true;
            }
            catch (ApplicationException)
            {
                return false;
            }
        }

        public bool EditProfile(string username, string password, string email)
        {
            try
            {
                bridge.EditProfile(username, password, email);
                return true;
            }
            catch (ApplicationException)
            {
                return false;
            }
        }

        public int CreateGame(int gameTypePolicy, int buyInPolicy, int chipPolicy, int minBet, int minPlayerCount,
            int maxPlayerCount,
            bool isSpectatable)
        {
            try
            {
                int gameID = bridge.CreateGame(gameTypePolicy, buyInPolicy, chipPolicy, minBet, minPlayerCount,
                    maxPlayerCount,
                    isSpectatable);
                return gameID;
            }
            catch (ApplicationException)
            {
                return -1;
            }
        }

        public int JoinGame(string username, int gameID)
        {
            try
            {
                bridge.JoinGame(username, gameID);
                return 1;
            }
            catch (ApplicationException)
            {
                return -1;
            }
        }

    }
}
