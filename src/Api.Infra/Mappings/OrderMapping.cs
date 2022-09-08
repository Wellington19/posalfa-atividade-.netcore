using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infra.Mappings
{
    public class OrderMapping : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("order");

            builder.HasKey(x => x.Id).HasName("id");

            builder.Property(x => x.ClientId)
                .HasColumnName("client_id")
                .IsRequired();            

            builder.Property(x => x.DateOrder)
                .HasColumnName("date_order")
                .IsRequired();            

            builder.HasOne(x => x.Client)
                .WithMany(x => x.Orders);

            builder.HasMany(x => x.ProductOrder)
                .WithOne(x => x.Order)
                .HasForeignKey(x => x.OrderId);
        }
    }
}
