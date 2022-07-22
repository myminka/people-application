using System;
using System.Threading.Tasks;

namespace PeopleApplication.Services
{
    public interface IPeopleService
    {
        Task<string> ShowAllPeople();
        Task<string> ShowPeopleById(Guid guid);
    }
}
