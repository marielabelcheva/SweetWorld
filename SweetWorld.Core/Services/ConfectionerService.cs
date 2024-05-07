using Microsoft.EntityFrameworkCore;
using SweetWorld.Core.Contracts;
using SweetWorld.Core.Models.OrderViewModels;
using SweetWorld.Core.Models.Pagination;
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

        public ConfectionerService(ApplicationDbContext dbContext) 
        { 
            this.dbContext = dbContext;
            this.Pager = null!;
        }

        public Pager Pager { get; set; }

        public async Task AddConfectionerAsync(string userId)
        {
            var user = await dbContext.Users.FindAsync(userId);

            if (user != null)
            {
                Confectioner confectioner = new Confectioner()
                {
                    Id = Guid.NewGuid(),
                    UserId = userId
                };

                await this.dbContext.Confectioners.AddAsync(confectioner);
                await this.dbContext.SaveChangesAsync();
            }

            else throw new NullReferenceException();
        }

        public async Task<IEnumerable<OrderClientViewModel>> AllOrdersForExecutingAsync(int page, Confectioner? confectioner)
        {
            var orders = await this.dbContext.Orders.Where(order => order.Status == "approved").Include(order => order.Product)
                                                    .Where(product => product.Product.ConfectionerId == confectioner.Id).ToListAsync();
            if (orders.Count != 0)
            {
                int totalItems = orders.Count;
                this.Pager = new Pager(totalItems, page);
                int skipItems = (page - 1) * this.Pager.PageSize;

                return orders.Select(order => new OrderClientViewModel()
                {
                    OrderId = order.Id,
                    ProductName = order.Product.Name,
                    ProductThumb = order.Product.Thumbnail,
                    CreationDate = order.CreationDate
                }).Skip(skipItems).Take(this.Pager.PageSize);
            }

            throw new NullReferenceException("No new orders!");
        }

        public async Task<IEnumerable<ProductViewModel>?> AllProductsOfAConfectionerAsync(int page, Guid? confectionerId)
        {
            Confectioner? confectionerProducts = await this.dbContext.Confectioners.Where(confectioner => confectioner.Id == confectionerId)
                                                                                   .Include(confectioner => confectioner.Products)
                                                                                   .FirstOrDefaultAsync();
            if (confectionerProducts?.Id == confectionerId)
            {
                int totalItems = confectionerProducts.Products.Count;
                this.Pager = new Pager(totalItems, page);
                int skipItems = (page - 1) * this.Pager.PageSize;

                return confectionerProducts?.Products.Select(product => new ProductViewModel()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Type = product.Type,
                    Price = product.Price,
                    Thumbnail = product.Thumbnail
                }).Skip(skipItems).Take(this.Pager.PageSize);
            }

            throw new NullReferenceException();
        }

        public async Task<IEnumerable<UserViewModel>> GetAllConfectionersAsync()
        {
            return await this.dbContext.Confectioners.Include(confectioner => confectioner.User).Select(confectioner => new UserViewModel()
            {
                Id = confectioner.UserId,
                FirstName = confectioner.User.FirstName,
                LastName = confectioner.User.LastName,
                Email = confectioner.User.Email,
                Role = "Confectioner",
                ProfilePictureURL = confectioner.User.ProfilePictureUrl
            }).ToListAsync();
        }

        public async Task<Confectioner?> GetConfectionerByUserIdAsync(string userId)
        {
            var confectioner =  await this.dbContext.Confectioners.FirstOrDefaultAsync(confectioner => confectioner.UserId == userId);

            if (confectioner?.UserId == userId) { return confectioner; }

            throw new NullReferenceException();
        }
    }
}
