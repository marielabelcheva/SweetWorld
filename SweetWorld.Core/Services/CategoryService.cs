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

            else throw new ArgumentException("Category has already exists!");
        }

        public async Task<IEnumerable<CategoryViewModel>> GetAllCategoriesAsync()
        {
            return await this.dbContext.Categories.Select(category => new CategoryViewModel
            {
                Id = category.Id,
                Name = category.Name
            }).ToListAsync();
        }

        public async Task<CategoryViewModel> RemoveCategoryAsync(Guid id)
        {
            Category? category = await this.dbContext.Categories.FirstOrDefaultAsync(category => category.Id == id);

            if (category != null)
            {
                CategoryViewModel viewModel = new CategoryViewModel()
                {
                    Id = category.Id,
                    Name = category.Name
                };

                return viewModel;
            }

            throw new NullReferenceException();
        }

        public async Task RemoveCategoryAsync(CategoryViewModel viewModel)
        {
            Category? category = await this.dbContext.Categories.FindAsync(viewModel.Id);

            if (category != null)
            {
                this.dbContext.Categories.Remove(category);
                await this.dbContext.SaveChangesAsync();
            }

            else throw new NullReferenceException();
        }
    }
}
