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
            var resultList = new List<People>();
            this._client.DefaultRequestHeaders.Clear();
            var nextUrl = await GetOnePage(resultList, "https://swapi.dev/api/people");
            while (!(nextUrl is null))
            {
                nextUrl = await GetOnePage(resultList, nextUrl);
            }

            return resultList;

            async Task<string> GetOnePage(List<People> list, string url)
            {
                var uri = new Uri(url);
                var json = await _client.GetStringAsync(uri);
                var response = JsonSerializer.Deserialize<SwapiResponse>(json);
                resultList.AddRange(response.Results);
                return response.Next;
            }
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
