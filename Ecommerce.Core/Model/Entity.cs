using Ecommerce.Core.IModel;

namespace Ecommerce.Core.Model;
public class Entity : IEntity , ISoftDelete
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime CreatedDate { get; private set; } = DateTime.Now;
    public Guid? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public bool IsDeleted { get; set; }
}
