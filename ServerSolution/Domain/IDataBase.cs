using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.GameModule;
using Domain.UserModule;

namespace Domain
{
    interface IDataBase
    {
        List<User> getRegisterUsers();
        List<IGame> getAllGames();
        void AddGame(IGame game);
    }
}
