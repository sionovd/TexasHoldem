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
                    return new Reply("true", true, null, -1);
                return new Reply("unknow error", false, null, -1);
            }
            catch (DomainException a)
            {
                return new Reply(a.Message, false, null, -1);
            }
            catch (NullReferenceException e)
            {
                return new Reply(e.Message, false, null, -1);
            }
        }

        [HttpPost]
        public Reply EditProfile(string username, string password, string email)
        {
            try
            {
                if (service.EditProfile(username, password, email))
                    return new Reply("true", true, null, -1);
                return new Reply("unknow error", false, null, -1);
            }
            catch (DomainException a)
            {
                return new Reply(a.Message, false, null, -1);
            }
        }

        [HttpPost]
        public Reply Login(string username, string password)
        {
            try
            {
                if (service.Login(username, password))
                    return new Reply(service.GetEmail(username), true, null, -1);
                return new Reply("unknow error", false, null, -1);
            }
            catch (DomainException a)
            {
                return new Reply(a.Message, false, null, -1);
            }
        }

        [HttpPost]
        public Reply Logout(string username)
        {
            try
            {
                if (service.Logout(username))
                    return new Reply("true", true, null, -1);
                return new Reply("unknow error", false, null, -1);
            }
            catch (DomainException a)
            {
                return new Reply(a.Message, false, null, -1);
            }
        }

        [HttpPost]
        public Reply RegisterWithMoney(string username, string password, string email, int money)
        {
            try
            {
                if (service.RegisterWithMoney(username, password, email, money))
                    return new Reply("true", true, null, -1);
                return new Reply("unknow error", false, null, -1);
            }
            catch (DomainException a)
            {
                return new Reply(a.Message, false, null, -1);
            }
        }

        [HttpPost]
        public Reply JoinGame(string username, int gameId)
        {
            try
            {
                return new Reply("", true, null, service.JoinGame(username, gameId));
            }
            catch (DomainException a)
            {
                return new Reply(a.Message, false, null, -1);
            }

        }

        [HttpPost]
        public Reply StartGame(string username, int gameID)
        {
            try
            {
                if (service.StartGame(username, gameID))
                    return new Reply("true", true, null, -1);
                return new Reply("unknow error", false, null, -1);
            }
            catch (DomainException a)
            {
                return new Reply(a.Message, false, null, -1);
            }

        }

        [HttpPost]
        public Reply LeaveGame(string username, int gameID)
        {
            try
            {
                if (service.LeaveGame(username, gameID))
                    return new Reply("true", true, null, -1);
                return new Reply("unknow error", false, null, -1);
            }
            catch (DomainException a)
            {
                return new Reply(a.Message, false, null, -1);
            }
        }

        [HttpPost]
        public Reply LeaveGame(int playerID, int gameID)
        {
            try
            {
                if (service.LeaveGame(playerID, gameID))
                    return new Reply("true", true, null, -1);
                return new Reply("unknow error", false, null, -1);
            }
            catch (DomainException a)
            {
                return new Reply(a.Message, false, null, -1);
            }
        }

        [HttpPost]
        public Reply Bet(int playerID, int gameID, int amount)
        {
            try
            {
                if (service.Bet(playerID, gameID, amount))
                    return new Reply("true", true, null, -1);
                return new Reply("unknow error", false, null, -1);
            }
            catch (DomainException a)
            {
                return new Reply(a.Message, false, null, -1);
            }
        }

        [HttpPost]
        public Reply Check(int playerID, int gameID)
        {
            try
            {
                if (service.Check(playerID, gameID))
                    return new Reply("true", true, null, -1);
                return new Reply("unknow error", false, null, -1);
            }
            catch (DomainException a)
            {
                return new Reply(a.Message, false, null, -1);
            }
        }

        [HttpPost]
        public Reply Fold(int playerID, int gameID)
        {
            try
            {
                if (service.Fold(playerID, gameID))
                    return new Reply("true", true, null, -1);
                return new Reply("unknow error", false, null, -1);
            }
            catch (DomainException a)
            {
                return new Reply(a.Message, false, null, -1);
            }
        }

        [HttpPost]
        public Reply Call(int playerID, int gameID)
        {
            try
            {
                if (service.Call(playerID, gameID))
                    return new Reply("true", true, null, -1);
                return new Reply("unknow error", false, null, -1);
            }
            catch (DomainException a)
            {
                return new Reply(a.Message, false, null, -1);
            }
        }

        [HttpPost]
        public Reply ReplayGame(string username, int gameID)
        {
            try
            {
                if (service.ReplayGame(username, gameID))
                    return new Reply("true", true, null, -1);
                return new Reply("unknow error", false, null, -1);
            }
            catch (DomainException a)
            {
                return new Reply(a.Message, false, null, -1);
            }
        }

        [HttpPost]
        public Reply SaveTurns(string username, int gameID, string turnData)
        {
            try
            {
                if (service.SaveTurns(username, gameID, turnData))
                    return new Reply("true", true, null, -1);
                return new Reply("unknow error", false, null, -1);
            }
            catch (DomainException a)
            {
                return new Reply(a.Message, false, null, -1);
            }
        }

        [HttpGet]
        public Reply SpectateGame(string username, int gameID)
        {
            try
            {
                return new Reply("true", true, null, service.SpectateGame(username, gameID));
            }
            catch (DomainException a)
            {
                return new Reply(a.Message, false, null, -1);
            }
        }

        [HttpPost]
        public Reply CreateGame(string username, List<KeyValuePair<string, int>> preferenceList)
        {
            try
            {
                return new Reply("true", true, null, service.CreateGame(username, preferenceList));
            }
            catch (DomainException a)
            {
                return new Reply(a.Message, false, null, -1);
            }
        }

        [HttpGet]
        public Reply SearchActiveGamesByPreferences(int gameType, int buyIn, int chipPolicy, int minBet,
            int maxPlayers, int minPlayers, int spectateGame)
        {
            try
            {
                return new Reply("true", true, service.SearchActiveGamesByPreferences(gameType, buyIn, chipPolicy, minBet, maxPlayers, minPlayers, spectateGame), -1);
            }
            catch (DomainException a)
            {
                return new Reply(a.Message, false, null, -1);
            }
        }

        [HttpGet]
        public Reply SearchActiveGamesByPot(int pot)
        {
            try
            {
                return new Reply("true", true, service.SearchActiveGamesByPot(pot), -1);
            }
            catch (DomainException a)
            {
                return new Reply(a.Message, false, null, -1);
            }
        }

        [HttpGet]
        public Reply SearchActiveGamesByPlayerName(string username)
        {
            try
            {
                return new Reply("true", true, service.SearchActiveGamesByPlayerName(username), -1);
            }
            catch (DomainException a)
            {
                return new Reply(a.Message, false, null, -1);
            }
        }

        [HttpGet]
        public Reply ViewSpectatableGames()
        {
            try
            {
                return new Reply("true", true, service.ViewSpectatableGames(), -1);
            }
            catch (DomainException a)
            {
                return new Reply(a.Message, false, null, -1);
            }
        }
    }
}
