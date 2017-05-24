using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexasHoldem;
using TexasHoldem.ServiceLayer;

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

        public bool RegisterWithMoney(string username, string password, string email, int money)
        {
            try
            {
                bridge.RegisterWithMoney(username, password, email, money);
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

        public int ViewMoneyBalanceOfUser(string username)
        {
            return bridge.ViewMoneyBalanceOfUser(username);
        }

        public int CreateGame(string username, int gameTypePolicy, int buyInPolicy, int chipPolicy, int minBet, int minPlayerCount,
            int maxPlayerCount,
            bool isSpectatable)
        {
            try
            {
                int gameID = bridge.CreateGame(username, gameTypePolicy, buyInPolicy, chipPolicy, minBet, minPlayerCount,
                    maxPlayerCount, isSpectatable);
                return gameID;
            }
            catch (DomainException e)
            {
                Console.WriteLine(e.ToString());
                return -1;
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

        public bool LeaveGame(int playerID, int gameID)
        {
            try
            {
                return bridge.LeaveGame(playerID, gameID);
            }
            catch (DomainException e)
            {
                ErrorLogger.LogError(e);
                return false;
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
                bridge.Bet(playerID, gameID, amount);
                return true;
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
                bridge.Call(playerID, gameID);
                return true;
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
                bridge.Check(playerID, gameID);
                return true;
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
                bridge.Fold(playerID, gameID);
                return true;
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
        }

        public bool ReplayGame(string username, int gameLogID)
        {
            try
            {
                return bridge.ReplayGame(username, gameLogID);
            }
            catch (DomainException e)
            {
                ErrorLogger.LogError(e);
                return false;
            }
        }
    }
}
