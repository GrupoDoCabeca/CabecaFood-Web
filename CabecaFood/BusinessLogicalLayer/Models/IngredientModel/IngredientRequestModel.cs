using Domain.Enums;

namespace BusinessLogicalLayer.Models.IngredientModel
{
    public class IngredientRequestModel
    {
        public string Name { get; set; }
        public AmountType AmountType { get; set; }
    }
}
