namespace Api.Domain.Entities
{
    public class ProductOrder
    {
        public int Id { get; private set; }
        public Guid OrderId { get; private set; }
        public Order Order { get; private set; }
        public Guid ProductId { get; private set; }        
        public Product Product { get; private set; }

        public ProductOrder(int id, Guid orderId, Guid productId)
        {
            Id = id;
            OrderId = orderId;
            ProductId = productId;            
        }        
    }
}
