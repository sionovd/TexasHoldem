using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


    public class ReplyInt
    {
        [JsonProperty("IntContent")]
        public int IntContent { get; set; }
        [JsonProperty("Sucsses")]
        public bool Sucsses { get; set; }
        [JsonProperty("ErrorMessage")]
        public string ErrorMessage { get; set; }
        public ReplyInt(bool sucsess, string content, int cont)
        {
            Sucsses = sucsess;
            ErrorMessage = content;
            IntContent = cont;
        }

    }


