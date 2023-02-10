using G2V.client.datasync.service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace G2V.client.datasync.service.Classes
{
    internal class Repository : IRepository
    {
        public async Task<Dictionary<IPAddress, int>> GetIpListAsync()
        {
            throw new NotImplementedException();
        }
    }
}
