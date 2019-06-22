using Newtonsoft.Json;

namespace SCB.Models
{
    public class Column
    {
        [JsonProperty]
        public string code;

        [JsonProperty]
        public string text;

        [JsonProperty]
        public string type;
    }
}