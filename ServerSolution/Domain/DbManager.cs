using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Domain.UserModule;
using PersistenceLayer;

namespace Domain
{
    public class DbManager : IDbManager
    {
        private IDatabase db;
        public DbManager()
        {
            db = new Database();
        }

        public List<User> GetRegisteredUsers()
        {
            SQLiteDataReader reader = db.GetRegisteredUsers();
            List<User> users = new List<User>();
            while (reader.Read())
            {
                User u = new User(reader["username"].ToString(), reader["password"].ToString(), reader["email"].ToString(), Int32.Parse(reader["money"].ToString()));
                u.League = new DefaultLeague();
                users.Add(u);
            }
            return users;
        }

        public User GetUser(string username)
        {
            SQLiteDataReader reader = db.GetUser(username);
            User user = null;
            while (reader.Read())
            {
                user = new User(reader["username"].ToString(), reader["password"].ToString(), reader["email"].ToString(), Int32.Parse(reader["money"].ToString()));
                user.League = new DefaultLeague();
            }
            return user;
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
            throw new NotImplementedException();
        }

        public bool UpdateUserLeague(User user, League league)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUserStats(User user)
        {
            throw new NotImplementedException();
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
