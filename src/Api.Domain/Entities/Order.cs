namespace Api.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; private set; }
        public Guid ClientId { get; private set; }
        public Client Client { get; private set; }        
        public ICollection<ProductOrder> ProductOrder { get; private set; }
        public DateTime DateOrder { get; private set; }        

        public Order(Guid id, Guid clientId)
        {
            Id = id;
            ClientId = clientId;            
            DateOrder = DateTime.UtcNow;
        }

        public Order(Guid clientId)
        {
            ClientId = clientId;
            DateOrder = DateTime.UtcNow;
        }

        public Order(Guid id, Guid clientId, ICollection<ProductOrder> productOrder)
        {
            Id = id;
            ClientId = clientId;
            ProductOrder = productOrder;
            DateOrder = DateTime.UtcNow;
        }

        public Order(Guid clientId, ICollection<ProductOrder> productOrder)
        {
            ClientId = clientId;
            ProductOrder = productOrder;
            DateOrder = DateTime.UtcNow;
        }
    }
}
