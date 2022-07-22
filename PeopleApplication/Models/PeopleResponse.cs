using Microsoft.AspNetCore.Mvc;
using System;

namespace PeopleApplication.Models
{
    public class PeopleResponse
    {
        public string Jsonrpc { get; set; }
        public string Method { get; set; }
        public Guid Id { get; set; }
        public IActionResult Result { get; set; }
    }
}
