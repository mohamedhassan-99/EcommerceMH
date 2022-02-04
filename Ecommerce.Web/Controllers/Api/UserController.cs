using Ecommerce.Application.InputModel;
using Ecommerce.Application.IServices;
using Ecommerce.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Web.Controllers.Api
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("CreateBrand")]
        public ActionResult CreateBrand(BrandInputModel brandInput)
        {
            _userService.CreateBrand(brandInput);
            return Ok("Done!");
        }

        [HttpPost("CreateCategory")]
        public ActionResult CreateCategory(CategoryInputModel categoryInput)
        {
            _userService.CreateCategory(categoryInput);
            return Ok("Done!");
        }

        [HttpPost("CreateProduct")]
        public ActionResult CreateProduct(ProductInputModel productInput)
        {
            _userService.CreateProduct(productInput);
            return Ok("Done!");
        }
        [HttpGet("GetAllBrands")]
        public ActionResult GetAllBrands()
        {
            return Ok(_userService.GetAllBrands());
        }

        [HttpGet("GetAllCategories")]
        public ActionResult GetAllCategories()
        {
            return Ok(_userService.GetAllCategories());
        }

        [HttpGet("GetAllProducts")]
        public ActionResult GetAllProducts()
        {
            return Ok(_userService.GetAllProducts());
        }

        [HttpGet("GetBrand")]
        public ActionResult GetBrand(Guid brandId)
        {
            return Ok(_userService.GetBrand(brandId));
        }

        [HttpGet("GetCategory")]
        public ActionResult GetCategory(Guid categoryId)
        {
            return Ok(_userService.GetCategory(categoryId));
        }

        [HttpGet("GetProduct")]
        public ActionResult GetProduct(Guid productId)
        {
            return Ok(_userService.GetProduct(productId));
        }

        [HttpDelete("DeleteProduct")]
        public ActionResult DeleteProduct(Guid productId)
        {
            _userService.DeleteProduct(productId);
            return Ok("Deleted!");
        }

        [HttpDelete("DeleteBrand")]
        public ActionResult DeleteBrand(Guid brandId)
        {
            _userService.DeleteBrand(brandId);
            return Ok("Deleted!");
        }

        [HttpDelete("DeleteCategory")]
        public ActionResult DeleteCategory(Guid categoryId)
        {
            _userService.DeleteCategory(categoryId);
            return Ok("Deleted!");
        }

        [HttpPatch("UpdateBrand")]
        public ActionResult UpdateBrand(Guid Id, BrandInputModel brandinput)
        {
            
            return Ok(_userService.UpdateBrand(Id, brandinput));
        }

        [HttpPatch("UpdateCategory")]
        public ActionResult UpdateCategory(Guid Id, CategoryInputModel categoryInput)
        {
            return Ok(_userService.UpdateCategory(Id,categoryInput));
        }

        [HttpPatch("UpdateProduct")]
        public ActionResult UpdateProduct(Guid Id, ProductInputModel productInput)
        {
            return Ok(_userService.UpdateProduct(Id, productInput));
        }
    }
}
