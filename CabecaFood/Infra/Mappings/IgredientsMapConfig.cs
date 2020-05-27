using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mappings
{
    public class IgredientsMapConfig : IEntityTypeConfiguration<Ingredients>
    {
        public void Configure(EntityTypeBuilder<Ingredients> builder)
        {
            builder.ToTable("INGREDIENTS");

            builder.Property(u => u.Id).UseIdentityColumn().IsRequired().HasColumnName("ID");

            builder.Property(u => u.Deleted).IsRequired().HasDefaultValue(false).HasColumnType("BIT").HasColumnName("DELETED");

            builder.Property(u => u.Name).IsRequired().HasColumnType("VARCHAR(100)").HasColumnName("NAME");

            builder.Property(u => u.AmountType).IsRequired().HasColumnName("AMOUNT_TYPE");

        }
    }
}
