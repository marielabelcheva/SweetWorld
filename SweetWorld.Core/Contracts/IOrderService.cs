using SweetWorld.Core.Models.OrderViewModels;

namespace SweetWorld.Core.Contracts
{
    public interface IOrderService
    {
        public Task AddOrderAsync(AddOrderViewModel viewModel);

        public Task DeleteOrderAsync(Guid id);

        public Task UpdateStatusOfAnOrderAsync(Guid id, string status);

        public Task<OrderClientViewModel> GetAllUnaprovedOrdersAsync();

        public Task AddOrderToTheCartAsync(Guid clientId, Guid productId);

        public Task DeleteOrderFromTheCartAsync(Guid clientId, Guid productId);
    }
}
