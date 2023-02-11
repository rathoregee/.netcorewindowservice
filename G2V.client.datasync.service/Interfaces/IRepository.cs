using G2V.client.datasync.service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace G2V.client.datasync.service.Interfaces
{
    public interface IRepository
    {
        public Task<IClientResult<IdNameDto>> GetAsync(int id);
    }
}
