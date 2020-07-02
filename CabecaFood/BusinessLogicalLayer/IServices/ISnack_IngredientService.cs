using BusinessLogicalLayer.Models.Snack_IngredientModel;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.IServices
{
    public interface ISnack_IngredientService
    {
        Task<Snack_IngredientResponseModel> Create(Snack_IngredientRequestModel snack_IngredientModel);
    }
}