using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mappings
{
    public class IgredientMapConfig : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder.ToTable("INGREDIENTS");

            builder.Property(i => i.Id).UseIdentityColumn().IsRequired().HasColumnName("ID");

            builder.Property(i => i.Deleted).IsRequired().HasDefaultValue(false).HasColumnType("BIT").HasColumnName("DELETED");

            builder.Property(i => i.Name).IsRequired().HasColumnType("VARCHAR(100)").HasColumnName("NAME");

            builder.Property(i => i.AmountType).IsRequired().HasColumnName("AMOUNT_TYPE");
        }
    }
}
