using Microsoft.AspNetCore.Http;
using ProxyKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProxyKitDemo
{
    public class ProxyHandlers : IProxyHandler
    {

        public Task<HttpResponseMessage> HandleProxyRequest(HttpContext httpContext)
        {
            string host = "https://fakerestapi.azurewebsites.net";
            var forwardContext = httpContext.ForwardTo(host);
            forwardContext.UpstreamRequest.RequestUri = new Uri("https://fakerestapi.azurewebsites.net/api/books");
            var response = forwardContext.Send();
            return response;
        }

        public Task<HttpResponseMessage> HandleProxyRequestForValues(HttpContext httpContext)
        {
            string host = "https://fakerestapi.azurewebsites.net";
            var forwardContext = httpContext.ForwardTo(host);
            forwardContext.UpstreamRequest.RequestUri = new Uri("https://fakerestapi.azurewebsites.net/api/Authors");
            var response = forwardContext.Send();
            return response;
        }
    }
}
