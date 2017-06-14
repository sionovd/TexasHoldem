using System;
using System.Data.SQLite;

namespace PersistenceLayer
{
    public class Database : IDatabase
    {
        public static bool isDBExists;
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
        public SQLiteDataReader GetRegisteredUsers()
        {
            string sql = "select * from Users";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            return reader;
            
        }

        public SQLiteDataReader GetUser(string username)
        {
            string sql = "select  * from Users where username = '" + username + "'";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            return reader;
            
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

        public bool AddGameLog()
        {
            throw new NotImplementedException();
        }

        public SQLiteDataReader GetGameLog()
        {
            throw new NotImplementedException();
        }

        public SQLiteDataReader GetListOfGameLogs()
        {
            throw new NotImplementedException();
        }
    }
}