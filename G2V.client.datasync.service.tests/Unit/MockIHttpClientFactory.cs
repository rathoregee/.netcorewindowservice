using Microsoft.Extensions.Configuration;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace G2V.client.datasync.service.tests.Unit
{
    public class MockIHttpClientFactory
    {
        private readonly Mock<IHttpClientFactory> _factory = new();
        private readonly Mock<IConfiguration> _mockConfig = new();
        public IHttpClientFactory HttpClientFactory => _factory.Object;
        public IConfiguration Configuration => _mockConfig.Object;
        public const string SERVICE_URL = "http://yahoo.com";
        public MockIHttpClientFactory()
        {
            SetupConifguration();
        }

        private void SetupConifguration()
        {
            _mockConfig.SetupGet(x => x[It.Is<string>(s => s == "SERVICE_URL")]).Returns(SERVICE_URL);
        }

        public void SetupGetAysnc<T>(T data)
        {
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(JsonConvert.SerializeObject(data))
                });

            var httpClient = new HttpClient(mockMessageHandler.Object);

            _factory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(httpClient);
        }

        public void SetupExSetUpException()
        {
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
                .Throws(new Exception("http exception"));

            var httpClient = new HttpClient(mockMessageHandler.Object);

            _factory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(httpClient);
        }
    }
}
