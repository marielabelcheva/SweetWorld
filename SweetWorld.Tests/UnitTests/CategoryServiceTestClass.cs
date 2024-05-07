using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using SweetWorld.Core.Contracts;
using SweetWorld.Core.Models.CategoryViewModels;
using SweetWorld.Core.Services;
using SweetWorld.Infrastructure.Data;
using SweetWorld.Infrastructure.Data.Migrations;
using SweetWorld.Infrastructure.Data.Models;

namespace SweetWorld.Tests.UnitTests
{
    [TestFixture]
    public class CategoryServiceTestClass : UnitTestsBase
    {
        private ICategoryService categoryService;

        [SetUp]
        public async Task SetUp()
        {
            this.categoryService = new CategoryService(this.context);
        }

        [Test]
        public async Task AllCategoriesShouldReturnCorrectCollection()
        {
            var dbCategories = await this.context.Categories.ToListAsync();

            var allCategories = (List<CategoryViewModel>)await categoryService.AllCategoriesAsync(1);

            Assert.That(allCategories.Count, Is.EqualTo(dbCategories.Count));
            Assert.That(allCategories[1].Id, Is.EqualTo(dbCategories[1].Id));
        }

        [Test]
        public async Task AllCategoriesShoulThrowException()
        {
            this.context.Categories.RemoveRange(await this.context.Categories.ToListAsync());
            await this.context.SaveChangesAsync();

            var ex = Assert.ThrowsAsync<NullReferenceException>(async () => await this.categoryService.AllCategoriesAsync(1));
            Assert.That(ex.Message, Is.EqualTo("No categories in the database!"));
        }

        [Test]
        [TestCase("Cakes")]
        [TestCase("cakes")]
        public async Task CreateCategoryShouldThrowException(string name)
        {
            var category = new CategoryViewModel
            {
                Name = name
            };

            var ex = Assert.ThrowsAsync<ArgumentException>(async () => await this.categoryService.AddCategoryAsync(category));
            Assert.That(ex.Message, Is.EqualTo("Category has already exists!"));
        }

        [Test]
        public async Task CreateCategoryShouldReturnCorrectResult()
        {
            var category = new CategoryViewModel { Name = "TestCategory" };

            await this.categoryService.AddCategoryAsync(category);

            var dbCategory = await this.context.Categories.FirstOrDefaultAsync(c => c.Name == category.Name);

            Assert.IsNotNull(dbCategory);
            Assert.That(dbCategory.Name, Is.EqualTo("TestCategory"));
        }

        [Test]
        [TestCase("00000000-0000-0000-0000-000000000000")]
        [TestCase("11c43ee8-b9d3-4e51-b73f-bd9dda66e29c")]
        public async Task DeleteCategoryShouldThrowException(string id)
        {
            Guid cat = Guid.Parse(id);

            Assert.ThrowsAsync<NullReferenceException>(async () => await this.categoryService.DeleteCategoryAsync(cat));
        }

        [Test]
        public async Task DeleteCategoryShouldReturnCorrectResult()
        {
            await this.categoryService.DeleteCategoryAsync(Guid.Parse("8d9c3c58-d7d1-402a-98fa-95dcaa062ffa"));

            var category = await this.context.Categories.FindAsync(Guid.Parse("8d9c3c58-d7d1-402a-98fa-95dcaa062ffa"));

            Assert.IsNull(category);
        }

        [Test]
        public async Task AllCategoriesOfAProductShouldReturnCorrectCollection()
        {
            var dbProduct = await this.context.Products.Include(product => product.Categories)
                                                          .ThenInclude(category => category.Category)
                                                          .FirstOrDefaultAsync(product => product.Id == Guid.Parse("aeb3a25b-3b13-48d0-b8d6-c8c9500a7e32"));

            var dbCategories = dbProduct?.Categories.Select(category => new CategoryViewModel()
            {
                Id = category.Category?.Id,
                Name = category.Category?.Name
            });

            var allCategories = await categoryService.GetAllCategoriesOfAProductAsync(Guid.Parse("aeb3a25b-3b13-48d0-b8d6-c8c9500a7e32"));

            Assert.That(allCategories.ToList().Count, Is.EqualTo(dbCategories?.ToList().Count));
            Assert.That(allCategories.ToList()[0].Id, Is.EqualTo(dbCategories?.ToList()[0].Id));
        }

        [Test]
        [TestCase("00000000-0000-0000-0000-000000000000")]
        [TestCase("11c43ee8-b9d3-4e51-b73f-bd9dda66e29c")]
        public async Task AllCategoriesOfAProductShouldThrowException(string id)
        {
            Guid productId = Guid.Parse(id);

            Assert.ThrowsAsync<NullReferenceException>(async () => await this.categoryService.GetAllCategoriesOfAProductAsync(productId));
        }

