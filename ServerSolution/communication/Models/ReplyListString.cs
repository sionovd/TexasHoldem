using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace communication.Models
{
    public class ReplyListString
    {
        [JsonProperty("ListIntContent")]
        public List<string> ListStringContent { get; set; }
        [JsonProperty("ErrorMessage")]
        public string ErrorMessage { get; set; }
        [JsonProperty("Sucsses")]
        public bool Sucsses { get; set; }
        public ReplyListString(bool sucsess, List<string> content, string errorMassage)
        {
            ListStringContent = content;
            Sucsses = sucsess;
            ErrorMessage = errorMassage;
        }

    }
}