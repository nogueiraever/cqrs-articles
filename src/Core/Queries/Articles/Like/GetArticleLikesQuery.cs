using System;

namespace Core.Queries
{
    public class GetArticleLikesQuery : Request
    {
        public GetArticleLikesQuery(Guid articleId)
        {
            ArticleId = articleId;
        }

        public Guid ArticleId { get; set; }
    }
}