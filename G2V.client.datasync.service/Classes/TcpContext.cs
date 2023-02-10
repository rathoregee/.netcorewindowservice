using G2V.client.datasync.service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G2V.client.datasync.service.Classes
{
    internal class TcpContext : ITcpContext
    {
        private List<TcpTask> _tcpTasks = new() { new TcpTask() };

        public async Task<List<TcpTask>> StartAsync(ILogger<ITcpContext> logger, IRepository repository)
        {
            foreach (var x in await repository.GetIpListAsync())
            {
                var task = new TcpTask();
                await task.StartAsync(logger, x.Key, x.Value);
                _tcpTasks.Add(task);
            }
            return _tcpTasks;
        }

        public void Stop()
        {
            foreach (var x in _tcpTasks)
            {
               x.Stop();
            }
        }
    }
}
