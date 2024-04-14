using SweetWorld.Core.Models.OrderViewModels;

namespace SweetWorld.Core.Contracts
{
    public interface IOrderService
    {
        public Task CheckoutCartAsync(DeliveryViewModel viewModel);

        public Task DeleteOrderAsync(Guid? id);

        public Task UpdateStatusOfAnOrderAsync(Guid? id, string status);

        public Task<OrderClientViewModel> GetAllUnaprovedOrdersAsync();

        public Task AddOrderToTheCartAsync(Guid? productId);

        public Task DeleteOrderFromTheCartAsync(Guid? productId);
    }
}
