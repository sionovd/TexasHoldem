using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexasHoldem.ServiceLayer;

namespace AcceptanceTests
{
    class ProxyService : IService
    {
        public bool Register(string username, string password, string email)
        {
            return true;
        }

        public bool RegisterWithMoney(string username, string password, string email, int money)
        {
            return true;
        }

        public bool EditProfile(string username, string password, string email)
        {
            return true;
        }

        public bool Login(string username, string password)
        {
            return true;
        }

        public bool Logout(string username)
        {
            return true;
        }

        public int ViewMoneyBalanceOfUser(string username)
        {
            return 5;
        }

        public int JoinGame(string username, int gameID)
        {
            return 1; //playerID
        }

        public bool LeaveGame(int playerID, int gameID)
        {
            throw new NotImplementedException();
        }

        public bool Bet(int playerID, int gameID, int amount)
        {
            return true;
        }

        public bool Check(int playerID, int gameID)
        {
            return true;
        }

        public bool Fold(int playerID, int gameID)
        {
            return true;
        }

        public bool Call(int playerID, int gameID)
        {
            return true;
        }

        public int CreateGame(string username, int gameTypePolicy, int buyInPolicy, int chipPolicy, int minBet, int minPlayerCount, int maxPlayerCount,
            bool isSpectatable)
        {
            return 1; //gameID
        }

        public List<int> SearchActiveGamesByPreferences(int gameType, int buyIn, int chipPolicy, int minBet, int maxPlayers, int minPlayers,
            int spectateGame)
        {
            List<int> list = new List<int>();
            list.Add(1);
            return list;
        }

        public List<int> SearchActiveGamesByPot(int pot)
        {
            List<int> list = new List<int>();
            list.Add(1);
            return list;
        }

        public List<int> SearchActiveGamesByPlayerName(string name)
        {
            List<int> list = new List<int>();
            list.Add(1);
            return list;
        }

        public List<int> ViewSpectatableGames()
        {
            List<int> list = new List<int>();
            list.Add(1);
            return list;
        }

        public bool SetDefaultLeague(int leagueID)
        {
            throw new NotImplementedException();
        }

        public bool SetLeagueCriteria(int leagueID, int points)
        {
            throw new NotImplementedException();
        }

        public bool MoveUserToLeague(string username, int leagueID)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
