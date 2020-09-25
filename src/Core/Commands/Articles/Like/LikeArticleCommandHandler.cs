using MediatR;
using Microsoft.Extensions.Options;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Commands
{
    public class LikeArticleCommandHandler : Handler<LikeArticleCommand>
    {
        private readonly IMediator mediator;
        private readonly Messaging messaging;

        public LikeArticleCommandHandler(IMediator mediator,
                                         IOptionsMonitor<Messaging> messaging)
        {
            this.mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
            this.messaging = messaging.CurrentValue;
        }

        public override async Task<Response> Handle(LikeArticleCommand request, CancellationToken cancellationToken)
        {
            await mediator.Send(new PublishCommand(messaging.Exchanges.Jobs, messaging.Queues.Articles.QueueName, messaging.Queues.Articles.LikeRoute, request.ArticleId));
            return await Task.FromResult(Success("Article liked."));
        }
    }
}