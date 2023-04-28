namespace Ecommerce.Models;

public class Product : Entity
{
    public string Description { get; set; }
    public Guid? BrandId { get; set; }
    public Brand? Brand { get; set; }
    public List<Category>? Categories { get; set; } = new List<Category>();
}
