using G2V.client.datasync.service.Classes;
using G2V.client.datasync.service.Enums;
using G2V.client.datasync.service.Extensions;
using G2V.client.datasync.service.Models;
using Xunit;

namespace G2V.client.datasync.service.tests.Unit
{
    public class ClientResultExtensionsTests
    {
        [Fact]
        public void Success()
        {
            var serviceResult = ClientResult.Success().AsServiceResult();
            Assert.Equal(ServiceResultStatus.Success, serviceResult.Status);
        }

        [Fact]
        public void Created()
        {
            var serviceResult = ClientResult.Created().AsServiceResult();
            Assert.Equal(ServiceResultStatus.Created, serviceResult.Status);
        }

        [Fact]
        public void Updated()
        {
            var serviceResult = ClientResult.Updated().AsServiceResult();
            Assert.Equal(ServiceResultStatus.Updated, serviceResult.Status);
        }

        [Fact]
        public void Deleted()
        {
            var serviceResult = ClientResult.Deleted().AsServiceResult();
            Assert.Equal(ServiceResultStatus.Deleted, serviceResult.Status);
        }

        [Fact]
        public void NotFound()
        {
            var serviceResult = ClientResult.NotFound().AsServiceResult();
            Assert.Equal(ServiceResultStatus.NotFound, serviceResult.Status);
        }

        [Fact]
        public void ServiceUnavailable()
        {
            var serviceResult = ClientResult.ServiceUnavailable().AsServiceResult();
            Assert.Equal(ServiceResultStatus.ServiceUnavailable, serviceResult.Status);
        }

        [Fact]
        public void Success_T()
        {
            var serviceResult = ClientResult.Success<NullPayload>().AsServiceResult();
            Assert.Equal(ServiceResultStatus.Success, serviceResult.Status);
        }

        [Fact]
        public void Created_T()
        {
            var serviceResult = ClientResult.Created<NullPayload>().AsServiceResult();
            Assert.Equal(ServiceResultStatus.Created, serviceResult.Status);
        }

        [Fact]
        public void Updated_T()
        {
            var serviceResult = ClientResult.Updated<NullPayload>().AsServiceResult();
            Assert.Equal(ServiceResultStatus.Updated, serviceResult.Status);
        }

        [Fact]
        public void Deleted_T()
        {
            var serviceResult = ClientResult.Deleted<NullPayload>().AsServiceResult();
            Assert.Equal(ServiceResultStatus.Deleted, serviceResult.Status);
        }

        [Fact]
        public void NotFound_T()
        {
            var serviceResult = ClientResult.NotFound<NullPayload>().AsServiceResult();
            Assert.Equal(ServiceResultStatus.NotFound, serviceResult.Status);
        }

        [Fact]
        public void ServiceUnavailable_T()
        {
            var serviceResult = ClientResult.ServiceUnavailable<NullPayload>().AsServiceResult();
            Assert.Equal(ServiceResultStatus.ServiceUnavailable, serviceResult.Status);
        }

        [Fact]
        public void Success_ResultT()
        {
            var serviceResult = ClientResult.Success().AsServiceResult<NullPayload>();
            Assert.Equal(ServiceResultStatus.Success, serviceResult.Status);
        }

        [Fact]
        public void Created_ResultT()
        {
            var serviceResult = ClientResult.Created().AsServiceResult<NullPayload>();
            Assert.Equal(ServiceResultStatus.Created, serviceResult.Status);
        }

        [Fact]
        public void Updated_ResultT()
        {
            var serviceResult = ClientResult.Updated().AsServiceResult<NullPayload>();
            Assert.Equal(ServiceResultStatus.Updated, serviceResult.Status);
        }

        [Fact]
        public void Deleted_ResultT()
        {
            var serviceResult = ClientResult.Deleted().AsServiceResult<NullPayload>();
            Assert.Equal(ServiceResultStatus.Deleted, serviceResult.Status);
        }

        [Fact]
        public void NotFound_ResultT()
        {
            var serviceResult = ClientResult.NotFound().AsServiceResult<NullPayload>();
            Assert.Equal(ServiceResultStatus.NotFound, serviceResult.Status);
        }

        [Fact]
        public void ServiceUnavailable_ResultT()
        {
            var serviceResult = ClientResult.ServiceUnavailable().AsServiceResult<NullPayload>();
            Assert.Equal(ServiceResultStatus.ServiceUnavailable, serviceResult.Status);
        }
    }
}
