using System.Threading.Tasks;

namespace Data.Sql
{
    public interface IArticlesWriteRepository
    {
        Task LikeAsync(long articleId, int likes);
    }
}