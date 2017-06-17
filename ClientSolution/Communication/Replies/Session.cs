using Newtonsoft.Json;
namespace Communication.Replies
{
    public class Session
    {
        [JsonProperty("MoneyBalance")]
        public int MoneyBalance { get; set; }
        [JsonProperty("Email")]
        public string Email { get; set; }
        [JsonProperty("LeagueName")]
        public string LeagueName { get; set;}
        [JsonProperty("ErrorMessage")]
        public string ErrorMessage { get; set; }
        [JsonProperty("Sucsses")]
        public bool Sucsses { get; set; }


        public Session(int moneyBalance, string email, string leaguegName, bool sucsess, string errorMassage)
        {
            MoneyBalance = moneyBalance;
            Email = email;
            LeagueName = leaguegName;
            Sucsses = sucsess;
            ErrorMessage = errorMassage;
        }
    }


}
