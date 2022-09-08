using Api.Domain.Entities;
using Api.Domain.Repositories;
using Api.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Api.Infra.Repositories
{
    public class ProductOrderRepository : IProductOrderRepository
    {
        private readonly ApiDbContext _dbContext;
        private readonly ILogger<ProductOrderRepository> _logger;

        public ProductOrderRepository(ApiDbContext dbContext, ILogger<ProductOrderRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<ProductOrder> Create(ProductOrder productOrder)
        {
            try
            {
                _dbContext.Add(productOrder);
                await _dbContext.SaveChangesAsync();
                return productOrder;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return productOrder;
            }
        }

        public async Task<ICollection<ProductOrder>?> FindById(Guid orderId)
        {
            return await _dbContext.ProductsOrder
                .Where(x => x.OrderId == orderId)
                .ToListAsync();
        }

        public async Task<bool> Delete(ProductOrder productOrder)
        {
            try
            {
                _dbContext.Remove(productOrder);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }
    }
}
