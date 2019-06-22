using Newtonsoft.Json;

namespace SCB.Models
{
    public class Variable
    {
        [JsonProperty]
        public string code;

        [JsonProperty]
        public string text;

        [JsonProperty]
        public string[] values;

        [JsonProperty]
        public string[] valueTexts;

        [JsonProperty]
        public bool elimination;

        [JsonProperty]
        public bool time;
    }
}