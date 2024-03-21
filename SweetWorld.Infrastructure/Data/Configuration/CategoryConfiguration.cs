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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("categories");
            builder.Property(category => category.Id).HasColumnName("id");
            builder.Property(category => category.Name).HasColumnName("name");

            builder.HasData(CreateCategories());
        }

        private List<Category> CreateCategories()
        {
            List<Category> categories = new List<Category>();

            Category category = new Category()
            {
                Id = Guid.Parse("46371267-0d7c-4e7a-a64f-8716972f0f54"),
                Name = "French pastries"
            };

            categories.Add(category);

            category = new Category()
            {
                Id = Guid.Parse("bd6b7990-7394-4c6e-af12-981ac6e2d28b"),
                Name = "Italian pastries"
            };

            categories.Add(category);

            category = new Category()
            {
                Id = Guid.Parse("a313707e-4307-4e0e-91b9-5ecd4399931f"),
                Name = "Turkish pastries"
            };

            categories.Add(category);

            category = new Category()
            {
                Id = Guid.Parse("bd90eb3d-e1b9-4308-8cd5-a6c887895ddc"),
                Name = "Cakes"
            };

            categories.Add(category);

            category = new Category()
            {
                Id = Guid.Parse("85901598-c0eb-49ac-93d7-8e680de25a68"),
                Name = "Doughnuts"
            };

            categories.Add(category);

            return categories;
        }
    }
}
