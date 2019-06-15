using Newtonsoft.Json;

namespace CSB.Models
{
    public class RawData
    {
        [JsonProperty]
        public Column[] columns;

        [JsonProperty]
        public Comment[] comments;

        [JsonProperty]
        public DataValue[] data;

    }
}