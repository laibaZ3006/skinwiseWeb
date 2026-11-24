using SkinwiseProj.Models;

namespace SkinwiseProj.Repositories.Interfaces
{
    public interface IIngredientRepository
    {
        Task<IEnumerable<Ingredient>> GetAllAsync();
    }
}
