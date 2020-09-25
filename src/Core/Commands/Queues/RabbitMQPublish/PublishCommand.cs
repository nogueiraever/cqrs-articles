namespace Core.Commands
{
    public class PublishCommand : Request
    {
        public PublishCommand(string exchangeName, string queueName, string routingKey, object data = null)
        {
            ExchangeName = exchangeName;
            QueueName = queueName;
            RoutingKey = routingKey;
            Data = data;
        }

        protected PublishCommand()
        {
        }

        public object Data { get; set; }
        public string ExchangeName { get; set; }
        public string QueueName { get; set; }
        public string RoutingKey { get; set; }
    }
}