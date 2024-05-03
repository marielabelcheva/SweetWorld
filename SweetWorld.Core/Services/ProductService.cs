using Microsoft.EntityFrameworkCore;
using SweetWorld.Core.Contracts;
using SweetWorld.Core.Models.ProductViewModels;
using SweetWorld.Infrastructure.Data;
using SweetWorld.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SweetWorld.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly ICategoryService categoryService;
        private readonly IIngredientService ingredientService;

        public ProductService(ApplicationDbContext dbContext, ICategoryService categoryService,
                              IIngredientService ingredientService)
        {
            this.dbContext = dbContext;
            this.categoryService = categoryService;
            this.ingredientService = ingredientService;
        }

        public async Task AddPiecesCountAndPrice(PiecesCountAndPriceViewModel viewModel)
        {
            var product = await this.dbContext.Products.FindAsync(viewModel.ProductId);

            if (product != null)
            {
                await this.dbContext.Pieces.AddAsync(new PiecesCount()
                {
                    Id = Guid.NewGuid(),
                    Count = viewModel.PiecesCount,
                    Price = viewModel.Price,
                    ProductId = product.Id
                });

                await this.dbContext.SaveChangesAsync();
            }

            else throw new ArgumentNullException();
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
            Product? product = await this.dbContext.Products.FindAsync(id);

            if (product != null)
            {
                this.dbContext.Products.Remove(product);
                await this.dbContext.SaveChangesAsync();
            }

            else throw new NullReferenceException();
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
                product.Price = viewModel.Price;
                product.Thumbnail = viewModel.Thumbnail;

                await this.dbContext.SaveChangesAsync();
            }

            else throw new NullReferenceException();
        }

        public async Task LikeProductAsync(Guid? id, Guid? clientId)
        {
            var product = await this.dbContext.Products.FindAsync(id) ;

            var client = await this.dbContext.Clients.FindAsync(clientId);

            if (product != null && client != null)
            {
                FavouriteProduct favourite = new FavouriteProduct()
                {
                    Product = product,
                    Client = client
                };

                await this.dbContext.Favourites.AddAsync(favourite);
                await this.dbContext.SaveChangesAsync();
            }

            else throw new NullReferenceException();
        }

        public async Task<IEnumerable<ProductViewModel>> GetProductsByPriceAsync(decimal price = 0)
        {
            var products = await this.dbContext.Products.ToListAsync();

            if (products.Count != 0)
            {
                if (price > 0) 
                { 
                    return products.Where(product => product.Price <= price).Select(product => new ProductViewModel()
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Type = product.Type,
                        Thumbnail = product.Thumbnail
                    });
                }
                else if (price == 0) 
                { 
                    return products.Select(product => new ProductViewModel()
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Type = product.Type,
                        Thumbnail = product.Thumbnail
                    });
                }
            }

            throw new NullReferenceException();
        }

        public async Task<IEnumerable<ProductViewModel>> GetProductsFromCategoryAsync(string? categoryName)
        {
            var categoryProducts = await this.dbContext.Categories.Where(category => category.Name == categoryName)
                                                          .Include(category => category.ProductsCategories)
                                                          .ThenInclude(product => product.Product).FirstOrDefaultAsync();

            if (categoryProducts?.Name == categoryName)
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

        public async Task<IEnumerable<ProductViewModel>> GetProductsFromTypeAsync(string type)
        {
            var products = await this.dbContext.Products.Where(product => product.Type == type).ToListAsync();

            if (products.Count != 0)
            {
                return products.Select(product => new ProductViewModel()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Type = product.Type,
                    Thumbnail = product.Thumbnail
                }); 
            }

            throw new NullReferenceException();
        }

        public async Task<ProductDataViewModel> ProductDataAsync(Guid? id)
        {
            Product? product = await this.dbContext.Products.Include(product => product.Confectioner)
                                                        .ThenInclude(confectioner => confectioner.User)
                                                        .FirstOrDefaultAsync(product => product.Id == id);
            if (product?.Id == id)
            {
                var related = await this.AllProductsAsync();

                return new ProductDataViewModel()
                {
                    Id = product?.Id,
                    Name = product?.Name,
                    Type = product?.Type,
                    Price = product?.Price,
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

        public async Task<IEnumerable<ProductViewModel>> WishListAsync(Guid? clientId)
        {
            Client? products = await this.dbContext.Clients.Where(c => c.Id == clientId).Include(c => c.FavouriteProducts)
                                                          .ThenInclude(fp => fp.Product).FirstOrDefaultAsync();



            if (products?.Id == clientId)
            {
                return products.FavouriteProducts.Select(product => new ProductViewModel()
                {
                    Id = product?.Product?.Id,
                    Name = product?.Product?.Name,
                    Type = product?.Product?.Type,
                    Thumbnail = product?.Product?.Thumbnail
                });
            }

            throw new NullReferenceException();
        }

        public async Task DeleteFromWishListAsync(Guid? productId, Guid? clientId)
        {
            var product = await this.dbContext.Favourites.FirstOrDefaultAsync(p => p.ProductId == productId && p.ClientId == clientId);

            if (product != null)
            {
                this.dbContext.Favourites.Remove(product);
                await this.dbContext.SaveChangesAsync();
            }

            else throw new ArgumentNullException();
        }

        public async Task<IEnumerable<string?>> GetAllTypesAsync()
        {
            return await this.dbContext.Products.Select(product => product.Type).Distinct().ToListAsync();
        }

        public async Task<IEnumerable<string?>> GetAllCategoriesAsync()
        {
            return await this.dbContext.Categories.Select(category => category.Name).ToListAsync();
        }

        public async Task<IEnumerable<ProductViewModel>> GetProductsByNameAsync(string? name)
        {
            var products = await this.dbContext.Products.Where(product => product.Name.ToLower().Contains(name.ToLower())).ToListAsync();

            if (products.Count != 0)
            {
                return products.Select(product => new ProductViewModel()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Type = product.Type,
                    Thumbnail = product.Thumbnail
                });
            }

            else throw new NullReferenceException("No products with this name!");
        }
    }
}
