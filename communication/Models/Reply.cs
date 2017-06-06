using Newtonsoft.Json;
namespace Communication.Replies
{
    public class Reply
    {
        [JsonProperty("Sucsses")]
        public bool Sucsses { get; set; }
        [JsonProperty("ErrorMessage")]
        public string ErrorMessage { get; set; }

        public Reply(bool sucsess , string content)
        {
            Sucsses = sucsess;
            ErrorMessage = content;
        }
    }
}
