using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communication.Service
{
    interface IService
    {
        Reply Register(string username, string password);
        Reply EditProfile(string username, string password, string email);
        Reply Login(string username, string password);
        Reply Logout(string username);
        
        int JoinGame(string username, int gameID);

        Reply LeaveGame(int playerID, int gameID);
        Reply Bet(int playerID, int gameID, int amount);
        Reply Check(int playerID, int gameID);
        Reply Fold(int playerID, int gameID);
        Reply Call(int playerID, int gameID);

        // GameCenter
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
