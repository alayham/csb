using Newtonsoft.Json;

namespace CSB.Models
{
    public class RawMetaData
    {
        [JsonProperty]
        public string title;

        [JsonProperty]
        public Variable[] variables;
    }
}