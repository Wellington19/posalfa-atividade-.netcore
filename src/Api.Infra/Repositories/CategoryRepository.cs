using Api.Domain.Entities;
using Api.Domain.Repositories;
using Api.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Api.Infra.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {        
        private readonly ApiDbContext _dbContext;
        private readonly ILogger<CategoryRepository> _logger;

        public CategoryRepository(ApiDbContext dbContext, ILogger<CategoryRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<Category> Create(Category category)
        {
            try
            {
                _dbContext.Add(category);
                await _dbContext.SaveChangesAsync();
                return category;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return category;
            }
        }
        public async Task<bool> Update(Category category)
        {
            try
            {
                _dbContext.Update(category);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<ICollection<Category>> Find()
        {
            return await _dbContext.Categories.ToListAsync();
        }
        public async Task<Category?> FindById(Guid categoryId)
        {
            return await _dbContext.Categories.FirstOrDefaultAsync(x => x.Id == categoryId);
        }

        public async Task<bool> Delete(Category category)
        {
            try
            {
                _dbContext.Remove(category);
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
