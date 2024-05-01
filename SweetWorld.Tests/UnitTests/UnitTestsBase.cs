using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;
using SweetWorld.Infrastructure.Data;
using SweetWorld.Infrastructure.Data.Models;
using SweetWorld.Tests.Mock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace SweetWorld.Tests.UnitTests
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

        protected ApplicationDbContext context;

        [SetUp]
        public async Task SetUpBase()
        {
            this.context = DbMock.Instance;

            await this.SeedData();
        }

        public async Task SeedData()
        {
            categories = new List<Category>()
            {
                new Category()
                {
                    Id = Guid.Parse("8d9c3c58-d7d1-402a-98fa-95dcaa062ffa"),
                    Name = "Cakes"
                },
                new Category()
                {
                    Id = Guid.Parse("39f03388-a904-402c-91de-7f09e5ba6df5"),
                    Name = "Cookies"
                }
            };

            users = new List<User>()
            {
                new User()
                {
                    Id = "b904dad3-7377-4edf-bc03-21217aaa452b",
                    FirstName = "Meri",
                    LastName = "Belcheva",
                    UserName = "meri05",
                    NormalizedUserName = "MERI05",
                    Email = "meribelcheva@gmail.com",
                    NormalizedEmail = "MERIBELCHEVA@GMAIL.COM",
                    PhoneNumber = "0898508050"
                },
                new User()
                {
                    Id = "f25654a2-67f5-44a0-8d4f-14890fdbb682",
                    FirstName = "Geri",
                    LastName = "Tsaneva",
                    UserName = "geri88",
                    NormalizedUserName = "GERI88",
                    Email = "geritsaneva@gmail.com",
                    NormalizedEmail = "GERITSANEVA@GMAIL.COM",
                    PhoneNumber = "0893052673"
                },
                new User()
                {
                    Id = "75a16645-a8f9-452d-8415-6902861b4bb5",
                    FirstName = "Kaly",
                    LastName = "Malchinikolova",
                    UserName = "kaly79",
                    NormalizedUserName = "KALY79",
                    Email = "kalypo3@gmail.com",
                    NormalizedEmail = "kalypo3@GMAIL.COM",
                    PhoneNumber = "0888752419"
                }
            };

            clients = new List<Client>()
            {
                new Client()
                {
                    Id = Guid.Parse("6d3f2835-3cfb-456e-a355-0725d13509d3"),
                    UserId = "f25654a2-67f5-44a0-8d4f-14890fdbb682"
                }
            };

            confectioners = new List<Confectioner>()
            {
                new Confectioner()
                {
                    Id = Guid.Parse("55f67761-62f4-4263-95b0-0302b3e0f8ee"),
                    UserId = "75a16645-a8f9-452d-8415-6902861b4bb5"
                }
            };

            roles = new List<IdentityRole>()
            {
                new IdentityRole()
                {
                    Id = "81e5b533-e867-42a0-8eeb-8b733720c114",
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                },
                new IdentityRole()
                {
                    Id = "b37a8cd2-595e-4855-bed3-d6c3ce52f4c2",
                    Name = "Client",
                    NormalizedName = "CLIENT"
                },
                new IdentityRole()
                {
                    Id = "54dc7cb6-11cb-4bca-8e51-254d4c8eb1c7",
                    Name = "Confectioner",
                    NormalizedName = "CONFECTIONER"
                }
            };

            userRoles = new List<IdentityUserRole<string>>()
            {
                new IdentityUserRole<string>()
                {
                    RoleId = "81e5b533-e867-42a0-8eeb-8b733720c114",
                    UserId = "b904dad3-7377-4edf-bc03-21217aaa452b"
                },
                new IdentityUserRole<string>()
                {
                    RoleId = "b37a8cd2-595e-4855-bed3-d6c3ce52f4c2",
                    UserId = "f25654a2-67f5-44a0-8d4f-14890fdbb682"
                },
                new IdentityUserRole<string>()
                {
                    RoleId = "54dc7cb6-11cb-4bca-8e51-254d4c8eb1c7",
                    UserId = "75a16645-a8f9-452d-8415-6902861b4bb5"
                }
            };

            products = new List<Product>()
            {
                new Product()
                {
                    Id = Guid.Parse("aeb3a25b-3b13-48d0-b8d6-c8c9500a7e32"),
                    Name = "Red velvet cake with strawberries",
                    Type = "Ordinary",
                    ConfectionerId = Guid.Parse("55f67761-62f4-4263-95b0-0302b3e0f8ee"),
                    Thumbnail = "https://tiffanysbakeryphilly.com/media/catalog/category/RedVelvetStrawberryShortcake_2_1.jpg"
                },
                new Product()
                {
                    Id = Guid.Parse("9720d6ab-fc73-4f3d-873f-8b9a5c47ddb3"),
                    Name = "Chocolate chip cookies / 100g",
                    Type = "Gluten-free",
                    ConfectionerId = Guid.Parse("55f67761-62f4-4263-95b0-0302b3e0f8ee"),
                    Thumbnail = "https://images.aws.nestle.recipes/resized/5b069c3ed2feea79377014f6766fcd49_Original_NTH_Chocolate_Chip_Cookie_1080_850.jpg",
                    Price = 4.99m
                }
            };

            productsCategories = new List<ProductsCategories>()
            {
                new ProductsCategories()
                {
                    ProductId = Guid.Parse("aeb3a25b-3b13-48d0-b8d6-c8c9500a7e32"),
                    CategoryId = Guid.Parse("8d9c3c58-d7d1-402a-98fa-95dcaa062ffa")
                },
                new ProductsCategories()
                {
                    ProductId = Guid.Parse("9720d6ab-fc73-4f3d-873f-8b9a5c47ddb3"),
                    CategoryId = Guid.Parse("39f03388-a904-402c-91de-7f09e5ba6df5")
                }
            };

            await this.context.Users.AddRangeAsync(this.users);
            await this.context.Roles.AddRangeAsync(this.roles);
            await this.context.UserRoles.AddRangeAsync(this.userRoles);
            await this.context.Clients.AddRangeAsync(this.clients);
            await this.context.Confectioners.AddRangeAsync(this.confectioners);
            await this.context.Categories.AddRangeAsync(this.categories);
            await this.context.Products.AddRangeAsync(this.products);
            await this.context.ProductsCategories.AddRangeAsync(this.productsCategories);

            await this.context.SaveChangesAsync();
        }

        [TearDown]
        public async Task TearDownBase()
        {
            await this.context.Database.EnsureDeletedAsync();
        }
    }
}
