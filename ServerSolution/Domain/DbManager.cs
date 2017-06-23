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

        public Dictionary<string, User> GetRegisteredUsers()
        {
            List<UserEntity> userEntitiesList = db.GetRegisteredUsers();
            List<UserStatisticsEntity> userStatEntitiesList = db.GetAllUserStatistics();
            Dictionary<string, User> registeredUsers = new Dictionary<string, User>();
            for (int i = 0; i < userEntitiesList.Count; i++)
            {
                UserEntity ue = userEntitiesList[i];
                UserStatisticsEntity use = userStatEntitiesList[i];
                User user = new User(ue.Username, ue.Password, ue.Email, ue.Money);
                user.Stats.Points = use.Points;
                user.Stats.AvgCashGain = use.AvgCashGain;
                user.Stats.AvgGrossProfit = use.AvgGrossProfit;
                user.Stats.HighestCashGain = use.HighestCashGain;
                user.Stats.NumOfGames = use.NumOfGames;
                user.Stats.TotalGrossProfit = use.TotalGrossProfit;
                registeredUsers.Add(user.Username, user);
            }
            return registeredUsers;
        }

        public User GetUser(string username)
        {
            throw new NotImplementedException();
        }

        public bool AddUser(User user)
        {
            //db.AddUser(user.Username, user.Get)
            return true;
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
