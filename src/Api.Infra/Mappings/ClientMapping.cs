using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infra.Mappings
{
    public class ClientMapping : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("client");

            builder.HasKey(x => x.Id).HasName("id");

            builder.Property(x => x.Document)
                .HasColumnName("document")
                .IsRequired();

            builder.Property(x => x.Email)
                .HasColumnName("email")
                .IsRequired();

            builder.Property(x => x.Name)
                .HasColumnName("name")
                .IsRequired();

            builder.HasMany(x => x.Orders)
                .WithOne(x => x.Client)
                .HasForeignKey(x => x.ClientId);

            builder.HasData(
                new Client(Guid.NewGuid(), "Jhon Doe", "17304539020", "jhon.doe@email.com")
            );
        }

    }
}
