using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PeopleApplication.Models;
using System;
using System.Collections.Generic;

namespace PeopleApplication.Filters
{
    public class ResourceFilter : Attribute, IResourceFilter
    {
        private PeopleRequest _data;
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            var fs = context.HttpContext.Response;
            var data = ((ObjectResult)context.Result).Value;
            var result = new PeopleResponse
            {
                Jsonrpc = _data.Jsonrpc,
                Method = _data.Method,
                Id = _data.Id,
                Result = (List<People>)data,
            };
            context.Result = new ObjectResult(result);
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            try
            {
                _data = context.HttpContext.Request.ReadFromJsonAsync<PeopleRequest>().Result;
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
