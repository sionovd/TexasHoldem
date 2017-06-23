using System;
using System.Collections.Generic;
using Domain.UserModule;
using PersistenceLayer;

namespace Domain
{
    public class DbManager
    {
        private DBHelper db;
        public DbManager()
        {
            db = new DBHelper();
        }

        public List<User> GetRegisteredUsers()
        {
            List<UserEntity> registeredUsers = db.GetRegisteredUsers();

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
