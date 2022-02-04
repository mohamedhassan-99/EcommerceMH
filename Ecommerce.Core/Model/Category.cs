namespace Ecommerce.Models
{
    public class Category : BaseClass
    {
        public Category()
        {
            Products = new List<Product>();
        }
        public List<Product> Products { get; set; }

    }
}
