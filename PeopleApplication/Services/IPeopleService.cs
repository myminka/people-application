using PeopleApplication.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PeopleApplication.Services
{
    public interface IPeopleService
    {
        Task<IList<PeopleResponse>> ShowAllPeople();
        Task<PeopleResponse> ShowPeopleById(Guid guid);
    }
}
