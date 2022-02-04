using Ecommerce.Application.InputModel;
using Ecommerce.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.IServices
{
    public interface IUserService
    {
        void CreateProduct(ProductInputModel productInput);
        List<ProductViewModel> GetAllProducts();
        ProductViewModel GetProduct(Guid id);
        ProductViewModel UpdateProduct(Guid productId,ProductInputModel productInput);
        
        void CreateCategory(CategoryInputModel categoryInput);
        List<CategoryViewModel> GetAllCategories();
        CategoryViewModel GetCategory(Guid id);
        CategoryViewModel UpdateCategory(Guid categoryId,CategoryInputModel categoryInput);
        
        void CreateBrand(BrandInputModel brandInput);
        List<BrandViewModel> GetAllBrands();
        BrandViewModel GetBrand(Guid id);
        BrandViewModel UpdateBrand(Guid brandId, BrandInputModel BrandInput);

        void DeleteProduct(Guid id);
        void DeleteBrand(Guid id);
        void DeleteCategory(Guid id);

    }
}
