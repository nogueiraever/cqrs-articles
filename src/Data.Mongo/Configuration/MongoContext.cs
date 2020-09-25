using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Data.Mongo
{
    public class MongoContext : IMongoContext
    {
        private readonly IMongoDatabase database;

        public MongoContext(IConfiguration configuration)
        {
            var mongoClient = new MongoClient(configuration.GetConnectionString("ArticlesMongo"));
            database = mongoClient.GetDatabase("Articles");
        }

        public IMongoDatabase Database { get => database; }
    }
}