using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infra.Mappings
{
    public class ProductOrderMapping : IEntityTypeConfiguration<ProductOrder>
    {
        public void Configure(EntityTypeBuilder<ProductOrder> builder)
        {
            builder.ToTable("product_order");

            builder.HasKey(x => new { x.Id, x.OrderId, x.ProductId });            

            builder.HasOne(x => x.Order)
                .WithMany(x => x.ProductOrder);

            builder.HasOne(x => x.Product)
                .WithMany(x => x.ProductOrder);            
        }
    }
}
