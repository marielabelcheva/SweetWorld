using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SweetWorld.Core.Contracts;
using SweetWorld.Core.Models.OrderViewModels;
using SweetWorld.Core.Models.Pagination;
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

        public OrderService(ApplicationDbContext dbContext) 
        { 
            this.dbContext = dbContext;
            this.Pager = null!;
        }

        public Pager Pager { get; set; }

        public async Task<CartOrderViewModel> AddOrderToTheCartAsync(Guid? productId)
        {
            var product = await this.dbContext.Products.Include(product => product.PiecesCountAndPrice)
                                                       .FirstOrDefaultAsync(product => product.Id == productId);

            if (product?.Id == productId)
            {
                var type = "other";
                if (product?.PiecesCountAndPrice.Count > 0) { type = "cake"; }

                var items = await this.dbContext.Pieces.Include(piece => piece.Product).Where(piece => piece.ProductId == product.Id).ToListAsync();


                return new CartOrderViewModel()
                {
                    Id = product?.Id,
                    Type = type,
                    Amount = 0,
                    AdditionalInformation = "",
                    Price = product?.Price,
                    Sizes = new SelectList(items, "Price", "Count")
                };
            }

            throw new NullReferenceException();
        }

        public async Task AddOrderToTheCartAsync(CartOrderViewModel viewModel, Client? client)
        {
            if (client != null)
            {
                var product = await this.dbContext.Products.FindAsync(viewModel.Id);

                await this.dbContext.Carts.AddAsync(new CartOrder()
                {
                    Id = Guid.NewGuid(),
                    ProductId = product?.Id,
                    ProductName = product?.Name,
                    ProductThumb = product?.Thumbnail,
                    ProductType = product?.Type,
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
            var user = await this.dbContext.Clients.Include(c => c.Cart).FirstOrDefaultAsync(c => c.Id == client.Id);

            foreach(var order in user?.Cart)
            {
                string status = "";

                if (order.AdditionalInformation != null) { status = "unapproved"; }
                else { status = "approved"; }

                await this.dbContext.Orders.AddAsync(new Order()
                {
                    Id = Guid.NewGuid(),
                    ClientId = user.Id,
                    ProductId = order.ProductId,
                    Amount = order.Amount,
                    CreationDate = DateTime.Today,
                    TotalPrice = order.Amount * order.UnitPrice,
                    AdditionalInformation = order.AdditionalInformation,
                    DeliveryAddress = $"{viewModel.Address}, {viewModel.City} [{viewModel.ZipCode}]",
                    Status = status
                });
            }

            user.Cart.Clear();

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

        public async Task<IEnumerable<OrderClientViewModel>> GetAllUnaprovedOrdersAsync(int page)
        {
            var orders = await this.dbContext.Orders.Where(order => order.Status == "unapproved")
                                                    .Include(order => order.Product).ToListAsync();
            if (orders.Count != 0)
            {
                int totalItems = orders.Count;
                this.Pager = new Pager(totalItems, page);
                int skipItems = (page - 1) * this.Pager.PageSize;

                return orders.Select(order => new OrderClientViewModel()
                {
                    OrderId = order.Id,
                    ProductName = order?.Product?.Name,
                    ProductThumb = order?.Product?.Thumbnail,
                    CreationDate = order?.CreationDate
                }).Skip(skipItems).Take(this.Pager.PageSize);
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

        public async Task<CartOrderViewModel> UpdateCartOrderAsync(Guid? cartId)
        {
            var order = await this.dbContext.Carts.FindAsync(cartId);

            if (order != null)
            {
                var product = await this.dbContext.Products.Include(p => p.PiecesCountAndPrice).FirstOrDefaultAsync(p => p.Id == order.ProductId);

                var type = "other";
                if (product?.PiecesCountAndPrice.Count > 0) { type = "cake"; }

                var items = await this.dbContext.Pieces.Include(piece => piece.Product).Where(piece => piece.ProductId == product.Id).ToListAsync();

                return new CartOrderViewModel()
                {
                    Id = order.Id,
                    Amount = order.Amount,
                    AdditionalInformation = order.AdditionalInformation,
                    Price = order.UnitPrice,
                    Type = type,
                    Sizes = new SelectList(items, "Price", "Count")
                };
            }

            throw new NullReferenceException();
        }

        public async Task UpdateCartOrderAsync(CartOrderViewModel cart)
        {
            var order = await dbContext.Carts.FindAsync(cart.Id);

            if (order != null)
            {
                order.Amount = cart.Amount;
                order.AdditionalInformation = cart.AdditionalInformation;
                order.UnitPrice = cart.Price;

                await this.dbContext.SaveChangesAsync();
            }

            else throw new NullReferenceException();
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
