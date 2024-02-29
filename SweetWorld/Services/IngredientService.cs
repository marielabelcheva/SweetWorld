using Microsoft.EntityFrameworkCore;
using SweetWorld.Contracts;
using SweetWorld.Data;
using SweetWorld.Data.Models;
using SweetWorld.Models.IngredientViewModels;

namespace SweetWorld.Services
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

            else throw new ArgumentException("Ingredient has alredy exists!");
        }

        public async Task<IEnumerable<IngredientViewModel>> GetAllIngredientsAsync()
        {
            return await this.dbContext.Ingredients.Select(ingredient => new IngredientViewModel
            {
                Id = ingredient.Id,
                Name = ingredient.Name
            }).ToListAsync();
        }

        public async Task<IngredientViewModel> RemoveIngredientAsync(Guid id)
        {
            Ingredient? ingredient = await this.dbContext.Ingredients.FirstOrDefaultAsync(ingredient => ingredient.Id == id);

            if (ingredient != null)
            {
                IngredientViewModel viewModel = new IngredientViewModel()
                {
                    Id = ingredient.Id,
                    Name = ingredient.Name
                };

                return viewModel;
            }

            throw new NullReferenceException();
        }

        public async Task RemoveIngredientAsync(IngredientViewModel viewModel)
        {
            Ingredient? ingredient = await this.dbContext.Ingredients.FindAsync(viewModel.Id);

            if (ingredient != null)
            {
                this.dbContext.Ingredients.Remove(ingredient);
                await this.dbContext.SaveChangesAsync();
            }

            else throw new NullReferenceException();
        }
    }
}
