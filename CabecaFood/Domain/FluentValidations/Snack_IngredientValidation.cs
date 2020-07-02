using Domain.Entities;
using Domain.FluentValidations.HBSIS.Padawan.Produtos.Domain;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;

namespace Domain.FluentValidations
{
    class Snack_IngredientValidation : AbstractValidator<Snack_Ingredient>
    {
        public HashSet<Error> CustomValidate(Snack_Ingredient snack_Ingredient)
        {
            return Validate(snack_Ingredient).Errors.Select(f => new Error(f.PropertyName, f.ErrorMessage)).ToHashSet();
        }

        public Snack_IngredientValidation()
        {
            RuleFor(d => d.SnackId)
                .GreaterThan(0).WithMessage("Lanche invalido").OverridePropertyName("Lanche");

            RuleFor(d => d.IngredientId)
                .GreaterThan(0).WithMessage("Ingrediente invalido").OverridePropertyName("Ingrediente");
        }
    }
}
