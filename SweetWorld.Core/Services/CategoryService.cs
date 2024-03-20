using Microsoft.EntityFrameworkCore;
using SweetWorld.Core.Contracts;
using SweetWorld.Infrastructure.Data;
using SweetWorld.Infrastructure.Data.Models;
using SweetWorld.Core.Models.CategoryViewModels;
using System.Security.Policy;

namespace SweetWorld.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext dbContext;

        public CategoryService(ApplicationDbContext dbContext) { this.dbContext = dbContext; }

        public async Task AddCategoryAsync(CategoryViewModel viewModel)
        {
            Category category = new Category()
            {
                Id = Guid.NewGuid(),
                Name = viewModel.Name
            };

            if(!await this.dbContext.Categories.ContainsAsync(category))
            {
                await this.dbContext.Categories.AddAsync(category);
                await this.dbContext.SaveChangesAsync();
            }

            throw new ArgumentException("Category has already exists!");
        }

        public async Task DeleteCategoryAsync(Guid id)
        {
            Category? category = await this.dbContext.Categories.FindAsync(id);

            if (category != null)
            {
                this.dbContext.Categories.Remove(category);
                await this.dbContext.SaveChangesAsync();
            }

            throw new NullReferenceException();
        }

        public async Task<IEnumerable<CategoryViewModel>> GetAllCategoriesAsync()
        {
            return await this.dbContext.Categories.Select(category => new CategoryViewModel
            {
                Id = category.Id,
                Name = category.Name
            }).ToListAsync();
        }

        public async Task<ICollection<string?>> GetAllCategoriesOfAProductAsync(Guid productId)
        {
            var product = await this.dbContext.Products.Include(product => product.Categories)
                                                        .ThenInclude(category => category.Category)
                                                        .FirstOrDefaultAsync(product => product.Id == productId);

            if (product?.Categories != null) { return product.Categories.Select(category => category?.Category?.Name).ToHashSet(); }

            throw new NullReferenceException();
        }
    }
}
