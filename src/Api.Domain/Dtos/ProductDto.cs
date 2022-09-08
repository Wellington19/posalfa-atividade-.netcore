namespace Api.Domain.Dtos
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public string? Description { get; set; }
        public int Code { get; set; }
        public decimal Price { get; set; }
        public double Stock { get; set; }
    }
}
