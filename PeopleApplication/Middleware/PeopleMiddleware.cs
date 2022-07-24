using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using PeopleApplication.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleApplication.Middleware
{
    public class PeopleMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        private readonly EndpointDataSource _endpoinDataSource;
        
        public PeopleMiddleware(RequestDelegate next, EndpointDataSource datasource)
        {
            _requestDelegate = next ?? throw new ArgumentException(nameof(next));
            _endpoinDataSource = datasource;
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

            var endpoint = _endpoinDataSource.Endpoints
    .FirstOrDefault(e => e.DisplayName == "PeopleApplication.Controllers.PeopleController.ListPeople (PeopleApplication)");

            var ea = _endpoinDataSource.Endpoints
                        .FirstOrDefault(e => e.DisplayName == "PeopleApplication.Controllers.PeopleController.ViewPeople (PeopleApplication)");

            switch (model.Method)
            {
                case "people.view":                    
                    context.SetEndpoint(
                    _endpoinDataSource.Endpoints
                        .FirstOrDefault(e => e.DisplayName == "PeopleApplication.Controllers.PeopleController.ListPeople (PeopleApplication)"));
                    break;
                case "people.list":
                    context.SetEndpoint(
                    _endpoinDataSource.Endpoints
                        .FirstOrDefault(e => e.DisplayName == "PeopleApplication.Controllers.PeopleController.ViewPeople (PeopleApplication)"));
                    break;
                default:
                    await _requestDelegate.Invoke(context);
                    break;
            }
        }
    }
}