        [Test]
        public async Task AddCategoryOfAProductShouldReturnCorrectResult()
        {
            var productId = Guid.Parse("aeb3a25b-3b13-48d0-b8d6-c8c9500a7e32");
            var categoryId = Guid.Parse("39f03388-a904-402c-91de-7f09e5ba6df5");

            await this.categoryService.AddCategoryOfaProductAsync(productId, categoryId);

            var dbCategory = await this.context.ProductsCategories
                                               .FirstOrDefaultAsync(c => c.ProductId == productId && c.CategoryId == categoryId);

            Assert.IsNotNull(dbCategory);
            Assert.That(dbCategory.CategoryId, Is.EqualTo(categoryId));
            Assert.That(dbCategory.ProductId, Is.EqualTo(productId));

        }

        [Test]
        [TestCase("00000000-0000-0000-0000-000000000000", "00000000-0000-0000-0000-000000000000")]
        [TestCase("00000000-0000-0000-0000-000000000000", "11c43ee8-b9d3-4e51-b73f-bd9dda66e29c")]
        [TestCase("00000000-0000-0000-0000-000000000000", "39f03388-a904-402c-91de-7f09e5ba6df5")]
        [TestCase("11c43ee8-b9d3-4e51-b73f-bd9dda66e29c", "00000000-0000-0000-0000-000000000000")]
        [TestCase("aeb3a25b-3b13-48d0-b8d6-c8c9500a7e32", "00000000-0000-0000-0000-000000000000")]
        [TestCase("aeb3a25b-3b13-48d0-b8d6-c8c9500a7e32", "11c43ee8-b9d3-4e51-b73f-bd9dda66e29c")]
        [TestCase("11c43ee8-b9d3-4e51-b73f-bd9dda66e29c", "39f03388-a904-402c-91de-7f09e5ba6df5")]
        [TestCase("11c43ee8-b9d3-4e51-b73f-bd9dda66e29c", "11c43ee8-b9d3-4e51-b73f-bd9dda66e29c")]
        public async Task AddCategoryOfAProductShouldThrowException(string productId, string categoryId)
        {
            var product = Guid.Parse(productId);
            var category = Guid.Parse(categoryId);

            Assert.ThrowsAsync<NullReferenceException>(async () => await this.categoryService.AddCategoryOfaProductAsync(product, category));
        }

        [Test]
        public async Task DeleteCategoryOfAProductShouldReturnCorrectResult()
        {
            var productId = Guid.Parse("aeb3a25b-3b13-48d0-b8d6-c8c9500a7e32");
            var categoryId = Guid.Parse("8d9c3c58-d7d1-402a-98fa-95dcaa062ffa");

            await this.categoryService.DeleteCategoryOfAProductAsync(productId, categoryId);

            var category = await this.context.ProductsCategories.FirstOrDefaultAsync(productCategory =>
                                                      productCategory.ProductId == productId && productCategory.CategoryId == categoryId);

            Assert.That(category?.CategoryId, Is.Not.EqualTo(categoryId));
            Assert.That(category?.ProductId, Is.Not.EqualTo(productId));
        }

        [Test]
        [TestCase("00000000-0000-0000-0000-000000000000", "00000000-0000-0000-0000-000000000000")]
        [TestCase("00000000-0000-0000-0000-000000000000", "11c43ee8-b9d3-4e51-b73f-bd9dda66e29c")]
        [TestCase("00000000-0000-0000-0000-000000000000", "8d9c3c58-d7d1-402a-98fa-95dcaa062ffa")]
        [TestCase("11c43ee8-b9d3-4e51-b73f-bd9dda66e29c", "00000000-0000-0000-0000-000000000000")]
        [TestCase("aeb3a25b-3b13-48d0-b8d6-c8c9500a7e32", "00000000-0000-0000-0000-000000000000")]
        [TestCase("aeb3a25b-3b13-48d0-b8d6-c8c9500a7e32", "11c43ee8-b9d3-4e51-b73f-bd9dda66e29c")]
        [TestCase("11c43ee8-b9d3-4e51-b73f-bd9dda66e29c", "8d9c3c58-d7d1-402a-98fa-95dcaa062ffa")]
        [TestCase("11c43ee8-b9d3-4e51-b73f-bd9dda66e29c", "11c43ee8-b9d3-4e51-b73f-bd9dda66e29c")]
        public async Task DeleteCategoryOfAProductShouldThrowException(string productId, string categoryId)
        {
            var product = Guid.Parse(productId);
            var category = Guid.Parse(categoryId);

            Assert.ThrowsAsync<NullReferenceException>(async () => await this.categoryService.DeleteCategoryOfAProductAsync(product, category));
        }
    }
}