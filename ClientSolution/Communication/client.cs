using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using Communication.Replies;
using Microsoft.AspNet.SignalR.Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Communication
{
    public class Client
    {
        private static string url = "http://localhost:53133/api/server/";
        private static Dictionary<string, HubConnection> connections = new Dictionary<string, HubConnection>();

        static void Main() { }

        public static async Task<Reply> RegisterWithMoney(string username, string password, string email, int money)
        {
            if (!username.Equals("") & !password.Equals("") & !email.Equals(""))
            {
                string newUrl = url + "RegisterWithMoney?username=" + username;
                newUrl = newUrl + "&password=" + password + "&email=" + email + "&money" + money;
                Reply ans = await PostBool(newUrl);
                if(ans.Sucsses)
                    UserInfo.GetUser().SetEmail(email);
                return ans;
            }
            return new Reply(false, "Invalid input!");
        }

        public static async Task<Reply> EditProfilePassword(string password)
        {
            if (!password.Equals(""))
            {
                string newUrl = url + "EditProfile?username=" + UserInfo.GetUser().GetUsername();
                newUrl = newUrl + "&password=" + password + "&email=" + UserInfo.GetUser().GetEmail();
                Reply ans = await PostBool(newUrl);
                if (ans.Sucsses)
                    UserInfo.GetUser().SetPassword(password);
                return ans;
            }
            return new Reply(false, "Invalid input!");
        }

        public static async Task<Reply> EditProfileEmail(string email)
        {
            if (!email.Equals(""))
            {
                string newUrl = url + "EditProfile?username=" + UserInfo.GetUser().GetUsername();
                newUrl = newUrl + "&password=" + UserInfo.GetUser().GetPassword() + "&email=" + email;
                Reply ans = await PostBool(newUrl);
                return ans;
            }
            return new Reply(false, "Invalid input!");
        }

        public static async Task<Reply> Register(string username, string password, string email)
        {
            if (!username.Equals("") & !password.Equals("") & !email.Equals(""))
            {
                string newUrl = url + "Register?username=" + username;
                newUrl = newUrl + "&password=" + password + "&email=" + email;
                Reply ans = await PostBool(newUrl);
                if (ans.Sucsses)
                {
                    await Login(username, password);
                }
                return ans;
            }
            return new Reply(false, "Invalid input!");
        }

        public static async Task<Reply> Login(string username, string password)
        {
            if (!username.Equals("") & !password.Equals(""))
            {
                string newUrl = url + "Login?username=" + username;
                newUrl = newUrl + "&password=" + password;
                Reply ans = await PostBool(newUrl);
                if (ans.Sucsses)
                {
                    connections.Add(username, signalRClient.connection(username));                    
                    UserInfo.GetUser().SetUserName(username);
                    UserInfo.GetUser().SetPassword(password);
                    UserInfo.GetUser().SetEmail(ans.ErrorMessage);
                    UserInfo.GetUser().SetMoneyBalance(Convert.ToInt32(await GetInt(url + "GetBalance?username=" + username)));
                }
                return ans;
            }
            return new Reply(false, "Invalid input!");
        }


        private static async Task<string> GetInt(string s)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(s))
                {
                    using (HttpContent content = res.Content)
                    {

                        Task<string> ans = content.ReadAsStringAsync();
                        return ans.Result;
                    }
                }
            }
        }

        public static async Task<Reply> Logout()
        {
            string newUrl = url + "Logout?username=" + UserInfo.GetUser().GetUsername();
            Reply ans = await PostBool(newUrl);
            string username = UserInfo.GetUser().GetUsername();
            //signalRClient.disconnect(connections[username]);
            connections.Remove(username);
            return ans;
        }

        public static async Task<Reply> DeleteAccount()
        {
            string newUrl = url + "DeleteAccount?username=" + UserInfo.GetUser().GetUsername();
            Reply ans = await PostBool(newUrl);
            return ans;
        }

        public static async Task<ReplyInt> JoinGame(int gameID)
        {
            string newUrl = url + "JoinGame?username=" + UserInfo.GetUser().GetUsername();
            newUrl = newUrl + "&gameID=" + gameID;
            ReplyInt ans = await PostInt(newUrl);
            return ans;
        }

        public static async Task<Reply> StartGame( int gameID)
        {
            string newUrl = url + "StartGame?username=" +  UserInfo.GetUser().GetUsername();
            newUrl = newUrl + "&gameID=" + gameID;
            Reply ans = await PostBool(newUrl);
            return ans;
        }

        public static async Task<Reply> LeaveGame(int gameID)
        {
            string newUrl = url + "LeaveGame?username=" + UserInfo.GetUser().GetUsername();
            newUrl = newUrl + "&gameID=" + gameID;
            Reply ans = await PostBool(newUrl);
            return ans;
        }

        public static async Task<Reply> Bet(int playerId,int gameID, int amount)
        {
            string newUrl = url + "Bet?playerID=" + playerId;
            newUrl = newUrl + "&gameID=" + gameID;
            newUrl = newUrl + "&amount=" + amount;
            Reply ans = await PostBool(newUrl);
            return ans;
        }

        public static async Task<Reply> Check(int playerId, int gameID)
        {
            string newUrl = url + "Check?playerID=" + playerId;
            newUrl = newUrl + "&gameID=" + gameID;
            Reply ans = await PostBool(newUrl);
            return ans;
        }

        public static async Task<Reply> Fold(int playerId, int gameID)
        {
            string newUrl = url + "Fold?playerID=" + playerId;
            newUrl = newUrl + "&gameID=" + gameID;
            Reply ans = await PostBool(newUrl);
            return ans;
        }

        public static async Task<Reply> Call(int playerId, int gameID)
        {
            string newUrl = url + "Call?playerID=" + playerId;
            newUrl = newUrl + "&gameID=" + gameID;
            Reply ans = await PostBool(newUrl);
            return ans;
        }

        // GameCenter
        public static async Task<ReplyInt> CreateGame(List<KeyValuePair<string, int>> preferenceList)
        {
            string newUrl = url + "CreateGame?username=" + UserInfo.GetUser().GetUsername();
            KeyValuePair<string, int>[] temp = preferenceList.ToArray();
            newUrl = newUrl + "&gameType=" + temp[0].Value;
            newUrl = newUrl + "&minPlayers=" + temp[1].Value;
            newUrl = newUrl + "&maxPlayers=" + temp[2].Value;
            newUrl = newUrl + "&minBet=" + temp[3].Value;
            newUrl = newUrl + "&chipPolicy=" + temp[4].Value;
            newUrl = newUrl + "&spectateGame=" + temp[5].Value;
            newUrl = newUrl + "&buyIn=" + temp[6].Value;
            ReplyInt ans = await PostInt(newUrl);
            return ans;
        }

        private static List<KeyValuePair<string, string>> convertToString(
            List<KeyValuePair<string, int>> preferenceList)
        {
            KeyValuePair<string, int>[] a = preferenceList.ToArray();
            List<KeyValuePair<string, string>> ans = new List<KeyValuePair<string, string>>();
            for (int i = 0; i < a.Length; i++)
                ans.Add(new KeyValuePair<string, string>(a[i].Key, a[i].Value.ToString()));
            return ans;
        }

        public static async Task<ReplyListInt> SearchActiveGamesByPreferences(int gameType, int buyIn, int chipPolicy,
            int minBet,
            int maxPlayers, int minPlayers, int spectateGame)
        {
            string newUrl = url + "SearchActiveGamesByPreferences?gameType=" + gameType;
            newUrl = newUrl + "&buyIn=" + buyIn;
            newUrl = newUrl + "&chipPolicy=" + chipPolicy;
            newUrl = newUrl + "&minBet=" + minBet;
            newUrl = newUrl + "&maxPlayers=" + maxPlayers;
            newUrl = newUrl + "&minPlayers=" + minPlayers;
            newUrl = newUrl + "&spectateGame=" + spectateGame;
            ReplyListInt ans = await GetListInt(newUrl);
            return ans;
        }

        public static async Task<ReplyListInt> SearchActiveGamesByPot(int pot)
        {
            string newUrl = url + "SearchActiveGamesByPot?pot=" + pot;
            ReplyListInt ans = await GetListInt(newUrl);
            return ans;
        }

        public static async Task<ReplyListInt> SearchActiveGamesByPlayerName(string name)
        {
            string newUrl = url + "SearchActiveGamesByPot?pot=" + name;
            ReplyListInt ans = await GetListInt(newUrl);
            return ans;
        }

        public static async Task<ReplyListInt> ViewSpectatableGames()
        {
            string newUrl = url + "ViewSpectatableGames";
            ReplyListInt ans = await GetListInt(newUrl);
            return ans;
        }


        // GameLog
        public static async Task<Reply> ReplayGame( int gameLogID)
        {
            string newUrl = url + "ReplayGame?username=" + UserInfo.GetUser().GetUsername();
            newUrl = newUrl + "&gameLogID=" + gameLogID;
            Reply ans = await PostBool(newUrl);
            return ans;
        }

        public static async Task<ReplyInt> SpectateGame( int gameID)
        {
            string newUrl = url + "SpectateGame?username=" + UserInfo.GetUser().GetUsername();
            newUrl = newUrl + "&gameID=" + gameID;
            ReplyInt ans = await GetIntReply(newUrl);
            return ans;
        }

        static async Task<HttpContentHeaders> GetRequest(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(url))
                {
                    using (HttpContent content = res.Content)
                    {
                        HttpContentHeaders headers = content.Headers;
                        return headers;
                    }
                }
            }
        }

        /*       static async Task<string> PostBool(string url)
               {
       
                   IEnumerable<KeyValuePair<string, string>> quieries = new List<KeyValuePair<string, string>>()
                   {
                       // new KeyValuePair<string,string>("x","1"),
                       //  new KeyValuePair<string,string>("y","2")
                   };
                   HttpContent q = new FormUrlEncodedContent(quieries);
       
                   using (HttpClient client = new HttpClient())
                   {
                       using (HttpResponseMessage res = await client.PostAsync(url, q))
                       {
                           using (HttpContent content = res.Content)
                           {
                               string ans = await content.ReadAsStringAsync();
                               return ans;
       
       
                           }
                       }
                   }
               }*/
        private static async Task<ReplyInt> PostInt(string surl, List<KeyValuePair<string, string>> preferenceList)
        {


            IEnumerable<KeyValuePair<string, string>> quieries = preferenceList;
            HttpContent q = new FormUrlEncodedContent(quieries);
           q.Headers.Add("a","1");
            MemoryStream stream1 = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<KeyValuePair<string, string>>));
            ser.WriteObject(stream1, preferenceList);
            stream1.Position = 0;
            StreamReader sr = new StreamReader(stream1);
            string a = sr.ReadToEnd();
            surl = surl + "&pl=" + a;
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.PostAsync(surl,q))
                {
                    using (HttpContent content = res.Content)
                    {

                        Task<string> ans = content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<ReplyInt>(JToken.Parse(ans.Result).ToString());
                    }
                }
            }
        }

        private static async Task<ReplyListInt> GetListInt(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(url))
                {
                    using (HttpContent content = res.Content)
                    {

                        Task<string> ans = content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<ReplyListInt>(JToken.Parse(ans.Result).ToString());
                    }
                }
            }
        }

        private static async Task<ReplyInt> GetIntReply(string url)
        {

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(url))
                {
                    using (HttpContent content = res.Content)
                    {

                        Task<string> ans = content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<ReplyInt>(JToken.Parse(ans.Result).ToString());
                    }
                }
            }
        }
        private static async Task<ReplyInt> PostInt(string url)
        {
            IEnumerable<KeyValuePair<string, string>> quieries = new List<KeyValuePair<string, string>>()
            {
                // new KeyValuePair<string,string>("x","1"),
                //  new KeyValuePair<string,string>("y","2")
            };
            HttpContent q = new FormUrlEncodedContent(quieries);

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.PostAsync(url, q))
                {
                    using (HttpContent content = res.Content)
                    {

                        Task<string> ans = content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<ReplyInt>(JToken.Parse(ans.Result).ToString());
                    }
                }
            }
        }

        private static async Task<Reply> PostBool(string url)
        {

            IEnumerable<KeyValuePair<string, string>> quieries = new List<KeyValuePair<string, string>>()
            {
                // new KeyValuePair<string,string>("x","1"),
                //  new KeyValuePair<string,string>("y","2")
            };
            HttpContent q = new FormUrlEncodedContent(quieries);

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.PostAsync(url, q))
                {
                    using (HttpContent content = res.Content)
                    {

                        Task<string> ans = content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<Reply>(JToken.Parse(ans.Result).ToString());
                    }
                }
            }

        }
    }

}
