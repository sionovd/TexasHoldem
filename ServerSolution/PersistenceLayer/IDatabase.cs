using System.Data.SQLite;

namespace PersistenceLayer
{
    /* For now we will have three tables: 
     * User (username is the primary key)
     * UserStatistics (contains foreign key to the User table's primary key)
     * GameLogs - not sure how to save them
     */
    public interface IDatabase
    {
        // return list of full User objects (including the statistics of each one)
        SQLiteDataReader GetRegisteredUsers();

        // return full User object, including the statistics 
        SQLiteDataReader GetUser(string username);

        // make sure to initialize each user statistic to 0
        bool AddUser(string username, string password, string email, int money, int leagueID);

        // make sure to delete the statistics entry as well
        bool DeleteUser(string username);

        bool EditUser(string username, string password, string email, int money);

        bool UpdateUserLeague(string username, int newLeagueID);

        bool UpdateUserStats(string username, int points, int numOfGames, int totalGrossProfit, int highestCashGain, int avgGrossProfit, int avgCashGain);


        // I don't know how to do the GameLog table, so I didn't define the parameters...

        bool AddGameLog();

        SQLiteDataReader GetGameLog();

        SQLiteDataReader GetListOfGameLogs();
    }
}
