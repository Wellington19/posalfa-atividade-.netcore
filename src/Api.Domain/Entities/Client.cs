namespace Api.Domain.Entities
{
    public class Client
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Document { get; private set; }
        public string Email { get; private set; }
        public ICollection<Order> Orders { get; private set; }

        public Client(Guid id, string name, string document, string email)
        {
            Id = id;
            Name = name;
            Document = document;
            Email = email;
        }

        public Client(string name, string document, string email)
        {
            Name = name;
            Document = document;
            Email = email;
        }
    }
}
