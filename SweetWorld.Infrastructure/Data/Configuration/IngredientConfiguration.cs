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

            ingredients.Add(new Ingredient()
            {
                Id = Guid.Parse("d62340b8-b340-4765-a289-cc4ec987e23a"),
                Name = "wipping cream"
            });

            ingredients.Add(new Ingredient()
            {
                Id = Guid.Parse("85311af6-ce87-461c-b7ff-699a86eb0b47"),
                Name = "flour"
            });

            ingredients.Add(new Ingredient()
            {
                Id = Guid.Parse("ac441ba7-a0ff-4f44-84e8-3c11b8430c73"),
                Name = "dark chocolate"
            });

            ingredients.Add(new Ingredient()
            {
                Id = Guid.Parse("19c410e1-f574-4e2e-b235-51906d01c727"),
                Name = "white chocolate"
            });

            ingredients.Add(new Ingredient()
            {
                Id = Guid.Parse("5df10646-eaea-4040-b50c-393cf49ca75e"),
                Name = "seasonal fruit"
            });

            ingredients.Add(new Ingredient()
            {
                Id = Guid.Parse("7d52d73e-b4e5-45f6-999e-9e7bd42e8a93"),
                Name = "strawberries"
            });

            ingredients.Add(new Ingredient()
            {
                Id = Guid.Parse("6a76316d-e003-40d4-8d5e-553d6c59747f"),
                Name = "eggs"
            });

            ingredients.Add(new Ingredient()
            {
                Id = Guid.Parse("a95acbbb-6cef-4a7b-a245-7f8d028e0de7"),
                Name = "sugar"
            });

            ingredients.Add(new Ingredient()
            {
                Id = Guid.Parse("cb3fc820-bf1d-4eee-a6c4-a9183618283a"),
                Name = "milk"
            });

            ingredients.Add(new Ingredient()
            {
                Id = Guid.Parse("beee5e53-e8ef-4d6e-a113-b449540d398e"),
                Name = "butter"
            });

            ingredients.Add(new Ingredient()
            {
                Id = Guid.Parse("9216d028-f18e-44d4-b932-2f78719c0cba"),
                Name = "baking powder"
            });

            ingredients.Add(new Ingredient()
            {
                Id = Guid.Parse("ae5e95cb-f722-4460-8f07-29d58df97a55"),
                Name = "cocoa"
            });

            ingredients.Add(new Ingredient()
            {
                Id = Guid.Parse("775e23ed-1fb6-4125-b23c-c43cb98fe1b6"),
                Name = "honey"
            });

            ingredients.Add(new Ingredient()
            {
                Id = Guid.Parse("75879d97-4f7e-4f11-860d-205d63dfb1e9"),
                Name = "vanilla"
            });

            ingredients.Add(new Ingredient()
            {
                Id = Guid.Parse("8e394b57-2c7a-42a1-b700-263d57f8cc5e"),
                Name = "jam"
            });

            ingredients.Add(new Ingredient()
            {
                Id = Guid.Parse("e880c006-3af2-4d28-b8a4-7684cb986185"),
                Name = "walnuts"
            });

            ingredients.Add(new Ingredient()
            {
                Id = Guid.Parse("16fe2f69-513c-4277-af3d-52b641fe9487"),
                Name = "water"
            });

            ingredients.Add(new Ingredient()
            {
                Id = Guid.Parse("662c546d-3e05-4cb4-a392-682cb3fed443"),
                Name = "sunflower oil"
            });

            ingredients.Add(new Ingredient()
            {
                Id = Guid.Parse("287e7803-b225-4131-b7f4-e3b57de672af"),
                Name = "red food coloring"
            });

            ingredients.Add(new Ingredient()
            {
                Id = Guid.Parse("1776e340-9db2-453a-b29f-947b732796cc"),
                Name = "lemon juice"
            });

            ingredients.Add(new Ingredient()
            {
                Id = Guid.Parse("c067592d-7db2-476b-8216-da94a089b269"),
                Name = "puff pastry"
            });

            ingredients.Add(new Ingredient()
            {
                Id = Guid.Parse("701c2a97-48ac-4781-8a08-c60c6aa3f040"),
                Name = "oat flakes"
            });

            ingredients.Add(new Ingredient()
            {
                Id = Guid.Parse("5f89b69f-ee79-488e-bd01-9527b101493a"),
                Name = "spelt flour"
            });

            ingredients.Add(new Ingredient()
            {
                Id = Guid.Parse("be3ebdea-a67c-4a28-b83e-c238cb85c09d"),
                Name = "coconut oil"
            });

            ingredients.Add(new Ingredient()
            {
                Id = Guid.Parse("6ad109c5-e8e7-4f40-8c0e-434f272db285"),
                Name = "cinnamon"
            });

            ingredients.Add(new Ingredient()
            {
                Id = Guid.Parse("ac3d8343-895b-4805-aaeb-3b0d2f9de96a"),
                Name = "banana"
            });

            ingredients.Add(new Ingredient()
            {
                Id = Guid.Parse("0955c74b-8e3c-4ad6-97fc-bdc72c4a70f2"),
                Name = "chickpeas"
            });

            ingredients.Add(new Ingredient()
            {
                Id = Guid.Parse("ad8bddfd-a20d-4f5b-b53b-86e008dc3fc1"),
                Name = "peanut butter"
            });

            ingredients.Add(new Ingredient()
            {
                Id = Guid.Parse("5a35c906-4373-43ef-a4c5-316058e22536"),
                Name = "brown sugar"
            });

            ingredients.Add(new Ingredient()
            {
                Id = Guid.Parse("65009db2-6a67-470e-951b-b9dfd68109f8"),
                Name = "rice flour"
            });

            ingredients.Add(new Ingredient()
            {
                Id = Guid.Parse("26e2241b-5ef0-4998-bf81-3be8b5c5dd64"),
                Name = "almond flour"
            });

            ingredients.Add(new Ingredient()
            {
                Id = Guid.Parse("59a4a752-8e59-4cc9-a5f2-5b52f5e998ca"),
                Name = "corn flour"
            });

            ingredients.Add(new Ingredient()
            {
                Id = Guid.Parse("05810086-be70-48b4-a40c-0330ebea7f7e"),
                Name = "grape seed oil"
            });

            ingredients.Add(new Ingredient()
            {
                Id = Guid.Parse("d8acfa7d-2e90-4fc3-a2a0-89441d7866c2"),
                Name = "orange essential oil"
            });

            ingredients.Add(new Ingredient()
            {
                Id = Guid.Parse("25464223-7321-45e1-a377-e3d3bc9a1a70"),
                Name = "avocado"
            });

            ingredients.Add(new Ingredient()
            {
                Id = Guid.Parse("2d8b869c-ef64-44d9-807a-1221ff08e3b9"),
                Name = "stevia"
            });

            ingredients.Add(new Ingredient()
            {
                Id = Guid.Parse("d90013c0-3372-4dce-8376-9d50e1952a0d"),
                Name = "apple"
            });

            ingredients.Add(new Ingredient()
            {
                Id = Guid.Parse("1c73c664-4242-467f-a13f-5816ed222b97"),
                Name = "carob flour"
            });

            return ingredients;
        }
    }
}
