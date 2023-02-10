namespace G2V.client.datasync.service
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IMobileServive _svc;

        public Worker(ILogger<Worker> logger, IMobileServive svc)
        {
            _logger = logger;
            _svc = svc;
        }
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{nameof(Worker)} {DateTime.Now} is starting.");
            _svc.Execute();
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

    public interface IMobileServive
    {
        void Execute();
    }
    public class SMSService : IMobileServive
    {
        public void Execute()
        {
            Console.WriteLine("SMS service executing.");
        }
    }
}