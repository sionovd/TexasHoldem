using Newtonsoft.Json;

namespace Communication.Replies
{
    public class ReplyString :Reply
    {
        [JsonProperty("StringContent")]
        public string StringContent { get; set; }

        public ReplyString(bool sucsess, string content) : base(sucsess,"")
        {
            StringContent = content;
        }
        
    }
}
