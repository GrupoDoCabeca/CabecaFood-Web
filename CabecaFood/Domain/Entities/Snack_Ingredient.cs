using Domain.DTO;

namespace Domain.Entities
{
    public class Snack_Ingredient
    {
        public int SnackId { get; protected set; }
        public virtual Snack Snack { get; protected set; }

        public int IngredientId { get; protected set; }
        public virtual Ingredient Ingredient { get; protected set; }

        public Snack_Ingredient()
        {

        }

        public Snack_Ingredient(Snack_IngredientDTO snack_IngredientDTO)
        {
            this.SnackId = snack_IngredientDTO.SnackId;
            this.IngredientId = snack_IngredientDTO.IngredientId;
        }
    }
}
