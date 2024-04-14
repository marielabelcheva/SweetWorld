using SweetWorld.Core.Models.OrderViewModels;
using SweetWorld.Core.Models.ProductViewModels;
using SweetWorld.Infrastructure.Data.Models;

namespace SweetWorld.Core.Contracts
{
    public interface IOrderService
    {
        public Task CheckoutCartAsync(DeliveryViewModel viewModel, Client client);

        public Task DeleteOrderAsync(Guid? id);

        public Task UpdateStatusOfAnOrderAsync(Guid? id, string status);

        public Task<IEnumerable<OrderClientViewModel>> GetAllUnaprovedOrdersAsync();

        public Task AddOrderToTheCartAsync(ProductDataViewModel viewModel, Client client);

        public Task DeleteOrderFromTheCartAsync(CartOrder order, Client client);
    }
}
