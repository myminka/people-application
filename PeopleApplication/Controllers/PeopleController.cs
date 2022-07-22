using Microsoft.AspNetCore.Mvc;
using PeopleApplication.Services;
using System;
using System.Threading.Tasks;
using PeopleApplication.Filters;
using System.Collections.Generic;
using PeopleApplication.Models;

namespace PeopleApplication.Controllers
{
    [Controller]
    [ResourceFilter]
    public class PeopleController : Controller
    {
        private readonly IPeopleService _service;
        public PeopleController(IPeopleService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [Route("People/")]
        public async Task<List<People>> List()
        {
            return await _service.ShowAllPeople();
        }

        [Route("People/{id}")]
        public async Task<People> View(int id)
        {
            return await _service.ShowPeopleById(Guid.NewGuid());
        }
    }
}