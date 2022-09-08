using Api.Domain.Dtos;
using Api.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _orderService.Find();
            if (result.Success) return Ok(result);
            
            return BadRequest(result);
        }

        [HttpGet, Route("{orderId}")]
        public async Task<IActionResult> GetAsync(Guid orderId)
        {
            var result = await _orderService.FindById(orderId);
            if (result.Success) return Ok(result);
            
            return BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] OrderDto orderDto)
        {
            var result = await _orderService.Create(orderDto);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete, Route("{orderId}")]
        public async Task<IActionResult> DeleteAsync(Guid orderId)
        {
            var result = await _orderService.Delete(orderId);

            if (result.Success) return Ok(result);

            return BadRequest(result);
        }
    }
}
