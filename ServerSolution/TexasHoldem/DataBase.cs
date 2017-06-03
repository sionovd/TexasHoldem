using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexasHoldem.GameModule;
using TexasHoldem.UserModule;

namespace TexasHoldem
{
    class DataBase : IDataBase
    {
        public void AddGame(IGame game)
        {
          //  throw new NotImplementedException();
        }

        public List<IGame> getAllGames()
        {
            return new List<IGame>();
          //  throw new NotImplementedException();
        }

        public List<User> getRegisterUsers()
        {
            return new List<User>();
            //  throw new NotImplementedException();
        }
    }
}
