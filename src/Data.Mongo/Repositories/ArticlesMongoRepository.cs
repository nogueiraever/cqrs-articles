using Core.Domain;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace Data.Mongo
{
    public class ArticlesMongoRepository : IArticlesMongoRepository
    {
        private readonly IMongoDatabase database;

        public ArticlesMongoRepository(IMongoContext mongoContext)
        {
            database = mongoContext.Database;
        }

        private IMongoCollection<Article> articles => database.GetCollection<Article>("Articles");

        public async Task<Article> GetById(Guid articleId)
        {
            return (await articles.FindAsync(a => a.Id == articleId)).FirstOrDefault();
        }

        public async Task Save(Article article)
        {
            await articles.InsertOneAsync(article);
        }

        public async Task Update(Article article)
        {
            await articles.FindOneAndReplaceAsync(c => c.Id == article.Id, article);
        }
    }
}