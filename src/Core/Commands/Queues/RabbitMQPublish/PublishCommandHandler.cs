using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Commands
{
    public class PublishCommandHandler : Handler<PublishCommand>
    {
        private readonly IModel model;

        public PublishCommandHandler(IModel model)
        {
            this.model = model ?? throw new System.ArgumentNullException(nameof(model));
        }

        public override async Task<Response> Handle(PublishCommand request, CancellationToken cancellationToken)
        {
            var mensagem = JsonSerializer.Serialize(request);
            var body = Encoding.UTF8.GetBytes(mensagem);
            System.Console.WriteLine(request.RoutingKey);
            model.QueueBind(request.QueueName, request.ExchangeName, request.RoutingKey);
            model.BasicPublish(request.ExchangeName, request.RoutingKey, null, body);
            return await Task.FromResult(Success("Publish successfull"));
        }
    }
}