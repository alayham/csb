using Newtonsoft.Json;

namespace SCB.Models
{
    public class DataValue
    {
        [JsonProperty]
        public string[] Key = new string[4];

        [JsonProperty]
        public string[] values = new string[1];
    }
}