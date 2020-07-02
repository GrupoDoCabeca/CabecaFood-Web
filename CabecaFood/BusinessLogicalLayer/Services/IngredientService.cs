using BusinessLogicalLayer.CustomsAutoMapper;
using BusinessLogicalLayer.IServices;
using BusinessLogicalLayer.Models.IngredientModel;
using Domain.DTO;
using Domain.Entities;
using Infra.IRepositories;
using Shared;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Services
{
    public class IngredientService : BaseService<Ingredient>, IIngredientService
    {
        private readonly IIngredientRepository _ingredientRepository;

        public IngredientService(IIngredientRepository ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }

        public async Task<IngredientResponseModel> Create(IngredientResponseModel ingredientModel)
        {
            var ingredient = IngredientMap.IngredientRequestModelToIngredient(ingredientModel);

            Validate(ingredient);

            await _ingredientRepository.Create(ingredient);

            return IngredientMap.IngredientToIngredientResponse(ingredient);
        }

        public async Task<IngredientResponseModel> Delete(int id)
        {
            ValidateId(id);

            var ingredient = await _ingredientRepository.GetById(id);

            if (ingredient == null)
                AddError("ingrediente", "Não encontrado");

            HandleError();

            await _ingredientRepository.Delete(id);
            await _ingredientRepository.Save();

            return IngredientMap.IngredientToIngredientResponse(ingredient);
        }

        public async Task<List<IngredientResponseModel>> GetAll()
        {
            var ingredients = await _ingredientRepository.GetAll();
            return ingredients.Select(x => IngredientMap.IngredientToIngredientResponse(x)).ToList();
        }

        public async Task<IngredientResponseModel> GetById(int id)
        {
            ValidateId(id);

            var ingredient = await _ingredientRepository.GetById(id);

            if (ingredient == null)
                AddError("ingrediente", "Não encontrado");

            HandleError();

            return IngredientMap.IngredientToIngredientResponse(ingredient);
        }

        public async Task<IngredientResponseModel> Update(int id, IngredientResponseModel ingredientModel)
        {
            var ingredient = IngredientMap.IngredientRequestModelToIngredient(ingredientModel);

            ValidateId(id);
            Validate(ingredient);

            var ingredientToUpdate = await _ingredientRepository.GetById(id);

            if (ingredientToUpdate == null)
                AddError("ingrediente", "Não encontrado");

            var ingredientDTO = Map.ChangeValues<Ingredient, IngredientDTO>(ingredient);
            ingredientToUpdate.Update(ingredientDTO);

            await _ingredientRepository.Update(ingredientToUpdate);
            await _ingredientRepository.Save();

            return IngredientMap.IngredientToIngredientResponse(ingredientToUpdate);
        }

        public override void Validate(Ingredient entity)
        {
            if (entity.IsInvalid())
                AddErrors(entity.GetErrors());

            HandleError();
        }
    }
}
