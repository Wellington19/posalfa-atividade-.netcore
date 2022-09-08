using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infra.Mappings
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("product");

            builder.HasKey(x => x.Id).HasName("id");

            builder.Property(x => x.CategoryId)
                .HasColumnName("category_id")
                .IsRequired();

            builder.Property(x => x.Description)
                .HasColumnName("description")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Code)
                .HasColumnName("code")
                .IsRequired();

            builder.Property(x => x.Price)
                .HasColumnName("price")
                .HasPrecision(10, 2)
                .IsRequired();

            builder.Property(x => x.Stock)
                .HasColumnName("stock")
                .IsRequired();

            builder.HasOne(x => x.Category)
                .WithMany(x => x.Products);

            builder.HasMany(x => x.ProductOrder)
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductId);            
        }

    }
}
