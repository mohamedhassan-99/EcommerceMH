namespace Ecommerce.Application.ViewModel;

public class ProductViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string BrandName { get; set; }
    public Guid BrandId { get; set; }
}
