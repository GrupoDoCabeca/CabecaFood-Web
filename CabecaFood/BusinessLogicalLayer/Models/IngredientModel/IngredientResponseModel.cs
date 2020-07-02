using BusinessLogicalLayer.Models.Interface;

namespace BusinessLogicalLayer.Models.IngredientModel
{
    public class IngredientResponseModel : IngredientRequestModel, IResponseModel
    {
        public int Id { get; set; }
    }
}
