using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace G2V.client.datasync.service.Interfaces
{
    internal interface IRepository
    {
        public Task<Dictionary<IPAddress,int>> GetIpListAsync();
    }
}
