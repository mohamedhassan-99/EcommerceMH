global using Ecommerce.Core.Model;

namespace Ecommerce.Models;

public class Brand : Entity
{
    public string Bio { get; set; }
    public List<Product> Products { get; set; } = new List<Product>();
}
