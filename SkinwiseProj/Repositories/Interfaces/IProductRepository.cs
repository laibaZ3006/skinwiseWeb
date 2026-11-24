using SkinwiseProj.Models;

namespace SkinwiseProj.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();

        Task<IEnumerable<Product>> SearchAsync(string? searchTerm);
    }
}
