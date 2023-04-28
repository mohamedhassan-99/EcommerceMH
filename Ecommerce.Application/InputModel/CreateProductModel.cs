namespace Ecommerce.Application.InputModel
{
    public class CreateProductModel
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Guid? BrandId { get; set; }

    }
}
