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

        

        public bool Login(string username, string password)
        {
            try
            {
                bridge.Login(username, password);
                return true;
            }
            catch (ApplicationException)
            {
                return false;
            }
        }

        public bool Logout(string username)
        {
            try
            {
                bridge.Logout(username);
                return true;
            }
            catch (ApplicationException)
            {
                return false;
            }
        }

        public int CreateGame(string username, int gameTypePolicy, int buyInPolicy, int chipPolicy, int minBet, int minPlayerCount,
            int maxPlayerCount,
            bool isSpectatable)
        {
            try
            {
                int gameID = bridge.CreateGame(username, gameTypePolicy, buyInPolicy, chipPolicy, minBet, minPlayerCount,
                    maxPlayerCount, isSpectatable);
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
            catch (ApplicationException e)
            {
                //if e == joingame exception return -2, or -3, or -4...
                    return -1;
            }
        }

        public bool Bet(int playerID, int gameID, int amount)
        {
            try
            {
                bridge.Bet(playerID, gameID, amount);
                return true;
            }
            catch (ApplicationException)
            {
                return false;
            }
        }

    }
}
