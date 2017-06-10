using System.Collections.Generic;

namespace ServiceLayer
{
    public interface IService
    {
        bool Register(string username, string password, string email);
        bool EditProfile(string username, string password, string email);
        bool Login(string username, string password);
        bool Logout(string username);
        void DeleteAccount(string username);

        int JoinGame(string username, int gameID);
        bool StartGame(string username, int gameID);
        bool LeaveGame(string username, int gameID);
        bool LeaveGame(int playerID, int gameID);
        bool Bet(int playerID, int gameID, int amount);
        bool Check(int playerID, int gameID);
        bool Fold(int playerID, int gameID);
        bool Call(int playerID, int gameID);


        int CreateGame(string username, List<KeyValuePair<string, int>> preferenceList);
        List<int> SearchActiveGamesByPreferences(int gameType, int buyIn, int chipPolicy, int minBet,
            int maxPlayers, int minPlayers, int spectateGame);
        List<int> SearchActiveGamesByPot(int pot);
        List<int> SearchActiveGamesByPlayerName(string name);
        List<int> ViewSpectatableGames();
        
        bool ReplayGame(string username, int gameLogID);
        int SpectateGame(string username, int gameID);


    }
}
