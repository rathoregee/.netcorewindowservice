using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace G2V.client.datasync.service.Interfaces
{
    internal interface ITcpTask
    {
        public Task<TcpClient> StartAsync(ILogger<ITcpContext> logger, IPAddress ip, int port);
        public void Stop();
    }
}
