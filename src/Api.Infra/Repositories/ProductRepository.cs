using Api.Domain.Entities;
using Api.Domain.Repositories;
using Api.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Api.Infra.Repositories
{
    public class ProductRepository : IProductRepository
    {        
        private readonly ApiDbContext _dbContext;
        private readonly ILogger<ProductRepository> _logger;

        public ProductRepository(ApiDbContext dbContext, ILogger<ProductRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<Product> Create(Product product)
        {
            try
            {
                _dbContext.Add(product);
                await _dbContext.SaveChangesAsync();
                return product;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return product;
            }
        }
        public async Task<bool> Update(Product product)
        {
            try
            {
                _dbContext.Update(product);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<ICollection<Product>> Find()
        {
            return await _dbContext.Products
                .Include(x => x.Category)
                .OrderBy(x => x.Description)
                .ToListAsync();
        }
        public async Task<Product?> FindById(Guid productId)
        {
            return await _dbContext.Products
                .Include(x => x.Category)
                .FirstOrDefaultAsync(x => x.Id == productId);
        }

        public async Task<Product?> FindByCode(int code)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(x => x.Code == code);
        }

        public async Task<bool> Delete(Product product)
        {
            try
            {
                _dbContext.Remove(product);
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
