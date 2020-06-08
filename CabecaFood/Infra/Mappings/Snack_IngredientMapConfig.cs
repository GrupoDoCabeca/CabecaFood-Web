using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mappings
{
    class Snack_IngredientMapConfig : IEntityTypeConfiguration<Snack_Ingredient>
    {
        public void Configure(EntityTypeBuilder<Snack_Ingredient> builder)
        {
            builder.ToTable("SNACK_INGREDIENT");

            builder.HasKey(t => new { t.IngredientId, t.SnackId });

            builder.HasOne(x => x.Snack).WithMany(s => s.Snacks_Ingredients).HasForeignKey(x => x.SnackId);

            builder.HasOne(x => x.Ingredient).WithMany(s => s.Snacks_Ingredients).HasForeignKey(x => x.IngredientId);
        }
    }
}
