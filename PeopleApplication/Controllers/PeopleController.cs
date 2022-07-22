using Microsoft.AspNetCore.Mvc;
using PeopleApplication.Services;
using System;

namespace PeopleApplication.Controllers
{
    public class PeopleController : Controller
    {
        private readonly IPeopleService _service;
        public PeopleController(IPeopleService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public Action View()
        {
            throw new NotImplementedException();
        }

        public Action List()
        {
            throw new NotImplementedException();
        }
    }
}
