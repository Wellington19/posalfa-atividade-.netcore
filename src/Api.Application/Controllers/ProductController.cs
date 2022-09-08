using Api.Domain.Dtos;
using Api.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _productService.Find();
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpGet, Route("{productId}")]
        public async Task<IActionResult> GetAsync(Guid productId)
        {
            var result = await _productService.FindById(productId);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] ProductDto productDto)
        {
            var result = await _productService.Create(productDto);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpPut, Route("{productId}")]
        public async Task<IActionResult> PutAsync(Guid productId, [FromBody] ProductDto productDto)
        {
            productDto.Id = productId;
            var result = await _productService.Update(productDto);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete, Route("{productId}")]
        public async Task<IActionResult> DeleteAsync(Guid productId)
        {
            var result = await _productService.Delete(productId);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }
    }
}
