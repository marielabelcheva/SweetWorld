using SweetWorld.Core.Models.OrderViewModels;
using SweetWorld.Core.Models.ProductViewModels;
using SweetWorld.Core.Models.UserViewModels;
using SweetWorld.Infrastructure.Data.Models;

namespace SweetWorld.Core.Contracts
{
    public interface IConfectionerService
    {
        public Task AddConfectionerAsync(string userId);

        public Task<IEnumerable<UserViewModel>> GetAllConfectionersAsync();

        public Task<IEnumerable<ProductConfectionerViewModel>> AllProductsOfAConfectionerAsync(Guid confectionerId);

        public Task<IEnumerable<OrderClientViewModel>> AllOrdersForExecutingAsync(Confectioner confectioner);
    }
}
