using Newtonsoft.Json;

namespace communication.Models
{
    public class Reply
    {
        [JsonProperty("Sucsses")]
        public bool Sucsses { get; set; }
        [JsonProperty("Content")]
        public Data Content { get; set; }
        public Reply( bool sucsess ,Data content)
        {
            Sucsses = sucsess;
            Content = content;
        }
        
    }
}
