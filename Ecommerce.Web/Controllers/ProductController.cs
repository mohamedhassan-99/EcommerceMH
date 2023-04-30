using Ecommerce.Application.InputModel;
using Ecommerce.Application.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Ecommerce.Web.Controllers.Api;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    //all the endpoint with models in its params should be handled by fluent validation, better for complex valdiation on the inputs;
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    /// <summary>
    /// You could send an empty body and a new generated product will be created for trail
    /// </summary>
    /// <param name="productInput"></param>
    /// <returns></returns>
    [HttpPost("CreateProduct")]
    public async Task<IActionResult> CreateProduct(CreateProductModel? productInput)
        => Ok(new string[] { await _productService.CreateProductAsync(productInput) });

    [HttpGet("GetAllProducts")]
    public async Task<IActionResult> GetAllProducts()
        => Ok(await _productService.GetAllProductsAsync());

    [HttpGet("GetProductCategories")]
    public async Task<IActionResult> GetProductCategories(Guid productId)
        => Ok(await _productService.GetProductCategoriesAsync(productId));

    [HttpGet("GetProduct")]
    public async Task<IActionResult> GetProduct(Guid productId)
        => Ok(await _productService.GetProductAsync(productId));

    [HttpGet("GetProductBrand")]
    public async Task<IActionResult> GetProductBrand(Guid productId)
        => Ok(await _productService.GetProductBrandAsync(productId));

    [HttpPut("UpdateProduct")]
    public async Task<IActionResult> UpdateProduct(UpdateProductModel updateProductModel)
        => Ok(new string[] { await _productService.UpdateProduct(updateProductModel) });

    [HttpDelete("DeleteProduct")]
    public async Task<IActionResult> DeleteProduct(Guid productId)
        => Ok(await _productService.DeleteProductAsync(productId));

}

