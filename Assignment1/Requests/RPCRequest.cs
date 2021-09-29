using System;
using System.Text.Json.Serialization;

namespace Assignment1.Requests
{
    public class RpcRequest
    {
        [JsonPropertyName("jsonrpc")]
        public string JsonRpc { get; set; } = "1.0";

        [JsonPropertyName("id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [JsonPropertyName("method")]
        public string Method { get; set; }

        [JsonPropertyName("params")]
        public object[] Params { get; set; }


        public RpcRequest(string method, params object[] @params)
        {
            Method = method;
            Params = @params;
        }
    }
}