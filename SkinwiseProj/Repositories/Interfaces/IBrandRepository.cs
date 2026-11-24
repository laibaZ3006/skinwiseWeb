using SkinwiseProj.Models;

namespace SkinwiseProj.Repositories.Interfaces
{
    public interface IBrandRepository
    {
        Task<IEnumerable<Brand>> GetAllAsync();
    }
}
