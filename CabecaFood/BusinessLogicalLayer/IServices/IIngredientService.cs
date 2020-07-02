using BusinessLogicalLayer.Models.IngredientModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.IServices
{
    public interface IIngredientService
    {
        Task<List<IngredientResponseModel>> GetAll();
        Task<IngredientResponseModel> GetById(int id);
        Task<IngredientResponseModel> Create(IngredientResponseModel ingredientModel);
        Task<IngredientResponseModel> Update(int id, IngredientResponseModel ingredientModel);
        Task<IngredientResponseModel> Delete(int id);
    }
}