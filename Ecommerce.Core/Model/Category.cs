namespace Ecommerce.Models
{
    public class Category : Entity
    {
        public Category()
        {
            Products = new List<Product>();
        }
        public List<Product> Products { get; set; }

    }
}
