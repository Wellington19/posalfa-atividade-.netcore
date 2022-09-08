using Api.Domain.Dtos;
using Api.Service.Services;

namespace Api.Service.Interfaces
{
    public interface IClientService
    {
        Task<ResultService<ClientDto>> Create(ClientDto clientDto);
        Task<ResultService> Update(ClientDto clientDto);
        Task<ResultService<ICollection<ClientDto>>> Find();
        Task<ResultService<ClientDto>>FindById(Guid clientId);
        Task<ResultService> Delete(Guid clientId);
    }
}
