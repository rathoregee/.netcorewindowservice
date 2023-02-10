using Autofac;
using Autofac.Extensions.DependencyInjection;
using G2V.client.datasync.service;
using Serilog;


//IHost host = Host.CreateDefaultBuilder(args)
//    .ConfigureServices(services =>
//    {
//        services.AddHostedService<Worker>();
//    }).
//    ConfigureAppConfiguration(
//            (hostContext, config) =>
//            {
//    config.SetBasePath(Directory.GetCurrentDirectory());
//    config.AddJsonFile("appsettings.json", false, true);
//    config.AddCommandLine(args);
//}
//      )
//    .ConfigureLogging(
//            loggingBuilder =>
//            {
//                var configuration = new ConfigurationBuilder()
//                   .AddJsonFile("appsettings.json")
//                   .Build();
//                var logger = new LoggerConfiguration()
//                    .ReadFrom.Configuration(configuration)
//                    .CreateLogger();
//                loggingBuilder.AddSerilog(logger, dispose: true);
//            }
//      )
//    .Build();

//await host.RunAsync();



await new HostBuilder()
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .ConfigureServices((hostContext, services) =>
            {
                services.AddHostedService<Worker>();
            })
            .ConfigureContainer<ContainerBuilder>(builder =>
            {
                // registering services in the Autofac ContainerBuilder   
                builder.RegisterType<SMSService>().As<IMobileServive>();


            })
            .ConfigureLogging(
                    loggingBuilder =>
                    {
                        var configuration = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .Build();
                        var logger = new LoggerConfiguration()
                            .ReadFrom.Configuration(configuration)
                            .WriteTo.Console()
                            .CreateLogger();
                        loggingBuilder.AddSerilog(logger, dispose: true);
                    }
                )
            .UseConsoleLifetime()
            .Build()
            .RunAsync();