namespace Api.Domain.Dtos
{
    public class ClientDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Document { get; set; }
        public string? Email { get; set; }
    }
}
