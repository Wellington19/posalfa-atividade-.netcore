using Api.Domain.Dtos;
using Api.Service.Services;

namespace Api.Service.Interfaces
{
    public interface IProductService
    {
        Task<ResultService<ProductResponseDto>> Create(ProductDto productDto);
        Task<ResultService> Update(ProductDto productDto);
        Task<ResultService<ICollection<ProductResponseDto>>> Find();
        Task<ResultService<ProductResponseDto>>FindById(Guid productId);
        Task<ResultService> Delete(Guid productId);
    }
}
