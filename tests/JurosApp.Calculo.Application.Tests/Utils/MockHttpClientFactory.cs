using Moq;
using Moq.Protected;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace JurosApp.Calculo.Application.Tests.Utils
{
    public class MockHttpClientFactory
    {
        public static HttpClient Create(HttpStatusCode httpStatusCode, string content)
        {
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = httpStatusCode,
                    Content = new StringContent(content)
                });

            return new HttpClient(mockMessageHandler.Object);
        }
    }
}
