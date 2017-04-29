using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexasHoldem
{
    class DataBase : IDataBase
    {
        public void AddGame(Game game)
        {
          //  throw new NotImplementedException();
        }

        public List<Game> getAllGames()
        {
            return new List<Game>();
          //  throw new NotImplementedException();
        }

        public List<User> getRegisterUsers()
        {
            return new List<User>();
            //  throw new NotImplementedException();
        }
    }
}
