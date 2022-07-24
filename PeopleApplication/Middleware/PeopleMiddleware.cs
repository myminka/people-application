using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using PeopleApplication.Models;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PeopleApplication.Middleware
{
    public class PeopleMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        private readonly EndpointDataSource _endpoinDataSource;
        
        public PeopleMiddleware(RequestDelegate next, EndpointDataSource datasource)
        {
            _requestDelegate = next;
            _endpoinDataSource = datasource;
        }

        public async Task Invoke(HttpContext context)
        {
            PeopleRequest model = null;
            try
            {
                model = context.Request.ReadFromJsonAsync<PeopleRequest>().Result;
                context.Request.Body = new MemoryStream(Encoding.UTF8.GetBytes(JsonSerializer.Serialize(model)));
            }
            catch
            {
                await _requestDelegate.Invoke(context);
                return;
            }

            switch (model.Method)
            {
                case "people.view":
                    context.SetEndpoint(_endpoinDataSource.Endpoints
                        .FirstOrDefault(e => e.DisplayName == "PeopleApplication.Controllers.PeopleController.ViewPeople (PeopleApplication)"));
                    break;
                case "people.list":
                    context.SetEndpoint(
                    _endpoinDataSource.Endpoints
                        .FirstOrDefault(e => e.DisplayName == "PeopleApplication.Controllers.PeopleController.ListPeople (PeopleApplication)"));
                    break;
                default:
                    break;
            }

            await _requestDelegate.Invoke(context);
        }
    }
}