using Api.Domain.Entities;

namespace Api.Domain.Repositories
{
    public interface ICategoryRepository
    {
        Task<Category> Create(Category category);
        Task<bool> Update(Category category);
        Task<ICollection<Category>> Find();
        Task<Category?> FindById(Guid categoryId);        
        Task<bool> Delete(Category category);
    }
}
