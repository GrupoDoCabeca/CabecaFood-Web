using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mappings
{
    class Order_SnackMapConfig : IEntityTypeConfiguration<Order_Snack>
    {
        public void Configure(EntityTypeBuilder<Order_Snack> builder)
        {
            builder.ToTable("ORDER_SNACK");

            builder.HasKey(t => new { t.OrderId, t.SnackId });

            builder.HasOne(x => x.Snack).WithMany(s => s.Orders_Snacks).HasForeignKey(x => x.SnackId);

            builder.HasOne(x => x.Order).WithMany(s => s.Order_Snacks).HasForeignKey(x => x.OrderId);
        }
    }
}
