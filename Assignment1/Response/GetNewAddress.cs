using System.Text.Json.Serialization;

namespace Assignment1.Response
{
    public class GetNewAddress
    {
        [JsonPropertyName("result")]
        public string Result { get; set; }

        [JsonPropertyName("error")]
        public string Error { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}