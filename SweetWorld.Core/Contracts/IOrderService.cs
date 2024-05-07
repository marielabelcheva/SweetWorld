using SweetWorld.Core.Models.OrderViewModels;
using SweetWorld.Core.Models.ProductViewModels;
using SweetWorld.Infrastructure.Data.Models;

namespace SweetWorld.Core.Contracts
{
    public interface IOrderService
    {
        public Task CheckoutCartAsync(DeliveryViewModel viewModel, Client? client);

        public Task DeleteOrderAsync(Guid? id);

        public Task UpdateStatusOfAnOrderAsync(Guid? id, string status);

        public Task<IEnumerable<OrderClientViewModel>> GetAllUnaprovedOrdersAsync();

        public Task<CartOrderViewModel> AddOrderToTheCartAsync(Guid? productId);

        public Task AddOrderToTheCartAsync(CartOrderViewModel viewModel, Client? client);

        public Task DeleteOrderFromTheCartAsync(Guid? cartOrderId, Client? client);

        public Task<OrderClientViewModel> OrderDetailAsync(Guid? id);

        public Task<IEnumerable<CartOrder>> AllOrdersFromTheCartAsync(Client? client);

        public Task UpdateCartOrderAsync(CartOrderViewModel cart);

        public Task<CartOrderViewModel> UpdateCartOrderAsync(Guid? cartId);

        public Task ClearCart(Client? client);
    }
}
