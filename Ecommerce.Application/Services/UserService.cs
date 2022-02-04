using AutoMapper;
using Ecommerce.Application.InputModel;
using Ecommerce.Application.IServices;
using Ecommerce.Application.ViewModel;
using Ecommerce.Infrastructure.AppContext;
using Ecommerce.Infrastructure.IBaseRepository;
using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Services
{
    public class UserService : IUserService
    {
        private readonly EcommerceDbContext _context;
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<Brand> _brandRepository;
        private readonly IMapper _mapper;

        public UserService
            (
            EcommerceDbContext context,
            IRepository<Product> productRepository,
            IRepository<Category> categoryRepository,
            IRepository<Brand> brandRepository,
            IMapper mapper
            )
        {
            _context = context;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _brandRepository = brandRepository;
            _mapper = mapper;
        }
        public void CreateBrand(BrandInputModel brandInput)
        {
            Brand brand = _mapper.Map<Brand>(brandInput);
            brand.Id = Guid.NewGuid();
            _brandRepository.Create(brand);
        }

        public void CreateCategory(CategoryInputModel categoryInput)
        {
            Category category = _mapper.Map<Category>(categoryInput);
            category.Id = Guid.NewGuid();
            _categoryRepository.Create(category);
        }

        public void CreateProduct(ProductInputModel productInput)
        {
            Product product = _mapper.Map<Product>(productInput);
            product.Id = Guid.NewGuid();
            _productRepository.Create(product);
        }


        public void DeleteBrand(Guid id)
        {
            var x = _brandRepository.FindOne(p => p.Id == id);
            _brandRepository.Delete(x);
        }

        public void DeleteCategory(Guid id)
        {
            var x = _categoryRepository.FindOne(p => p.Id == id);
            _categoryRepository.Delete(x);
        }

        public void DeleteProduct(Guid id)
        {
            var x = _productRepository.FindOne(p => p.Id == id);
            _productRepository.Delete(x);
        }

        public List<BrandViewModel> GetAllBrands()
        {
            var brands = _brandRepository.Get();

            var brandsViewModel = new List<BrandViewModel>();

            foreach (var brand in brands)
            {
                var brandViewModel = _mapper.Map<BrandViewModel>(brand);

                brandsViewModel.Add(brandViewModel);
            }
            return brandsViewModel;
        }

        public List<CategoryViewModel> GetAllCategories()
        {
            var categories = _categoryRepository.Get();

            var categoriesViewModel = new List<CategoryViewModel>();

            foreach(var category in categories)
            {
                var categoryViewModel = _mapper.Map<CategoryViewModel>(category);
                
                categoriesViewModel.Add(categoryViewModel);
            }
            return categoriesViewModel;
        }

        public List<ProductViewModel> GetAllProducts()
        {
            var products = _productRepository.Get();

            var productsViewModel = new List<ProductViewModel>();

            foreach (var product in products)
            {
                var productViewModel = _mapper.Map<ProductViewModel>(product);
                
                productsViewModel.Add(productViewModel);
            }

            return productsViewModel; 
        }

        public BrandViewModel GetBrand(Guid id)
        {
            var brand = _brandRepository.Get().Where(b => b.Id == id).FirstOrDefault();

            return _mapper.Map<BrandViewModel>(brand);
        }

        public CategoryViewModel GetCategory(Guid id)
        {
            var category = _categoryRepository.Get().Where(c => c.Id == id).FirstOrDefault();

            return _mapper.Map<CategoryViewModel>(category);
        }

        public ProductViewModel GetProduct(Guid id)
        {
            var product = _productRepository.Get().Where(p => p.Id == id).FirstOrDefault();

            return _mapper.Map<ProductViewModel>(product);
        }

        public BrandViewModel UpdateBrand(Guid brandId,BrandInputModel brandInput)
        {
            var selectedBrand = _brandRepository.Get().Where(b => b.Id == brandId).FirstOrDefault();

            selectedBrand.Name = brandInput.Name;

            selectedBrand.Bio = brandInput.Bio;

            _brandRepository.Edit(selectedBrand);

            return _mapper.Map<BrandViewModel>(selectedBrand);

        }

        public CategoryViewModel UpdateCategory(Guid categoryId, CategoryInputModel categoryInput)
        {
            var selectedCategory = _categoryRepository.Get().Where(c => c.Id == categoryId).FirstOrDefault();

            selectedCategory.Name = categoryInput.Name;

            _categoryRepository.Edit(selectedCategory);

            return _mapper.Map<CategoryViewModel>(selectedCategory);
        }

        public ProductViewModel UpdateProduct(Guid productId, ProductInputModel productInput)
        {
            var selectedProduct = _productRepository.Get().Where(p => p.Id == productId).FirstOrDefault();
            
            selectedProduct.Name = productInput.Name;
            selectedProduct.Description = productInput.Description;
            selectedProduct.BrandId = productInput.BrandId;

            _productRepository.Edit(selectedProduct);

            return _mapper.Map<ProductViewModel>(selectedProduct);
        }
    }
}
