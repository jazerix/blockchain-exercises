using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Assignment1
{
    public class GetUnspentTransactions
    {
        [JsonPropertyName("result")]
        public List<Add> Result { get; set; }

        [JsonPropertyName("error")]
        public string Error { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }
    }

    public class Add
    {
        [JsonPropertyName("txid")]
        public string Id { get; set; }
        
        [JsonPropertyName("address")]
        public string Address { get; set; }
        
        [JsonPropertyName("label")] 
        public string Label { get; set; }
        
        [JsonPropertyName("amount")] 
        public decimal Amount { get; set; }
    }
}