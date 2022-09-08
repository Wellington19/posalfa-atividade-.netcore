namespace Api.Domain.Dtos
{
    public class OrderResponseDto
    {
        public Guid Id { get; set; }
        public ICollection<ProductOrderResponseDto> ProductOrder { get; set; }
        public ClientDto Client { get; set; }        
    }
}
