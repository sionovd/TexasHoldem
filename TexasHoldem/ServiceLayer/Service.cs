﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexasHoldem.ServiceLayer
{
    class Service : IService
    {
        public bool Register(string username, string password, string email)
        {
            throw new NotImplementedException();
        }

        public bool EditProfile(string username, string password, string email)
        {
            throw new NotImplementedException();
        }

        public bool Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public bool Logout(string username)
        {
            throw new NotImplementedException();
        }

        public int JoinGame(string username, int gameID)
        {
            throw new NotImplementedException();
        }

        public bool LeaveGame(string username, int gameID)
        {
            throw new NotImplementedException();
        }

        public bool Bet(int playerID, int gameID, int amount)
        {
            throw new NotImplementedException();
        }

        public bool Check(int playerID, int gameID)
        {
            throw new NotImplementedException();
        }

        public bool Fold(int playerID, int gameID)
        {
            throw new NotImplementedException();
        }

        public bool Call(int playerID, int gameID)
        {
            throw new NotImplementedException();
        }

        public List<int> SearchActiveGames(string username, string filter)
        {
            throw new NotImplementedException();
        }

        public List<int> ListSpectatableGames()
        {
            throw new NotImplementedException();
        }

        public int CreateGame(string username, int gameTypePolicy, int buyInPolicy, int chipPolicy, int minBet, int minPlayerCount, int maxPlayerCount,
            bool isSpectatable)
        {
            throw new NotImplementedException();
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

        public bool SpectateGame(string username, int gameLogID)
        {
            throw new NotImplementedException();
        }
    }
}