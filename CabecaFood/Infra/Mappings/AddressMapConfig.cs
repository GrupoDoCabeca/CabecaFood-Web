using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mappings
{
    public class AddressMapConfig : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("ADDRESS");

            builder.Property(u => u.Id).UseIdentityColumn().IsRequired().HasColumnName("ID");

            builder.Property(u => u.Deleted).IsRequired().HasDefaultValue(false).HasColumnType("BIT").HasColumnName("DELETED");

            builder.Property(u => u.State).IsRequired().HasColumnType("VARCHAR(100)").HasColumnName("STATE");

            builder.Property(u => u.City).IsRequired().HasColumnType("VARCHAR(100)").HasColumnName("CITY");

            builder.Property(u => u.Neighborhood).IsRequired().HasColumnType("VARCHAR(100)").HasColumnName("NEIGHBORHOOD");

            builder.Property(u => u.Street).IsRequired().HasColumnType("VARCHAR(100)").HasColumnName("STREET");

            builder.Property(u => u.Number).IsRequired().HasColumnType("VARCHAR(6)").HasColumnName("NUMBER");
        }
    }
}
