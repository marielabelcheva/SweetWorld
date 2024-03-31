using SweetWorld.Core.Contracts;
using SweetWorld.Core.Models.OrderViewModels;
using SweetWorld.Infrastructure.Data;
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

        public async Task AddOrderAsync(AddOrderViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public async Task AddOrderToTheCartAsync(Guid clientId, Guid productId)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteOrderAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteOrderFromTheCartAsync(Guid clientId, Guid productId)
        {
            throw new NotImplementedException();
        }

        public async Task<OrderClientViewModel> GetAllUnaprovedOrdersAsync()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateStatusOfAnOrderAsync(Guid id, string status)
        {
            throw new NotImplementedException();
        }
    }
}
