using System;
using System.Text.Json.Serialization;

namespace Assignment1.Requests
{
    public class RPCRequest
    {
        [JsonPropertyName("jsonrpc")]
        public string JsonRpc { get; set; } = "1.0";

        [JsonPropertyName("id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [JsonPropertyName("method")]
        public string Method { get; set; }

        public string[] Params { get; set; }


        public RPCRequest(string method, params string[] @params)
        {
            Method = method;
            Params = @params;
        }
    }
}