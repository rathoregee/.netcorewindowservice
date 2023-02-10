using G2V.client.datasync.service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace G2V.client.datasync.service.Classes
{
    internal class TcpTask : ITcpTask
    {
        private TcpClient _client = new();

        public async Task<TcpClient> StartAsync(ILogger<ITcpContext> logger, IPAddress ip, int port)
        {
            try
            {
                var ipEndPoint = new IPEndPoint(ip, port);

                await _client.ConnectAsync(ipEndPoint);

                await using NetworkStream stream = _client.GetStream();

                var buffer = new byte[1_024];
                int received = await stream.ReadAsync(buffer);

                var message = Encoding.UTF8.GetString(buffer, 0, received);
                Console.WriteLine($"Message received: \"{message}\"");

            }
            catch
            {
                _client.Dispose();
            }

            return _client;
        }

        public void Stop()
        {
            _client.Close();          
        }
    }
}
