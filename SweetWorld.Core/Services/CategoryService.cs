using Microsoft.EntityFrameworkCore;
using SweetWorld.Core.Contracts;
using SweetWorld.Infrastructure.Data;
using SweetWorld.Infrastructure.Data.Models;
using SweetWorld.Core.Models.CategoryViewModels;
using System.Security.Policy;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        public async Task DeleteCategoryAsync(Guid? id)
        {
            Category? category = await this.dbContext.Categories.FindAsync(id);

            if (category != null)
            {
                this.dbContext.Categories.Remove(category);
                await this.dbContext.SaveChangesAsync();
            }

            throw new NullReferenceException();
        }

        public SelectList GetAllCategoriesAsync() { return new SelectList(this.dbContext.Categories, "Id", "Name"); }

        public async Task AddCategoryOfaProductAsync(Guid? productId, Guid? categoryId)
        {
            Product? product = await this.dbContext.Products.FindAsync(productId);
            Category? category = await this.dbContext.Categories.FindAsync(categoryId);

            if (product != null && category != null)
            {
                ProductsCategories productCategory = new ProductsCategories()
                {
                    Product = product,
                    Category = category
                };

                await this.dbContext.ProductsCategories.AddAsync(productCategory);
                await this.dbContext.SaveChangesAsync();
            }

            throw new NullReferenceException();
        }

        public async Task<IEnumerable<string?>> GetAllCategoriesOfAProductAsync(Guid? productId)
        {
            var product = await this.dbContext.Products.Include(product => product.Categories)
                                                        .ThenInclude(category => category.Category)
                                                        .FirstOrDefaultAsync(product => product.Id == productId);

            if (product?.Categories != null) { return product.Categories.Select(category => category?.Category?.Name).ToHashSet(); }

            throw new NullReferenceException();
        }

        public async Task DeleteCategoryOfAProductAsync(Guid? productId, Guid? categoryId)
        {
            var productCat = await this.dbContext.ProductsCategories.FirstOrDefaultAsync(productCategory =>
                                                      productCategory.ProductId == productId && productCategory.CategoryId == categoryId);

            if (productCat != null)
            {
                this.dbContext.ProductsCategories.Remove(productCat);
                await this.dbContext.SaveChangesAsync();
            }

            throw new NullReferenceException();
        }
    }
}
