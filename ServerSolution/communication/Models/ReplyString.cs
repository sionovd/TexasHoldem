using Newtonsoft.Json;

namespace Communication.Replies
{
    public class ReplyString
    {
        [JsonProperty("StringContent")]
        public string StringContent { get; set; }
        [JsonProperty("ErrorMessage")]
        public string ErrorMessage { get; set; }
        [JsonProperty("Sucsses")]
        public bool Sucsses { get; set; }
        public ReplyString(bool sucsess, string content,string errorMassage) 
        {
            StringContent = content;
            Sucsses = sucsess;
            ErrorMessage = errorMassage;
        }
        
    }
}
