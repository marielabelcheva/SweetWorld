using SweetWorld.Infrastructure.Data.Models;
using SweetWorld.Core.Models.CategoryViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SweetWorld.Core.Contracts
{
    public interface ICategoryService
    {
        public Task AddCategoryAsync(CategoryViewModel viewModel);

        public Task AddCategoryOfaProductAsync(Guid? productId, Guid? categoryId);

        public SelectList GetAllCategoriesAsync();

        public Task<IEnumerable<string?>> GetAllCategoriesOfAProductAsync(Guid? productId);

        public Task DeleteCategoryAsync(Guid? id);

        public Task DeleteCategoryOfAProductAsync(Guid? productId, Guid? categoryId);
    }
}
