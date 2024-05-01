using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using SweetWorld.Core.Contracts;
using SweetWorld.Core.Models.UserViewModels;
using SweetWorld.Core.Services;
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
    }
}
