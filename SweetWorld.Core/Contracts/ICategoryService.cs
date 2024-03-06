using SweetWorld.Infrastructure.Data.Models;
using SweetWorld.Core.Models.CategoryViewModels;

namespace SweetWorld.Core.Contracts
{
    public interface ICategoryService
    {
        public Task AddCategoryAsync(CategoryViewModel viewModel);

        public Task<IEnumerable<CategoryViewModel>> GetAllCategoriesAsync();

        public Task<CategoryViewModel> RemoveCategoryAsync(Guid id);

        public Task RemoveCategoryAsync(CategoryViewModel viewModel);

        //all products from category - pagination
    }
}
