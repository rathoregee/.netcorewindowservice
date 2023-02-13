using Autofac;
using Autofac.Extensions.DependencyInjection;
using G2V.client.datasync.service;
using G2V.client.datasync.service.Classes;
using G2V.client.datasync.service.Interfaces;
using Serilog;

var configuration = new ConfigurationBuilder()
              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
              .AddEnvironmentVariables()
              .AddCommandLine(args)
              .Build();

var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .MinimumLevel.Information()
                .WriteTo.Console()
                .CreateLogger();

await new HostBuilder()
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .ConfigureServices((hostContext, services) =>
            {
                services.AddHostedService<Worker>();
            })
            .ConfigureContainer<ContainerBuilder>(builder =>
            {               
                // registering services in the Autofac ContainerBuilder   
                builder.RegisterType<OrchestrationContext>().As<IOrchestrationContext>().InstancePerLifetimeScope();
                builder.RegisterType<Repository>().As<IRepository>().InstancePerLifetimeScope();
                builder.RegisterInstance(configuration).As<IConfiguration>();
                builder.Register<IHttpClientFactory>(_ =>
                {
                    var services = new ServiceCollection();
                    services.AddHttpClient();
                    var provider = services.BuildServiceProvider();
                    return provider.GetRequiredService<IHttpClientFactory>();
                });
                builder.RegisterType<ApiClient>().As<IApiClient>().InstancePerLifetimeScope();

            })
            .ConfigureLogging(
                    loggingBuilder =>
                    {                        
                        loggingBuilder.AddSerilog(logger, dispose: true);
                    }
                )
            .UseConsoleLifetime()
            .Build()
            .RunAsync();