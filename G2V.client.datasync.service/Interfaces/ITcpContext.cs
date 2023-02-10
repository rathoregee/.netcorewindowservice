using G2V.client.datasync.service.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G2V.client.datasync.service.Interfaces
{
    internal interface ITcpContext
    {        
        public Task<List<TcpTask>> StartAsync(ILogger<ITcpContext> logger, IRepository repository);
        public void Stop();
    }
}