namespace Api.Domain.Dtos
{
    public class ProductResponseDto
    {
        public Guid Id { get; set; }
        public CategoryDto Category { get; set; }
        public string? Description { get; set; }
        public int Code { get; set; }
        public decimal Price { get; set; }
        public double Stock { get; set; }
    }
}
