using Domain.Entities;
using Domain.FluentValidations.HBSIS.Padawan.Produtos.Domain;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;

namespace Domain.FluentValidations
{
    class Order_SnackValidation : AbstractValidator<Order_Snack>
    {
        public HashSet<Error> CustomValidate(Order_Snack order_Snack)
        {
            return Validate(order_Snack).Errors.Select(f => new Error(f.PropertyName, f.ErrorMessage)).ToHashSet();
        }

        public Order_SnackValidation()
        {
            RuleFor(d => d.OrderId)
                .GreaterThan(0).WithMessage("Pedido invalido").OverridePropertyName("Pedido");

            RuleFor(d => d.SnackId)
                .GreaterThan(0).WithMessage("lanche invalido").OverridePropertyName("Lanche");
        }
    }
}
