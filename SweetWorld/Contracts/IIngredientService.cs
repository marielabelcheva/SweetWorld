using SweetWorld.Models.IngredientViewModels;

namespace SweetWorld.Contracts
{
    public interface IIngredientService
    {
        public Task AddIngredientAsync(IngredientViewModel viewModel);

        public Task<IEnumerable<IngredientViewModel>> GetAllIngredientsAsync();

        public Task<IngredientViewModel> RemoveIngredientAsync(Guid id);

        public Task RemoveIngredientAsync(IngredientViewModel viewModel);
    }
}
