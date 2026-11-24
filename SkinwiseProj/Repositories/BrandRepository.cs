
using Dapper;
using Microsoft.Data.SqlClient;
using SkinwiseProj.Models;
using SkinwiseProj.Repositories.Interfaces;

namespace SkinwiseProj.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private readonly IConfiguration _configuration;

        public BrandRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<Brand>> GetAllAsync()
        {
            using var connection = new SqlConnection(
                _configuration.GetConnectionString("DefaultConnection")
            );

            string sql = @"
                SELECT Id, Name
                FROM Brands
                ORDER BY Name";

            return await connection.QueryAsync<Brand>(sql);
        }
    }
}
