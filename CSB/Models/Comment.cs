using Newtonsoft.Json;

namespace SCB.Models
{
    public class Comment
    {
        [JsonProperty]
        public string variable;

        [JsonProperty]
        public string value;

        [JsonProperty]
        public string comment;

    }
}