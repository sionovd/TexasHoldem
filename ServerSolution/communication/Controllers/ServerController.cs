using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.UI.WebControls;
using Communication.Replies;
using Domain;
using Domain.ServiceLayer;
using Domain.UserModule;


namespace communication.Controllers
{
    public class ServerController : ApiController
    {
        private Service service = new Service();
        private ServerHub Hub = ServerHub.GetInstance;


        [HttpPost]
        public Reply Register(string username, string password, string email)
        {
            try
            {
                if (service.Register(username, password, email))
                    return new Reply(true, "");
                return new Reply(false, "unknow error");
            }
            catch (DomainException a)
            {
                return new Reply(false, (a.Message));
            }
            catch (NullReferenceException e)
            {
                return new Reply(false, e.Message);
            }
        }

        [HttpPost]
        public Reply EditProfile(string username, string password, string email)
        {
            try
            {
                if (service.EditProfile(username, password, email))
                    return new Reply(true, "");
                return new Reply(false, "unknow error");
            }
            catch (DomainException a)
            {
                return new Reply(false, (a.Message));
            }
        }

        [HttpPost]
        public Reply Login(string username, string password)
        {
            try
            {
                if (service.Login(username, password))
                {
                    User temp = UserController.GetInstance.GetUserByName(username);
                    return new Reply(true, temp.Email);
                }
                    
                return new Reply(false, "unknow error");
            }
            catch (DomainException a)
            {
                return new Reply(false, a.Message);
            }
        }

        [HttpGet]
        public int GetBalance(string username)
        {
            return UserController.GetInstance.GetUserByName(username).MoneyBalance;
        }
        [HttpPost]
        public Reply Logout(string username)
        {
            try
            {
                if (service.Logout(username))
                    return new Reply(true, "");
                return new Reply(false, "unknow error");
            }
            catch (DomainException a)
            {
                return new Reply(false, (a.Message));
            }
        }



        [HttpPost]
        public ReplyInt JoinGame(string username, int gameId)
        {
            try
            {
                int playerID = service.JoinGame(username, gameId);
                Hub.addPlayerToTableCom(username, gameId);
                return new ReplyInt(true,"",playerID);
            }
            catch (DomainException a)
            {
                return new ReplyInt(false, a.Message,-1);
            }

        }

        [HttpPost]
        public Reply StartGame(string username, int gameID)
        {
            try
            {
                if (service.StartGame(username, gameID))
                    return new Reply(true, "");
                return new Reply(false, "unknow error");
            }
            catch (DomainException a)
            {
                return new Reply(false, (a.Message));
            }

        }

        [HttpPost]
        public Reply LeaveGame(string username, int gameID)
        {
            try
            {
                if (service.LeaveGame(username, gameID))
                {
                    Hub.removePlayerFromTableCom(username, gameID);
                    return new Reply(true, "");
                }
                return new Reply(false, "unknow error");
            }
            catch (DomainException a)
            {
                return new Reply(false, (a.Message));
            }
        }

        [HttpPost]
        public Reply LeaveGame(int playerID, int gameID)
        {
            try
            {
                if (service.LeaveGame(playerID, gameID))
                    return new Reply(true, "");
                return new Reply(false, "unknow error");
            }
            catch (DomainException a)
            {
                return new Reply(false, (a.Message));
            }
        }

        [HttpPost]
        public Reply Bet(int playerID, int gameID, int amount)
        {
            try
            {
                if (service.Bet(playerID, gameID, amount))
                    return new Reply(true, "");
                return new Reply(false, "unknow error");
            }
            catch (DomainException a)
            {
                return new Reply(false, (a.Message));
            }
        }

        [HttpPost]
        public Reply Check(int playerID, int gameID)
        {
            try
            {
                if (service.Check(playerID, gameID))
                    return new Reply(true, "");
                return new Reply(false, "unknow error");
            }
            catch (DomainException a)
            {
                return new Reply(false, (a.Message));
            }
        }

