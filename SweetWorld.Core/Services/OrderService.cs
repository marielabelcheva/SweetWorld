using Microsoft.EntityFrameworkCore;
using SweetWorld.Core.Contracts;
using SweetWorld.Core.Models.OrderViewModels;
using SweetWorld.Core.Models.ProductViewModels;
using SweetWorld.Infrastructure.Data;
using SweetWorld.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetWorld.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext dbContext;

        public OrderService(ApplicationDbContext dbContext) { this.dbContext = dbContext; }

        public async Task AddOrderToTheCartAsync(ProductDataViewModel viewModel, Client client)
        {
            client.Cart.Add(new CartOrder()
            {
                ProductId = viewModel.Id,
                ProductName = viewModel.Name,
                ProductThumb = viewModel.Thumbnail,
                ProductType = viewModel.Type,
                Amount = viewModel.Amount,
                UnitPrice = viewModel.Price,
                AdditionalInformation = viewModel.AdditionalInformation
            });

            await this.dbContext.SaveChangesAsync();
        }

        public async Task CheckoutCartAsync(DeliveryViewModel viewModel, Client client)
        {
            foreach(var order in client.Cart)
            {
                string status = "";

                if (order.AdditionalInformation != null) { status = "unapproved"; }
                else { status = "approved"; }

                await this.dbContext.Orders.AddAsync(new Order()
                {
                    Id = Guid.NewGuid(),
                    ClientId = client.Id,
                    ProductId = order.ProductId,
                    Amount = order.Amount,
                    CreationDate = DateTime.Today,
                    TotalPrice = order.Amount * order.UnitPrice,
                    AdditionalInformation = order.AdditionalInformation,
                    DeliveryAddress = $"{viewModel.Address}, {viewModel.City} [{viewModel.ZipCode}]",
                    Status = status
                });
            }

            client.Cart.Clear();

            await this.dbContext.SaveChangesAsync();
        }

        public async Task DeleteOrderAsync(Guid? id)
        {
            Order? order = await this.dbContext.Orders.FirstOrDefaultAsync(order => order.Id == id);

            if (order != null)
            {
                this.dbContext.Orders.Remove(order);
                await this.dbContext.SaveChangesAsync();
            }

            throw new NullReferenceException();
        }

        public async Task DeleteOrderFromTheCartAsync(CartOrder order, Client client)
        {
            client.Cart.Remove(order);

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<OrderClientViewModel>> GetAllUnaprovedOrdersAsync()
        {
            var orders = await this.dbContext.Orders.Where(order => order.Status == "unapproved")
                                                    .Include(order => order.Product).ToListAsync();
            if (orders != null)
            {
                return orders.Select(order => new OrderClientViewModel()
                {
                    OrderId = order.Id,
                    ProductName = order?.Product?.Name,
                    ProductThumb = order?.Product?.Thumbnail,
                    ProductType = order?.Product?.Type,
                    CreationDate = order?.CreationDate,
                    Amount = order?.Amount,
                    TotalPrice = order?.TotalPrice,
                    Status = order?.Status,
                    AdditionalInformation = order?.AdditionalInformation
                });
            }

            throw new NullReferenceException("No new orders!");
        }

        public async Task UpdateStatusOfAnOrderAsync(Guid? id, string status)
        {
            Order? order = await this.dbContext.Orders.FindAsync(id);

            if (order != null)
            {
                order.Status = status;

                await this.dbContext.SaveChangesAsync();
            }

            throw new NullReferenceException();
        }
    }
}
