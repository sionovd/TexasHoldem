using System.Web.Script.Serialization;
using Newtonsoft.Json;
namespace Communication.Replies
{
    public class UserDetails
    {
        [JsonProperty("MoneyBalance")]
        public int MoneyBalance { get; set; }
        [JsonProperty("Email")]
        public string Email { get; set; }
        [JsonProperty("LeagueName")]
        public string LeagueName { get; set;}


        public UserDetails()
        {
            
        }

        public UserDetails(string content)
        {
            UserDetails userDetails = new JavaScriptSerializer().Deserialize<UserDetails>(content);
            MoneyBalance = userDetails.MoneyBalance;
            Email = userDetails.Email;
            LeagueName = userDetails.LeagueName;
        }

        public static string ConvertToString(UserDetails userDetails)
        {
            return new JavaScriptSerializer().Serialize(userDetails);
        }
    }


}
