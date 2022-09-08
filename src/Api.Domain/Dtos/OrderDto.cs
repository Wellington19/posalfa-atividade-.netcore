namespace Api.Domain.Dtos
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public ICollection<ProductOrderDto> Products { get; set; }
        public string DocumentClient { get; set; }        
    }
}
