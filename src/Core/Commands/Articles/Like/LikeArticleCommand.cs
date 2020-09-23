namespace Core.Commands
{
    public class LikeArticleCommand : Request
    {
        public LikeArticleCommand(long articleId)
        {
            ArticleId = articleId;
        }

        public long ArticleId { get; set; }
    }
}