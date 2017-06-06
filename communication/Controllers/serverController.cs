using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using communication.Models;
using Newtonsoft.Json;
using TexasHoldem;
using TexasHoldem.ServiceLayer;

namespace communication.Controllers
{
    public class ServerController : ApiController
    {
        private Service service = new Service();
        [HttpPost]
        public Reply Register(string username, string password, string email)
        {
            try
            {
                if (service.Register(username, password, email))
                    return new Reply(true, new DataString("true"));
                return new Reply(false, new DataString("unknow error"));
            }
            catch (DomainException a)
            {
                return new Reply(false, new DataString(a.Message));
            }
            catch (NullReferenceException e)
            {
                return new Reply(false, new DataString(e.Message));
            }
        }

        [HttpPost]
        public Reply EditProfile(string username, string password, string email)
        {
            try
            {
                if (service.EditProfile(username, password, email))
                    return new Reply(true, new DataString("true"));
                return new Reply(false, new DataString("unknow error"));
            }
            catch (DomainException a)
            {
                return new Reply(false, new DataString(a.Message));
            }
        }

        [HttpPost]
        public Reply Login(string username, string password)
        {
            try
            {
                if (service.Login(username, password))
                    return new Reply(true, new DataString("true"));
                return new Reply(false, new DataString("unknow error"));
            }
            catch (DomainException a)
            {
                return new Reply(false, new DataString(a.Message));
            }
        }

        [HttpPost]
        public Reply Logout(string username)
        {
            try
            {
                if (service.Logout(username))
                    return new Reply(true, new DataString("true"));
                return new Reply(false, new DataString("unknow error"));
            }
            catch (DomainException a)
            {
                return new Reply(false, new DataString(a.Message));
            }
        }

        [HttpPost]
        public Reply RegisterWithMoney(string username, string password, string email, int money)
        {
            try
            {
                if (service.RegisterWithMoney(username, password, email, money))
                    return new Reply(true, new DataString("true"));
                return new Reply(false, new DataString("unknow error"));
            }
            catch (DomainException a)
            {
                return new Reply(false, new DataString(a.Message));
            }
        }

        [HttpPost]
        public Reply JoinGame(string username, int gameId)
        {
            try
            {
                return new Reply( true, new DataInt(service.JoinGame(username, gameId)));
            }
            catch (DomainException a)
            {
                return new Reply(false, new DataString(a.Message));
            }

        }

        [HttpPost]
        public Reply StartGame(string username, int gameID)
        {
            try
            {
                if (service.StartGame(username, gameID))
                    return new Reply(true, new DataString("true"));
                return new Reply(false, new DataString("unknow error"));
            }
            catch (DomainException a)
            {
                return new Reply(false, new DataString(a.Message));
            }

        }

        [HttpPost]
        public Reply LeaveGame(string username, int gameID)
        {
            try
            {
                if (service.LeaveGame(username, gameID))
                    return new Reply(true, new DataString("true"));
                return new Reply(false, new DataString("unknow error"));
            }
            catch (DomainException a)
            {
                return new Reply(false, new DataString(a.Message));
            }
        }

        [HttpPost]
        public Reply LeaveGame(int playerID, int gameID)
        {
            try
            {
                if (service.LeaveGame(playerID, gameID))
                    return new Reply(true, new DataString("true"));
                return new Reply(false, new DataString("unknow error"));
            }
            catch (DomainException a)
            {
                return new Reply(false, new DataString(a.Message));
            }
        }

        [HttpPost]
        public Reply Bet(int playerID, int gameID, int amount)
        {
            try
            {
                if (service.Bet(playerID, gameID, amount))
                    return new Reply(true, new DataString("true"));
                return new Reply(false, new DataString("unknow error"));
            }
            catch (DomainException a)
            {
                return new Reply(false, new DataString(a.Message));
            }
        }

        [HttpPost]
        public Reply Check(int playerID, int gameID)
        {
            try
            {
                if (service.Check(playerID, gameID))
                    return new Reply(true, new DataString("true"));
                return new Reply(false, new DataString("unknow error"));
            }
            catch (DomainException a)
            {
                return new Reply(false, new DataString(a.Message));
            }
        }

