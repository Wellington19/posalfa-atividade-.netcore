using Api.Domain.Dtos;
using Api.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _categoryService.Find();
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpGet, Route("{categoryId}")]
        public async Task<IActionResult> GetAsync(Guid categoryId)
        {
            var result = await _categoryService.FindById(categoryId);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CategoryDto categoryDto)
        {
            var result = await _categoryService.Create(categoryDto);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpPut, Route("{categoryId}")]
        public async Task<IActionResult> PutAsync(Guid categoryId, [FromBody] CategoryDto categoryDto)
        {
            categoryDto.Id = categoryId;
            var result = await _categoryService.Update(categoryDto);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete, Route("{categoryId}")]
        public async Task<IActionResult> DeleteAsync(Guid categoryId)
        {
            var result = await _categoryService.Delete(categoryId);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }
    }
}
