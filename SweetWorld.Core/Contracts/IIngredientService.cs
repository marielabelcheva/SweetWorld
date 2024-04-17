using SweetWorld.Core.Models.IngredientViewModels;

namespace SweetWorld.Core.Contracts
{
    public interface IIngredientService
    {
        public Task AddIngredientAsync(string name);

        public Task AddIngredientOfAProductAsync(Guid? productId, string name);

        public Task<IEnumerable<string?>> GetAllIngredientsAsync();

        public Task<IEnumerable<string?>> GetAllIngredientsOfAProductAsync(Guid? productId);

        public Task DeleteIngredientAsync(Guid? id);
    }
}
