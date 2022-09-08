using Api.Domain.Dtos;
using Api.Domain.Entities;
using Api.Domain.Repositories;
using Api.Domain.Validations;
using Api.Service.Interfaces;
using AutoMapper;

namespace Api.Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<CategoryDto>> Create(CategoryDto categoryDto)
        {
            if (categoryDto == null) return ResultService.Fail<CategoryDto>("Objeto não informado");

            var result = await new CategoryDtoValidator().ValidateAsync(categoryDto);
            if (!result.IsValid) return ResultService.RequestError<CategoryDto>("Um ou mais erros foram encontrados", result);

            var categoryPersisted = await _categoryRepository.Create(_mapper.Map<Category>(categoryDto));
            var categoryDtoPersisted = _mapper.Map<CategoryDto>(categoryPersisted);

            return ResultService.Ok(categoryDtoPersisted);
        }

        public async Task<ResultService> Update(CategoryDto categoryDto)
        {
            if (categoryDto.Id == Guid.Empty) return ResultService.Fail<CategoryDto>("ID da categoria não informado");

            var result = await new CategoryDtoValidator().ValidateAsync(categoryDto);
            if (!result.IsValid) return ResultService.RequestError<CategoryDto>("Um ou mais erros foram encontrados", result);

            var category = await _categoryRepository.FindById(categoryDto.Id);
            if (category == null) return ResultService.Fail("Categoria não encontrada");
            
            var categoryUpdated = _mapper.Map(categoryDto, category);
            if (await _categoryRepository.Update(categoryUpdated)) return ResultService.Ok("Categoria editada com sucesso");

            return ResultService.Fail("Ocorreu um erro ao editar a categoria");
        }

        public async Task<ResultService<ICollection<CategoryDto>>> Find()
        {
            var categories = await _categoryRepository.Find();
            var categoriesMappeds = _mapper.Map<ICollection<CategoryDto>>(categories);
            return ResultService.Ok(categoriesMappeds);
        }

        public async Task<ResultService<CategoryDto>> FindById(Guid categoryId)
        {
            if (categoryId == Guid.Empty) return ResultService.Fail<CategoryDto>("ID da categoria não informado");

            var category = await _categoryRepository.FindById(categoryId);
            if (category == null) return ResultService.Fail<CategoryDto>("Categoria não encontrada");

            var categoryDto = _mapper.Map<CategoryDto>(category);

            return ResultService.Ok(categoryDto);
        }

        public async Task<ResultService> Delete(Guid categoryId)
        {
            if (categoryId == Guid.Empty) return ResultService.Fail<CategoryDto>("ID da categoria não informada");

            var category = await _categoryRepository.FindById(categoryId);
            if (category == null) return ResultService.Fail("Categoria não encontrada");

            if (await _categoryRepository.Delete(category)) return ResultService.Ok("Categoria excluída com sucesso");

            return ResultService.Fail("Ocorreu um erro ao excluir a categoria");
        }
    }
}
