using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

    public class Reply
    {
        [JsonProperty("Sucsses")]
        public bool Sucsses { get; set; }
        [JsonProperty("ErrorMessage")]
        public string ErrorMessage { get; set; }
        public Reply(bool sucsess, string content)
        {
            Sucsses = sucsess;
            ErrorMessage = content;
        }

    public static implicit operator Task<object>(Reply v)
    {
        throw new NotImplementedException();
    }
}




