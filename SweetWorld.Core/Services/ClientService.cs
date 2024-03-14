using Microsoft.EntityFrameworkCore;
using SweetWorld.Core.Contracts;
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

        public ClientService(ApplicationDbContext dbContext) { this.dbContext = dbContext; }

        public async Task AddClientAsync(string userId)
        {
            Client client = new Client()
            {
                Id = Guid.NewGuid(),
                UserId = userId
            };

            await this.dbContext.Clients.AddAsync(client);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserViewModel>> GetAllClientsAsync()
        {
            return await this.dbContext.Clients.Include(client => client.User).Select(client => new UserViewModel()
            {
                Id = client.UserId,
                FirstName = client.User.FirstName,
                LastName = client.User.LastName,
                Email = client.User.Email,
                Phone = client.User.PhoneNumber,
                ProfilePictureURL = client.User.ProfilePictureUrl
            }).ToListAsync();
        }
    }
}
