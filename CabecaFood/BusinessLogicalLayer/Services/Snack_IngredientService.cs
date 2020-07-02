using BusinessLogicalLayer.CustomsAutoMapper;
using BusinessLogicalLayer.IServices;
using BusinessLogicalLayer.Models.Snack_IngredientModel;
using Domain.FluentValidations.HBSIS.Padawan.Produtos.Domain;
using Infra.IRepositories;
using Shared.CustomsExceptions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Services
{
    public class Snack_IngredientService : ISnack_IngredientService
    {

        private readonly ISnack_IngredientRepository _snack_IngredientRepository;

        public Snack_IngredientService(ISnack_IngredientRepository snack_IngredientRepository)
        {
            _snack_IngredientRepository = snack_IngredientRepository;
        }

        public async Task<Snack_IngredientResponseModel> Create(Snack_IngredientRequestModel snack_IngredientModel)
        {
            var errors = new HashSet<Error>();

            var snack_Ingredient = Snack_IngredientMap.Snack_IngredientRequestToSnack_Ingredient(snack_IngredientModel);

            if (snack_Ingredient.SnackId < 1)
                errors.Add(new Error("Lanche", "Invalido"));

            if (snack_Ingredient.IngredientId <= 1)
                errors.Add(new Error("Ingrediente", "Invalido"));

            if (errors.Any())
                throw new BadRequestException(errors);

            await _snack_IngredientRepository.Create(snack_Ingredient);
            await _snack_IngredientRepository.Save();

            return Snack_IngredientMap.Snack_IngredientToSnack_IngredientResponse(snack_Ingredient);
        }
    }
}
