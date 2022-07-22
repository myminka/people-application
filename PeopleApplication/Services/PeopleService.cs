using PeopleApplication.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
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

        public async Task<List<People>> ShowAllPeople()
        {
            this._client.DefaultRequestHeaders.Clear();
            var uri = new Uri("https://swapi.dev/api/people");
            var json = await _client.GetStringAsync(uri);
            return JsonSerializer.Deserialize<List<People>>(json);
        }

        public async Task<People> ShowPeopleById(Guid guid)
        {
            this._client.DefaultRequestHeaders.Clear();
            var uri = new Uri("https://swapi.dev/api/people/1");
            var json = await _client.GetStringAsync(uri);
            return JsonSerializer.Deserialize<People>(json);
        }
    }
}
