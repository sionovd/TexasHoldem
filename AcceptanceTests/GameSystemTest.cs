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

        public int JoinGame(string username, int gameID)
        {
            try
            {
                bridge.JoinGame(username, gameID);
                return 0;
            }
            catch (ApplicationException)
            {
                return -1;
            }
        }

    }
}
