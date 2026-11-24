
using Dapper;
using Microsoft.Data.SqlClient;
using SkinwiseProj.Models;
using SkinwiseProj.Repositories.Interfaces;

namespace SkinwiseProj.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IConfiguration _configuration;

        public ProductRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private SqlConnection CreateConnection()
        {
            return new SqlConnection(
                _configuration.GetConnectionString("DefaultConnection")
            );
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            using var connection = CreateConnection();

            string sql = @"
                SELECT
                    p.Id,
                    p.Name,
                    p.Category,
                    p.Price,
                    p.BrandId,
                    b.Name AS BrandName
                FROM Products p
                INNER JOIN Brands b ON p.BrandId = b.Id
                ORDER BY p.Name";

            return await connection.QueryAsync<Product>(sql);
        }

        public async Task<IEnumerable<Product>> SearchAsync(string? searchTerm)
        {
            using var connection = CreateConnection();

            string sql = @"
                SELECT
                    p.Id,
                    p.Name,
                    p.Category,
                    p.Price,
                    p.BrandId,
                    b.Name AS BrandName
                FROM Products p
                INNER JOIN Brands b ON p.BrandId = b.Id
                WHERE
                    (@SearchTerm IS NULL
                    OR p.Name LIKE '%' + @SearchTerm + '%'
                    OR p.Category LIKE '%' + @SearchTerm + '%'
                    OR b.Name LIKE '%' + @SearchTerm + '%')
                ORDER BY p.Name";

            return await connection.QueryAsync<Product>(
                sql,
                new
                {
                    SearchTerm = string.IsNullOrWhiteSpace(searchTerm)
                    ? null : searchTerm.Trim()
                }
            );
        }
    }
}
