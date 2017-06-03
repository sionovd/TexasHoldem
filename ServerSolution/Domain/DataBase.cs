using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.GameModule;
using Domain.UserModule;

namespace Domain
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
