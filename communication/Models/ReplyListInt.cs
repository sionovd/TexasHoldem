using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Communication.Replies
{
    public class ReplyListInt:Reply
    {
        [JsonProperty("ListIntContent")]
        public List<int> ListIntContent { get; set; }
        public ReplyListInt(bool sucsess, List<int> content) : base(sucsess,"")
        {
            ListIntContent = content;
        }
        public ReplyListInt(bool sucsess, string content)
            : base(sucsess,content)
        {
           
        }
    }
}