using Data.Mongo;
using Data.Sql;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace IoC
{
    public static class Dependencies
    {
        public static void RegisterDependencies(this IServiceCollection services)
        {
            MongoConfiguration.Configure();
            services.TryAddScoped<IMongoContext, MongoContext>();
            services.TryAddScoped<IArticlesWriteRepository, ArticlesWriteRepository>();
            services.TryAddScoped<IArticlesMongoRepository, ArticlesMongoRepository>();
        }
    }
}