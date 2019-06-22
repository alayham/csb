using Newtonsoft.Json;

namespace SCB.Models
{
    public class RawMetaData
    {
        [JsonProperty]
        public string title;

        [JsonProperty]
        public Variable[] variables;
    }
}