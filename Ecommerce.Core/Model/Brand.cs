global using Ecommerce.Core.Model;

namespace Ecommerce.Models
{
    public class Brand : BaseClass
    {
        public Brand()
        {
            Products = new List<Product>();
        }
        public string Bio { get; set; }
        public List<Product> Products { get; set; }
    }
}
