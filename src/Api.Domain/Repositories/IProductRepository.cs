using Api.Domain.Entities;

namespace Api.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<Product> Create(Product product);
        Task<bool> Update(Product product);
        Task<ICollection<Product>> Find();
        Task<Product?> FindById(Guid productId);
        Task<Product?> FindByCode(int code);
        Task<bool> Delete(Product product);
    }
}
