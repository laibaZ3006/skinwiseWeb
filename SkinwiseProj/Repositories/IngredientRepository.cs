
using Dapper;
using Microsoft.Data.SqlClient;
using SkinwiseProj.Models;
using SkinwiseProj.Repositories.Interfaces;


namespace SkinwiseProj.Repositories
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly IConfiguration _configuration;

        public IngredientRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<Ingredient>> GetAllAsync()
        {
            using var connection = new SqlConnection(
                _configuration.GetConnectionString("DefaultConnection")
            );

            string sql = @"
                SELECT Id, Name, Description
                FROM Ingredients
                ORDER BY Name";

            return await connection.QueryAsync<Ingredient>(sql);
        }
    }
}
