using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SweetWorld.Data.Models;

namespace SweetWorld.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Confectioner> Confectioners { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductsIngredients> ProductsIngredients { get; set; }
        public DbSet<ProductsCategories> ProductsCategories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ProductsIngredients>().HasKey(p => new { p.IngredientId, p.ProductId });
            builder.Entity<ProductsCategories>().HasKey(p => new { p.ProductId, p.CategoryId });

            base.OnModelCreating(builder);
        }
    }
}