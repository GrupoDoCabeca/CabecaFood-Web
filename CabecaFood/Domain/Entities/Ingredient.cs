using Domain.DTO;
using Domain.Enums;
using Domain.FluentValidations.HBSIS.Padawan.Produtos.Domain;
using System.Collections.Generic;

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
        public Ingredient(IngredientsDTO ingredients)
        {
            this.Name = ingredients.Name.FormatProps();
            this.AmountType = ingredients.AmountType;
        }

        //Metodos
        public void Update(IngredientsDTO ingredients)
        {
            this.Name = ingredients.Name.FormatProps();
            this.AmountType = ingredients.AmountType;
        }

        public override HashSet<Error> GetErrors()
        {
            throw new System.NotImplementedException();
        }

        public override bool IsInvalid()
        {
            throw new System.NotImplementedException();
        }
    }
}
