using Newtonsoft.Json;

namespace Company.Function
{
    public class Counter
    {
        [JsonProperty("id")]
        public string Id { get; set; } = string.Empty;

        [JsonProperty("count")]
        public int Count { get; set; }
    }
}