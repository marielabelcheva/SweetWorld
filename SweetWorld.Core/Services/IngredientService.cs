using Microsoft.EntityFrameworkCore;
using SweetWorld.Core.Contracts;
using SweetWorld.Infrastructure.Data;
using SweetWorld.Infrastructure.Data.Models;
using SweetWorld.Core.Models.IngredientViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using SweetWorld.Core.Models.Pagination;
using CloudinaryDotNet.Actions;

namespace SweetWorld.Core.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly ApplicationDbContext dbContext;

        public IngredientService(ApplicationDbContext dbContext) 
        { 
            this.dbContext = dbContext;
            this.Pager = null!;
        }

        public Pager Pager { get; set; }

        public async Task AddIngredientAsync(IngredientViewModel viewModel)
        {
            Ingredient? ingredient = new Ingredient()
            {
                Id = Guid.NewGuid(),
                Name = viewModel.Name
            };

            if (!await this.dbContext.Ingredients.Select(ing => ing.Name.ToLower()).ContainsAsync(ingredient?.Name?.ToLower()))
            {
                await this.dbContext.Ingredients.AddAsync(ingredient);
                await this.dbContext.SaveChangesAsync();
            }

            else throw new ArgumentException("Ingredient has alredy exists!");
        }

        public async Task<IEnumerable<IngredientViewModel>> GetAllIngredientsAsync(int page)
        {
            if (this.dbContext.Ingredients.Count() != 0) 
            {
                int totalItems = await this.dbContext.Ingredients.CountAsync();
                this.Pager = new Pager(totalItems, page);
                int skipItems = (page - 1) * this.Pager.PageSize;

                return await this.dbContext.Ingredients.Select(ingredient => new IngredientViewModel()
                {
                    Id = ingredient.Id,
                    Name = ingredient.Name
                }).Skip(skipItems).Take(this.Pager.PageSize).ToListAsync(); 
            }

            throw new NullReferenceException("No ingredients in the database!");
        }

        public SelectList GetIngredientsAsync() { return new SelectList(this.dbContext.Ingredients, "Id", "Name"); }

        public async Task DeleteIngredientAsync(Guid? id)
        {
            Ingredient? ingredient = await this.dbContext.Ingredients.FindAsync(id);

            if (ingredient != null)
            {
                this.dbContext.Ingredients.Remove(ingredient);
                await this.dbContext.SaveChangesAsync();
            }

            else throw new NullReferenceException();
        }

        public async Task AddIngredientOfAProductAsync(Guid? productId, Guid? ingredientId)
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

            else throw new NullReferenceException();
        }

        public async Task<IEnumerable<string?>?> GetAllIngredientsOfAProductAsync(Guid? productId)
        {
            var product = await this.dbContext.Products.Include(product => product.Ingredients)
                                                        .ThenInclude(ingredient => ingredient.Ingredient)
                                                        .FirstOrDefaultAsync(product => product.Id == productId);

            if (product?.Id == productId) { return product?.Ingredients.Select(ingredient => ingredient?.Ingredient?.Name); }

            throw new NullReferenceException();
        }
    }
}
