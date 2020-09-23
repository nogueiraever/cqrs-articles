using Core;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;

namespace IoC.Extensions
{
    public static class RabbitExtension
    {
        public static void AddRabbit(this IServiceCollection services, Messaging messaging, RabbitMQConfiguration rabbitMQConfiguration)
        {
            var factory = new ConnectionFactory
            {
                HostName = rabbitMQConfiguration.Hostname,
                UserName = rabbitMQConfiguration.Username,
                Password = rabbitMQConfiguration.Password
            };

            var conexaoRabbit = factory.CreateConnection();
            IModel _channel = conexaoRabbit.CreateModel();
            services.AddSingleton(conexaoRabbit);
            services.AddSingleton(_channel);

            _channel.ExchangeDeclare(messaging.Exchanges.Jobs, ExchangeType.Topic);
            _channel.QueueDeclare(messaging.Queues.Articles.QueueName, false, false, false, null);
            _channel.QueueBind(messaging.Queues.Articles.QueueName, messaging.Exchanges.Jobs, "*");
        }
    }
}