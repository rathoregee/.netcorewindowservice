using G2V.client.datasync.service.Interfaces;
using G2V.client.datasync.service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G2V.client.datasync.service.Classes
{
    public class Repository : IRepository
    {
        private readonly IApiClient _api;
        private readonly ILogger<Repository> _logger;
        public Repository(IApiClient api, ILogger<Repository> logger)
        {
            _api = api;
            _logger = logger;
        }
        public async Task<IClientResult<IdNameDto>> GetAsync(int id)
        {
            try
            {
                var result = await _api.GetAsync<IdNameDto>("/TEST");

                return ClientResult.Success(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "logging exception details at GetAsync");

                return ClientResult.ServiceUnavailable<IdNameDto>();
            }
        }
    }
}
