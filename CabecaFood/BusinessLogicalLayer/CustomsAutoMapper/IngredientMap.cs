using BusinessLogicalLayer.Models.IngredientModel;
using Domain.Entities;
using Shared;

namespace BusinessLogicalLayer.CustomsAutoMapper
{
    public static class IngredientMap
    {
        public static Ingredient IngredientRequestModelToIngredient(IngredientRequestModel ingredientRequest)
        {
            return Map.ChangeValues<IngredientRequestModel, Ingredient>(ingredientRequest);
        }

        public static IngredientResponseModel IngredientToIngredientResponse(Ingredient ingredient)
        {
            return Map.ChangeValues<Ingredient, IngredientResponseModel>(ingredient);
        }
    }
}
