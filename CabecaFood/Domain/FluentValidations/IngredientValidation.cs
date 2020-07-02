using Domain.Entities;
using Domain.FluentValidations.HBSIS.Padawan.Produtos.Domain;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;

namespace Domain.FluentValidations
{
    class IngredientValidation : AbstractValidator<Ingredient>
    {
        public HashSet<Error> CustomValidate(Ingredient ingredient)
        {
            return Validate(ingredient).Errors.Select(f => new Error(f.PropertyName, f.ErrorMessage)).ToHashSet();
        }

        public IngredientValidation()
        {
            RuleFor(d => d.Name)
               .Cascade(CascadeMode.StopOnFirstFailure)
               .NotEmpty().WithMessage("Nome deve ser informado").OverridePropertyName("Nome")
               .NotNull().WithMessage("Nome deve ser informado").OverridePropertyName("Nome")
               .Length(2, 100).WithMessage("Nome deve conter entre 2 a 100 caracteres").OverridePropertyName("Nome");

            RuleFor(d => (int)d.AmountType)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .GreaterThanOrEqualTo(0).WithMessage("Quantidade deve ser valida").OverridePropertyName("Tipo quantidade")
                .LessThan(3).WithMessage("Quantidade deve ser valida").OverridePropertyName("Tipo quantidade");
        }
    }
}
