using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Communication
{
    public class Reply
    {
        [JsonProperty("StringContext")]
        public string StringContext { get; set; }
        [JsonProperty("IntContext")]
        public int IntContext { get; set; }
        [JsonProperty("Sucsses")]
        public bool Sucsses { get; set; }
        [JsonProperty("ExtraData")]
        public List<int> ExtraData { get; set; }

        public Reply(string context, bool sucsess, List<int> data, int intContent)
        {
            Sucsses = sucsess;
            StringContext = context;
            ExtraData = data;
            IntContext = intContent;
        }
    }
}
