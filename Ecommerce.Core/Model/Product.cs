namespace Ecommerce.Models
{
    public class Product : BaseClass
    {
        public Product()
        {
            Categories = new List<Category>();
        }
        public string Description { get; set; }
        public Guid BrandId { get; set; }
        public Brand Brand { get; set; }
        public List<Category> Categories { get; set; }
    }
}
