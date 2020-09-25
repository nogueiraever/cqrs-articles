using Core;
using IoC;
using IoC.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LikeService
{
    public class Program
    {
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    var messagingConfiguration = hostContext.Configuration.GetSection(nameof(Messaging)).Get<Messaging>();

                    services.Configure<Messaging>(c =>
                    {
                        c.Exchanges = messagingConfiguration.Exchanges;
                        c.Queues = messagingConfiguration.Queues;
                    });

                    var rabbitMQConfiguration = hostContext.Configuration.GetSection(nameof(RabbitMQConfiguration)).Get<RabbitMQConfiguration>();
                    _ = services.Configure<RabbitMQConfiguration>(c =>
                    {
                        c.Hostname = rabbitMQConfiguration.Hostname;
                        c.Username = rabbitMQConfiguration.Username;
                        c.Password = rabbitMQConfiguration.Password;
                    });

                    services.AddRabbit(messagingConfiguration, rabbitMQConfiguration);
                    services.RegisterDependencies();
                    services.AddHostedService<Worker>();
                });

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
    }
}