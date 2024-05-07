using Microsoft.EntityFrameworkCore;
using SweetWorld.Core.Contracts;
using SweetWorld.Infrastructure.Data;
using SweetWorld.Infrastructure.Data.Models;
using SweetWorld.Core.Models.CategoryViewModels;
using System.Security.Policy;
using Microsoft.AspNetCore.Mvc.Rendering;
using SweetWorld.Core.Models.IngredientViewModels;
using Microsoft.AspNetCore.Mvc;
using SweetWorld.Core.Models.Pagination;

namespace SweetWorld.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext dbContext;

        public CategoryService(ApplicationDbContext dbContext) 
        { 
            this.dbContext = dbContext;
            this.Pager = null!;
        }

        public Pager Pager { get; set; }

        public async Task AddCategoryAsync(CategoryViewModel viewModel)
        {
            Category category = new Category()
            {
                Id = Guid.NewGuid(),
                Name = viewModel.Name
            };

            if(await this.dbContext.Categories.Where(cat => cat.Name.ToLower() == viewModel.Name.ToLower()).CountAsync() == 0)
            {
                await this.dbContext.Categories.AddAsync(category);
                await this.dbContext.SaveChangesAsync();
            }

            else throw new ArgumentException("Category has already exists!");
        }

        public async Task DeleteCategoryAsync(Guid? id)
        {
            Category? category = await this.dbContext.Categories.FindAsync(id);

            if (category != null)
            {
                this.dbContext.Categories.Remove(category);
                await this.dbContext.SaveChangesAsync();
            }

            else throw new NullReferenceException();
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

            else throw new NullReferenceException();
        }

        public async Task DeleteCategoryOfAProductAsync(Guid? productId, Guid? categoryId)
        {
            var productCat = await this.dbContext.ProductsCategories.FirstOrDefaultAsync(productCategory =>
                                                      productCategory.ProductId == productId && productCategory.CategoryId == categoryId);

            if (productCat?.ProductId == productId && productCat?.CategoryId == categoryId)
            {
                this.dbContext.ProductsCategories.Remove(productCat);
                await this.dbContext.SaveChangesAsync();
            }

            else throw new NullReferenceException();
        }

        public async Task<IEnumerable<CategoryViewModel>> AllCategoriesAsync(int page)
        {
            if (this.dbContext.Categories.Count() != 0)
            {
                int totalItems = await this.dbContext.Categories.CountAsync();
                this.Pager = new Pager(totalItems, page);
                int skipItems = (page - 1) * this.Pager.PageSize;

                return await this.dbContext.Categories.Select(category => new CategoryViewModel()
                {
                    Id = category.Id,
                    Name = category.Name
                }).Skip(skipItems).Take(this.Pager.PageSize).ToListAsync();
            }

            throw new NullReferenceException("No categories in the database!");
        }

        public async Task<IEnumerable<CategoryViewModel>> GetAllCategoriesOfAProductAsync(Guid? productId)
        {
            var product = await this.dbContext.Products.Include(product => product.Categories)
                                                       .ThenInclude(category => category.Category)
                                                        .FirstOrDefaultAsync(product => product.Id == productId);

            if (product?.Id == productId)
            {
                return product.Categories.Select(category => new CategoryViewModel()
                {
                    Id = category.Category?.Id,
                    Name = category.Category?.Name
                });
            }

            throw new NullReferenceException();
        }
    }
}
