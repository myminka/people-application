using PeopleApplication.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PeopleApplication.Services
{
    public class PeopleService : IPeopleService
    {
        public async Task<IList<PeopleResponse>> ShowAllPeople()
        {
            throw new NotImplementedException();
        }

        public async Task<PeopleResponse> ShowPeopleById(Guid guid)
        {
            throw new NotImplementedException();
        }
    }
}
