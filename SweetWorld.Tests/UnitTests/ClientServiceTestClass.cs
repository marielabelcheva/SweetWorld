using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using SweetWorld.Core.Contracts;
using SweetWorld.Core.Models.OrderViewModels;
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
    public class ClientServiceTestClass : UnitTestsBase
    {
        private IClientService clientService;

        [SetUp]
        public async Task SetUp() { this.clientService = new ClientService(this.context); }

        [Test]
        [TestCase("00000000-0000-0000-0000-000000000000")]
        [TestCase("11c43ee8-b9d3-4e51-b73f-bd9dda66e29c")]
        public async Task AddClientShouldThrowException(string id)
        {
            Assert.ThrowsAsync<NullReferenceException>(async () => await this.clientService.AddClientAsync(id));
        }

        [Test]
        public async Task AddClientShouldReturnCorrectResult()
        {
            await this.clientService.AddClientAsync("b904dad3-7377-4edf-bc03-21217aaa452b");

            var dbClient = await this.context.Clients.FirstOrDefaultAsync(c => c.UserId == "b904dad3-7377-4edf-bc03-21217aaa452b");

            Assert.IsNotNull(dbClient);
            Assert.That(dbClient.UserId, Is.EqualTo("b904dad3-7377-4edf-bc03-21217aaa452b"));
        }

        [Test]
        public async Task AllClientsShouldReturnCorrectCollection()
        {
            var dbClients = await this.context.Clients.ToListAsync();

            var allClients = (List<UserViewModel>)await this.clientService.GetAllClientsAsync();

            Assert.That(allClients.Count, Is.EqualTo(dbClients.Count));
            Assert.That(allClients[0].Id, Is.EqualTo(dbClients[0].UserId));
        }

        [Test]
        [TestCase("00000000-0000-0000-0000-000000000000")]
        [TestCase("11c43ee8-b9d3-4e51-b73f-bd9dda66e29c")]
        [TestCase("b904dad3-7377-4edf-bc03-21217aaa452b")]
        public async Task GetClientByUserIdShouldThrowException(string id)
        {
            Assert.ThrowsAsync<NullReferenceException>(async () => await this.clientService.GetClientByUserIdAsync(id));
        }

        [Test]
        public async Task GetClientByUserIdShouldReturnCorrectResult()
        {
            var client = await this.clientService.GetClientByUserIdAsync("f25654a2-67f5-44a0-8d4f-14890fdbb682");

            var dbClient = await this.context.Clients.FirstOrDefaultAsync(c => c.UserId == "f25654a2-67f5-44a0-8d4f-14890fdbb682");

            Assert.IsNotNull(dbClient);
            Assert.That(dbClient.UserId, Is.EqualTo("f25654a2-67f5-44a0-8d4f-14890fdbb682"));
            Assert.That(client?.UserId, Is.EqualTo("f25654a2-67f5-44a0-8d4f-14890fdbb682"));
        }

        [Test]
        [TestCase("00000000-0000-0000-0000-000000000000")]
        [TestCase("11c43ee8-b9d3-4e51-b73f-bd9dda66e29c")]
        public async Task AllOrdersOfAClientShouldThrowException(string id)
        {
            Guid? user = Guid.Parse(id);

            Assert.ThrowsAsync<NullReferenceException>(async () => await this.clientService.AllOrdersOfAClientAsync(1, user));
        }

        [Test]
        public async Task AllOrdersOfAClientShouldReturnCorrectResult()
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

            var dbClient = await this.context.Clients.Where(client => client.Id == Guid.Parse("6d3f2835-3cfb-456e-a355-0725d13509d3"))
                                                                                   .Include(client => client.Orders)
                                                                                   .ThenInclude(order => order.Product)
                                                                                   .FirstOrDefaultAsync();

            var dbOrders = dbClient?.Orders.Select(order => new OrderClientViewModel()
            {
                OrderId = order.Id,
                ProductName = order.Product?.Name,
                ProductThumb = order.Product?.Thumbnail,
                CreationDate = order.CreationDate,
            });

            var allOrders = await this.clientService.AllOrdersOfAClientAsync(1, Guid.Parse("6d3f2835-3cfb-456e-a355-0725d13509d3"));

            Assert.That(allOrders?.ToList().Count, Is.EqualTo(dbOrders?.ToList().Count));
            Assert.That(allOrders.ToList()[0].OrderId, Is.EqualTo(Guid.Parse("66cd2178-03e8-477f-a534-222ceecf50d6")));
            Assert.That(dbOrders?.ToList()[0].OrderId, Is.EqualTo(Guid.Parse("66cd2178-03e8-477f-a534-222ceecf50d6")));
        }
    }
}
