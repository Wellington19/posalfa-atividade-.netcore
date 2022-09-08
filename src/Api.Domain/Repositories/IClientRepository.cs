using Api.Domain.Entities;

namespace Api.Domain.Repositories
{
    public interface IClientRepository
    {
        Task<Client> Create(Client client);
        Task<bool> Update(Client client);
        Task<ICollection<Client>> Find();
        Task<Client?> FindById(Guid clientId);
        Task<Client?> FindByDocument(string document);        
        Task<bool> Delete(Client client);
    }
}
