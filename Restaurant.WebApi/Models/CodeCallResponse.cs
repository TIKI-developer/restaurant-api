using Newtonsoft.Json;

namespace Restaurant.WebApi.Models
{
    public class CodeCallResponse
    {
        [JsonProperty("status")]
        public required string Status {  get; set; }

        [JsonProperty("code")]
        public required string Code { get; set; }

        [JsonProperty("call_id")]
        public required string CallId { get; set; }

        [JsonProperty("cost")]
        public required float Cost { get; set; }

        [JsonProperty("balance")]
        public required float Balance { get; set; }
    }
}
