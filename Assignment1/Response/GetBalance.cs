using System.Text.Json.Serialization;

namespace Assignment1
{
    public class GetBalance
    {
        [JsonPropertyName("result")]
        public decimal Result { get; set; }

        [JsonPropertyName("error")]
        public string Error { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}