using AutoFixture;
using G2V.client.datasync.service.Classes;
using G2V.client.datasync.service.Enums;
using G2V.client.datasync.service.Interfaces;
using G2V.client.datasync.service.Models;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace G2V.client.datasync.service.tests.Unit
{
    public class RepositoryTests : IDisposable
    {
        private readonly MockIHttpClientFactory _mock;
        private readonly Mock<ILogger<Repository>> _loggger = new();
        private IRepository _sut;
        private IApiClient _client;
        private static readonly Fixture _fixture = new();
        public RepositoryTests()
        {
            _mock = new();            
        }
        public void Dispose()
        {
            
        }

        [Fact]
        public async Task RepositoryTests_GetAsync_OK()
        {
            var Expected = _fixture.Create<IdNameDto>();
            _mock.SetupGetAysnc(Expected);
            _client = new ApiClient(_mock.Configuration, _mock.HttpClientFactory);
            _sut = new Repository(_client, _loggger.Object);
            var actual =  await _sut.GetAsync(1);        
            Assert.NotNull(actual);
            Assert.Equal(ClientResultStatus.Success, actual.Status);
            Assert.Equal(Expected.Id, actual.Payload.Id);
            Assert.Equal(Expected.Name, actual.Payload.Name);
        }
    }
}
