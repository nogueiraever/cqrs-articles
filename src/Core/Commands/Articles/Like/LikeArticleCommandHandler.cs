using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Commands
{
    public class LikeArticleCommandHandler : Handler<LikeArticleCommand>
    {
        public override async Task<Response> Handle(LikeArticleCommand request, CancellationToken cancellationToken)
        {
            var message = JsonSerializer.Serialize(request);

            return Success("Article liked.");
        }
    }
}