using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Infra.Context
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ProductOrder> ProductsOrder { get; set; }

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApiDbContext).Assembly);
        }
    }
}
