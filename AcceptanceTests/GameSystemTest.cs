﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            catch (ApplicationException)
            {
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
            catch (ApplicationException)
            {
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
            catch (ApplicationException)
            {
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
            catch (ApplicationException)
            {
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
            catch (ApplicationException)
            {
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
            catch (ApplicationException)
            {
                return -1;
            }
        }

        public int JoinGame(string username, int gameID)
        {
            try
            {
                bridge.JoinGame(username, gameID);
                return 1;
            }
            catch (ApplicationException e)
            {
                //if e == joingame exception return -2, or -3, or -4...
                return -1;
            }
        }

        public bool Bet(int playerID, int gameID, int amount)
        {
            try
            {
                bridge.Bet(playerID, gameID, amount);
                return true;
            }
            catch (ApplicationException)
            {
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
            catch (ApplicationException)
            {
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
            catch (ApplicationException)
            {
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
            catch (ApplicationException)
            {
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

    }
}
