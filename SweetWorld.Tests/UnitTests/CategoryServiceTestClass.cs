using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using SweetWorld.Core.Contracts;
using SweetWorld.Core.Models.CategoryViewModels;
using SweetWorld.Core.Services;
using SweetWorld.Infrastructure.Data;
using SweetWorld.Infrastructure.Data.Models;

namespace SweetWorld.Tests.UnitTests
{
    [TestFixture]
    public class CategoryServiceTestClass : UnitTestsBase
    {
        private ICategoryService categoryService;

        [SetUp]
        public async Task Setup()
        {
            this.categoryService = new CategoryService(this.context);
        }

        [Test]
        public async Task AllCategoriesShouldReturnCorrectCollection()
        {
            var dbCategories = await this.context.Categories.ToListAsync();

            var allCategories = (List<CategoryViewModel>)await categoryService.AllCategoriesAsync();

            Assert.That(allCategories.Count, Is.EqualTo(dbCategories.Count));
            Assert.That(allCategories[1].Id, Is.EqualTo(dbCategories[1].Id));
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
    }
}