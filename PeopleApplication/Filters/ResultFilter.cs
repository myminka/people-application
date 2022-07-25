using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PeopleApplication.Models;
using System;
using System.Reflection;
using Mono.Reflection;
using System.Threading.Tasks;

namespace PeopleApplication.Filters
{
    public class ResultFilter : Attribute, IResultFilter
    {
        private PeopleRequest _data;

        public void OnResultExecuted(ResultExecutedContext context)
        {
        }

        public async void OnResultExecuting(ResultExecutingContext context)
        {
            try
            {
                _data = await context.HttpContext.Request.ReadFromJsonAsync<PeopleRequest>();
            }
            catch
            {
                _data = new PeopleRequest
                {
                    Id = default,
                    Jsonrpc = "2.0",
                    Method = "uncknown",
                };
            }

            var data = ((ObjectResult)context.Result).Value;

            var result = new PeopleResponse
            {
                Jsonrpc = _data.Jsonrpc,
                Method = _data.Method,
                Id = _data.Id,
                Result = data
            };

            context.Result = new ObjectResult(result);
        }
    }
}
