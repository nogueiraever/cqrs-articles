using Data.Sql;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace IoC
{
    public static class Dependencies
    {
        public static void RegisterDependencies(this IServiceCollection services)
        {
            services.TryAddScoped<IArticlesWriteRepository, ArticlesWriteRepository>();
        }
    }
}