using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

public class Client
{
    //private static string url = "http://texasholdem1.azurewebsites.net/api/server/";
    private static string url = "http://localhost:53133/api/server/";
    //  private static Dictionary<string, HubConnection> connections = new Dictionary<string, HubConnection>();

    static void Main() { }

    public static async Task<ReplyString> GetUserStats(string username)
    {
        string newUrl = url + "GetUserStats?username=" + username;
        ReplyString ans = await GetReplyString(newUrl);
        return ans;
    }

    public static async Task<ReplyListString> Get20TopTotalGrossProfit()
    {
        string newUrl = url + "Get20TopTotalGrossProfit";
        ReplyListString ans = await GetListString(newUrl);
        return ans;
    }

    public static async Task<ReplyListString> Get20TopAmountOfGames()
    {
        string newUrl = url + "Get20TopAmountOfGames";
        ReplyListString ans = await GetListString(newUrl);
        return ans;
    }

    public static async Task<ReplyListString> Get20TopHighestCashInGame()
    {
        string newUrl = url + "Get20TopHighestCashInGame";
        ReplyListString ans = await GetListString(newUrl);
        return ans;
    }


    private static async Task<ReplyListString> GetListString(string url)
    {
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(url))
                {
                    using (HttpContent content = res.Content)
                    {
                        Task<string> ans = content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<ReplyListString>(JToken.Parse(ans.Result).ToString());
                    }
                }
            }
        }
    }

    
    public static async Task<Reply> Login(string username, string password)
    {
        if (!username.Equals("") & !password.Equals(""))
        {
            string newUrl = url + "LoginWebClient?username=" + username;
            newUrl = newUrl + "&password=" + password;
            Reply ans = await PostBool(newUrl);
            if (ans.Sucsses)
            {
                //            connections.Add(username, signalRClient.connection(username));
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
    

    public static async Task<Reply> Logout(string user)
    {
        string newUrl = url + "LogoutWebClient?username=" + user;
        Reply ans = await PostBool(newUrl);
        return ans;
    }

    private static async Task<ReplyString> GetReplyString(string url)
    {

        using (HttpClient client = new HttpClient())
        {
            using (HttpResponseMessage res = await client.GetAsync(url))
            {
                using (HttpContent content = res.Content)
                {

                    Task<string> ans = content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<ReplyString>(JToken.Parse(ans.Result).ToString());
                }
            }
        }
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

        private static async Task<ReplyInt> PostInt(string surl, List<KeyValuePair<string, string>> preferenceList)
    {
        IEnumerable<KeyValuePair<string, string>> quieries = preferenceList;
        HttpContent q = new FormUrlEncodedContent(quieries);
        q.Headers.Add("a", "1");
        MemoryStream stream1 = new MemoryStream();
        DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<KeyValuePair<string, string>>));
        ser.WriteObject(stream1, preferenceList);
        stream1.Position = 0;
        StreamReader sr = new StreamReader(stream1);
        string a = sr.ReadToEnd();
        surl = surl + "&pl=" + a;
        using (HttpClient client = new HttpClient())
        {
            using (HttpResponseMessage res = await client.PostAsync(surl, q))
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

    private static async Task<ReplyString> PostString(string url)
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
                    return JsonConvert.DeserializeObject<ReplyString>(JToken.Parse(ans.Result).ToString());
                }
            }
        }

    }
}