        [HttpPost]
        public Reply Fold(int playerID, int gameID)
        {
            try
            {
                if (service.Fold(playerID, gameID))
                    return new Reply(true, new DataString("true"));
                return new Reply(false, new DataString("unknow error"));
            }
            catch (DomainException a)
            {
                return new Reply(false, new DataString(a.Message));
            }
        }

        [HttpPost]
        public Reply Call(int playerID, int gameID)
        {
            try
            {
                if (service.Call(playerID, gameID))
                    return new Reply(true, new DataString("true"));
                return new Reply(false, new DataString("unknow error"));
            }
            catch (DomainException a)
            {
                return new Reply(false, new DataString(a.Message));
            }
        }

        [HttpPost]
        public Reply ReplayGame(string username, int gameID)
        {
            try
            {
                if (service.ReplayGame(username, gameID))
                    return new Reply(true, new DataString("true"));
                return new Reply(false, new DataString("unknow error"));
            }
            catch (DomainException a)
            {
                return new Reply(false, new DataString(a.Message));
            }
        }

        [HttpPost]
        public Reply SaveTurns(string username, int gameID, string turnData)
        {
            try
            {
                if (service.SaveTurns(username, gameID, turnData))
                    return new Reply(true, new DataString("true"));
                return new Reply(false,new DataString( "unknow error"));
            }
            catch (DomainException a)
            {
                return new Reply(false, new DataString(a.Message));
            }
        }

        [HttpGet]
        public Reply SpectateGame(string username, int gameID)
        {
            try
            {
                return new Reply( true, new DataInt(service.SpectateGame(username, gameID)));
            }
            catch (DomainException a)
            {
                return new Reply(false, new DataString(a.Message));
            }
        }

        [HttpPost]
        public Reply CreateGame(string username, List<KeyValuePair<string, int>> preferenceList)
        {
            try
            {
                return new Reply(true,new DataInt(service.CreateGame(username, preferenceList)));
            }
            catch (DomainException a)
            {
                return new Reply(false, new DataString(a.Message));
            }
        }

        [HttpPost]
        public Reply CreateGame(string username, int gameTypePolicy, int buyInPolicy, int chipPolicy, int minBet,
            int minPlayerCount, int maxPlayerCount, bool isSpectatable)
        {
            try
            {
                return new Reply(true, new DataInt(service.CreateGame(username, gameTypePolicy, buyInPolicy, chipPolicy, minBet, minPlayerCount, maxPlayerCount, isSpectatable)));
            }
            catch (DomainException a)
            {
                return new Reply(false, new DataString(a.Message));
            }
        }

        [HttpGet]
        public Reply SearchActiveGamesByPreferences(int gameType, int buyIn, int chipPolicy, int minBet,
            int maxPlayers, int minPlayers, int spectateGame)
        {
            try
            {
                return new Reply(true, new DataListInt(service.SearchActiveGamesByPreferences(gameType, buyIn, chipPolicy, minBet, maxPlayers, minPlayers, spectateGame)));
            }
            catch (DomainException a)
            {
                return new Reply(false, new DataString(a.Message));
            }
        }

        [HttpGet]
        public Reply SearchActiveGamesByPot(int pot)
        {
            try
            {
                return new Reply(true, new DataListInt(service.SearchActiveGamesByPot(pot)));
            }
            catch (DomainException a)
            {
                return new Reply(false, new DataString(a.Message));
            }
        }

        [HttpGet]
        public Reply SearchActiveGamesByPlayerName(string username)
        {
            try
            {
                return new Reply(true, new DataListInt(service.SearchActiveGamesByPlayerName(username)));
            }
            catch (DomainException a)
            {
                return new Reply(false, new DataString(a.Message));
            }
        }

        [HttpGet]
        public Reply ViewSpectatableGames()
        {
            try
            {
                return new Reply(true, new DataListInt(service.ViewSpectatableGames()));
            }
            catch (DomainException a)
            {
                return new Reply(false, new DataString(a.Message));
            }
        }
    }
}
