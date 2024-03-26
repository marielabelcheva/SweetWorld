using SweetWorld.Core.Models.IngredientViewModels;

namespace SweetWorld.Core.Contracts
{
    public interface IIngredientService
    {
        public Task AddIngredientAsync(IngredientViewModel viewModel);

        public Task AddIngredientOfAProductAsync(Guid productId, Guid ingredientId);

        public Task<IEnumerable<IngredientViewModel>> GetAllIngredientsAsync(); // pagination

        public Task<ICollection<string?>> GetAllIngredientsOfAProductAsync(Guid productId);

        public Task DeleteIngredientAsync(Guid id);

        public Task DeleteIngredientOfAProductAsync(Guid productId, Guid ingredientId);
    }
}
