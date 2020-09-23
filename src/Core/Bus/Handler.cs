using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Core
{
    public abstract class Handler<T> : IRequestHandler<T, Response> where T : Request
    {
        public abstract Task<Response> Handle(T request, CancellationToken cancellationToken);

        protected Response Error(string message)
        {
            return new Response(message);
        }

        protected Response Success(object data)
        {
            return new Response(data);
        }

        protected Response Success(string message)
        {
            return new Response(message);
        }
    }
}