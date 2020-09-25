using Data.Mongo;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Queries
{
    public class GetArticleLikesQueryHandler : Handler<GetArticleLikesQuery>
    {
        private readonly IArticlesMongoRepository articlesMongoRepository;

        public GetArticleLikesQueryHandler(IArticlesMongoRepository articlesMongoRepository)
        {
            this.articlesMongoRepository = articlesMongoRepository ?? throw new System.ArgumentNullException(nameof(articlesMongoRepository));
        }

        public override async Task<Response> Handle(GetArticleLikesQuery request, CancellationToken cancellationToken)
        {
            if (request.ArticleId == Guid.Empty)
                return Error("The article Id is required.", HttpStatusCode.BadRequest);

            var article = await articlesMongoRepository.GetById(request.ArticleId);
            if (article != null)
                return Success(article.Likes);

            return Error("Article not found.", HttpStatusCode.NoContent);
        }
    }
}