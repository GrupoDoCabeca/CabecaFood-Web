using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mappings
{
    public class SnackMapConfig : IEntityTypeConfiguration<Snack>
    {
        public void Configure(EntityTypeBuilder<Snack> builder)
        {
            builder.ToTable("SNACK");

            builder.Property(u => u.Id).UseIdentityColumn().IsRequired().HasColumnName("ID");

            builder.Property(u => u.Deleted).IsRequired().HasDefaultValue(false).HasColumnType("BIT").HasColumnName("DELETED");

            builder.Property(u => u.Name).IsRequired().HasColumnType("VARCHAR(100)").HasColumnName("NAME");

            builder.Property(u => u.Price).IsRequired().HasColumnType("FLOAT").HasColumnName("PRICE");

            builder.Property(u => u.Description).IsRequired().HasColumnType("VARCHAR(100)").HasColumnName("DESCRIPTION");
        }
    }
}
