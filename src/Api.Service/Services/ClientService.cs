using Api.Domain.Dtos;
using Api.Domain.Entities;
using Api.Domain.Repositories;
using Api.Domain.Validations;
using Api.Service.Interfaces;
using AutoMapper;

namespace Api.Service.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public ClientService(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<ClientDto>> Create(ClientDto clientDto)
        {
            if (clientDto == null) return ResultService.Fail<ClientDto>("Objeto não informado");

            var result = await new ClientDtoValidator().ValidateAsync(clientDto);
            if (!result.IsValid) return ResultService.RequestError<ClientDto>("Um ou mais erros foram encontrados", result);

            var clientPersisted = await _clientRepository.Create(_mapper.Map<Client>(clientDto));
            var clientDtoPersisted = _mapper.Map<ClientDto>(clientPersisted);

            return ResultService.Ok(clientDtoPersisted);
        }

        public async Task<ResultService> Update(ClientDto clientDto)
        {
            if (clientDto.Id == Guid.Empty) return ResultService.Fail<ClientDto>("ID do cliente não informado");

            var result = await new ClientDtoValidator().ValidateAsync(clientDto);
            if (!result.IsValid) return ResultService.RequestError<ClientDto>("Um ou mais erros foram encontrados", result);

            var client = await _clientRepository.FindById(clientDto.Id);
            if (client == null) return ResultService.Fail("Cliente não encontrado");
            
            var clientUpdated = _mapper.Map(clientDto, client);
            if (await _clientRepository.Update(clientUpdated)) return ResultService.Ok("Cliente editado com sucesso");

            return ResultService.Fail("Ocorreu um erro ao editar o cliente");
        }

        public async Task<ResultService<ICollection<ClientDto>>> Find()
        {
            var clients = await _clientRepository.Find();
            var clientsMappeds = _mapper.Map<ICollection<ClientDto>>(clients);
            return ResultService.Ok(clientsMappeds);
        }

        public async Task<ResultService<ClientDto>> FindById(Guid clientId)
        {
            if (clientId == Guid.Empty) return ResultService.Fail<ClientDto>("ID do cliente não informado");

            var client = await _clientRepository.FindById(clientId);
            if (client == null) return ResultService.Fail<ClientDto>("Cliente não encontrado");

            var clientDto = _mapper.Map<ClientDto>(client);

            return ResultService.Ok(clientDto);
        }

        public async Task<ResultService> Delete(Guid clientId)
        {
            if (clientId == Guid.Empty) return ResultService.Fail<ClientDto>("ID do cliente não informado");

            var client = await _clientRepository.FindById(clientId);
            if (client == null) return ResultService.Fail("Cliente não encontrado");

            if (await _clientRepository.Delete(client)) return ResultService.Ok("Cliente excluído com sucesso");

            return ResultService.Fail("Ocorreu um erro ao excluir o cliente");
        }
    }
}
