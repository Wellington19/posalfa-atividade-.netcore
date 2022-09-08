using Api.Domain.Dtos;
using Api.Domain.Entities;
using AutoMapper;

namespace Api.Domain.Mappings
{
    public class EntityToDtoMapping : Profile
    {
        public EntityToDtoMapping()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<Product, ProductDto>();
            CreateMap<Product, ProductResponseDto>();
            CreateMap<ProductOrder, ProductOrderResponseDto>();
            CreateMap<Client, ClientDto>();
            CreateMap<Order, OrderResponseDto>();
        }
    }
}
