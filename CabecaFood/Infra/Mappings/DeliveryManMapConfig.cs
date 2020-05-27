using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mappings
{
    public class DeliveryManMapConfig : IEntityTypeConfiguration<DeliveryMan>
    {
        public void Configure(EntityTypeBuilder<DeliveryMan> builder)
        {
            builder.ToTable("DELIVERY_MAN");

            builder.Property(u => u.Id).UseIdentityColumn().IsRequired().HasColumnName("ID");

            builder.Property(u => u.Deleted).IsRequired().HasDefaultValue(false).HasColumnType("BIT").HasColumnName("DELETED");

            builder.Property(u => u.Name).IsRequired().HasColumnType("VARCHAR(100)").HasColumnName("NAME");

            builder.Property(u => u.PIS).IsRequired().HasColumnType("CHAR(11)").HasColumnName("PIS");

            builder.Property(u => u.Salary).IsRequired().HasColumnType("FLOAT").HasColumnName("SALARY");

        }
    }
}
