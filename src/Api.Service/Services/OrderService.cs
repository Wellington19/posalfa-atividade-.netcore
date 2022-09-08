using Api.Domain.Dtos;
using Api.Domain.Entities;
using Api.Domain.Repositories;
using Api.Domain.Validations;
using Api.Service.Interfaces;
using AutoMapper;

namespace Api.Service.Services
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IProductOrderRepository _productOrderRepository;
        private readonly IClientRepository _clientRepository;

        public OrderService
        (
            IMapper mapper,
            IOrderRepository orderRepository,
            IProductRepository productRepository,
            IProductOrderRepository productOrderRepository,
            IClientRepository clientRepository
        )
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _productOrderRepository = productOrderRepository;
            _clientRepository = clientRepository;
        }

        public async Task<ResultService<OrderResponseDto>> Create(OrderDto orderDto)
        {
            if (orderDto == null) return ResultService.Fail<OrderResponseDto>("Objeto não informado");

            var validationResult = await new OrderDtoValidator().ValidateAsync(orderDto);
            if (!validationResult.IsValid) return ResultService.RequestError<OrderResponseDto>("Um ou mais erros foram encontrados", validationResult);

            var client = await _clientRepository.FindByDocument(orderDto.DocumentClient);
            if (client == null) return ResultService.Fail<OrderResponseDto>("Cliente não encontrado");

            var order = new Order(client.Id);
            var orderPersisted = await _orderRepository.Create(order);

            int i = 1;
            foreach (var item in orderDto.Products)
            {
                var product = await _productRepository.FindByCode(item.CodeProduct);
                if (product != null) 
                {
                    var productOrder = new ProductOrder(i, orderPersisted.Id, product.Id);
                    await _productOrderRepository.Create(productOrder);
                    i++;
                }                
            }            
            var orderMapped = _mapper.Map<OrderResponseDto>(orderPersisted);

            return ResultService.Ok(orderMapped);
        }

        public async Task<ResultService<ICollection<OrderResponseDto>>> Find()
        {
            var orders = await _orderRepository.Find();
            return ResultService.Ok(_mapper.Map<ICollection<OrderResponseDto>>(orders));
        }

        public async Task<ResultService<OrderResponseDto>> FindById(Guid orderId)
        {
            if (orderId == Guid.Empty) return ResultService.Fail<OrderResponseDto>("Id do pedido não informado");

            var order = await _orderRepository.FindById(orderId);
            if (order == null) return ResultService.Fail<OrderResponseDto>("Pedido não encontrado");

            var orderMapped = _mapper.Map<OrderResponseDto>(order);

            return ResultService.Ok(orderMapped);
        }

        public async Task<ResultService> Delete(Guid orderId)
        {
            if (orderId == Guid.Empty) return ResultService.Fail<OrderResponseDto>("Id do pedido não informado");

            var order = await _orderRepository.FindById(orderId);
            if (order == null) return ResultService.Fail<OrderResponseDto>("Pedido não encontrado");

            var productsOrder = await _productOrderRepository.FindById(orderId);
            foreach (var item in productsOrder)
            {
                await _productOrderRepository.Delete(item);
            }

            if (await _orderRepository.Delete(order)) return ResultService.Ok("Pedido excluído com sucesso");

            return ResultService.Fail<OrderResponseDto>("Ocorreu um erro ao remover pedido");
        }
    }
}
