using Newtonsoft.Json;

namespace Communication.Replies
{
    public class ReplyInt : Reply
    {
        [JsonProperty("IntContent")]
        public int IntContent { get; set; }
        public ReplyInt(bool sucsess, int content)
            : base(sucsess,"")
        {
            IntContent = content;
        }
        public ReplyInt(bool sucsess, string content)
            : base(sucsess,content)
        {
           
        }
    }
}
