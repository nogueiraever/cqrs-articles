using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Threading.Tasks;

namespace Data.Sql
{
    public class ArticlesWriteRepository : IArticlesWriteRepository
    {
        private readonly string connectionString;

        public ArticlesWriteRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("ArticlesPgSql");
        }

        public async Task LikeAsync(long articleId, int likes)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                await connection.ExecuteAsync("update articles set likes = @likes where id = @articleId", new { articleId, likes });
            }
        }
    }
}