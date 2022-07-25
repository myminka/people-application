using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PeopleApplication.Models;
using System;
using System.Text;
using System.Text.Json;

namespace PeopleApplication.Filters
{
    public class ResourceFilter : Attribute, IResourceFilter
    {
        private PeopleRequest _data;
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            var data = ((ObjectResult)context.Result).Value;
            var result = new PeopleResponse
            {
                Jsonrpc = _data.Jsonrpc,
                Method = _data.Method,
                Id = _data.Id,
                Result = data,
            };

            context.Result = new ObjectResult(result);
            var bytes = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(result));
            
            context.HttpContext.Response.Body.WriteAsync(bytes);
        }

        public async void OnResourceExecuting(ResourceExecutingContext context)
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
        }
    }
}
