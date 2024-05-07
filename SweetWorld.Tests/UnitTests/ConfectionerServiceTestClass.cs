using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using SweetWorld.Core.Contracts;
using SweetWorld.Core.Models.OrderViewModels;
using SweetWorld.Core.Models.ProductViewModels;
using SweetWorld.Core.Models.UserViewModels;
using SweetWorld.Core.Services;
using SweetWorld.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetWorld.Tests.UnitTests
{
    [TestFixture]
    public class ConfectionerServiceTestClass : UnitTestsBase
    {
        private IConfectionerService confectionerService;

        [SetUp]
        public async Task SetUp() { this.confectionerService = new ConfectionerService(this.context); }

        [Test]
        [TestCase("00000000-0000-0000-0000-000000000000")]
        [TestCase("11c43ee8-b9d3-4e51-b73f-bd9dda66e29c")]
        public async Task AddConfectionerShouldThrowException(string id)
        {
            Assert.ThrowsAsync<NullReferenceException>(async () => await this.confectionerService.AddConfectionerAsync(id));
        }

        [Test]
        public async Task AddConfectionerShouldReturnCorrectResult()
        {
            await this.confectionerService.AddConfectionerAsync("b904dad3-7377-4edf-bc03-21217aaa452b");

            var dbConfectioner = await this.context.Confectioners.FirstOrDefaultAsync(c => c.UserId == "b904dad3-7377-4edf-bc03-21217aaa452b");

            Assert.IsNotNull(dbConfectioner);
            Assert.That(dbConfectioner.UserId, Is.EqualTo("b904dad3-7377-4edf-bc03-21217aaa452b"));
        }

        [Test]
        [TestCase("00000000-0000-0000-0000-000000000000")]
        [TestCase("11c43ee8-b9d3-4e51-b73f-bd9dda66e29c")]
        public async Task AllProductsOfAConfectionerShouldThrowException(string id)
        {
            Guid? user = Guid.Parse(id);

            Assert.ThrowsAsync<NullReferenceException>(async () => await this.confectionerService.AllProductsOfAConfectionerAsync(1, user));
        }

        [Test]
        public async Task AllProductsOfAConfectionerShouldReturnCorrectResult()
        {
            var dbConfectioner = await this.context.Confectioners.Where(confectioner => confectioner.Id == Guid.Parse("55f67761-62f4-4263-95b0-0302b3e0f8ee"))
                                                                                   .Include(confectioner => confectioner.Products)
                                                                                   .FirstOrDefaultAsync();

            var dbProducts = dbConfectioner?.Products.Select(product => new ProductViewModel()
            {
                Id = product.Id,
                Name = product.Name,
                Type = product.Type,
                Price = product.Price,
                Thumbnail = product.Thumbnail
            });

            var allProducts = await this.confectionerService.AllProductsOfAConfectionerAsync(1, Guid.Parse("55f67761-62f4-4263-95b0-0302b3e0f8ee"));

            Assert.That(allProducts?.ToList().Count, Is.EqualTo(dbProducts?.ToList().Count));
            Assert.That(allProducts.ToList()[0].Id, Is.EqualTo(dbProducts?.ToList()[0].Id));
        }

        [Test]
        public async Task AllConfectionerssShouldReturnCorrectCollection()
        {
            var dbConfectioners = await this.context.Confectioners.ToListAsync();

            var allConfectioners = (List<UserViewModel>)await this.confectionerService.GetAllConfectionersAsync();

            Assert.That(allConfectioners.Count, Is.EqualTo(dbConfectioners.Count));
            Assert.That(allConfectioners[0].Id, Is.EqualTo(dbConfectioners[0].UserId));
        }

        [Test]
        [TestCase("00000000-0000-0000-0000-000000000000")]
        [TestCase("11c43ee8-b9d3-4e51-b73f-bd9dda66e29c")]
        [TestCase("b904dad3-7377-4edf-bc03-21217aaa452b")]
        public async Task GetConfectionerByUserIdShouldThrowException(string id)
        {
            Assert.ThrowsAsync<NullReferenceException>(async () => await this.confectionerService.GetConfectionerByUserIdAsync(id));
        }

        [Test]
        public async Task GetConfectionerByUserIdShouldReturnCorrectResult()
        {
            var confectioner = await this.confectionerService.GetConfectionerByUserIdAsync("75a16645-a8f9-452d-8415-6902861b4bb5");

            var dbConfectioner = await this.context.Confectioners.FirstOrDefaultAsync(c => c.UserId == "75a16645-a8f9-452d-8415-6902861b4bb5");

            Assert.IsNotNull(dbConfectioner);
            Assert.That(dbConfectioner?.UserId, Is.EqualTo("75a16645-a8f9-452d-8415-6902861b4bb5"));
            Assert.That(confectioner?.UserId, Is.EqualTo("75a16645-a8f9-452d-8415-6902861b4bb5"));
        }

        [Test]
        public async Task AllOrdersForExecutingShouldThrowException()
        {
            var user = await this.confectionerService.GetConfectionerByUserIdAsync("75a16645-a8f9-452d-8415-6902861b4bb5");

            var ex = Assert.ThrowsAsync<NullReferenceException>(async () => await this.confectionerService.AllOrdersForExecutingAsync(1, user));
            Assert.That(ex.Message, Is.EqualTo("No new orders!"));
        }

        [Test]
        public async Task AllOrdersForExecutingShouldReturnCorrectResult()
        {
            var order = new Order()
            {
                Id = Guid.Parse("66cd2178-03e8-477f-a534-222ceecf50d6"),
                ClientId = Guid.Parse("6d3f2835-3cfb-456e-a355-0725d13509d3"),
                ProductId = Guid.Parse("aeb3a25b-3b13-48d0-b8d6-c8c9500a7e32"),
                Amount = 1,
                CreationDate = DateTime.Today,
                TotalPrice = 20.99m,
                DeliveryAddress = "TestAddress",
                Status = "approved"
            };

            await this.context.Orders.AddAsync(order);
            await this.context.SaveChangesAsync();

            var user = await this.confectionerService.GetConfectionerByUserIdAsync("75a16645-a8f9-452d-8415-6902861b4bb5");

            var dbOrders = this.context.Orders.Where(order => order.Status == "approved").Include(order => order.Product)
                                                    .Where(product => product.Product.ConfectionerId == user.Id)
                                                    .Select(order => new OrderClientViewModel()
                                                    {
                                                        OrderId = order.Id,
                                                        ProductName = order.Product.Name,
                                                        ProductThumb = order.Product.Thumbnail,
                                                        CreationDate = order.CreationDate
                                                    });

            var allOrders = await this.confectionerService.AllOrdersForExecutingAsync(1, user);

            Assert.That(allOrders?.ToList().Count, Is.EqualTo(dbOrders?.ToList().Count));
            Assert.That(allOrders.ToList()[0].OrderId, Is.EqualTo(Guid.Parse("66cd2178-03e8-477f-a534-222ceecf50d6")));
            Assert.That(dbOrders?.ToList()[0].OrderId, Is.EqualTo(Guid.Parse("66cd2178-03e8-477f-a534-222ceecf50d6")));
        }
    }
}
