namespace Api.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; private set; }
        public Guid CategoryId { get; private set; }                
        public string Description { get; private set; }
        public int Code { get; private set; }
        public decimal Price { get; private set; }
        public double Stock { get; private set; }
        public Category Category { get; private set; }
        public ICollection<ProductOrder> ProductOrder { get; private set; }

        public Product(Guid id, Guid categoryId, string description, int code, decimal price, double stock)
        {
            Id = id;
            CategoryId = categoryId;
            Description = description;
            Code = code;
            Price = price;
            Stock = stock;
        }

        public Product(Guid categoryId, string description, int code, decimal price, double stock)
        {
            CategoryId = categoryId;
            Description = description;
            Code = code;
            Price = price;
            Stock = stock;
        }
    }
}
