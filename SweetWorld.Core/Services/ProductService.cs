﻿using Microsoft.EntityFrameworkCore;
using SweetWorld.Core.Contracts;
using SweetWorld.Core.Models.ProductViewModels;
using SweetWorld.Infrastructure.Data;
using SweetWorld.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetWorld.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly ICategoryService categoryService;
        private readonly IIngredientService ingredientService;
        private readonly IImageService imageService;

        public ProductService(ApplicationDbContext dbContext, ICategoryService categoryService,
                              IIngredientService ingredientService, IImageService imageService)
        {
            this.dbContext = dbContext;
            this.categoryService = categoryService;
            this.ingredientService = ingredientService;
            this.imageService = imageService;
        }

        public async Task AddProductAsync(AddProductViewModel viewModel, Guid? confectionerId)
        {
            Product product = new Product()
            {
                Id = Guid.NewGuid(),
                Name = viewModel.Name,
                Type = viewModel.Type,
                Price = viewModel.Price,
                Thumbnail = viewModel.Thumbnail,
                ConfectionerId = confectionerId
            };

            await this.dbContext.Products.AddAsync(product);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductViewModel>> AllProductsAsync()
        {
            return await this.dbContext.Products
                                       .Select(product => new ProductViewModel()
                                       {
                                           Id = product.Id,
                                           Name = product.Name,
                                           Type = product.Type,
                                           Thumbnail = product.Thumbnail
                                       }).ToListAsync();
        }

        public async Task DeleteProductAsync(Guid? id)
        {
            Product? product = await this.dbContext.Products.FirstOrDefaultAsync(product => product.Id == id);

            if (product != null)
            {
                this.dbContext.Products.Remove(product);
                await this.dbContext.SaveChangesAsync();
            }

            throw new NullReferenceException();
        }

        public async Task<EditProductViewModel> EditProductAsync(Guid? id)
        {
            Product? product = await this.dbContext.Products.FindAsync(id);

            if (product != null)
            {
                return new EditProductViewModel()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Type = product.Type,
                    Price = product.Price,
                    Thumbnail = product.Thumbnail
                };
            }

            throw new NullReferenceException();
        }

        public async Task EditProductAsync(EditProductViewModel viewModel)
        {
            Product? product = await this.dbContext.Products.FindAsync(viewModel.Id);

            if (product != null ) 
            {
                product.Name = viewModel.Name;
                product.Type = viewModel.Type;
                product.Price = viewModel.Price;
                product.Thumbnail = viewModel.Thumbnail;

                await this.dbContext.SaveChangesAsync();
            }
        }

        public IEnumerable<ProductViewModel> GetProductsByPriceAsync(IEnumerable<ProductViewModel> products, decimal price = 0)
        {
            if (products != null)
            {
                if (price > 0) { return products.Where(product => product.Price <= price); }
                else if (price == 0) { return products; }
            }

            throw new NullReferenceException();
        }

        public async Task<IEnumerable<ProductViewModel>> GetProductsFromCategoryAsync(Guid? categoryId)
        {
            var categoryProducts = await this.dbContext.Categories.Where(category => category.Id == categoryId)
                                                          .Include(category => category.ProductsCategories)
                                                          .ThenInclude(product => product.Product).FirstOrDefaultAsync();

            if (categoryProducts?.ProductsCategories != null)
            {
                return categoryProducts.ProductsCategories.Select(product => new ProductViewModel()
                {
                    Id = product?.Product?.Id,
                    Name = product?.Product?.Name,
                    Type = product?.Product?.Type,
                    Price = product?.Product?.Price,
                    Thumbnail = product?.Product?.Thumbnail
                });
            }

            throw new NullReferenceException();
        }

        public IEnumerable<ProductViewModel> GetProductsFromTypeAsync(IEnumerable<ProductViewModel> products, string type)
        {
            if (products != null)
            {
                return products.Where(product => product.Type == type);
            }

            throw new NullReferenceException();
        }

        public async Task<ProductDataViewModel> ProductDataAsync(Guid? id)
        {
            Product? product = await this.dbContext.Products.Include(product => product.Confectioner)
                                                        .ThenInclude(confectioner => confectioner.User)
                                                        .FirstOrDefaultAsync(product => product.Id == id);
            if (product != null)
            {
                var related = await this.AllProductsAsync();

                return new ProductDataViewModel()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Type = product.Type,
                    Price = product.Price,
                    ConfectionerName = $"{product?.Confectioner?.User?.FirstName} {product?.Confectioner?.User?.LastName}",
                    Thumbnail = product?.Thumbnail,
                    PiecesCountAndPrice = product?.PiecesCountAndPrice,
                    Images = product?.Images,
                    Ingredients = await this.ingredientService.GetAllIngredientsOfAProductAsync(product?.Id),
                    Categories = await this.categoryService.GetAllCategoriesOfAProductAsync(product?.Id),
                    Related = related.Where(p => p.Type == product.Type && p.Id != product.Id).Take(4)
            };
            }

            throw new NullReferenceException();
        }
    }
}
