using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using SweetWorld.Core.Contracts;
using SweetWorld.Core.Models.IngredientViewModels;
using SweetWorld.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetWorld.Tests.UnitTests
{
    [TestFixture]
    public class IngredientServiceTestClass : UnitTestsBase
    {
        private IIngredientService ingredientService;

        [SetUp]
        public async Task SetUp()
        {
            this.ingredientService = new IngredientService(this.context);
        }

        [Test]
        public async Task AllIngredientsShouldReturnCorrectCollection()
        {
            var dbIngredients = await this.context.Ingredients.ToListAsync();

            var allIngredients = (List<IngredientViewModel>)await this.ingredientService.GetAllIngredientsAsync();

            Assert.That(allIngredients.Count, Is.EqualTo(dbIngredients.Count));
            Assert.That(allIngredients[1].Id, Is.EqualTo(dbIngredients[1].Id));
        }

        [Test]
        public async Task AlIngredientsShoulThrowException()
        {
            this.context.Ingredients.RemoveRange(await this.context.Ingredients.ToListAsync());
            await this.context.SaveChangesAsync();

            var ex = Assert.ThrowsAsync<NullReferenceException>(async () => await this.ingredientService.GetAllIngredientsAsync());
            Assert.That(ex.Message, Is.EqualTo("No ingredients in the database!"));
        }

        [Test]
        [TestCase("Flour")]
        [TestCase("flour")]
        public async Task CreateIngredientShouldThrowException(string name)
        {
            var ingredient = new IngredientViewModel
            {
                Name = name
            };

            var ex = Assert.ThrowsAsync<ArgumentException>(async () => await this.ingredientService.AddIngredientAsync(ingredient));
            Assert.That(ex.Message, Is.EqualTo("Ingredient has alredy exists!"));
        }

        [Test]
        public async Task CreateIngredientShouldReturnCorrectResult()
        {
            var ingredient = new IngredientViewModel { Name = "TestIngredient" };

            await this.ingredientService.AddIngredientAsync(ingredient);

            var dbIngredient = await this.context.Ingredients.FirstOrDefaultAsync(i => i.Name == ingredient.Name);

            Assert.IsNotNull(dbIngredient);
            Assert.That(dbIngredient.Name, Is.EqualTo("TestIngredient"));
        }

        [Test]
        [TestCase("00000000-0000-0000-0000-000000000000")]
        [TestCase("11c43ee8-b9d3-4e51-b73f-bd9dda66e29c")]
        public async Task DeleteIngredientShouldThrowException(string id)
        {
            Guid ingredient = Guid.Parse(id);

            Assert.ThrowsAsync<NullReferenceException>(async () => await this.ingredientService.DeleteIngredientAsync(ingredient));
        }

        [Test]
        public async Task DeleteIngredientShouldReturnCorrectResult()
        {
            await this.ingredientService.DeleteIngredientAsync(Guid.Parse("3a367cd3-b14c-4431-86e0-6d463ce4dafe"));

            var ingredient = await this.context.Ingredients.FindAsync(Guid.Parse("3a367cd3-b14c-4431-86e0-6d463ce4dafe"));

            Assert.IsNull(ingredient);
        }

        [Test]
        public async Task AllIngredientsOfAProductShouldReturnCorrectCollection()
        {
            var dbProduct = await this.context.Products.Include(product => product.Ingredients)
                                                          .ThenInclude(ingredient => ingredient.Ingredient)
                                                          .FirstOrDefaultAsync(product => product.Id == Guid.Parse("aeb3a25b-3b13-48d0-b8d6-c8c9500a7e32"));

            var dbIngredients = dbProduct?.Ingredients.Select(ingredient => ingredient.Ingredient?.Name);

            var allIngredients = await ingredientService.GetAllIngredientsOfAProductAsync(Guid.Parse("aeb3a25b-3b13-48d0-b8d6-c8c9500a7e32"));

            Assert.That(allIngredients?.ToList().Count, Is.EqualTo(dbIngredients?.ToList().Count));
            Assert.That(allIngredients?.ToList()[0], Is.EqualTo(dbIngredients?.ToList()[0]));
        }

        [Test]
        [TestCase("00000000-0000-0000-0000-000000000000")]
        [TestCase("11c43ee8-b9d3-4e51-b73f-bd9dda66e29c")]
        public async Task AllIngredientsOfAProductShouldThrowException(string id)
        {
            Guid productId = Guid.Parse(id);

            Assert.ThrowsAsync<NullReferenceException>(async () => await this.ingredientService.GetAllIngredientsOfAProductAsync(productId));
        }

        [Test]
        public async Task AddIngredientOfAProductShouldReturnCorrectResult()
        {
            var productId = Guid.Parse("aeb3a25b-3b13-48d0-b8d6-c8c9500a7e32");
            var ingredientId = Guid.Parse("d6148ba7-d9c6-45ea-aa6b-d880f5c8cd83");

            await this.ingredientService.AddIngredientOfAProductAsync(productId, ingredientId);

            var dbIngredient = await this.context.ProductsIngredients
                                               .FirstOrDefaultAsync(i => i.ProductId == productId && i.IngredientId == ingredientId);

            Assert.IsNotNull(dbIngredient);
            Assert.That(dbIngredient.IngredientId, Is.EqualTo(ingredientId));
            Assert.That(dbIngredient.ProductId, Is.EqualTo(productId));

        }

        [Test]
        [TestCase("00000000-0000-0000-0000-000000000000", "00000000-0000-0000-0000-000000000000")]
        [TestCase("00000000-0000-0000-0000-000000000000", "11c43ee8-b9d3-4e51-b73f-bd9dda66e29c")]
        [TestCase("00000000-0000-0000-0000-000000000000", "d6148ba7-d9c6-45ea-aa6b-d880f5c8cd83")]
        [TestCase("11c43ee8-b9d3-4e51-b73f-bd9dda66e29c", "00000000-0000-0000-0000-000000000000")]
        [TestCase("aeb3a25b-3b13-48d0-b8d6-c8c9500a7e32", "00000000-0000-0000-0000-000000000000")]
        [TestCase("aeb3a25b-3b13-48d0-b8d6-c8c9500a7e32", "11c43ee8-b9d3-4e51-b73f-bd9dda66e29c")]
        [TestCase("11c43ee8-b9d3-4e51-b73f-bd9dda66e29c", "d6148ba7-d9c6-45ea-aa6b-d880f5c8cd83")]
        [TestCase("11c43ee8-b9d3-4e51-b73f-bd9dda66e29c", "11c43ee8-b9d3-4e51-b73f-bd9dda66e29c")]
        public async Task AddIngredientOfAProductShouldThrowException(string productId, string categoryId)
        {
            var product = Guid.Parse(productId);
            var category = Guid.Parse(categoryId);

            Assert.ThrowsAsync<NullReferenceException>(async () => await this.ingredientService.AddIngredientOfAProductAsync(product, category));
        }
    }
}
