using Newtonsoft.Json;

namespace SCB.Models
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