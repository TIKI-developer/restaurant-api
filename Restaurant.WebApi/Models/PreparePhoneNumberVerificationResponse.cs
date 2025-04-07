using Newtonsoft.Json;

namespace Restaurant.WebApi.Models
{
    public class PreparePhoneNumberVerificationResponse
    {
        [JsonProperty("status")]
        public required string Status { get; set; }

        [JsonProperty("status_code")]
        public required string StatusCode { get; set; }

        [JsonProperty("check_id")]
        public required string CheckId { get; set; }

        [JsonProperty("call_phone")]
        public required string CallNumber { get; set; }

        [JsonProperty("call_phone_pretty")]
        public required string CallNumberPretty { get; set; }

        [JsonProperty("call_phone_html")]
        public required string CallNumberHtml { get; set; }
    }
}
