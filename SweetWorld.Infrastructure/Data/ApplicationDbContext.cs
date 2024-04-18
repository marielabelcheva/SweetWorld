using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
        public DbSet<CartOrder> Carts {  get; set; }
        public DbSet<FavouriteProduct> Favourites { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new IngredientConfiguration());

            builder.ApplyConfiguration(new CategoryConfiguration());

            builder.ApplyConfiguration(new UserConfiguration());

            builder.ApplyConfiguration(new ConfectionerConfiguration());

            builder.ApplyConfiguration(new ClientConfiguration());

            builder.ApplyConfiguration(new ProductConfiguration());

            builder.ApplyConfiguration(new ProductsIngredientsConfiguration());

            builder.ApplyConfiguration(new ProductsCategoriesConfiguration());

            builder.ApplyConfiguration(new OrderConfiguration());

            builder.ApplyConfiguration(new CartOrderConfiguration());

            builder.ApplyConfiguration(new FavouriteProductConfiguration());

            builder.ApplyConfiguration(new ImageConfiguration());

            builder.ApplyConfiguration(new RoleConfiguration());

            builder.ApplyConfiguration(new UsersRolesConfiguration());

            base.OnModelCreating(builder);
        }
    }
}