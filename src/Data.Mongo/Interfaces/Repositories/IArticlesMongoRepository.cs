using Core.Domain;
using System;
using System.Threading.Tasks;

namespace Data.Mongo
{
    public interface IArticlesMongoRepository
    {
        Task<Article> GetById(Guid articleId);

        Task Save(Article article);

        Task Update(Article article);
    }
}