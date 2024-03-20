using SweetWorld.Infrastructure.Data.Models;
using SweetWorld.Core.Models.CategoryViewModels;

namespace SweetWorld.Core.Contracts
{
    public interface ICategoryService
    {
        public Task AddCategoryAsync(CategoryViewModel viewModel);

        //public Task AddCategoryOfaProductAsync(Guid productId, Guid categoryId);

        public Task<IEnumerable<CategoryViewModel>> GetAllCategoriesAsync();

        public Task<ICollection<string?>> GetAllCategoriesOfAProductAsync(Guid productId);

        public Task DeleteCategoryAsync(Guid id);

        //public Task DeleteCategoryOfAProductAsync(Guid productId, Guid categoryId);

        //all products from category - pagination
    }
}
