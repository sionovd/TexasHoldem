using System;
using System.Collections.Generic;
using Domain.UserModule;
using PersistenceLayer;

namespace Domain
{
    public class DbManager
    {
        private static DbManager dbManager;
        private DBHelper db;
        private DbManager()
        {
            db = new DBHelper();
        }

        public static DbManager GetInstance
        {
            get
            {
                if (dbManager == null)
                    dbManager = new DbManager();
                return dbManager;
            }
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
            return db.AddUser(user.Username, user.Password, user.Email, user.MoneyBalance, user.League.Id);
        }

        public bool DeleteUser(User user)
        {
            return db.DeleteUser(user.Username);
        }

        public bool EditUser(User user)
        {
            return db.EditUser(user.Username, user.Password, user.Email, user.MoneyBalance);
        }

        public bool UpdateUserLeague(User user, League league)
        {
            return db.UpdateUserLeague(user.Username, league.Id);
        }

        public bool UpdateUserStats(User user)
        {
            return db.UpdateUserStats(user.Username, user.Stats.Points, user.Stats.NumOfGames,
                user.Stats.TotalGrossProfit, user.Stats.HighestCashGain, user.Stats.AvgGrossProfit,
                user.Stats.AvgCashGain);
        }

        public bool AddGameLog(GameLog log)
        {

            return db.AddGameLog(log.GameID, GameLog.ConvertToString(log));
        }

        public GameLog GetGameLog(int gameID)
        {
            GamelogsEntity logEntity = db.GetGameLog(gameID);
            GameLog gameLog = new GameLog(logEntity.GameLogSerial);
            return gameLog;
        }

        public Dictionary<int, GameLog> GetListOfGameLogs()
        {
            List<GamelogsEntity> gameLogEntities = db.GetListOfGameLogs();
            Dictionary<int, GameLog> gameLogs = new Dictionary<int, GameLog>();
            foreach (GamelogsEntity gamelogsEntity in gameLogEntities)
            {
                gameLogs.Add(gamelogsEntity.GameID, new GameLog(gamelogsEntity.GameLogSerial));
            }
            return gameLogs;
        }

        public void DeleteData()
        {
            db.DeleteAllData();
        }
    }
}
