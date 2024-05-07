using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using SweetWorld.Core.Contracts;
using SweetWorld.Core.Models.CategoryViewModels;
using SweetWorld.Core.Models.ProductViewModels;
using SweetWorld.Core.Services;
using SweetWorld.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SweetWorld.Tests.UnitTests
{
    [TestFixture]
    public class ProductServiceTestClass : UnitTestsBase
    {
        private IProductService productService;
        private ICategoryService categoryService;
        private IIngredientService ingredientService;

        [SetUp]
        public async Task SetUp()
        {
            this.categoryService = new CategoryService(this.context);
            this.ingredientService = new IngredientService(this.context);
            this.productService = new ProductService(this.context, this.categoryService, this.ingredientService);
        }

        [Test]
        [TestCase("00000000-0000-0000-0000-000000000000")]
        [TestCase("11c43ee8-b9d3-4e51-b73f-bd9dda66e29c")]
        public async Task AddPiecesCountShouldThrowException(string id)
        {
            var model = new PiecesCountAndPriceViewModel()
            {
                ProductId = Guid.Parse(id),
                PiecesCount = 2,
                Price = 3
            };

            Assert.ThrowsAsync<ArgumentNullException>(async () => await this.productService.AddPiecesCountAndPrice(model));
        }

        [Test]
        public async Task AddPiecesCountShouldReturnCorrectResult()
        {
            var model = new PiecesCountAndPriceViewModel()
            {
                ProductId = Guid.Parse("aeb3a25b-3b13-48d0-b8d6-c8c9500a7e32"),
                PiecesCount = 2,
                Price = 3
            };

            await this.productService.AddPiecesCountAndPrice(model);

            var dbModel = await this.context.Pieces.FirstOrDefaultAsync(p => p.ProductId == model.ProductId && 
                                                                             p.Count == model.PiecesCount && p.Price == model.Price);

            Assert.IsNotNull(dbModel);
            Assert.That(dbModel.ProductId, Is.EqualTo(Guid.Parse("aeb3a25b-3b13-48d0-b8d6-c8c9500a7e32")));
            Assert.That(dbModel.Count, Is.EqualTo(2));
            Assert.That(dbModel.Price, Is.EqualTo(3));
        }

        [Test]
        public async Task AddProductShouldReturnCorrectResult()
        {
            var model = new AddProductViewModel()
            {
                Name = "Test",
                Type = "test",
                Thumbnail = "test.png"
            };

            await this.productService.AddProductAsync(model, Guid.Parse("55f67761-62f4-4263-95b0-0302b3e0f8ee"));

            var dbProduct = await this.context.Products.FirstOrDefaultAsync(p => p.Name == model.Name);

            Assert.IsNotNull(dbProduct);
            Assert.That(dbProduct.ConfectionerId, Is.EqualTo(Guid.Parse("55f67761-62f4-4263-95b0-0302b3e0f8ee")));
            Assert.That(dbProduct.Name, Is.EqualTo("Test"));
            Assert.That(dbProduct.Type, Is.EqualTo("test"));
        }

        [Test]
        public async Task AllProductsShouldReturnCorrectCollection()
        {
            var dbProducts = await this.context.Products.ToListAsync();

            var allProducts = await this.productService.AllProductsAsync(1);

            Assert.That(allProducts.ToList().Count, Is.EqualTo(dbProducts.Count));
            Assert.That(allProducts.ToList()[1].Id, Is.EqualTo(dbProducts[1].Id));
        }

        [Test]
        [TestCase("00000000-0000-0000-0000-000000000000")]
        [TestCase("11c43ee8-b9d3-4e51-b73f-bd9dda66e29c")]
        public async Task DeleteProductShouldThrowException(string id)
        {
            Guid product = Guid.Parse(id);

            Assert.ThrowsAsync<NullReferenceException>(async () => await this.productService.DeleteProductAsync(product));
        }

        [Test]
        public async Task DeleteProductShouldReturnCorrectResult()
        {
            await this.productService.DeleteProductAsync(Guid.Parse("aeb3a25b-3b13-48d0-b8d6-c8c9500a7e32"));

            var product = await this.context.Products.FindAsync(Guid.Parse("aeb3a25b-3b13-48d0-b8d6-c8c9500a7e32"));

            Assert.IsNull(product);
        }

        [Test]
        [TestCase("00000000-0000-0000-0000-000000000000")]
        [TestCase("11c43ee8-b9d3-4e51-b73f-bd9dda66e29c")]
        public async Task EditProductShouldThrowException(string id)
        {
            Guid product = Guid.Parse(id);

            Assert.ThrowsAsync<NullReferenceException>(async () => await this.productService.EditProductAsync(product));
        }

        [Test]
        public async Task EditProductShouldReturnCorrectResult()
        {
            var model = await this.productService.EditProductAsync(Guid.Parse("aeb3a25b-3b13-48d0-b8d6-c8c9500a7e32"));

            Assert.IsNotNull(model);
            Assert.That(model.Id, Is.EqualTo(Guid.Parse("aeb3a25b-3b13-48d0-b8d6-c8c9500a7e32")));
            Assert.That(model.Name, Is.EqualTo("Red velvet cake with strawberries"));
        }

        [Test]
        [TestCase("00000000-0000-0000-0000-000000000000")]
        [TestCase("11c43ee8-b9d3-4e51-b73f-bd9dda66e29c")]
        public async Task EditProductViewShouldThrowException(string id)
        {
            var model = new EditProductViewModel()
            {
                Id = Guid.Parse(id),
                Name = "Test",
                Thumbnail = "test.png",
                Price = 3
            };

            Assert.ThrowsAsync<NullReferenceException>(async () => await this.productService.EditProductAsync(model));
        }

        [Test]
        public async Task EditProductViewShouldReturnCorrectResult()
        {
            var model = new EditProductViewModel()
            {
                Id = Guid.Parse("aeb3a25b-3b13-48d0-b8d6-c8c9500a7e32"),
                Name = "Test",
                Thumbnail = "test.png",
                Price = 3
            };

            await this.productService.EditProductAsync(model);

            var product = await this.context.Products.FindAsync(model.Id);

            Assert.IsNotNull(product);
            Assert.That(product.Id, Is.EqualTo(Guid.Parse("aeb3a25b-3b13-48d0-b8d6-c8c9500a7e32")));
            Assert.That(product.Name, Is.EqualTo("Test"));
        }

        [Test]
        public async Task LikeProductShouldReturnCorrectResult()
        {
            var productId = Guid.Parse("aeb3a25b-3b13-48d0-b8d6-c8c9500a7e32");
            var clientId = Guid.Parse("6d3f2835-3cfb-456e-a355-0725d13509d3");

            await this.productService.LikeProductAsync(productId, clientId);

            var dbResult = await this.context.Favourites.FirstOrDefaultAsync(p => p.ProductId == productId && p.ClientId == clientId);

            Assert.IsNotNull(dbResult);
            Assert.That(dbResult.ClientId, Is.EqualTo(clientId));
            Assert.That(dbResult.ProductId, Is.EqualTo(productId));

        }

        [Test]
        [TestCase("00000000-0000-0000-0000-000000000000", "00000000-0000-0000-0000-000000000000")]
        [TestCase("00000000-0000-0000-0000-000000000000", "11c43ee8-b9d3-4e51-b73f-bd9dda66e29c")]
        [TestCase("00000000-0000-0000-0000-000000000000", "6d3f2835-3cfb-456e-a355-0725d13509d3")]
        [TestCase("11c43ee8-b9d3-4e51-b73f-bd9dda66e29c", "00000000-0000-0000-0000-000000000000")]
        [TestCase("aeb3a25b-3b13-48d0-b8d6-c8c9500a7e32", "00000000-0000-0000-0000-000000000000")]
        [TestCase("aeb3a25b-3b13-48d0-b8d6-c8c9500a7e32", "11c43ee8-b9d3-4e51-b73f-bd9dda66e29c")]
        [TestCase("11c43ee8-b9d3-4e51-b73f-bd9dda66e29c", "6d3f2835-3cfb-456e-a355-0725d13509d3")]
        [TestCase("11c43ee8-b9d3-4e51-b73f-bd9dda66e29c", "11c43ee8-b9d3-4e51-b73f-bd9dda66e29c")]
        public async Task LikeProductShouldThrowException(string productId, string clientId)
        {
            var product = Guid.Parse(productId);
            var client = Guid.Parse(clientId);

            Assert.ThrowsAsync<NullReferenceException>(async () => await this.productService.LikeProductAsync(product, client));
        }

        [Test]
        [TestCase(7)]
        [TestCase(0)]
        public async Task FilterByPriceShouldReturnCorrectCollection(decimal price)
        {
            var dbProducts = await this.context.Products.ToListAsync();

            if (price > 0) { dbProducts = dbProducts.Where(p => p.Price <= price).ToList(); }

            var allProducts = await this.productService.GetProductsByPriceAsync(price);

            Assert.That(allProducts.ToList().Count, Is.EqualTo(dbProducts.Count));
            Assert.That(allProducts.ToList()[0].Id, Is.EqualTo(dbProducts[0].Id));
        }

        [Test]
        public async Task FilterByPriceShoulThrowException()
        {
            this.context.Products.RemoveRange(await this.context.Products.ToListAsync());
            await this.context.SaveChangesAsync();

            Assert.ThrowsAsync<NullReferenceException>(async () => await this.productService.GetProductsByPriceAsync());
        }

        [Test]
        public async Task FilterByCategoryShouldReturnCorrectCollection()
        {
            var dbProducts = await this.context.ProductsCategories.Include(product => product.Category)
                                                                  .Where(category => category.Category.Name == "Cakes").ToListAsync();

            var allProducts = await this.productService.GetProductsFromCategoryAsync("Cakes");

            Assert.That(allProducts.ToList().Count, Is.EqualTo(dbProducts?.Count));
            Assert.That(allProducts.ToList()[0].Id, Is.EqualTo(dbProducts?[0].ProductId));
        }

        [Test]
        public async Task FilterByCategoryShoulThrowException()
        {
            this.context.Categories.RemoveRange(await this.context.Categories.ToListAsync());
            await this.context.SaveChangesAsync();

            Assert.ThrowsAsync<NullReferenceException>(async () => await this.productService.GetProductsFromCategoryAsync("Cakes"));
        }

        [Test]
        public async Task FilterByTypeShouldReturnCorrectCollection()
        {
            var dbProducts = await this.context.Products.Where(product => product.Type == "Ordinary").ToListAsync();

            var allProducts = await this.productService.GetProductsFromTypeAsync("Ordinary");

            Assert.That(allProducts.ToList().Count, Is.EqualTo(dbProducts?.Count));
            Assert.That(allProducts.ToList()[0].Id, Is.EqualTo(dbProducts?[0].Id));
        }

        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("Test")]
        public async Task FilterByTypeShoulThrowException(string type)
        {
            Assert.ThrowsAsync<NullReferenceException>(async () => await this.productService.GetProductsFromTypeAsync(type));
        }

        [Test]
        [TestCase("00000000-0000-0000-0000-000000000000")]
        [TestCase("11c43ee8-b9d3-4e51-b73f-bd9dda66e29c")]
        public async Task ProductDataShouldThrowException(string id)
        {
            Guid product = Guid.Parse(id);

            Assert.ThrowsAsync<NullReferenceException>(async () => await this.productService.ProductDataAsync(product));
        }

        [Test]
        public async Task ProductDataShouldReturnCorrectResult()
        {
            var model = await this.productService.ProductDataAsync(Guid.Parse("aeb3a25b-3b13-48d0-b8d6-c8c9500a7e32"));

            Assert.IsNotNull(model);
            Assert.That(model.Id, Is.EqualTo(Guid.Parse("aeb3a25b-3b13-48d0-b8d6-c8c9500a7e32")));
            Assert.That(model.Name, Is.EqualTo("Red velvet cake with strawberries"));
        }

        [Test]
        public async Task WishListShouldReturnCorrectCollection()
        {
            var favorite = new FavouriteProduct()
            {
                ProductId = Guid.Parse("aeb3a25b-3b13-48d0-b8d6-c8c9500a7e32"),
                ClientId = Guid.Parse("6d3f2835-3cfb-456e-a355-0725d13509d3")
            };

            await this.context.Favourites.AddAsync(favorite);
            await this.context.SaveChangesAsync();

            var dbFavorites = await this.context.Favourites.Where(f => f.ClientId == Guid.Parse("6d3f2835-3cfb-456e-a355-0725d13509d3")).ToListAsync();

            var allFavorites = await this.productService.WishListAsync(1, Guid.Parse("6d3f2835-3cfb-456e-a355-0725d13509d3"));

            Assert.That(allFavorites.ToList().Count, Is.EqualTo(dbFavorites.Count));
            Assert.That(allFavorites.ToList()[0].Id, Is.EqualTo(dbFavorites[0].ProductId));
        }

        [Test]
        [TestCase("00000000-0000-0000-0000-000000000000")]
        [TestCase("11c43ee8-b9d3-4e51-b73f-bd9dda66e29c")]
        public async Task WishListShoulThrowException(string id)
        {
            var client = Guid.Parse(id);

            Assert.ThrowsAsync<NullReferenceException>(async () => await this.productService.WishListAsync(1, client));
        }

        [Test]
        public async Task DislikeProductShouldReturnCorrectResult()
        {
            var favorite = new FavouriteProduct()
            {
                ProductId = Guid.Parse("aeb3a25b-3b13-48d0-b8d6-c8c9500a7e32"),
                ClientId = Guid.Parse("6d3f2835-3cfb-456e-a355-0725d13509d3")
            };

            await this.context.Favourites.AddAsync(favorite);
            await this.context.SaveChangesAsync();

            await this.productService.DeleteFromWishListAsync(favorite.ProductId, favorite.ClientId);

            var dbResult = await this.context.Favourites.FirstOrDefaultAsync(p => p.ProductId == favorite.ProductId && p.ClientId == favorite.ClientId);

            Assert.IsNull(dbResult);
        }

        [Test]
        [TestCase("00000000-0000-0000-0000-000000000000", "00000000-0000-0000-0000-000000000000")]
        [TestCase("00000000-0000-0000-0000-000000000000", "11c43ee8-b9d3-4e51-b73f-bd9dda66e29c")]
        [TestCase("00000000-0000-0000-0000-000000000000", "6d3f2835-3cfb-456e-a355-0725d13509d3")]
        [TestCase("11c43ee8-b9d3-4e51-b73f-bd9dda66e29c", "00000000-0000-0000-0000-000000000000")]
        [TestCase("aeb3a25b-3b13-48d0-b8d6-c8c9500a7e32", "00000000-0000-0000-0000-000000000000")]
        [TestCase("aeb3a25b-3b13-48d0-b8d6-c8c9500a7e32", "11c43ee8-b9d3-4e51-b73f-bd9dda66e29c")]
        [TestCase("11c43ee8-b9d3-4e51-b73f-bd9dda66e29c", "6d3f2835-3cfb-456e-a355-0725d13509d3")]
        [TestCase("11c43ee8-b9d3-4e51-b73f-bd9dda66e29c", "11c43ee8-b9d3-4e51-b73f-bd9dda66e29c")]
        public async Task DisikeProductShouldThrowException(string productId, string clientId)
        {
            var product = Guid.Parse(productId);
            var client = Guid.Parse(clientId);

            Assert.ThrowsAsync<ArgumentNullException>(async () => await this.productService.DeleteFromWishListAsync(product, client));
        }

        [Test]
        public async Task AllTypesShouldReturnCorrectCollection()
        {
            var dbTypes = await this.context.Products.Select(product => product.Type).Distinct().ToListAsync();

            var allTypes = await this.productService.GetAllTypesAsync();

            Assert.That(allTypes.ToList().Count, Is.EqualTo(dbTypes.Count));
            Assert.That(allTypes.ToList()[1], Is.EqualTo(dbTypes[1]));
        }

        [Test]
        public async Task AllCategoriesShouldReturnCorrectCollection()
        {
            var dbCategories = await this.context.Categories.Select(category => category.Name).ToListAsync();

            var allCategories = await this.productService.GetAllCategoriesAsync();

            Assert.That(allCategories.ToList().Count, Is.EqualTo(dbCategories.Count));
            Assert.That(allCategories.ToList()[1], Is.EqualTo(dbCategories[1]));
        }

        [Test]
        public async Task FilterByNameShouldReturnCorrectCollection()
        {
            var dbProducts = await this.context.Products.Where(product => product.Name.ToLower().Contains("cake".ToLower())).ToListAsync();

            var allProducts = await this.productService.GetProductsByNameAsync("cake");

            Assert.That(allProducts.ToList().Count, Is.EqualTo(dbProducts?.Count));
            Assert.That(allProducts.ToList()[0].Id, Is.EqualTo(dbProducts?[0].Id));
        }

        [Test]
        [TestCase("Test")]
        public async Task FilterByNameShoulThrowException(string name)
        {
            var ex = Assert.ThrowsAsync<NullReferenceException>(async () => await this.productService.GetProductsByNameAsync(name));
            Assert.That(ex.Message, Is.EqualTo("No products with this name!"));
        }
    }
}
