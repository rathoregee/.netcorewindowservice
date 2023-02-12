using AutoFixture;
using G2V.client.datasync.service.Classes;
using G2V.client.datasync.service.Interfaces;
using G2V.client.datasync.service.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace G2V.client.datasync.service.tests.Unit
{
    public class ApiClientTests : IDisposable
    {
        private readonly MockIHttpClientFactory _mock;
        private IApiClient _sut;
        private static readonly Fixture _fixture = new();
        public ApiClientTests()
        {
            _mock = new();
        }
        public void Dispose()
        {
        }

        [Fact]
        public async Task ApiClientTests_GetAsync_OK()
        {
            var Expected = _fixture.Create<IdNameDto>();
            _mock.SetupGetAysnc(Expected);
            _sut = new ApiClient(_mock.Configuration, _mock.HttpClientFactory);     
            var actual =  await _sut.GetAsync<IdNameDto>("/Test");        
            Assert.NotNull(actual);
            Assert.Equal(Expected.Id, actual.Id);
            Assert.Equal(Expected.Name, actual.Name);
        }
    }
}
