using Api.Domain.Dtos;
using Api.Domain.Entities;
using AutoMapper;

namespace Api.Domain.Mappings
{
    public class DtoToEntityMapping : Profile
    {
        public DtoToEntityMapping()
        {
            CreateMap<CategoryDto, Category>();
            CreateMap<ProductDto, Product>();
            CreateMap<ProductResponseDto, Product>();
            CreateMap<ProductOrderResponseDto, Product>();
            CreateMap<ClientDto, Client>();
            CreateMap<OrderResponseDto, Order>();
        }
    }
}
