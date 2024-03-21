using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SweetWorld.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetWorld.Infrastructure.Data.Configuration
{
    public class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder.ToTable("ingredients");
            builder.Property(ingredient => ingredient.Id).HasColumnName("id");
            builder.Property(ingredient => ingredient.Name).HasColumnName("name");

            builder.HasData(CreateIngredients());
        }

        private List<Ingredient> CreateIngredients()
        {
            List<Ingredient> ingredients = new List<Ingredient>();

            Ingredient ingredient = new Ingredient()
            {
                Id = Guid.Parse("d62340b8-b340-4765-a289-cc4ec987e23a"),
                Name = "wipping cream"
            };

            ingredients.Add(ingredient);

            ingredient = new Ingredient()
            {
                Id = Guid.Parse("85311af6-ce87-461c-b7ff-699a86eb0b47"),
                Name = "wheat flour"
            };

            ingredients.Add(ingredient);

            ingredient = new Ingredient()
            {
                Id = Guid.Parse("ac441ba7-a0ff-4f44-84e8-3c11b8430c73"),
                Name = "chocolate mousse"
            };

            ingredients.Add(ingredient);

            ingredient = new Ingredient()
            {
                Id = Guid.Parse("19c410e1-f574-4e2e-b235-51906d01c727"),
                Name = "vanilla mousse"
            };

            ingredients.Add(ingredient);

            ingredient = new Ingredient()
            {
                Id = Guid.Parse("5df10646-eaea-4040-b50c-393cf49ca75e"),
                Name = "bananas"
            };

            ingredients.Add(ingredient);

            ingredient = new Ingredient()
            {
                Id = Guid.Parse("7d52d73e-b4e5-45f6-999e-9e7bd42e8a93"),
                Name = "strawberries"
            };

            ingredients.Add(ingredient);

            ingredient = new Ingredient()
            {
                Id = Guid.Parse("6a76316d-e003-40d4-8d5e-553d6c59747f"),
                Name = "eggs"
            };

            ingredients.Add(ingredient);

            ingredient = new Ingredient()
            {
                Id = Guid.Parse("a95acbbb-6cef-4a7b-a245-7f8d028e0de7"),
                Name = "sugar"
            };

            ingredients.Add(ingredient);

            ingredient = new Ingredient()
            {
                Id = Guid.Parse("cb3fc820-bf1d-4eee-a6c4-a9183618283a"),
                Name = "milk"
            };

            ingredients.Add(ingredient);

            ingredient = new Ingredient()
            {
                Id = Guid.Parse("beee5e53-e8ef-4d6e-a113-b449540d398e"),
                Name = "butter"
            };

            ingredients.Add(ingredient);

            ingredient = new Ingredient()
            {
                Id = Guid.Parse("9216d028-f18e-44d4-b932-2f78719c0cba"),
                Name = "baking powder"
            };

            ingredients.Add(ingredient);

            ingredient = new Ingredient()
            {
                Id = Guid.Parse("ae5e95cb-f722-4460-8f07-29d58df97a55"),
                Name = "cocoa"
            };

            ingredients.Add(ingredient);

            ingredient = new Ingredient()
            {
                Id = Guid.Parse("775e23ed-1fb6-4125-b23c-c43cb98fe1b6"),
                Name = "honey"
            };

            ingredients.Add(ingredient);

            return ingredients;
        }
    }
}
