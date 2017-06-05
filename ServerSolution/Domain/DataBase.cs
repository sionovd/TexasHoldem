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

        public List<User> GetRegisteredUsers()
        {
            throw new NotImplementedException();
        }

        public User GetUser(string username)
        {
            throw new NotImplementedException();
        }

        public bool AddUser(string username, string password, string email, int money, int leagueID)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUser(string username)
        {
            throw new NotImplementedException();
        }

        public bool EditUser(string username, string password, string email, int money)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUserLeague(string username, int newLeagueID)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUserStats(string username, int points, int numOfGames, int totalGrossProfit, int highestCashGain,
            int avgGrossProfit, int avgCashGain)
        {
            throw new NotImplementedException();
        }
    }
}
