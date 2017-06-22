﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceLayer
{
    public class DatabaseORM : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<UserStatisticsEntity> UserStatstics { get; set; }
        public DbSet<GamelogsEntity> GameLogs { get; set; }

    }
    public class UserEntity
    {
        [Key]
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Money { get; set; }
        public int LeagueId { get; set; }
    }

    public class UserStatisticsEntity
    {
        [Key]
        public string Username { get; set; }
        public int Points { get; set; }
        public int NumOfGames { get; set; }
        public int TotalGrossProfit { get; set; }
        public int HighestCashGain { get; set; }
        public int AvgGrossProfit { get; set; }
        public int AvgCashGain { get; set; }
    }

    public class GamelogsEntity
    {
        [Key]
        public int LogId { get; set; }
        public string GameLogSerial { get; set; }
    }

    //The DB Helper
    public class DBHelper
    {
        public DBHelper() { }

        public List<UserEntity> GetRegisteredUsers()
        {
            var users = new List<UserEntity>();
            using (var context = new DatabaseORM())
            {
                foreach (UserEntity u in context.Users)
                {
                    users.Add(u);
                }
            }
            return users;
        }
        public UserEntity GetUser(string username)
        {
            UserEntity user = new UserEntity();
            using (var context = new DatabaseORM())
            {
                foreach (UserEntity u in context.Users)
                {
                    if (u.Username.Equals(username))
                    {
                        user = u;
                        return user;
                    }
                }
            }
            return null;
        }
        public bool AddUser(string username, string password, string email, int money, int leagueID)
        {
            using (var context = new DatabaseORM())
            {
                context.Users.Add(new UserEntity() { Username = username, Password = password, Email = email, Money = money, LeagueId = leagueID });
                context.UserStatstics.Add(new UserStatisticsEntity()
                {
                    Username = username,
                    AvgCashGain = 0,
                    AvgGrossProfit = 0,
                    HighestCashGain = 0,
                    NumOfGames = 0,
                    Points = 0,
                    TotalGrossProfit = 0
                });
                context.SaveChanges();
            }
            return true;
        }
        public bool DeleteUser(string username)
        {
            using (var context = new DatabaseORM())
            {
                foreach (UserEntity u in context.Users)
                {
                    if (u.Username.Equals(username))
                    {
                        context.Users.Remove(u);
                        context.SaveChanges();
                        return true;
                    }
                }
            }
            return false;
        }
        public bool EditUser(string username, string password, string email, int money)
        {
            using (var context = new DatabaseORM())
            {
                foreach (UserEntity u in context.Users)
                {
                    if (u.Username.Equals(username))
                    {
                        context.Users.Remove(u);
                        u.Password = password;
                        u.Email = email;
                        u.Money = money;
                        context.Users.Add(u);
                        context.SaveChanges();
                        return true;
                    }
                }
            }
            return false;
        }
        public bool UpdateUserLeague(string username, int newLeagueID)
        {
            using (var context = new DatabaseORM())
            {
                foreach (UserEntity u in context.Users)
                {
                    if (u.Username.Equals(username))
                    {
                        context.Users.Remove(u);
                        u.LeagueId = newLeagueID;
                        context.Users.Add(u);
                        context.SaveChanges();
                        return true;
                    }
                }
            }
            return false;
        }
        public bool UpdateUserStats(string username, int points, int numOfGames, int totalGrossProfit, int highestCashGain, int avgGrossProfit, int avgCashGain)
        {
            using (var context = new DatabaseORM())
            {
                foreach (UserStatisticsEntity us in context.UserStatstics)
                {
                    if (us.Username.Equals(username))
                    {
                        context.UserStatstics.Remove(us);
                        us.Points = points;
                        us.NumOfGames = numOfGames;
                        us.TotalGrossProfit = totalGrossProfit;
                        us.HighestCashGain = highestCashGain;
                        us.AvgGrossProfit = avgGrossProfit;
                        us.AvgCashGain = avgCashGain;
                        context.UserStatstics.Add(us);
                        context.SaveChanges();
                    }
                }
            }
            return false;
        }


        public bool AddGameLog(int logId, string serial)
        {
            using (var context = new DatabaseORM())
            {
                context.GameLogs.Add(new GamelogsEntity() { LogId = logId, GameLogSerial = serial });
            }
            return false;
        }

        public GamelogsEntity GetGameLog(int logId)
        {
            using (var context = new DatabaseORM())
            {
                foreach (GamelogsEntity gl in context.GameLogs)
                {
                    if (gl.LogId == logId)
                    {
                        return gl;
                    }
                }
            }
            return null;
        }

        public List<GamelogsEntity> GetListOfGameLogs()
        {
            var gameLogsList = new List<GamelogsEntity>();
            using (var context = new DatabaseORM())
            {
                foreach (GamelogsEntity gl in context.GameLogs)
                {
                    gameLogsList.Add(gl);
                }
            }
            return gameLogsList;
        }
    }
}
