using Domain.DTO;
using Domain.Enums;
using Domain.FluentValidations;
using Domain.FluentValidations.HBSIS.Padawan.Produtos.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Entities
{
    public class Ingredient : BaseEntity
    {
        //Propriedades
        public string Name { get; protected set; }
        public AmountType AmountType { get; protected set; }

        public virtual ICollection<Snack_Ingredient> Snacks_Ingredients { get; protected set; }

        //Construtores
        public Ingredient()
        {

        }
        public Ingredient(IngredientDTO ingredient)
        {
            this.Name = ingredient.Name.FormatProps();
            this.AmountType = ingredient.AmountType;
        }

        //Metodos
        public void Update(IngredientDTO ingredient)
        {
            this.Name = ingredient.Name.FormatProps();
            this.AmountType = ingredient.AmountType;
        }

        public override HashSet<Error> GetErrors()
        {
            return new IngredientValidation().CustomValidate(this);
        }

        public override bool IsInvalid()
        {
            return new IngredientValidation().CustomValidate(this).Any();
        }
    }
}
