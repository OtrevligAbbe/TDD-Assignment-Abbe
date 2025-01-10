using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

// A mock HTTP message handler for simulating HTTP responses
public class MockHttpMessageHandler : HttpMessageHandler
{
    private readonly Func<HttpRequestMessage, HttpResponseMessage> _handler;

    // Constructor accepts a function to handle HTTP requests and return mock responses
    public MockHttpMessageHandler(Func<HttpRequestMessage, HttpResponseMessage> handler)
    {
        _handler = handler;
    }

    // Overrides SendAsync to return a mock HTTP response based on the provided handler function
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_handler(request));
    }
}
