using Domain.DTO;
using Domain.FluentValidations;
using Domain.FluentValidations.HBSIS.Padawan.Produtos.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Entities
{
    public class DeliveryMan : BaseEntity
    {
        //Propriedades
        public string Name { get; protected set; }
        public double Salary { get; protected set; }
        public string PIS { get; protected set; }

        public ICollection<Order> Orders { get; protected set; }

        //Construtores
        public DeliveryMan()
        {

        }

        public DeliveryMan(DeliveryManDTO deliveryMan)
        {
            this.Name = deliveryMan.Name.FormatProps();
            this.PIS = deliveryMan.PIS.FormatProps();
            this.Salary = deliveryMan.Salary;
        }


        //Metodos
        public void Update(DeliveryManDTO deliveryMan)
        {
            this.Name = deliveryMan.Name.FormatProps();
            this.PIS = deliveryMan.PIS.FormatProps();
            this.Salary = deliveryMan.Salary;
        }

        public override HashSet<Error> GetErrors()
        {
            return new DeliveryManValidation().CustomValidate(this);
        }

        public override bool IsInvalid()
        {
            return new DeliveryManValidation().CustomValidate(this).Any();
        }
    }
}
