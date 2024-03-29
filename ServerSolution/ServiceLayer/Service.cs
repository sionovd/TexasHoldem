﻿using System;
using System.Collections.Generic;
using Domain.DomainLayerExceptions;
using Domain.GameCenterModule;

namespace ServiceLayer
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
                throw new NotAPasswordException("no password was entered");
            return gameCenter.Register(username, password, email);
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

        public bool LogoutWebClient(string username)
        {
            return gameCenter.LogoutWebClient(username);
        }

        public bool LoginWebClient(string username, string password)
        {
            return gameCenter.LoginWebClient(username, password);
        }

        public void DeleteAccount(string username)
        {
            gameCenter.DeleteAccount(username);
        }

        public string GetUserDetails(string username)
        {
            return gameCenter.GetUserDetails(username);
        }

        public List<string> GetAllUsernames()
        {
            return gameCenter.GetAllUsernames();
        }

        public string GetUserStats(string username)
        {
            return gameCenter.GetUserStats(username);
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

        public List<int> ViewReplays()
        {
            return gameCenter.GetAllReplays();
        }

        public void SendMessage(string senderUsername, string message, int gameID)
        {
            gameCenter.SendMessage(senderUsername, message, gameID);
        }

        public void SendWhisper(string senderUsername, string receiverUsername, string whisper, int gameID)
        {
            gameCenter.SendWhisper(senderUsername, receiverUsername, whisper, gameID);
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

        /****************************/

        public List<string> Get20TopHighestCashInGame()
        {
            return gameCenter.Get20TopHighestCashInGame();
        }

        public List<string> Get20TopAmountOfGames()
        {
            return gameCenter.Get20TopAmountOfGames();
        }

        public List<string> Get20TopTotalGrossProfit()
        {
            return gameCenter.Get20TopTotalGrossProfit();
        }

        /*************************/
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

        public string ReplayGame(int gameID)
        {
            return gameCenter.GetReplayInfo(gameID);
        }

        public int SpectateGame(string username, int gameID)
        {
            return gameCenter.SpectateGame(username, gameID);
        }
    }
}
