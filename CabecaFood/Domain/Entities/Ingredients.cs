using Domain.DTO;
using Domain.Enums;

namespace Domain.Entities
{
    public class Ingredients : BaseEntity
    {
        //Propriedades
        public string Name { get; protected set; }
        public AmountType AmountType { get; protected set; }

        //Construtores
        public Ingredients()
        {

        }
        public Ingredients(string name, AmountType amountType)
        {
            this.Name = name.FormatProps();
            this.AmountType = amountType;
        }
        public Ingredients(IngredientsDTO ingredients)
        {
            this.Name = ingredients.Name.FormatProps();
            this.AmountType = ingredients.AmountType;
        }

        //Metodos
        public void Update(string name, AmountType amountType)
        {
            this.Name = name.FormatProps();
            this.AmountType = amountType;
        }
        public void Update(IngredientsDTO ingredients)
        {
            this.Name = ingredients.Name.FormatProps();
            this.AmountType = ingredients.AmountType;
        }
    }
}
