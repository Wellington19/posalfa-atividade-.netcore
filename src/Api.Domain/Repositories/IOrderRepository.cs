using Api.Domain.Entities;

namespace Api.Domain.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> Create(Order order);        
        Task<ICollection<Order>> Find();
        Task<Order?> FindById(Guid orderId);               
        Task<bool> Delete(Order order);
    }
}
