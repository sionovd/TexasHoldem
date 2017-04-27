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
        bool Register(string username, string password, string email);      // uc.RegisterUser(username, password, email);
        bool EditProfile(string username, string password, string email);   // uc.EditUserProfile(username, password, email);
        bool Login(string username, string password);                       // uc.LoginUser(username, password);
        bool Logout(string username);                                       // uc.LogoutUser(username); 

        // Game
        int JoinGame(string username, int gameID);                                           // game.AddPlayer(user)            
        bool LeaveGame(string username, int gameID);                                          // game.RemovePlayer(user)
        bool Bet(int playerID, int gameID, int amount);                                    // game.Bet(user, amount)
        bool Check(int playerID, int gameID);                                              // game.Check(user)
        bool Fold(int playerID, int gameID);                                               // game.Fold(user)
        bool Call(int playerID, int gameID);                                               // game.Call(user)

        // GameCenter
        List<int> SearchActiveGames(string username, string filter);                        // gc.GetActiveGames(user, filter);
        List<int> ListSpectatableGames();                                  // gc.GetSpectatableGames();
        int CreateGame(int gameTypePolicy, int buyInPolicy, int chipPolicy, int minBet,
            int minPlayerCount, int maxPlayerCount, bool isSpectatable);                        // gc.CreateGame(...);
        bool SetDefaultLeague(int leagueID);
        bool SetLeagueCriteria(int leagueID, int points);
        bool MoveUserToLeague(string username, int leagueID);

        // GameLog
        bool ReplayGame(string username, int gameLogID);                                         // gamelog.ShowReplay(user, game);
        bool SaveTurns(string username, int gameID, string turnData);                         // log.SaveTurns(user, game, turnData);
        bool SpectateGame(string username, int gameLogID);                                       // log.ShowGame(user, game) 


    }
}
