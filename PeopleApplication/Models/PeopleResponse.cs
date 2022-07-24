using System;
using System.Collections.Generic;

namespace PeopleApplication.Models
{
    public class PeopleResponse
    {
        public string Jsonrpc { get; set; }
        public string Method { get; set; }
        public Guid Id { get; set; }
        public List<People> Result { get; set; }
    }
}
