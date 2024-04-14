using SweetWorld.Core.Models.ProductViewModels;

namespace SweetWorld.Core.Contracts
{
    public interface IProductService
    {
        public Task<IEnumerable<ProductViewModel>> AllProductsAsync();

        public Task AddProductAsync(AddProductViewModel viewModel);

        public Task<EditProductViewModel> EditProductAsync(Guid? id);

        public Task EditProductAsync(EditProductViewModel viewModel);

        public Task DeleteProductAsync(Guid? id);

        public Task<ProductDataViewModel> ProductDataAsync(Guid? id);

        public Task<IEnumerable<ProductViewModel>> GetProductsFromTypeAsync(string type);

        public Task<IEnumerable<ProductViewModel>> GetProductsFromCategoryAsync(Guid? categoryId);

        public Task<IEnumerable<ProductViewModel>> GetProductsByPriceAsync(decimal price = 0.0m);

        //upload images to product and delete them after deleting product
    }
}
