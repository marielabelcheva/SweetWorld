using SweetWorld.Core.Models.IngredientViewModels;

namespace SweetWorld.Core.Contracts
{
    public interface IIngredientService
    {
        public Task AddIngredientAsync(IngredientViewModel viewModel);

        public Task<IEnumerable<IngredientViewModel>> GetAllIngredientsAsync();

        public Task<IngredientViewModel> RemoveIngredientAsync(Guid id);

        public Task RemoveIngredientAsync(IngredientViewModel viewModel);

        public Task<IEnumerable<string?>> GetAllIngredientsOfAProductAsync(Guid productId);
    }
}
