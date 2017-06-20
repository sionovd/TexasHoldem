using System;
using System.Collections.Generic;
using Domain;
using Domain.DomainLayerExceptions;
using ServiceLayer;

namespace AcceptanceTests
{
    public class GameSystemTest
    {
        private IService bridge;

        public GameSystemTest()
        {
            bridge = new Service();
        }

        public bool Register(string username, string password, string email)
        {
            try
            {
                bridge.Register(username, password, email);
                return true;
            }
            catch (DomainException e)
            {
                ErrorLogger.LogError(e);
                return false;
            }
        }

        public bool EditProfile(string username, string password, string email)
        {
            try
            {
                bridge.EditProfile(username, password, email);
                return true;
            }
            catch (DomainException e)
            {
                ErrorLogger.LogError(e);
                return false;
            }
        }



        public bool Login(string username, string password)
        {
            try
            {
                bridge.Login(username, password);
                return true;
            }
            catch (DomainException e)
            {
                ErrorLogger.LogError(e);
                return false;
            }
        }

        public bool Logout(string username)
        {
            try
            {
                bridge.Logout(username);
                return true;
            }
            catch (DomainException e)
            {
                ErrorLogger.LogError(e);
                return false;
            }
        }

        public bool DeleteAccount(string username)
        {
            try
            {
                bridge.DeleteAccount(username);
                return true;
            }
            catch (DomainException e)
            {
                ErrorLogger.LogError(e);
                return false;
            }
        }

        public bool SendMessage(string senderUsername, string message, int gameID)
        {
            try
            {
                bridge.SendMessage(senderUsername, message, gameID);
                return true;
            }
            catch (DomainException e)
            {
                ErrorLogger.LogError(e);
                return false;
            }
        }

        public bool SendWhisper(string senderUsername, string receiverUsername, string whisper, int gameID)
        {
            try
            {
                bridge.SendWhisper(senderUsername, receiverUsername, whisper, gameID);
                return true;
            }
            catch (DomainException e)
            {
                ErrorLogger.LogError(e);
                return false;
            }
        }

        public int CreateGame(string username, List<KeyValuePair<string, int>> preferenceList)
        {
            try
            {
                int gameID = bridge.CreateGame(username, preferenceList);
                return gameID;
            }
            catch (DomainException e)
            {
                ErrorLogger.LogError(e);
                return -1;
            }
        }

        public bool StartGame(string username, int gameID)
        {
            return bridge.StartGame(username, gameID);
        }

        public int JoinGame(string username, int gameID)
        {
            try
            {
                return bridge.JoinGame(username, gameID);
            }
            catch (DomainException e)
            {
                ErrorLogger.LogError(e);
                return -1;
            }
        }

        public bool LeaveGame(string username, int gameID)
        {
            try
            {
                return bridge.LeaveGame(username, gameID);
            }
            catch (DomainException e)
            {
                ErrorLogger.LogError(e);
                return false;
            }
        }

        public bool Bet(int playerID, int gameID, int amount)
        {
            try
            {
                return bridge.Bet(playerID, gameID, amount);
            }
            catch (DomainException e)
            {
                ErrorLogger.LogError(e);
                return false;
            }

        }

        public bool Call(int playerID, int gameID)
        {
            try
            {
                return bridge.Call(playerID, gameID);
            }
            catch (DomainException e)
            {
                ErrorLogger.LogError(e);
                return false;
            }

        }

        public bool Check(int playerID, int gameID)
        {
            try
            {
                return bridge.Check(playerID, gameID);
            }
            catch (DomainException e)
            {
                ErrorLogger.LogError(e);
                return false;
            }
           
        }

        public bool Fold(int playerID, int gameID)
        {
            try
            {
                return bridge.Fold(playerID, gameID);
            }
            catch (DomainException e)
            {
                ErrorLogger.LogError(e);
                return false;
            }

        }

        public bool SearchActiveGamesByPreferences(int gameType, int buyIn, int chipPolicy, int minBet, int minPlayers, int maxPlayers, int spectateGame)
        {
            return bridge.SearchActiveGamesByPreferences(gameType, buyIn, chipPolicy, minBet, maxPlayers, minPlayers,
                           spectateGame)
                       .Count > 0;
        }

        public bool SearchAciveGamesByPot(int potSize)
        {
            return bridge.SearchActiveGamesByPot(potSize).Count > 0;
        }

        public bool SearchActiveGamesByPlayerName(string playerName)
        {
            return bridge.SearchActiveGamesByPlayerName(playerName).Count > 0;
        }

        public bool ViewSpectatableGames()
        {
            return bridge.ViewSpectatableGames().Count > 0;
        }

        public int SpectateGame(string username, int gameID)
        {
            try
            {
                return bridge.SpectateGame(username, gameID);
            }
            catch (DomainException e)
            {
                ErrorLogger.LogError(e);
                return -1;
            }
            catch (Exception e)
            {
                ErrorLogger.LogError(e);
                throw e;
            }
        }

        public bool ReplayGame(int gameLogID)
        {
            try
            {
                bridge.ReplayGame(gameLogID);
                return true;
            }
            catch (DomainException e)
            {
                ErrorLogger.LogError(e);
                return false;
            }
        }
    }
}
