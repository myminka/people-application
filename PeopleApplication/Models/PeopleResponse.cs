using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PeopleApplication.Models
{
    public class PeopleResponse
    {
        [JsonPropertyName("jsonrpc")]
        public string Jsonrpc { get; set; }

        [JsonPropertyName("method")]
        public string Method { get; set; }

        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("result")]
        public object Result { get; set; }
    }
}