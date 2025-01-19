using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace TDD_Assignment_Abbe.Test.TestHelpers
{
    /// Lets you define a function to handle any incoming HttpRequest 
    /// and generate the desired HttpResponse.
    public class MockHttpMessageHandler : HttpMessageHandler
    {
        private readonly Func<HttpRequestMessage, HttpResponseMessage> _handlerFunc;

        public MockHttpMessageHandler(Func<HttpRequestMessage, HttpResponseMessage> handlerFunc)
        {
            _handlerFunc = handlerFunc;
        }

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            var response = _handlerFunc(request);
            return Task.FromResult(response);
        }
    }
}
