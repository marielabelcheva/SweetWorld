using SweetWorld.Data.Models;
using SweetWorld.Models.CategoryViewModels;

namespace SweetWorld.Contracts
{
    public interface ICategoryService
    {
        public Task AddCategoryAsync(CategoryViewModel viewModel);

        public Task<IEnumerable<CategoryViewModel>> GetAllCategoriesAsync();

        public Task<CategoryViewModel> RemoveCategoryAsync(Guid id);

        public Task RemoveCategoryAsync(CategoryViewModel viewModel);

    }
}
