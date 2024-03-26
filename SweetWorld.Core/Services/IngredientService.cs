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

        public async Task AddIngredientAsync(IngredientViewModel viewModel)
        {
            Ingredient ingredient = new Ingredient()
            {
                Id = Guid.NewGuid(),
                Name = viewModel.Name
            };

            if (!await this.dbContext.Ingredients.ContainsAsync(ingredient))
            {
                await this.dbContext.Ingredients.AddAsync(ingredient);
                await this.dbContext.SaveChangesAsync();
            }

            throw new ArgumentException("Ingredient has alredy exists!");
        }

        public async Task<IEnumerable<IngredientViewModel>> GetAllIngredientsAsync()
        {
            return await this.dbContext.Ingredients.Select(ingredient => new IngredientViewModel
            {
                Id = ingredient.Id,
                Name = ingredient.Name
            }).ToListAsync();
        }

        public async Task DeleteIngredientAsync(Guid id)
        {
            Ingredient? ingredient = await this.dbContext.Ingredients.FindAsync(id);

            if (ingredient != null)
            {
                this.dbContext.Ingredients.Remove(ingredient);
                await this.dbContext.SaveChangesAsync();
            }

            throw new NullReferenceException();
        }

        public async Task AddIngredientOfAProductAsync(Guid productId, Guid ingredientId)
        {
            Product? product = await this.dbContext.Products.FindAsync(productId);
            Ingredient? ingredient = await this.dbContext.Ingredients.FindAsync(ingredientId);

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

        public async Task<ICollection<string?>> GetAllIngredientsOfAProductAsync(Guid productId)
        {
            var product = await this.dbContext.Products.Include(product => product.Ingredients)
                                                        .ThenInclude(ingredient => ingredient.Ingredient)
                                                        .FirstOrDefaultAsync(product => product.Id == productId);

            if (product?.Ingredients != null) { return product.Ingredients.Select(ingredient => ingredient?.Ingredient?.Name).ToHashSet(); }

            throw new NullReferenceException();
        }

        public async Task DeleteIngredientOfAProductAsync(Guid productId, Guid ingredientId)
        {
            var productIngredient = await this.dbContext.ProductsIngredients.FirstOrDefaultAsync(productIngredient =>
                                          productIngredient.ProductId == productId && productIngredient.IngredientId == ingredientId);

            if (productIngredient != null)
            {
                this.dbContext.ProductsIngredients.Remove(productIngredient);
                await this.dbContext.SaveChangesAsync();
            }

            throw new NullReferenceException();
        }
    }
}
