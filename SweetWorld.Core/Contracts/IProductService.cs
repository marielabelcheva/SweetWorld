using SweetWorld.Core.Models.ProductViewModels;
using SweetWorld.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using SweetWorld.Core.Models.Pagination;

namespace SweetWorld.Core.Contracts
{
    public interface IProductService
    {
        public Task<IEnumerable<ProductViewModel>> AllProductsAsync(int page);

        public Task AddProductAsync(AddProductViewModel viewModel, Guid? confectionerId);

        public Task<EditProductViewModel> EditProductAsync(Guid? id);

        public Task EditProductAsync(EditProductViewModel viewModel);

        public Task DeleteProductAsync(Guid? id);

        public Task<ProductDataViewModel> ProductDataAsync(Guid? id);

        public Task<IEnumerable<ProductViewModel>> GetProductsFromTypeAsync(string type);

        public Task<IEnumerable<ProductViewModel>> GetProductsFromCategoryAsync(string? categoryName);

        public Task<IEnumerable<ProductViewModel>> GetProductsByPriceAsync(decimal price = 0.0m);

        public Task<IEnumerable<ProductViewModel>> GetProductsByNameAsync(string? name);

        public Task LikeProductAsync(Guid? id, Guid? clientId);

        public Task<IEnumerable<ProductViewModel>> WishListAsync(int page, Guid? clientId);

        public Task AddPiecesCountAndPrice(PiecesCountAndPriceViewModel viewModel);

        public Task DeleteFromWishListAsync(Guid? productId, Guid? clientId);

        public Task<IEnumerable<string?>> GetAllTypesAsync();

        public Task<IEnumerable<string?>> GetAllCategoriesAsync();

        public Pager Pager { get; set; }
}
}
