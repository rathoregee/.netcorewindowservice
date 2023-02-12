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
            //:TODO
        }

        [Fact]
        public async Task RepositoryTests_GetAsync_OK()
        {
            //Given
            var expected = _fixture.Create<IdNameDto>();
            _mock.SetupGetAysnc(expected);
            _client = new ApiClient(_mock.Configuration, _mock.HttpClientFactory);
            _sut = new Repository(_client, _loggger.Object);
            //When
            var actual =  await _sut.GetAsync(1);
            //Then
            Assert.NotNull(actual);
            Assert.Equal(ClientResultStatus.Success, actual.Status);
            Assert.Equal(expected.Id, actual.Payload.Id);
            Assert.Equal(expected.Name, actual.Payload.Name);
        }

        [Fact]
        public async Task RepositoryTests_GetAsync_NotFound()
        {
            //Given           
            _mock.SetupGetAysnc_Null<IdNameDto>();
            _client = new ApiClient(_mock.Configuration, _mock.HttpClientFactory);
            _sut = new Repository(_client, _loggger.Object);
            //When
            var actual = await _sut.GetAsync(1);
            //Then
            Assert.NotNull(actual);
            Assert.Equal(ClientResultStatus.NotFound, actual.Status);
        }


        [Fact]
        public async Task RepositoryTests_GetAsync_Exception()
        {
            //Given           
            _mock.SetUpException();
            _client = new ApiClient(_mock.Configuration, _mock.HttpClientFactory);
            _sut = new Repository(_client, _loggger.Object);
            //When
            var actual = await _sut.GetAsync(1);
            //Then
            Assert.NotNull(actual);
            Assert.Equal(ClientResultStatus.ServiceUnavailable, actual.Status);
        }
    }
}
