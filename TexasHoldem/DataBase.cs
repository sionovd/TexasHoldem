using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexasHoldem
{
    interface DataBase
    {
        List<User> getRegisterUsers();
        List<Game> getAllGames();
        void AddGame(Game game);
    }
}
