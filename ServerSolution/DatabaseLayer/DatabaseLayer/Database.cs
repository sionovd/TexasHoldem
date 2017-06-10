using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Domain.GameModule;
using Domain.UserModule;
using Domain;

namespace DatabaseLayer
{
    public class Database : IDataBase
    {
        public static bool isDBExists = false;
        private SQLiteConnection m_dbConnection;

        public Database()
        {
            if (!isDBExists)
                SQLiteConnection.CreateFile("MyDatabase.sqlite");
            isDBExists = true;
        }
        public void openDatabase()
        {
            m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();
        }
        public void closeDatabase()
        {
            m_dbConnection.Close();
        }
        public void init()
        {
            string sql = "create table Users (username VARCHAR(20), password VARCHAR(20), email VARCHAR(50), money INT, leagueID INT)";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            sql = "create table UserStatistics (username VARCHAR(20), points INT, numOfGames INT, totalGrossProfit INT, highestCashGain INT, avgGrossProfit INT, avgCashGain INT)";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            sql = "create table GameLogs (logId INT, serialize BLOB)";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        }
        public List<User> GetRegisteredUsers()
        {
            List<User> users = new List<User>();
            string sql = "select * from Users";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
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
            User user = null;
            string sql = "select  * from Users where username = '" + username + "'";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                user = new User(reader["username"].ToString(), reader["password"].ToString(), reader["email"].ToString(), Int32.Parse(reader["money"].ToString()));
                user.League = new DefaultLeague();
            }
            return user;
        }

        public bool AddUser(string username, string password, string email, int money, int leagueID)
        {
            string sql = "insert into Users (username, password, email, money, leagueID) values ('" + username +"', '" + password + "', '" + email
                    + "', " + money + ", " + leagueID + ")";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            sql = "insert into UserStatistics (username, points, numOfGames, totalGrossProfit, highestCashGain, avgGrossProfit, avgCashGain) values ('" +
                username + "',0,0,0,0,0,0)";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            return true;
        }

        public bool DeleteUser(string username)
        {
            string sql = "delete from Users where username = '" + username + "'";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            sql = "delete from UserStatistics where username = '" + username + "'";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            return true;
        }

        public bool EditUser(string username, string password, string email, int money)
        {
            string sql = "UPDATE Users SET password = '" + password + "', email = '" + email + "', money = " + money + " WHERE username = '" + username + "'";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            return true;
        }

        public bool UpdateUserLeague(string username, int newLeagueID)
        {
            string sql = "UPDATE Users SET leagueID = " + newLeagueID + " WHERE username = '" + username + "'";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            return true;
        }

        public bool UpdateUserStats(string username, int points, int numOfGames, int totalGrossProfit, int highestCashGain, int avgGrossProfit, int avgCashGain)
        {
            string sql = "UPDATE UserStatistics SET points = " + points + ", numOfGames = " + numOfGames + ", totalGrossProfit = "
                + totalGrossProfit + ", highestCashGain = " + highestCashGain + ", avgGrossProft = " + avgGrossProfit +
                ", avgCashGain = " + avgCashGain + " WHERE username = '" + username + "'";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            return true;
        }
    }
}