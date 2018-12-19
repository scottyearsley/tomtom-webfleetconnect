using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TomTom.WebFleetConnect.Specs
{
    public class FakeHttpMessageHandler : HttpMessageHandler
    {
        private readonly Func<HttpRequestMessage, HttpResponseMessage> _messageReceived;

        public FakeHttpMessageHandler(Func<HttpRequestMessage, HttpResponseMessage> messageReceived)
        {
            _messageReceived = messageReceived;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, 
            CancellationToken cancellationToken)
        {
            if (_messageReceived != null)
            {
                return Task.FromResult(_messageReceived.Invoke(request));
            }

            return Task.FromResult<HttpResponseMessage>(null);
        }

        public static HttpResponseMessage CreateResponse(HttpStatusCode statusCode, object responseObject)
        {
            return new HttpResponseMessage(statusCode)
            {
                Content = new StringContent(JsonConvert.SerializeObject(responseObject))
            };
        }
    }
}