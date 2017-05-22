using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexasHoldem.GameModule;
using TexasHoldem.UserModule;

namespace TexasHoldem
{
    interface IDataBase
    {
        List<User> getRegisterUsers();
        List<IGame> getAllGames();
        void AddGame(IGame game);
    }
}
