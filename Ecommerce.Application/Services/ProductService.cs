using AutoMapper;
using Ecommerce.Application.InputModel;
using Ecommerce.Application.IServices;
using Ecommerce.Application.ViewModel;
using Ecommerce.Core.Enum;
using Ecommerce.Infrastructure.IBaseRepository;
using Ecommerce.Models;

namespace Ecommerce.Application.Services;

public class ProductService : IProductService
{
    private readonly IUnitOfWork _unit;
    private readonly IMapper _mapper; // should use projection within the query that will be sent to the database instead of using it here;

    public ProductService(IUnitOfWork unit, IMapper mapper)
    {
        _unit = unit;
        _mapper = mapper;
    }

    public async Task<string> CreateProductAsync(CreateProductModel? productInput)
    {
        var product = productInput == null ? GenerateDummyProduct() : _mapper.Map<Product>(productInput);

        await _unit.ProductRepository.CreateAsync(product);

        await _unit.SaveAsync();

        return "Product Created Successfully";
    }

    public async Task<string> DeleteProductAsync(Guid id)
    {
        await _unit.ProductRepository.DeleteAsync(id);

        return "Product Deleted";
    }

    public async Task<List<ProductViewModel>> GetAllProductsAsync()
        => _mapper.Map<List<ProductViewModel>>(await _unit.ProductRepository.GetAllAsync());

    public async Task<ProductViewModel> GetProductAsync(Guid id)
        => _mapper.Map<ProductViewModel>(await _unit.ProductRepository.GetSingleAsync(a => a.Id == id, ProductIncludes.Brand)
                                         ?? throw new Exception("NotFound"));

    public async Task<BrandViewModel> GetProductBrandAsync(Guid productId)
        => _mapper.Map<BrandViewModel>(await _unit.ProductRepository.GetProductBrandAsync(productId));

    public async Task<List<CategoryViewModel>> GetProductCategoriesAsync(Guid productId)
    => _mapper.Map<List<CategoryViewModel>>(await _unit.ProductRepository.GetProductCategoriesAsync(productId) ?? new List<Category>());


    public async Task<string> UpdateProduct(UpdateProductModel productInput)
    {

        var dBProduct = await _unit.ProductRepository.GetSingleAsync(a => a.Id == productInput.Id, ProductIncludes.Brand);
        // could you different approaches like attach or mapping, I just want to keep it simple her
        dBProduct.Description = productInput.Description;
        dBProduct.BrandId = productInput.BrandId;
        dBProduct.Name = productInput.Name;

        await _unit.SaveAsync();
        return "Product Updated";
    }
    private Product GenerateDummyProduct()
    {
        return new Product
        {
            Id = Guid.NewGuid(),
            BrandId = new Guid("55125622-b1f1-4a04-8e16-ce6d65fbe233"),
            CreatedBy = Guid.NewGuid(),
            Name = "Auto Generated Name " + new Random().Next().ToString(),
            Description = "Auto Generated Description " + new Random().Next().ToString()
        };
    }

}
