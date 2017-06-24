using System;
using System.Collections.Generic;
using ServiceLayer;

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

        public bool LoginWebClient(string username, string password)
        {
            throw new NotImplementedException();
        }

        public bool LogoutWebClient(string username)
        {
            throw new NotImplementedException();
        }

        public void DeleteAccount(string username)
        {
            throw new NotImplementedException();
        }

        public string GetUserDetails(string username)
        {
            throw new NotImplementedException();
        }

        public List<string> GetAllUsernames()
        {
            throw new NotImplementedException();
        }

        public string GetUserStats(string username)
        {
            throw new NotImplementedException();
        }

        public int ViewMoneyBalanceOfUser(string username)
        {
            return 5;
        }

        public int JoinGame(string username, int gameID)
        {
            return 1; //playerID
        }

        public bool StartGame(string username, int gameID)
        {
            return true;
        }

        public bool LeaveGame(string username, int gameID)
        {
            return true;
        }

        public bool LeaveGame(int playerID, int gameID)
        {
            return true;
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

        public string GetReplayInfo(int gameID)
        {
            throw new NotImplementedException();
        }

        public void SendMessage(string senderUsername, string message, int gameID)
        {
        }

        public void SendWhisper(string senderUsername, string receiverUsername, string whisper, int gameID)
        {
        }

        public int CreateGame(string username, List<KeyValuePair<string, int>> preferenceList)
        {
            return 1;
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

        public List<int> ViewReplays()
        {
            throw new NotImplementedException();
        }

        public string ReplayGame(int gameID)
        {
            throw new NotImplementedException();
        }

        public int SpectateGame(string username, int gameID)
        {
            throw new NotImplementedException();
        }

        public List<string> Get20TopHighestCashInGame()
        {
            throw new NotImplementedException();
        }

        public List<string> Get20TopAmountOfGames()
        {
            throw new NotImplementedException();
        }

        public List<string> Get20TopTotalGrossProfit()
        {
            throw new NotImplementedException();
        }
    }
}
