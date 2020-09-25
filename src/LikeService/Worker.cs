using Core;
using Core.Commands;
using Data.Mongo;
using Data.Sql;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace LikeService
{
    public class Worker : BackgroundService
    {
        private readonly Messaging messaging;
        private readonly IModel model;
        private readonly IServiceScopeFactory serviceScopeFactory;

        public Worker(IModel model,
                      IOptionsMonitor<Messaging> messaging,
                      IServiceScopeFactory serviceScopeFactory)
        {
            this.model = model ?? throw new ArgumentNullException(nameof(model));
            this.serviceScopeFactory = serviceScopeFactory ?? throw new ArgumentNullException(nameof(serviceScopeFactory));
            this.messaging = messaging.CurrentValue;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();
            var consumer = new EventingBasicConsumer(model);
            consumer.Received += async (ch, ea) =>
            {
                if (ea.RoutingKey == messaging.Queues.Articles.LikeRoute)
                {
                    var message = Encoding.UTF8.GetString(ea.Body.Span);
                    var command = JsonSerializer.Deserialize<PublishCommand>(message);
                    await Like(Guid.Parse(command.Data.ToString()));
                    model.BasicAck(ea.DeliveryTag, false);
                }
                else
                    model.BasicNack(ea.DeliveryTag, false, false);
            };

            model.BasicConsume(messaging.Queues.Articles.QueueName, false, consumer);
        }

        private async Task Like(Guid articleId)
        {
            using (var scope = serviceScopeFactory.CreateScope())
            {
                var articlesMongoRepository = scope.ServiceProvider.GetRequiredService<IArticlesMongoRepository>();
                var articlesWriteRepository = scope.ServiceProvider.GetRequiredService<IArticlesWriteRepository>();

                var article = await articlesMongoRepository.GetById(articleId);
                if (article != null)
                {
                    article.Like();
                    await articlesMongoRepository.Update(article);
                    await articlesWriteRepository.LikeAsync(articleId, article.Likes);
                }
            }
        }
    }
}