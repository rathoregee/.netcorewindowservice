using G2V.client.datasync.service.Interfaces;

namespace G2V.client.datasync.service
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<IOrchestrationContext> _logger;
        private readonly IOrchestrationContext _context;
        private readonly IRepository _repository;

        public Worker(ILogger<IOrchestrationContext> logger, IOrchestrationContext context, IRepository repository)
        {
            _logger = logger;
            _context = context;
            _repository = repository;
        }
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{nameof(Worker)} {DateTime.Now} is starting.");
            _context.StartAsync(_logger, _repository);
            return base.StartAsync(cancellationToken);
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Hearbeat running at: {time}", DateTimeOffset.Now);
                await Task.Delay(5000, stoppingToken);
            }
        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation($"{nameof(Worker)} is stopping.");
            await base.StopAsync(stoppingToken);
        }
    }
}