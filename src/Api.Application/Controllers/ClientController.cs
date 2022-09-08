using Api.Domain.Dtos;
using Api.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _clientService.Find();
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpGet, Route("{clientId}")]
        public async Task<IActionResult> GetAsync(Guid clientId)
        {
            var result = await _clientService.FindById(clientId);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] ClientDto clientDto)
        {
            var result = await _clientService.Create(clientDto);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpPut, Route("{clientId}")]
        public async Task<IActionResult> PutAsync(Guid clientId, [FromBody] ClientDto clientDto)
        {
            clientDto.Id = clientId;
            var result = await _clientService.Update(clientDto);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete, Route("{clientId}")]
        public async Task<IActionResult> DeleteAsync(Guid clientId)
        {
            var result = await _clientService.Delete(clientId);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }
    }
}
