using BusinessLogicalLayer.Models.Snack_IngredientModel;
using Domain.Entities;
using Shared;

namespace BusinessLogicalLayer.CustomsAutoMapper
{
    public static class Snack_IngredientMap
    {
        public static Snack_Ingredient Snack_IngredientRequestToSnack_Ingredient(Snack_IngredientRequestModel snack_IngredientRequestModel)
        {
            return Map.ChangeValues<Snack_IngredientRequestModel, Snack_Ingredient>(snack_IngredientRequestModel);
        }

        public static Snack_IngredientResponseModel Snack_IngredientToSnack_IngredientResponse(Snack_Ingredient snack_Ingredient)
        {
            return Map.ChangeValues<Snack_Ingredient, Snack_IngredientResponseModel>(snack_Ingredient);
        }
    }
}
