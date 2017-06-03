using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Communication.Service;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Communication
{
    public class Client
    {
        private static string url = "http://localhost:53133/api/server/";
        private static string _username;
        private static string _email;
        private static string _password;
        private static int _playerId;
        public static void Main(string[] args)
        { }

        public static async Task<Reply> RegisterWithMoney(string username, string password, string email, int money)
        {
            if (!username.Equals("") & !password.Equals("") & !email.Equals(""))
            {
                string newUrl = url + "RegisterWithMoney?username=" + username;
                newUrl = newUrl + "&password=" + password + "&email=" + email + "&money" + money;
                Reply ans = await Post(newUrl);
                return ans;
            }
            return new Reply("Invalid input!", false, null, -1);

        }

        public static async Task<Reply> EditProfilePassword(string password)
        {
            if (!password.Equals(""))
            {
                string newUrl = url + "EditProfile?username=" + _username;
                newUrl = newUrl + "&password=" + password + "&email=" + _email;
                Reply ans = await Post(newUrl);
                return ans;
            }
            return new Reply("Invalid input!", false, null, -1);
        }

        public static async Task<Reply> EditProfileEmail(string email)
        {
            if (!email.Equals(""))
            {
                string newUrl = url + "EditProfile?username=" + _username;
                newUrl = newUrl + "&password=" + _password + "&email=" + email;
                Reply ans = await Post(newUrl);
                return ans;
            }
            return new Reply("Invalid input!", false, null, -1);
        }

        public static async Task<Reply> Register(string username, string password, string email)
        {
            if (!username.Equals("") & !password.Equals("") & !email.Equals(""))
            {
                string newUrl = url + "Register?username=" + username;
                newUrl = newUrl + "&password=" + password + "&email=" + email;
                Reply ans = await Post(newUrl);
                if (ans.Sucsses)
                {
                    Login(username, password);
                }
                return ans;
            }
            return new Reply("Invalid input!", false, null, -1);
        }

        public static async Task<Reply> Login(string username, string password)
        {
            if (!username.Equals("") & !password.Equals(""))
            {
                string newUrl = url + "Login?username=" + username;
                newUrl = newUrl + "&password=" + password;
                Reply ans = await Post(newUrl);
                if (ans.Sucsses)
                {
                    _username = username;
                    _password = password;
                    _email = ans.StringContext;
                }
                return ans;
            }
            return new Reply("Invalid input!", false, null, -1);
        }

        public static async Task<Reply> Logout()
        {
            string newUrl = url + "Logout?username=" + _username;
            Reply ans = await Post(newUrl);
            return ans;
        }

        public static async Task<Reply> JoinGame(int gameID)
        {
            string newUrl = url + "JoinGame?username=" + _username;
            newUrl = newUrl + "&gameID=" + gameID;
            Reply ans = await Post(newUrl);
            if (ans.Sucsses)
            {
                _playerId = ans.IntContext;
            }
            return ans;
        }

        public static async Task<Reply> StartGame(string username, int gameID)
        {
            string newUrl = url + "StartGame?username=" + username;
            newUrl = newUrl + "&gameID=" + gameID;
            Reply ans = await Post(newUrl);
            return ans;
        }

        public static async Task<Reply> LeaveGame(int gameID)
        {
            string newUrl = url + "LeaveGame?username=" + _username;
            newUrl = newUrl + "&gameID=" + gameID;
            Reply ans = await Post(newUrl);
            return ans;
        }

        public static async Task<Reply> Bet( int gameID, int amount)
        {
            string newUrl = url + "Bet?playerID=" + _playerId;
            newUrl = newUrl + "&gameID=" + gameID;
            newUrl = newUrl + "&amount=" + amount;
            Reply ans = await Post(newUrl);
            return ans;
        }

        public static async Task<Reply> Check(int gameID)
        {
            string newUrl = url + "Check?playerID=" + _playerId;
            newUrl = newUrl + "&gameID=" + gameID;
            Reply ans = await Post(newUrl);
            return ans;
        }
        public static async Task<Reply> Fold( int gameID)
        {
            string newUrl = url + "Fold?playerID=" + _playerId;
            newUrl = newUrl + "&gameID=" + gameID;
            Reply ans = await Post(newUrl);
            return ans;
        }
        public static async Task<Reply> Call(int gameID)
        {
            string newUrl = url + "Call?playerID=" + _playerId;
            newUrl = newUrl + "&gameID=" + gameID;
            Reply ans = await Post(newUrl);
            return ans;
        }

        // GameCenter
        public static async Task<Reply> CreateGame(string username, List<KeyValuePair<string, int>> preferenceList)
        {
            return null;
        }

        public static async Task<Reply> SearchActiveGamesByPreferences(int gameType, int buyIn, int chipPolicy, int minBet,
            int maxPlayers, int minPlayers, int spectateGame)
        {
            string newUrl = url + "SearchActiveGamesByPreferences?gameType=" + gameType;
            newUrl = newUrl + "&buyIn=" + buyIn;
            newUrl = newUrl + "&chipPolicy=" + chipPolicy;
            newUrl = newUrl + "&minBet=" + minBet;
            newUrl = newUrl + "&maxPlayers=" + maxPlayers;
            newUrl = newUrl + "&minPlayers=" + minPlayers;
            newUrl = newUrl + "&spectateGame=" + spectateGame;
            Reply ans = await Post(newUrl);
            return ans;
        }
        public static async Task<Reply> SearchActiveGamesByPot(int pot)
        {
            string newUrl = url + "SearchActiveGamesByPot?pot=" + pot;
            Reply ans = await Post(newUrl);
            return ans;
        }
        public static async Task<Reply> SearchActiveGamesByPlayerName(string name)
        {
            string newUrl = url + "SearchActiveGamesByPot?pot=" + name;
            Reply ans = await Post(newUrl);
            return ans;
        }
        public static async Task<Reply> ViewSpectatableGames()
        {
            string newUrl = url + "ViewSpectatableGames";
            Reply ans = await Post(newUrl);
            return ans;
        }


        // GameLog
        public static async Task<Reply> ReplayGame(string username, int gameLogID)
        {
            string newUrl = url + "ReplayGame?username=" + username;
            newUrl = newUrl + "&gameLogID=" + gameLogID;
            Reply ans = await Post(newUrl);
            return ans;
        }
        public static async Task<Reply> SaveTurns(string username, int gameID, string turnData)
        {
            string newUrl = url + "SaveTurns?username=" + username;
            newUrl = newUrl + "&gameID=" + gameID;
            newUrl = newUrl + "&turnData=" + turnData;
            Reply ans = await Post(newUrl);
            return ans;
        }
        public static async Task<Reply> SpectateGame(string username, int gameID)
        {
            string newUrl = url + "SpectateGame?username=" + username;
            newUrl = newUrl + "&gameID=" + gameID;
            Reply ans = await Post(newUrl);
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

 /*       static async Task<string> Post(string url)
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
        static async Task<Reply> Post(string url)
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
