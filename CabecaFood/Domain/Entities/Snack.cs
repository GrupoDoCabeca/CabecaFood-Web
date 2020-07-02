using Domain.DTO;
using Domain.FluentValidations;
using Domain.FluentValidations.HBSIS.Padawan.Produtos.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Entities
{
    public class Snack : BaseEntity
    {
        //Propriedades
        public string Name { get; protected set; }
        public double Price { get; protected set; }
        public string Description { get; protected set; }

        public int? OrderId { get; protected set; }
        public virtual Order Order { get; set; }



        //Construtores
        public Snack()
        {

        }
        public Snack(SnackDTO snack)
        {
            this.Name = snack.Name.FormatProps();
            this.Description = snack.Description.FormatProps();
            this.Price = snack.Price;
        }

        //Metodos

        public void SetOrderId(int orderId)
        {
            this.OrderId = orderId;
        }

        public void Update(SnackDTO snack)
        {
            this.Name = snack.Name.FormatProps();
            this.Description = snack.Description.FormatProps();
            this.Price = snack.Price;
        }

        public override HashSet<Error> GetErrors()
        {
            return new SnackValidation().CustomValidate(this);
        }

        public override bool IsInvalid()
        {
            return new SnackValidation().CustomValidate(this).Any();
        }
    }
}
