using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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

        public static implicit operator ReplyListString(string v)
        {
            throw new NotImplementedException();
        }
    }

