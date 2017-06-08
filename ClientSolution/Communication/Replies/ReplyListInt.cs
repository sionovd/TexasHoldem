using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Communication.Replies
{
    public class ReplyListInt
    {
        [JsonProperty("ListIntContent")]
        public List<int> ListIntContent { get; set; }
        [JsonProperty("ErrorMessage")]
        public string ErrorMessage { get; set; }
        [JsonProperty("Sucsses")]
        public bool Sucsses { get; set; }
        public ReplyListInt(bool sucsess, List<int> content, string errorMassage) 
        {
            ListIntContent = content;
            Sucsses = sucsess;
            ErrorMessage = errorMassage;
        }

    }
}