using G2V.client.datasync.service.Enums;
using G2V.client.datasync.service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G2V.client.datasync.service.Classes
{
    public class OrchestrationContext : IOrchestrationContext
    {
        public async Task StartAsync(ILogger<IOrchestrationContext> logger, IRepository repository)
        {
          var response =  await repository.GetAsync(1);

            if (response.Status == ClientResultStatus.Success)
            {
                Console.WriteLine(response.Payload.ToString());
            }
        }

        public void Stop()
        {
            throw new NotSupportedException();
        }
    }
}
