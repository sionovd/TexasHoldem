using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexasHoldem.ServiceLayer
{
    public interface IService
    {
        // UserController 
        bool Register(string username, string password, string email);
        bool RegisterWithMoney(string username, string password, string email, int money);
        bool EditProfile(string username, string password, string email);
        bool Login(string username, string password);
        bool Logout(string username);
        int ViewMoneyBalanceOfUser(string username);

        // Game
        int JoinGame(string username, int gameID);
        bool StartGame(string username, int gameID);
        bool LeaveGame(string username, int gameID);
        bool LeaveGame(int playerID, int gameID);
        bool Bet(int playerID, int gameID, int amount);
        bool Check(int playerID, int gameID);
        bool Fold(int playerID, int gameID);
        bool Call(int playerID, int gameID);

        // GameCenter
        int CreateGame(string username, List<KeyValuePair<string, int>> preferenceList);
        int CreateGame(string username, int gameTypePolicy, int buyInPolicy, int chipPolicy, int minBet,
            int minPlayerCount, int maxPlayerCount, bool isSpectatable);
        List<int> SearchActiveGamesByPreferences(int gameType, int buyIn, int chipPolicy, int minBet,
            int maxPlayers, int minPlayers, int spectateGame);
        List<int> SearchActiveGamesByPot(int pot);
        List<int> SearchActiveGamesByPlayerName(string name);
        List<int> ViewSpectatableGames();
        

        // GameLog
        bool ReplayGame(string username, int gameLogID);
        bool SaveTurns(string username, int gameID, string turnData);
        int SpectateGame(string username, int gameID);


    }
}
