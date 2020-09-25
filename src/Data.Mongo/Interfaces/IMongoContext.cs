using MongoDB.Driver;

namespace Data.Mongo
{
    public interface IMongoContext
    {
        IMongoDatabase Database { get; }
    }
}