using Api.Domain.Entities;
using Api.Domain.Repositories;
using Api.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Api.Infra.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApiDbContext _dbContext;
        private readonly ILogger<OrderRepository> _logger;

        public OrderRepository(ApiDbContext dbContext, ILogger<OrderRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<Order> Create(Order order)
        {
            try
            {
                _dbContext.Add(order);
                await _dbContext.SaveChangesAsync();
                return order;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return order;
            }
        }        

        public async Task<ICollection<Order>> Find()
        {
            return await _dbContext.Orders
                .Include(x => x.ProductOrder)
                    .ThenInclude(x => x.Product)
                        .ThenInclude(x => x.Category)
                .Include(x => x.Client)
                .OrderBy(x => x.DateOrder)
                .ToListAsync();
        }

        public async Task<Order?> FindById(Guid orderId)
        {
            return await _dbContext.Orders
                .Include(x => x.ProductOrder)
                    .ThenInclude(x => x.Product)
                        .ThenInclude(x => x.Category)
                .Include(x => x.Client)
                .FirstOrDefaultAsync(x => x.Id == orderId);
        }

        public async Task<bool> Delete(Order order)
        {
            try
            {
                _dbContext.Remove(order);
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
