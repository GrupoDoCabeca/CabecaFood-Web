using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mappings
{
    public class OrderMapConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("ORDER");

            builder.Property(u => u.Id).UseIdentityColumn().IsRequired().HasColumnName("ID");

            builder.Property(u => u.Deleted).IsRequired().HasDefaultValue(false).HasColumnType("BIT").HasColumnName("DELETED");

            builder.Property(u => u.DateTime).HasDefaultValueSql("getdate()").IsRequired().HasColumnType("DATETIME2").HasColumnName("DATE");
        }
    }
}
