namespace Api.Domain.Entities
{
    public class Category
    {
        public Guid Id { get; private set; }
        public string Description { get; private set; }  
        public ICollection<Product> Products { get; private set; }

        public Category(Guid id, string description)
        {
            Id = id;
            Description = description;            
        }

        public Category(string description)
        {
            Description = description;            
        }
    }
}
