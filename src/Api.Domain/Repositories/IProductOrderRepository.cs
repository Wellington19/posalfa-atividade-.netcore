using Api.Domain.Entities;

namespace Api.Domain.Repositories
{
    public interface IProductOrderRepository
    {
        Task<ProductOrder> Create(ProductOrder productOrder);
        Task<ICollection<ProductOrder>?> FindById(Guid orderId);
        Task<bool> Delete(ProductOrder productOrder);
    }
}
