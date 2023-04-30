namespace Ecommerce.Infrastructure.IBaseRepository;

public interface IUnitOfWork
{
    IProductRepository ProductRepository { get; }
    Task SaveAsync();
}
