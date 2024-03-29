﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SweetWorld.Infrastructure.Data.Configuration;
using SweetWorld.Infrastructure.Data.Models;

namespace SweetWorld.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Confectioner> Confectioners { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductsIngredients> ProductsIngredients { get; set; }
        public DbSet<ProductsCategories> ProductsCategories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new IngredientConfiguration());

            builder.ApplyConfiguration(new CategoryConfiguration());

            builder.ApplyConfiguration(new UserConfiguration());

            builder.ApplyConfiguration(new ConfectionerConfiguration());

            builder.ApplyConfiguration(new ClientConfiguration());

            builder.Entity<Product>().ToTable("products");
            builder.Entity<Product>().Property(product => product.Id).HasColumnName("id");
            builder.Entity<Product>().Property(product => product.Name).HasColumnName("name");
            builder.Entity<Product>().Property(product => product.Type).HasColumnName("type");
            builder.Entity<Product>().Property(product => product.Price).HasColumnName("price");
            builder.Entity<Product>().Property(product => product.ConfectionerId).HasColumnName("confectioner_id");
            builder.Entity<Product>().Ignore(product => product.PiecesCountShapeAndPrice);

            builder.Entity<ProductsIngredients>().ToTable("products_ingredients");
            builder.Entity<ProductsIngredients>().HasKey(product => new { product.IngredientId, product.ProductId });
            builder.Entity<ProductsIngredients>().Property(product => product.ProductId).HasColumnName("product_id");
            builder.Entity<ProductsIngredients>().Property(product => product.IngredientId).HasColumnName("ingredient_id");

            builder.Entity<ProductsCategories>().ToTable("products_categories");
            builder.Entity<ProductsCategories>().HasKey(product => new { product.CategoryId, product.ProductId });
            builder.Entity<ProductsCategories>().Property(product => product.ProductId).HasColumnName("product_id");
            builder.Entity<ProductsCategories>().Property(product => product.CategoryId).HasColumnName("category_id");

            builder.ApplyConfiguration(new OrderConfiguration());

            builder.ApplyConfiguration(new ImageConfiguration());

            builder.ApplyConfiguration(new RoleConfiguration());

            builder.ApplyConfiguration(new UsersRolesConfiguration());

            base.OnModelCreating(builder);
        }
    }
}