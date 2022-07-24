using PeopleApplication.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PeopleApplication.Services
{
    public interface IPeopleService
    {
        Task<List<People>> ShowAllPeople();
        Task<People> ShowPeopleById(Guid guid);
    }
}