using Autofac;
using Autofac.Extensions.DependencyInjection;
using G2V.client.datasync.service;
using G2V.client.datasync.service.Classes;
using G2V.client.datasync.service.Interfaces;
using Serilog;

await new HostBuilder()
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .ConfigureServices((hostContext, services) =>
            {
                services.AddHostedService<Worker>();
            })
            .ConfigureContainer<ContainerBuilder>(builder =>
            {
                // registering services in the Autofac ContainerBuilder   
                builder.RegisterType<OrchestrationContext>().As<IOrchestrationContext>();
                builder.RegisterType<Repository>().As<IRepository>();
                builder.RegisterType<ApiClient>().As<IApiClient>();

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