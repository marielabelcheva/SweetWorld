using Microsoft.EntityFrameworkCore;
using SweetWorld.Core.Contracts;
using SweetWorld.Core.Models.OrderViewModels;
using SweetWorld.Core.Models.Pagination;
using SweetWorld.Core.Models.UserViewModels;
using SweetWorld.Infrastructure.Data;
using SweetWorld.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetWorld.Core.Services
{
    public class ClientService : IClientService
    {
        private readonly ApplicationDbContext dbContext;

        public ClientService(ApplicationDbContext dbContext) 
        { 
            this.dbContext = dbContext;
            this.Pager = null!;
        }

        public Pager Pager { get; set; }

        public async Task AddClientAsync(string userId)
        {
            var user = await dbContext.Users.FindAsync(userId);

            if (user != null)
            {
                Client client = new Client()
                {
                    Id = Guid.NewGuid(),
                    UserId = user.Id
                };

                await this.dbContext.Clients.AddAsync(client);
                await this.dbContext.SaveChangesAsync();
            }

            else throw new NullReferenceException();
        }

        public async Task<IEnumerable<OrderClientViewModel>?> AllOrdersOfAClientAsync(int page, Guid? clientId)
        {
            Client? clientOrders = await this.dbContext.Clients.Where(client => client.Id == clientId).Include(client => client.Orders)
                                                              .ThenInclude(order => order.Product).FirstOrDefaultAsync();
            if (clientOrders?.Id == clientId) 
            {
                int totalItems = clientOrders.Orders.Count;
                this.Pager = new Pager(totalItems, page);
                int skipItems = (page - 1) * this.Pager.PageSize;

                return clientOrders?.Orders.Select(order => new OrderClientViewModel()
                {
                    OrderId = order.Id,
                    ProductName = order.Product?.Name,
                    ProductThumb = order.Product?.Thumbnail,
                    CreationDate = order.CreationDate,
                }).Skip(skipItems).Take(this.Pager.PageSize);
            }

            throw new NullReferenceException();
        }

        public async Task<IEnumerable<UserViewModel>> GetAllClientsAsync()
        {
            return await this.dbContext.Clients.Include(client => client.User).Select(client => new UserViewModel()
            {
                Id = client.UserId,
                FirstName = client.User.FirstName,
                LastName = client.User.LastName,
                Email = client.User.Email,
                Role = "Client",
                ProfilePictureURL = client.User.ProfilePictureUrl
            }).ToListAsync();
        }

        public async Task<Client?> GetClientByUserIdAsync(string userId)
        {
            var client =  await this.dbContext.Clients.FirstOrDefaultAsync(client => client.UserId == userId);

            if (client?.UserId == userId) { return client; }

            throw new NullReferenceException();
        }
    }
}
