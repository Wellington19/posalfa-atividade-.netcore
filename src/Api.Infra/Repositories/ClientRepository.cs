using Api.Domain.Entities;
using Api.Domain.Repositories;
using Api.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Api.Infra.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly ApiDbContext _dbContext;
        private readonly ILogger<ClientRepository> _logger;

        public ClientRepository(ApiDbContext dbContext, ILogger<ClientRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<Client> Create(Client client)
        {
            try
            {
                _dbContext.Add(client);
                await _dbContext.SaveChangesAsync();
                return client;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return client;
            }
        }

        public async Task<bool> Update(Client client)
        {
            try
            {
                _dbContext.Update(client);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<ICollection<Client>> Find()
        {
            return await _dbContext.Clients.ToListAsync();
        }

        public async Task<Client?> FindById(Guid clientId)
        {
            return await _dbContext.Clients.FirstOrDefaultAsync(x => x.Id == clientId);
        }

        public async Task<Client?> FindByDocument(string document)
        {
            return await _dbContext.Clients.FirstOrDefaultAsync(x => x.Document == document);
        }

        public async Task<bool> Delete(Client client)
        {
            try
            {
                _dbContext.Remove(client);
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
