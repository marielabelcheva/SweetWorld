using SweetWorld.Core.Models.IngredientViewModels;
using System.Web.Mvc;

namespace SweetWorld.Core.Contracts
{
    public interface IIngredientService
    {
        public Task AddIngredientAsync(IngredientViewModel viewModel);

        public Task AddIngredientOfAProductAsync(Guid? productId, Guid? ingredientId);

        public Task<IEnumerable<IngredientViewModel>> GetAllIngredientsAsync();

        public SelectList GetIngredientsAsync();

        public Task<IEnumerable<string?>> GetAllIngredientsOfAProductAsync(Guid? productId);

        public Task DeleteIngredientAsync(Guid? id);
    }
}
