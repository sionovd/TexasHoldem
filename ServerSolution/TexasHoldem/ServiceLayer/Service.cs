using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexasHoldem.GameCenterModule;
using TexasHoldem.GameModule;
using TexasHoldem.UserModule;

namespace TexasHoldem.ServiceLayer
{
    public class Service : IService
    {
        private GameCenter gameCenter;

        public Service()
        {
            gameCenter = GameCenter.GetInstance;
        }

        public bool Register(string username, string password, string email)
        {
            if (password == null)
                throw new NotAPasswordException("hello");
            return gameCenter.Register(username, password, email);
        }

        public bool RegisterWithMoney(string username, string password, string email, int money)
        {
            return gameCenter.RegisterWithMoney(username, password, email, money);
        }

        public string GetEmail(string username)
        {
            return gameCenter.GetEmail(username);
        }
        public bool EditProfile(string username, string password, string email)
        {
            return gameCenter.EditProfile(username, password, email);
        }

        public bool Login(string username, string password)
        {
            return gameCenter.Login(username, password);
        }

        public bool Logout(string username)
        {
            return gameCenter.Logout(username);
        }

        public int ViewMoneyBalanceOfUser(string username)
        {
            throw new NotImplementedException();
        }

        public int JoinGame(string username, int gameID)
        {
            return gameCenter.JoinGame(username, gameID);
        }

        public bool StartGame(string username, int gameID)
        {
            return gameCenter.StartGame(username, gameID);
        }

        public bool LeaveGame(string username, int gameID)
        {
            return gameCenter.LeaveGame(username, gameID);
        }

        public bool LeaveGame(int playerID, int gameID)
        {
            return gameCenter.LeaveGame(playerID, gameID);
        }

        public bool Bet(int playerID, int gameID, int amount)
        {
            return gameCenter.Bet(playerID, gameID, amount);
        }

        public bool Check(int playerID, int gameID)
        {
            return gameCenter.Check(playerID, gameID);
        }

        public bool Fold(int playerID, int gameID)
        {
            return gameCenter.Fold(playerID, gameID);
        }

        public bool Call(int playerID, int gameID)
        {
            return gameCenter.Call(playerID, gameID);
        }

        public int CreateGame(string username, List<KeyValuePair<string, int>> preferenceList)
        {
            return gameCenter.CreateGame(username, preferenceList);
        }

        public List<int> SearchActiveGamesByPreferences(int gameType, int buyIn, int chipPolicy, int minBet, int maxPlayers, int minPlayers,
            int spectateGame)
        {
            return gameCenter.GetActiveGamesByPreferences(gameType, buyIn, chipPolicy, minBet, maxPlayers, minPlayers,
                spectateGame);
            
        }

        public List<int> SearchActiveGamesByPot(int pot)
        {
            return gameCenter.GetActiveGamesByPot(pot);
        }

        public List<int> SearchActiveGamesByPlayerName(string name)
        {
            return gameCenter.GetActiveGamesByPlayerName(name);
        }

        public List<int> ViewSpectatableGames()
        {
            return gameCenter.GetSpectatableGames();
        }

        public bool ReplayGame(string username, int gameLogID)
        {
            throw new NotImplementedException();
        }

        public bool SaveTurns(string username, int gameID, string turnData)
        {
            throw new NotImplementedException();
        }

        public int SpectateGame(string username, int gameID)
        {
            return gameCenter.SpectateGame(username, gameID);
        }
    }
}