        [HttpPost]
        public Reply Fold(int playerID, int gameID)
        {
            try
            {
                if (service.Fold(playerID, gameID))
                    return new Reply(true, "");
                return new Reply(false, "unknow error");
            }
            catch (DomainException a)
            {
                return new Reply(false, (a.Message));
            }
        }

        [HttpPost]
        public Reply Call(int playerID, int gameID)
        {
            try
            {
                if (service.Call(playerID, gameID))
                    return new Reply(true, "");
                return new Reply(false, "unknow error");
            }
            catch (DomainException a)
            {
                return new Reply(false, (a.Message));
            }
        }

        [HttpPost]
        public Reply ReplayGame(string username, int gameID)
        {
            try
            {
                if (service.ReplayGame(username, gameID))
                    return new Reply(true, "");
                return new Reply(false, "unknow error");
            }
            catch (DomainException a)
            {
                return new Reply(false, (a.Message));
            }
        }

  /*      [HttpPost]
        public Reply SaveTurns(string username, int gameID, string turnData)
        {
            try
            {
                if (service.SaveTurns(username, gameID, turnData))
                    return new Reply(true, "");
                return new Reply(false, "unknow error");
            }
            catch (DomainException a)
            {
                return new Reply(false, (a.Message));
            }
        }*/

        [HttpGet]
        public ReplyInt SpectateGame(string username, int gameID)
        {
            try
            {
                return new ReplyInt(true,"", service.SpectateGame(username, gameID));
            }
            catch (DomainException a)
            {
                return new ReplyInt(false, a.Message,-1);
            }
        }

        [HttpPost]
        public ReplyInt CreateGame(string username, List<KeyValuePair<string, string>> pl)
        {
            List<KeyValuePair<string, int>> preferenceList = convertToInt(pl);
            try
            {
                int gameId = service.CreateGame(username, preferenceList);
                Hub.addPlayerToTableCom(username, gameId);
                return new ReplyInt(true, "",gameId);
            }
            catch (DomainException a)
            {
                return new ReplyInt(false, a.Message,-1);
            }
        }

        private List<KeyValuePair<string, int>> convertToInt(List<KeyValuePair<string, string>> pl)
        {
            if (pl != null)
            {
                KeyValuePair<string, string>[] a = pl.ToArray();
                List<KeyValuePair<string, int>> ans = new List<KeyValuePair<string, int>>();
                for (int i = 0; i < a.Length; i++)
                    ans.Add(new KeyValuePair<string, int>(a[i].Key, Convert.ToInt32(a[i].Value)));
                return ans;
            }
            return null;
        }

        [HttpGet]
        public ReplyListInt SearchActiveGamesByPreferences(int gameType, int buyIn, int chipPolicy, int minBet,
            int maxPlayers, int minPlayers, int spectateGame)
        {
            try
            {
                return new ReplyListInt(true, service.SearchActiveGamesByPreferences(gameType, buyIn, chipPolicy, minBet, maxPlayers, minPlayers, spectateGame),"");
            }
            catch (DomainException a)
            {
                return new ReplyListInt(false, null,(a.Message));
            }
        }

        [HttpGet]
        public ReplyListInt SearchActiveGamesByPot(int pot)
        {
            try
            {
                return new ReplyListInt(true, service.SearchActiveGamesByPot(pot),"");
            }
            catch (DomainException a)
            {
                return new ReplyListInt(false,null, a.Message);
            }
        }

        [HttpGet]
        public ReplyListInt SearchActiveGamesByPlayerName(string username)
        {
            try
            {
                return new ReplyListInt(true, service.SearchActiveGamesByPlayerName(username),"");
            }
            catch (DomainException a)
            {
                return new ReplyListInt(false,null, a.Message);
            }
        }

        [HttpGet]
        public ReplyListInt ViewSpectatableGames()
        {
            try
            {
                return new ReplyListInt(true, service.ViewSpectatableGames(),"");
            }
            catch (DomainException a)
            {
                return new ReplyListInt(false,null, a.Message);
            }
        }
    }
}