﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G2V.client.datasync.service.Interfaces
{
    internal interface IOrchestrationContext
    {        
        public Task StartAsync(ILogger<IOrchestrationContext> logger, IRepository repository);
        public void Stop();
    }
}