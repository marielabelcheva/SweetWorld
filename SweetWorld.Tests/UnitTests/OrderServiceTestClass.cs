using CloudinaryDotNet;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using SweetWorld.Core.Contracts;
using SweetWorld.Core.Models.OrderViewModels;
using SweetWorld.Core.Models.ProductViewModels;
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
    public class OrderServiceTestClass : UnitTestsBase
    {
        private IOrderService orderService;

        [SetUp]
        public async Task SetUp() { this.orderService = new OrderService(this.context); }

        [Test]
        [TestCase("00000000-0000-0000-0000-000000000000")]
        [TestCase("11c43ee8-b9d3-4e51-b73f-bd9dda66e29c")]
        public async Task AddOrderToTheCartShouldThrowException(string id)
        {
            Guid? product = Guid.Parse(id);

            Assert.ThrowsAsync<NullReferenceException>(async () => await this.orderService.AddOrderToTheCartAsync(product));
        }

        [Test]
        public async Task AddOrderToTheCartShouldReturnCorrectResult()
        {
            var model = await this.orderService.AddOrderToTheCartAsync(Guid.Parse("aeb3a25b-3b13-48d0-b8d6-c8c9500a7e32"));

            Assert.IsNotNull(model);
            Assert.That(model.Id, Is.EqualTo(Guid.Parse("aeb3a25b-3b13-48d0-b8d6-c8c9500a7e32")));
        }

        [Test]
        [TestCase("00000000-0000-0000-0000-000000000000")]
        [TestCase("11c43ee8-b9d3-4e51-b73f-bd9dda66e29c")]
        public async Task AddOrderToTheCartViewShouldThrowException(string id)
        {
            var model = new CartOrderViewModel()
            {
                Id = Guid.Parse("aeb3a25b-3b13-48d0-b8d6-c8c9500a7e32"),
                Type = "test",
                Amount = 2
            };
            var client = await this.context.Clients.FindAsync(Guid.Parse(id));

            Assert.ThrowsAsync<NullReferenceException>(async () => await this.orderService.AddOrderToTheCartAsync(model, client));
        }

        [Test]
        public async Task AddOrderToTheCartViewShouldReturnCorrectResult()
        {
            var model = new CartOrderViewModel()
            {
                Id = Guid.Parse("aeb3a25b-3b13-48d0-b8d6-c8c9500a7e32"),
                Type = "test",
                Amount = 2
            };
            var client = await this.context.Clients.FindAsync(Guid.Parse("6d3f2835-3cfb-456e-a355-0725d13509d3"));

            await this.orderService.AddOrderToTheCartAsync(model, client);

            var dbClient = await this.context.Clients.FindAsync(Guid.Parse("6d3f2835-3cfb-456e-a355-0725d13509d3"));
            var dbClientCart = dbClient?.Cart.FirstOrDefault(order => order.ProductId == Guid.Parse("aeb3a25b-3b13-48d0-b8d6-c8c9500a7e32"));

            Assert.IsNotNull(dbClientCart);
            Assert.That(dbClientCart.ProductId, Is.EqualTo(Guid.Parse("aeb3a25b-3b13-48d0-b8d6-c8c9500a7e32")));
        }

        [Test]
        public async Task CheckoutCartShouldReturnCorrectResult()
        {
            var client = await this.context.Clients.FindAsync(Guid.Parse("6d3f2835-3cfb-456e-a355-0725d13509d3"));

            var delivery = new DeliveryViewModel()
            {
                City = "Test",
                ZipCode = "6000",
                Address = "test_address"
            };

            await this.context.Carts.AddAsync(new CartOrder()
            {
                Id = Guid.NewGuid(),
                ProductId = Guid.Parse("aeb3a25b-3b13-48d0-b8d6-c8c9500a7e32"),
                ClientId = client?.Id,
                ProductName = "Test",
                ProductThumb = "someUrl.png",
                ProductType = "Test",
                Amount = 2,
                UnitPrice = 3
            });

            await this.context.SaveChangesAsync();

            await this.orderService.CheckoutCartAsync(delivery, client);

            var dbClient = await this.context.Clients.FindAsync(Guid.Parse("6d3f2835-3cfb-456e-a355-0725d13509d3"));
            var dbClientCart = dbClient?.Cart;
            var dbOrder = await this.context.Orders.FirstOrDefaultAsync(o => o.ClientId == Guid.Parse("6d3f2835-3cfb-456e-a355-0725d13509d3")
                                                                        && o.ProductId == Guid.Parse("aeb3a25b-3b13-48d0-b8d6-c8c9500a7e32"));

            Assert.IsNotNull(dbClientCart);
            Assert.IsNotNull(dbOrder);
            Assert.IsEmpty(dbClientCart);
            Assert.That(dbOrder.ProductId, Is.EqualTo(Guid.Parse("aeb3a25b-3b13-48d0-b8d6-c8c9500a7e32")));
            Assert.That(dbOrder.ClientId, Is.EqualTo(Guid.Parse("6d3f2835-3cfb-456e-a355-0725d13509d3")));
            Assert.That(dbOrder.Status, Is.EqualTo("approved"));
        }

        [Test]
        [TestCase("00000000-0000-0000-0000-000000000000")]
        [TestCase("11c43ee8-b9d3-4e51-b73f-bd9dda66e29c")]
        public async Task DeleteOrderShouldThrowException(string id)
        {
            Guid order = Guid.Parse(id);

            Assert.ThrowsAsync<NullReferenceException>(async () => await this.orderService.DeleteOrderAsync(order));
        }

        [Test]
        public async Task DeleteOrderShouldReturnCorrectResult()
        {
            var order = new Order()
            {
                Id = Guid.Parse("92acf84f-a8be-4b94-9b58-1a6e6bdcdb4c"),
                ClientId = Guid.Parse("6d3f2835-3cfb-456e-a355-0725d13509d3"),
                ProductId = Guid.Parse("aeb3a25b-3b13-48d0-b8d6-c8c9500a7e32"),
                Amount = 1,
                CreationDate = DateTime.Today,
                TotalPrice = 4,
                DeliveryAddress = "test_address",
                Status = "test"
            };

            await this.context.Orders.AddAsync(order);
            await this.context.SaveChangesAsync();

            await this.orderService.DeleteOrderAsync(order.Id);

            var dbOrder = await this.context.Orders.FindAsync(Guid.Parse("92acf84f-a8be-4b94-9b58-1a6e6bdcdb4c"));

            Assert.IsNull(dbOrder);
        }

        [Test]
        [TestCase("00000000-0000-0000-0000-000000000000")]
        [TestCase("11c43ee8-b9d3-4e51-b73f-bd9dda66e29c")]
        public async Task DeleteOrderFromCartShouldThrowException(string id)
        {
            Guid order = Guid.Parse(id);

            var client = await this.context.Clients.FindAsync(Guid.Parse("6d3f2835-3cfb-456e-a355-0725d13509d3"));

            Assert.ThrowsAsync<NullReferenceException>(async () => await this.orderService.DeleteOrderFromTheCartAsync(order, client));
        }

        [Test]
        public async Task DeleteOrderFromCartShouldReturnCorrectResult()
        {
            var client = await this.context.Clients.FindAsync(Guid.Parse("6d3f2835-3cfb-456e-a355-0725d13509d3"));

            var cart = new CartOrder()
            {
                Id = Guid.Parse("79bc1bf1-c2a4-44ff-9850-0ab0962c892e"),
                ClientId = Guid.Parse("6d3f2835-3cfb-456e-a355-0725d13509d3"),
                ProductId = Guid.Parse("aeb3a25b-3b13-48d0-b8d6-c8c9500a7e32"),
                ProductName = "Test name",
                ProductThumb = "test.png",
                ProductType = "test",
                Amount = 1
            };

            await this.context.Carts.AddAsync(cart);
            await this.context.SaveChangesAsync();

            await this.orderService.DeleteOrderFromTheCartAsync(Guid.Parse("79bc1bf1-c2a4-44ff-9850-0ab0962c892e"), client);

            var dbCart = await this.context.Carts.FindAsync(Guid.Parse("79bc1bf1-c2a4-44ff-9850-0ab0962c892e"));

            Assert.IsNull(dbCart);
        }

        [Test]
        public async Task AllUnapprovedOrdersShouldReturnCorrectCollection()
        {
            var order = new Order()
            {
                Id = Guid.Parse("92acf84f-a8be-4b94-9b58-1a6e6bdcdb4c"),
                ClientId = Guid.Parse("6d3f2835-3cfb-456e-a355-0725d13509d3"),
                ProductId = Guid.Parse("aeb3a25b-3b13-48d0-b8d6-c8c9500a7e32"),
                Amount = 1,
                CreationDate = DateTime.Today,
                TotalPrice = 4,
                DeliveryAddress = "test_address",
                Status = "unapproved"
            };

            await this.context.Orders.AddAsync(order);
            await this.context.SaveChangesAsync();

            var dbUOrders = await this.context.Orders.Where(o => o.Status == "unapproved").ToListAsync();

            var allUOrders = await this.orderService.GetAllUnaprovedOrdersAsync(1);

            Assert.That(allUOrders.ToList().Count, Is.EqualTo(dbUOrders.Count));
            Assert.That(allUOrders.ToList()[0].OrderId, Is.EqualTo(dbUOrders[0].Id));
        }

        [Test]
        public async Task AllUnapprovedOrdersShoulThrowException()
        {
            var order = new Order()
            {
                Id = Guid.Parse("92acf84f-a8be-4b94-9b58-1a6e6bdcdb4c"),
                ClientId = Guid.Parse("6d3f2835-3cfb-456e-a355-0725d13509d3"),
                ProductId = Guid.Parse("aeb3a25b-3b13-48d0-b8d6-c8c9500a7e32"),
                Amount = 1,
                CreationDate = DateTime.Today,
                TotalPrice = 4,
                DeliveryAddress = "test_address",
                Status = "test"
            };

            await this.context.Orders.AddAsync(order);
            await this.context.SaveChangesAsync();

            var ex = Assert.ThrowsAsync<NullReferenceException>(async () => await this.orderService.GetAllUnaprovedOrdersAsync(1));
            Assert.That(ex.Message, Is.EqualTo("No new orders!"));
        }

        [Test]
        public async Task OrderDetailShouldReturnCorrectResult()
        {
            var order = new Order()
            {
                Id = Guid.Parse("92acf84f-a8be-4b94-9b58-1a6e6bdcdb4c"),
                ClientId = Guid.Parse("6d3f2835-3cfb-456e-a355-0725d13509d3"),
                ProductId = Guid.Parse("aeb3a25b-3b13-48d0-b8d6-c8c9500a7e32"),
                Amount = 1,
                CreationDate = DateTime.Today,
                TotalPrice = 4,
                DeliveryAddress = "test_address",
                Status = "unapproved"
            };

            await this.context.Orders.AddAsync(order);
            await this.context.SaveChangesAsync();

            var result = await this.orderService.OrderDetailAsync(order.Id);

            Assert.IsNotNull(result);
            Assert.That(result.OrderId, Is.EqualTo(Guid.Parse("92acf84f-a8be-4b94-9b58-1a6e6bdcdb4c")));
        }

        [Test]
        [TestCase("00000000-0000-0000-0000-000000000000")]
        [TestCase("11c43ee8-b9d3-4e51-b73f-bd9dda66e29c")]
        public async Task OrderDetailShoulThrowException(string id)
        {
            Guid order = Guid.Parse(id);

            var ex = Assert.ThrowsAsync<NullReferenceException>(async () => await this.orderService.OrderDetailAsync(order));
            Assert.That(ex.Message, Is.EqualTo("There's no order with this identifier"));
        }

        [Test]
        [TestCase("00000000-0000-0000-0000-000000000000")]
        [TestCase("11c43ee8-b9d3-4e51-b73f-bd9dda66e29c")]
        public async Task UpdateCartOrderShouldThrowException(string id)
        {
            Guid? cart = Guid.Parse(id);

            Assert.ThrowsAsync<NullReferenceException>(async () => await this.orderService.UpdateCartOrderAsync(cart));
        }

        [Test]
        public async Task UpdateCartOrderShouldReturnCorrectResult()
        {
            await this.context.Carts.AddAsync(new CartOrder()
            {
                Id = Guid.Parse("11c43ee8-b9d3-4e51-b73f-bd9dda66e29c"),
                ProductId = Guid.Parse("aeb3a25b-3b13-48d0-b8d6-c8c9500a7e32"),
                ClientId = Guid.Parse("6d3f2835-3cfb-456e-a355-0725d13509d3"),
                ProductName = "Test",
                ProductThumb = "test.png",
                ProductType = "Test",
                Amount = 3
            });

            await this.context.SaveChangesAsync();

            var model = await this.orderService.UpdateCartOrderAsync(Guid.Parse("11c43ee8-b9d3-4e51-b73f-bd9dda66e29c"));

            Assert.IsNotNull(model);
            Assert.That(model.Id, Is.EqualTo(Guid.Parse("11c43ee8-b9d3-4e51-b73f-bd9dda66e29c")));
        }

        [Test]
        [TestCase("00000000-0000-0000-0000-000000000000")]
        [TestCase("11c43ee8-b9d3-4e51-b73f-bd9dda66e29c")]
        public async Task UpdateCartOrderViewShouldThrowException(string id)
        {
            var model = new CartOrderViewModel()
            {
                Id = Guid.Parse(id),
                Type = "test",
                Amount = 2
            };

            Assert.ThrowsAsync<NullReferenceException>(async () => await this.orderService.UpdateCartOrderAsync(model));
        }

        [Test]
        public async Task UpdateCartOrderViewShouldReturnCorrectResult()
        {
            await this.context.Carts.AddAsync(new CartOrder()
            {
                Id = Guid.Parse("11c43ee8-b9d3-4e51-b73f-bd9dda66e29c"),
                ProductId = Guid.Parse("aeb3a25b-3b13-48d0-b8d6-c8c9500a7e32"),
                ClientId = Guid.Parse("6d3f2835-3cfb-456e-a355-0725d13509d3"),
                ProductName = "Test",
                ProductThumb = "test.png",
                ProductType = "Test",
                Amount = 3
            });

            await this.context.SaveChangesAsync();

            var model = new CartOrderViewModel()
            {
                Id = Guid.Parse("11c43ee8-b9d3-4e51-b73f-bd9dda66e29c"),
                Type = "Test",
                Amount = 2
            };

            await this.orderService.UpdateCartOrderAsync(model);

            var dbCart = await this.context.Carts.FindAsync(Guid.Parse("11c43ee8-b9d3-4e51-b73f-bd9dda66e29c"));

            Assert.IsNotNull(dbCart);
            Assert.That(dbCart.Amount, Is.EqualTo(2));
        }

        [Test]
        public async Task UpdateStatusOfAnOrderShouldReturnCorrectResult()
        {
            var order = new Order()
            {
                Id = Guid.Parse("92acf84f-a8be-4b94-9b58-1a6e6bdcdb4c"),
                ClientId = Guid.Parse("6d3f2835-3cfb-456e-a355-0725d13509d3"),
                ProductId = Guid.Parse("aeb3a25b-3b13-48d0-b8d6-c8c9500a7e32"),
                Amount = 1,
                CreationDate = DateTime.Today,
                TotalPrice = 4,
                DeliveryAddress = "test_address",
                Status = "unapproved"
            };

            await this.context.Orders.AddAsync(order);
            await this.context.SaveChangesAsync();

            await this.orderService.UpdateStatusOfAnOrderAsync(Guid.Parse("92acf84f-a8be-4b94-9b58-1a6e6bdcdb4c"), "approved");

            var dbOrder = await this.context.Orders.FindAsync(Guid.Parse("92acf84f-a8be-4b94-9b58-1a6e6bdcdb4c"));

            Assert.IsNotNull(dbOrder);
            Assert.That(dbOrder.Status, Is.EqualTo("approved"));
        }

        [Test]
        [TestCase("00000000-0000-0000-0000-000000000000")]
        [TestCase("11c43ee8-b9d3-4e51-b73f-bd9dda66e29c")]
        public async Task UpdateStatusOfAnOrderShoulThrowException(string id)
        {
            Guid order = Guid.Parse(id);

            Assert.ThrowsAsync<NullReferenceException>(async () => await this.orderService.UpdateStatusOfAnOrderAsync(order, "test"));
        }

        [Test]
        public async Task ClearCartShouldReturnCorrectResult()
        {
            var client = await this.context.Clients.FindAsync(Guid.Parse("6d3f2835-3cfb-456e-a355-0725d13509d3"));

            var order = new CartOrder()
            {
                Id = Guid.Parse("79bc1bf1-c2a4-44ff-9850-0ab0962c892e"),
                ClientId = Guid.Parse("6d3f2835-3cfb-456e-a355-0725d13509d3"),
                ProductId = Guid.Parse("aeb3a25b-3b13-48d0-b8d6-c8c9500a7e32"),
                ProductName = "Test name",
                ProductThumb = "test.png",
                ProductType = "test",
                Amount = 1
            };

            await this.context.Carts.AddAsync(order);
            await this.context.SaveChangesAsync();

            await this.orderService.ClearCart(client);

            var result = await this.context.Carts.Where(o => o.ClientId == client.Id).ToListAsync();

            Assert.IsEmpty(result);
        }

        [Test]
        public async Task GetCartOrdersShouldReturnCorrectResult()
        {
            var client = await this.context.Clients.FindAsync(Guid.Parse("6d3f2835-3cfb-456e-a355-0725d13509d3"));

            var order = new CartOrder()
            {
                Id = Guid.Parse("79bc1bf1-c2a4-44ff-9850-0ab0962c892e"),
                ClientId = Guid.Parse("6d3f2835-3cfb-456e-a355-0725d13509d3"),
                ProductId = Guid.Parse("aeb3a25b-3b13-48d0-b8d6-c8c9500a7e32"),
                ProductName = "Test name",
                ProductThumb = "test.png",
                ProductType = "test",
                Amount = 1
            };

            await this.context.Carts.AddAsync(order);
            await this.context.SaveChangesAsync();

            var clientCart = await this.orderService.AllOrdersFromTheCartAsync(client);

            var dbClientCart = await this.context.Carts.Where(o => o.ClientId == client.Id).ToListAsync();

            Assert.That(clientCart.ToList().Count, Is.EqualTo(dbClientCart.Count));
            Assert.That(clientCart.ToList()[0].Id, Is.EqualTo(dbClientCart[0].Id));
        }
    }
}
