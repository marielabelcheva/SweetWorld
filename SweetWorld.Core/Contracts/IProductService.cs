using SweetWorld.Core.Models.ProductViewModels;
using SweetWorld.Infrastructure.Data.Models;

namespace SweetWorld.Core.Contracts
{
    public interface IProductService
    {
        public Task<IEnumerable<ProductViewModel>> AllProductsAsync();

        public Task AddProductAsync(AddProductViewModel viewModel, Guid? confectionerId);

        public Task<EditProductViewModel> EditProductAsync(Guid? id);

        public Task EditProductAsync(EditProductViewModel viewModel);

        public Task DeleteProductAsync(Guid? id);

        public Task<ProductDataViewModel> ProductDataAsync(Guid? id);

        public IEnumerable<ProductViewModel> GetProductsFromTypeAsync(IEnumerable<ProductViewModel> products, string type);

        public Task<IEnumerable<ProductViewModel>> GetProductsFromCategoryAsync(Guid? categoryId);

        public IEnumerable<ProductViewModel> GetProductsByPriceAsync(IEnumerable<ProductViewModel> products, decimal price = 0.0m);

        //add piecesCountandPriceOfAProduct

        
    }
}
