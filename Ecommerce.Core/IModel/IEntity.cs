namespace Ecommerce.Core.IModel;
public interface IEntity
{
    Guid Id { get; set; }
    string Name { get; set; }
    Guid CreatedBy { get; set; }
    DateTime CreatedDate { get; set; }
    Guid? ModifiedBy { get; set; }
    DateTime? ModifiedDate { get; set; }

}
