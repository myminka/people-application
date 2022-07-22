using Microsoft.AspNetCore.Http;
using PeopleApplication.Models;
using System;
using System.Threading.Tasks;

namespace PeopleApplication.Middleware
{
    public class PeopleMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        public PeopleMiddleware(RequestDelegate next)
        {
            _requestDelegate = next ?? throw new ArgumentException(nameof(next));
        }

        public async Task Invoke(HttpContext context)
        {
            PeopleRequest model = null;
            try
            {
                model = context.Request.ReadFromJsonAsync<PeopleRequest>().Result;
            }
            catch
            {
                await _requestDelegate.Invoke(context);
                return;
            }

            context.Request.Method = "GET";
            switch (model.Method)
            {
                case "people.view":
                    context.Request.Path = "https://localhost:44334/people/1";
                    break;
                case "people.list":
                    context.Request.Path = "https://localhost:44334/people";
                    break;
                default:
                    await _requestDelegate.Invoke(context);
                    break;
            }
        }
    }
}