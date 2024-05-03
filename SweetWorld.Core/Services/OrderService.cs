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
            if (client != null)
            {
                await this.dbContext.Carts.AddAsync(new CartOrder()
                {
                    Id = Guid.NewGuid(),
                    ProductId = viewModel.Id,
                    ProductName = viewModel.Name,
                    ProductThumb = viewModel.Thumbnail,
                    ProductType = viewModel.Type,
                    Amount = viewModel.Amount,
                    UnitPrice = viewModel.Price,
                    AdditionalInformation = viewModel.AdditionalInformation,
                    ClientId = client.Id
                });

                await this.dbContext.SaveChangesAsync();
            }
            else throw new NullReferenceException();
        }

        public async Task<IEnumerable<CartOrder>> AllOrdersFromTheCartAsync(Client? client)
        {
            return await this.dbContext.Carts.Where(order => order.ClientId == client.Id).ToListAsync();
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

        public async Task ClearCart(Client? client)
        {
            var orders = await this.dbContext.Carts.Where(order => order.ClientId == client.Id).ToListAsync();

            this.dbContext.Carts.RemoveRange(orders);

            await this.dbContext.SaveChangesAsync();
        }

        public async Task DeleteOrderAsync(Guid? id)
        {
            Order? order = await this.dbContext.Orders.FindAsync(id);

            if (order != null)
            {
                this.dbContext.Orders.Remove(order);
                await this.dbContext.SaveChangesAsync();
            }

            else throw new NullReferenceException();
        }

        public async Task DeleteOrderFromTheCartAsync(Guid? cartOrderId, Client client)
        {
            var order = await this.dbContext.Carts.FindAsync(cartOrderId);

            if (order != null)
            {
                this.dbContext.Carts.Remove(order);
                await this.dbContext.SaveChangesAsync();
            }

            else throw new NullReferenceException();
        }

        public async Task<IEnumerable<OrderClientViewModel>> GetAllUnaprovedOrdersAsync()
        {
            var orders = await this.dbContext.Orders.Where(order => order.Status == "unapproved")
                                                    .Include(order => order.Product).ToListAsync();
            if (orders.Count != 0)
            {
                return orders.Select(order => new OrderClientViewModel()
                {
                    OrderId = order.Id,
                    ProductName = order?.Product?.Name,
                    ProductThumb = order?.Product?.Thumbnail,
                    CreationDate = order?.CreationDate
                });
            }

            else throw new NullReferenceException("No new orders!");
        }

        public async Task<OrderClientViewModel> OrderDetailAsync(Guid? id)
        {
            Order? order = await this.dbContext.Orders.Include(ord => ord.Product).FirstOrDefaultAsync(ord => ord.Id == id);

            if (order?.Id == id)
            {
                return new OrderClientViewModel()
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
                };
            }

            throw new NullReferenceException("There's no order with this identifier");
        }

        public async Task UpdateCartAsyncAsync(IEnumerable<CartOrder> cart, Client? client)
        {
            int index = 0;

            foreach(var order in this.dbContext.Carts.Where(order => order.ClientId == client.Id))
            {
                order.Amount = cart.ToList()[index].Amount;
                order.AdditionalInformation = cart.ToList()[index].AdditionalInformation;
            }

            await this.dbContext.SaveChangesAsync();
        }

        public async Task UpdateStatusOfAnOrderAsync(Guid? id, string status)
        {
            Order? order = await this.dbContext.Orders.FindAsync(id);

            if (order != null)
            {
                order.Status = status;

                await this.dbContext.SaveChangesAsync();
            }

            else throw new NullReferenceException();
        }
    }
}
