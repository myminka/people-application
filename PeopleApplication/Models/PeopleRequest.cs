using System;
using System.Text.Json.Serialization;

namespace PeopleApplication.Models
{
    public class PeopleRequest
    { 
        [JsonPropertyName("jsonrpc")]
        public string Jsonrpc { get; set; }

        [JsonPropertyName("method")]
        public string Method { get; set; }

        [JsonPropertyName("id")]
        public Guid Id { get; set; }
    }
}