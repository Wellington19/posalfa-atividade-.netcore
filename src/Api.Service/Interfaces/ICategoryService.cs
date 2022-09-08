using Api.Domain.Dtos;
using Api.Service.Services;

namespace Api.Service.Interfaces
{
    public interface ICategoryService
    {
        Task<ResultService<CategoryDto>> Create(CategoryDto categoryDto);
        Task<ResultService> Update(CategoryDto categoryDto);
        Task<ResultService<ICollection<CategoryDto>>> Find();
        Task<ResultService<CategoryDto>>FindById(Guid categoryId);
        Task<ResultService> Delete(Guid categoryId);
    }
}
