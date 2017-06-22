using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Domain.UserModule;
using PersistenceLayer;

namespace Domain
{
    public class DbManager
    {
        public DbManager()
        {
          //  db = new Database();
        }

        public List<User> GetRegisteredUsers()
        {
            throw new NotImplementedException();
        }

        public User GetUser(string username)
        {
            throw new NotImplementedException();
        }

        public bool AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUser(User user)
        {
            throw new NotImplementedException();
        }

        public bool EditUser(User user)
        {
            return true;
        }

        public bool UpdateUserLeague(User user, League league)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUserStats(User user)
        {
            return true;
        }

        public bool AddGameLog()
        {
            throw new NotImplementedException();
        }

        public GameLog GetGameLog()
        {
            throw new NotImplementedException();
        }

        public List<GameLog> GetListOfGameLogs()
        {
            throw new NotImplementedException();
        }
    }
}
