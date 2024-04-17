using Microsoft.EntityFrameworkCore;
using SweetWorld.Core.Contracts;
using SweetWorld.Infrastructure.Data;
using SweetWorld.Infrastructure.Data.Models;
using SweetWorld.Core.Models.IngredientViewModels;

namespace SweetWorld.Core.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly ApplicationDbContext dbContext;

        public IngredientService(ApplicationDbContext dbContext) { this.dbContext = dbContext; }

        public async Task AddIngredientAsync(string name)
        {
            Ingredient ingredient = new Ingredient()
            {
                Id = Guid.NewGuid(),
                Name = name
            };

            if (!await this.dbContext.Ingredients.Select(ing => ing.Name).ContainsAsync(name))
            {
                await this.dbContext.Ingredients.AddAsync(ingredient);
                await this.dbContext.SaveChangesAsync();
            }

            throw new ArgumentException("Ingredient has alredy exists!");
        }

        public async Task<IEnumerable<string?>> GetAllIngredientsAsync()
        {
            if (this.dbContext.Ingredients.Count() != 0) 
            { return await this.dbContext.Ingredients.Select(ingredient => ingredient.Name).ToListAsync(); }

            throw new NullReferenceException("No ingredients in the database!");
        }

        public async Task DeleteIngredientAsync(Guid? id)
        {
            Ingredient? ingredient = await this.dbContext.Ingredients.FindAsync(id);

            if (ingredient != null)
            {
                this.dbContext.Ingredients.Remove(ingredient);
                await this.dbContext.SaveChangesAsync();
            }

            throw new NullReferenceException();
        }

        public async Task AddIngredientOfAProductAsync(Guid? productId, string name)
        {
            Product? product = await this.dbContext.Products.FindAsync(productId);
            Ingredient? ingredient = await this.dbContext.Ingredients.FirstOrDefaultAsync(ing => ing.Name == name);

            if (product != null && ingredient != null)
            {
                ProductsIngredients productIngredient = new ProductsIngredients()
                {
                    Product = product,
                    Ingredient = ingredient
                };

                await this.dbContext.ProductsIngredients.AddAsync(productIngredient);
                await this.dbContext.SaveChangesAsync();
            }

            throw new NullReferenceException();
        }

        public async Task<IEnumerable<string?>> GetAllIngredientsOfAProductAsync(Guid? productId)
        {
            var product = await this.dbContext.Products.Include(product => product.Ingredients)
                                                        .ThenInclude(ingredient => ingredient.Ingredient)
                                                        .FirstOrDefaultAsync(product => product.Id == productId);

            if (product?.Ingredients != null) { return product.Ingredients.Select(ingredient => ingredient?.Ingredient?.Name).ToHashSet(); }

            throw new NullReferenceException();
        }
    }
}
