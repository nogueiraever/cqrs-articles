using System;
using System.Threading.Tasks;

namespace Data.Sql
{
    public interface IArticlesWriteRepository
    {
        Task LikeAsync(Guid articleId, int likes);
    }
}