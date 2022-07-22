using PeopleApplication.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PeopleApplication.Services
{
    public class PeopleService : IPeopleService
    {
        private readonly HttpClient _client;
        public PeopleService()
        {
            _client = new HttpClient();
        }

        public async Task<string> ShowAllPeople()
        {
            this._client.DefaultRequestHeaders.Clear();
            Uri uri = new Uri("https://swapi.dev/api/people");
            return await _client.GetStringAsync(uri);
        }

        public async Task<string> ShowPeopleById(Guid guid)
        {
            this._client.DefaultRequestHeaders.Clear();
            Uri uri = new Uri("https://swapi.dev/api/people/1");
            return await _client.GetStringAsync(uri);
        }
    }
}
