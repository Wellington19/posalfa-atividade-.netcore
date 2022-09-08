using Api.Domain.Dtos;
using Api.Domain.Entities;
using Api.Domain.Repositories;
using Api.Domain.Validations;
using Api.Service.Interfaces;
using AutoMapper;

namespace Api.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<ProductResponseDto>> Create(ProductDto productDto)
        {
            if (productDto == null) return ResultService.Fail<ProductResponseDto>("Objeto não informado");

            var result = await new ProductDtoValidator().ValidateAsync(productDto);
            if (!result.IsValid) return ResultService.RequestError<ProductResponseDto>("Um ou mais erros foram encontrados", result);

            var category = await _categoryRepository.FindById(productDto.CategoryId);
            if (category == null) return ResultService.Fail<ProductResponseDto>("Categoria não encontrada");
            
            var productPersisted = await _productRepository.Create(_mapper.Map<Product>(productDto));
            var productMapped = _mapper.Map<ProductResponseDto>(productPersisted);            

            return ResultService.Ok(productMapped);            
        }

        public async Task<ResultService> Update(ProductDto productDto)
        {
            if (productDto.Id == Guid.Empty) return ResultService.Fail<ProductDto>("ID do produto não informado");

            var result = await new ProductDtoValidator().ValidateAsync(productDto);
            if (!result.IsValid) return ResultService.RequestError<ProductDto>("Um ou mais erros foram encontrados", result);

            var product = await _productRepository.FindById(productDto.Id);
            if (product == null) return ResultService.Fail("Produto não encontrado");

            var category = await _categoryRepository.FindById(productDto.CategoryId);
            if (category == null) return ResultService.Fail("Categoria não encontrada");

            var productUpdated = _mapper.Map(productDto, product);
            if (await _productRepository.Update(productUpdated)) return ResultService.Ok("Produto editado com sucesso");

            return ResultService.Fail("Ocorreu um erro ao editar o produto");
        }

        public async Task<ResultService<ICollection<ProductResponseDto>>> Find()
        {
            var products = await _productRepository.Find();
            var productsMappeds = _mapper.Map<ICollection<ProductResponseDto>>(products);
            return ResultService.Ok(productsMappeds);
        }

        public async Task<ResultService<ProductResponseDto>> FindById(Guid productId)
        {
            if (productId == Guid.Empty) return ResultService.Fail<ProductResponseDto>("ID do produto não informado");

            var product = await _productRepository.FindById(productId);
            if (product == null) return ResultService.Fail<ProductResponseDto>("Produto não encontrado");

            var productMapped = _mapper.Map<ProductResponseDto>(product);

            return ResultService.Ok(productMapped);
        }

        public async Task<ResultService> Delete(Guid productId)
        {
            if (productId == Guid.Empty) return ResultService.Fail<ProductDto>("ID do produto não informado");

            var product = await _productRepository.FindById(productId);
            if (product == null) return ResultService.Fail("Produto não encontrado");

            if (await _productRepository.Delete(product)) return ResultService.Ok("Produto excluído com sucesso");

            return ResultService.Fail("Ocorreu um erro ao excluir o produto");
        }
    }
}
