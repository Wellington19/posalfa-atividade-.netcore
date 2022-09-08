using Api.Domain.Dtos;
using Api.Service.Services;

namespace Api.Service.Interfaces
{
    public interface IOrderService
    {
        Task<ResultService<OrderResponseDto>> Create(OrderDto orderDto);
        Task<ResultService<ICollection<OrderResponseDto>>> Find();
        Task<ResultService<OrderResponseDto>> FindById(Guid orderId);
        Task<ResultService> Delete(Guid orderId);
    }
}
