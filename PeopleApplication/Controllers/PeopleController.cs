using Microsoft.AspNetCore.Mvc;
using PeopleApplication.Services;
using System;
using System.Threading.Tasks;

namespace PeopleApplication.Controllers
{
    [Controller]
    [Route("people")]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleService _service;
        public PeopleController(IPeopleService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet]
        public async Task<string> List()
        {
            return await _service.ShowAllPeople();
        }

        [HttpGet("{id}")]
        public async Task<string> View(int id)
        {
            return await _service.ShowPeopleById(Guid.NewGuid());
        }
    }
}
