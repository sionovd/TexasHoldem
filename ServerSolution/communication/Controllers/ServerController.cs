using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Script.Serialization;
using communication.Models;
using Communication.Replies;
using Domain;
using Domain.DomainLayerExceptions;
using Domain.UserModule;
using ServiceLayer;

namespace communication.Controllers
{
    public class ServerController : ApiController
    {
        private Service service = new Service();


        [HttpGet]
        public ReplyListString GetAllUsernames()
        {
            try
            {
                List<string> usernames = service.GetAllUsernames();
                return new ReplyListString(true, usernames, "");
            }
            catch (DomainException e)
            {
                return new ReplyListString(false, null, e.Message);
            }
        }

        [HttpGet]
        public ReplyString GetUserStats(string username)
        {
            try
            {
                string stats = service.GetUserStats(username);
                return new ReplyString(true, stats, "");


                /*
                  
                 this is how you call this function from the client:
                 public static async Task<ReplyString> GetUserStats(string username)
                 {
                    string newUrl = url + "GetUserStats?username=" + username;
                    ReplyString ans = await PostString(newUrl);
                    return ans;
                 }
                 
                
                and this is how you deserialize it into your object:
                 
                
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                Statistics a  = serializer.Deserialize<Statistics>(stats); <--- "stats" is a string

                

                 */
            }
            catch (DomainException e)
            {
                return new ReplyString(false, "", e.Message);
            }
        }

        [HttpPost]
        public ReplyString GetUserDetails(string username)
        {
            try
            {
                return new ReplyString(true, service.GetUserDetails(username), "");
            }
            catch (DomainException e)
            {
                return new ReplyString(false, "", e.Message);
            }
        }

        [HttpPost]
        public ReplyString GetReplayInfo(int gameID)
        {
            try
            {
                return new ReplyString(true, service.ReplayGame(gameID), "");
            }
            catch (DomainException e)
            {
                return new ReplyString(false, "", e.Message);
            }
        }

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
        public Reply DeleteAccount(string username)
        {
            try
            {
                service.DeleteAccount(username);
                return new Reply(true, "");
            }
            catch (DomainException e)
            {
                return new Reply(false, e.Message);
            }
        }

        [HttpPost]
        public Reply SendMessage(string senderUsername, string message, int gameID)
        {
            try
            {
                service.SendMessage(senderUsername, message, gameID);
                return new Reply(true, "");
            }
            catch (DomainException e)
            {
                return new Reply(false, e.Message);
            }
        }

        [HttpPost]
        public Reply SendWhisper(string senderUsername, string receiverUsername, string whisper, int gameID)
        {
            try
            {
                service.SendWhisper(senderUsername, receiverUsername, whisper, gameID);
                return new Reply(true, "");
            }
            catch (DomainException e)
            {
                return new Reply(false, e.Message);
            }
        }

        [HttpPost]
        public ReplyInt JoinGame(string username, int gameId)
        {
            try
            {
                int playerID = service.JoinGame(username, gameId);
                ServerHub.addPlayerToTableCom(username, gameId);
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
                    ServerHub.removePlayerFromTableCom(username, gameID);
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

        [HttpGet]
        public ReplyInt SpectateGame(string username, int gameID)
        {
            try
            {
                int spectatorID = service.SpectateGame(username, gameID);
                ServerHub.addPlayerToTableCom(username, gameID);
                return new ReplyInt(true,"", spectatorID);
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
                ServerHub.addPlayerToTableCom(username, gameId);
                return new ReplyInt(true, "",gameId);
            }
            catch (DomainException a)
            {
                return new ReplyInt(false, a.Message,-1);
            }
        }

        [HttpPost]
        public ReplyInt CreateGame(string username, int gameType, int minPlayers, int maxPlayers, int minBet,
            int chipPolicy, int spectateGame, int buyIn)
        {
            try
            {
                List<KeyValuePair<string, int>> toSand = new List<KeyValuePair<string, int>>();
                toSand.Add(new KeyValuePair<string, int>("gameType", gameType));
                toSand.Add(new KeyValuePair<string, int>("minPlayers", minPlayers));
                toSand.Add(new KeyValuePair<string, int>("maxPlayers", maxPlayers));
                toSand.Add(new KeyValuePair<string, int>("minBet", minBet));
                toSand.Add(new KeyValuePair<string, int>("chipPolicy", chipPolicy));
                toSand.Add(new KeyValuePair<string, int>("spectateGame", spectateGame));
                toSand.Add(new KeyValuePair<string, int>("buyIn", buyIn));
                int gameId = service.CreateGame(username, toSand);
                ServerHub.addPlayerToTableCom(username, gameId);
                return new ReplyInt(true, "", gameId);
            }
            catch (DomainException a)
            {
                return new ReplyInt(false, a.Message, -1);
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