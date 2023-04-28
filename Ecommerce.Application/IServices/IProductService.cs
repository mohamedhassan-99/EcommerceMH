using Ecommerce.Application.InputModel;
using Ecommerce.Application.ViewModel;

namespace Ecommerce.Application.IServices
{
    public interface IProductService
    {
        Task<string> CreateProductAsync(CreateProductModel? productInput);
        Task<List<ProductViewModel>> GetAllProductsAsync();
        Task<ProductViewModel> GetProductAsync(Guid id);
        string UpdateProduct(UpdateProductModel productInput);
        Task<string> DeleteProductAsync(Guid productId);
        Task<BrandViewModel> GetProductBrandAsync(Guid productId);
        Task<List<CategoryViewModel>> GetProductCategoriesAsync(Guid productId);
        
    }
}
