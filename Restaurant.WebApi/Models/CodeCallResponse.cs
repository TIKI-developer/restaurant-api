using Newtonsoft.Json;

namespace Restaurant.WebApi.Models
{
    public class CodeCallResponse
    {
        [JsonProperty("success")]
        public required bool Success { get; set; }

        [JsonProperty("data")]
        public required CodeCallResponseData Data { get; set; }

        public class CodeCallResponseData
        {
            [JsonProperty("pin")]
            public required string Pin { get; set; }
            [JsonProperty("key")]
            public required string Key { get; set; }
            [JsonProperty("operator")]
            public required string Operator { get; set; }
        }
    }
}
