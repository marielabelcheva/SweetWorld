using Microsoft.EntityFrameworkCore;
using SweetWorld.Core.Contracts;
using SweetWorld.Core.Models.ProductViewModels;
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
    public class ConfectionerService : IConfectionerService
    {
        private readonly ApplicationDbContext dbContext;

        public ConfectionerService(ApplicationDbContext dbContext) { this.dbContext = dbContext; }

        public async Task AddConfectionerAsync(string userId)
        {
            Confectioner confectioner = new Confectioner()
            {
                Id = Guid.NewGuid(),
                UserId = userId
            };

            await this.dbContext.Confectioners.AddAsync(confectioner);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductConfectionerViewModel>> AllProductsOfAConfectioner(Guid confectionerId)
        {
            Confectioner? confectionerProducts = await this.dbContext.Confectioners.Where(confectioner => confectioner.Id == confectionerId)
                                                                                   .Include(confectioner => confectioner.Products)
                                                                                   .FirstOrDefaultAsync();
            if (confectionerProducts != null)
            {
                return confectionerProducts.Products.Select(product => new ProductConfectionerViewModel()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Type = product.Type,
                    Price = product.Price,
                    Thumbnail = product.Thumbnail
                });
            }

            throw new NullReferenceException("No orders!");
        }

        public async Task<IEnumerable<UserViewModel>> GetAllConfectionersAsync()
        {
            return await this.dbContext.Confectioners.Include(confectioner => confectioner.User).Select(confectioner => new UserViewModel()
            {
                Id = confectioner.UserId,
                FirstName = confectioner.User.FirstName,
                LastName = confectioner.User.LastName,
                Email = confectioner.User.Email,
                Phone = confectioner.User.PhoneNumber,
                ProfilePictureURL = confectioner.User.ProfilePictureUrl
            }).ToListAsync();
        }
    }
}
