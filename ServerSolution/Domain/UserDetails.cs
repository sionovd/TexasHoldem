using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace Domain
{
    public class UserDetails
    {
        [JsonProperty("MoneyBalance")]
        public int MoneyBalance { get; set; }
        [JsonProperty("Email")]
        public string Email { get; set; }
        [JsonProperty("LeagueName")]
        public string LeagueName { get; set; }

        public UserDetails()
        {
            
        }

        public UserDetails(int moneyBalance, string email, string leaguegName)
        {
            MoneyBalance = moneyBalance;
            Email = email;
            LeagueName = leaguegName;
        }

        public static string ConvertToString(UserDetails userDetails)
        {
            return new JavaScriptSerializer().Serialize(userDetails);
        }
    }
}