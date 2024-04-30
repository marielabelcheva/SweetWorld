using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;
using SweetWorld.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace SweetWorld.Tests
{
    public class UnitTestsBase
    {
        protected List<IdentityRole> roles;
        protected List<User> users;
        protected List<Client> clients;
        protected List<Confectioner> confectioners;
        protected List<CartOrder> cartOrders;
        protected List<FavouriteProduct> favouriteProducts;
        protected List<Ingredient> ingredients;
        protected List<Image> images;
        protected List<Category> categories;
        protected List<Order> orders;
        protected List<Product> products;
        protected List<ProductsCategories> productsCategories;
        protected List<ProductsIngredients> productsIngredients;
        protected List<PiecesCount> piecesCounts;
        protected List<IdentityUserRole<string>> userRoles;
    }
}
