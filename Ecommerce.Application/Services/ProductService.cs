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
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper; // should use projection within the query that will be sent to the database instead of using it here;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<string> CreateProductAsync(CreateProductModel? productInput)
    {
        var product = productInput == null ? GenerateDummyProduct() : _mapper.Map<Product>(productInput);

        await _productRepository.CreateAsync(product);

        await _productRepository.SaveAsync();

        return "Product Created Successfully";
    }

    public async Task<string> DeleteProductAsync(Guid id)
    {
        await _productRepository.DeleteAsync(id);

        await _productRepository.SaveAsync();
        return "Product Deleted";
    }

    public async Task<List<ProductViewModel>> GetAllProductsAsync()
        => _mapper.Map<List<ProductViewModel>>(await _productRepository.GetAllAsync());

    public async Task<ProductViewModel> GetProductAsync(Guid id)
        => _mapper.Map<ProductViewModel>(await _productRepository.GetSingleAsync(a => a.Id == id, ProductIncludes.Brand));

    public async Task<BrandViewModel> GetProductBrandAsync(Guid productId)
        => _mapper.Map<BrandViewModel>(await _productRepository.GetProductBrandAsync(productId));

    public async Task<List<CategoryViewModel>> GetProductCategoriesAsync(Guid productId)
    => _mapper.Map<List<CategoryViewModel>>(await _productRepository.GetProductCategoriesAsync(productId) ?? new List<Category>());


    public string UpdateProduct(UpdateProductModel productInput)
    {
        var updatedProduct = _mapper.Map<Product>(productInput);

        _productRepository.Edit(updatedProduct);

        _productRepository.SaveAsync();
        return "Product Updated";
    }
    private Product GenerateDummyProduct() 
    {
        return new Product
        {
            Id = Guid.NewGuid(),
            BrandId = new Guid("55125622-b1f1-4a04-8e16-ce6d65fbe233"),
            CreatedBy = Guid.NewGuid(),
            Name = "Auto Generated Name "+ new Random().Next().ToString(),
            Description = "Auto Generated Description " + new Random().Next().ToString()
        };
    }

}
