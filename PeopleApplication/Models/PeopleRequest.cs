using System;

namespace PeopleApplication.Models
{
    public class PeopleRequest
    { 
        public string Jsonrpc { get; set; }
        public string Method { get; set; }
        public Guid Id { get; set; }
    }
}
