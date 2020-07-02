using Domain.DTO;
using Domain.FluentValidations;
using Domain.FluentValidations.HBSIS.Padawan.Produtos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Entities
{
    public class Order : BaseEntity
    {
        //Propriedades
        public DateTime DateTime { get; protected set; }

        public int UserId { get; protected set; }
        public virtual User User { get; protected set; }

        public virtual ICollection<Order_Snack> Order_Snacks { get; protected set; }

        public int? DeliveryManId { get; protected set; }
        public virtual DeliveryMan DeliveryMan { get; protected set; }

        //Construtores
        public Order()
        {
        }
        public Order(OrderDTO order)
        {
            this.DateTime = DateTime.UtcNow;
            this.UserId = order.UserId;
            this.DeliveryManId = order.DeliveryManId;
        }

        public void AddDeliveryMan(int deliveryManId)
        {
            this.DeliveryManId = deliveryManId;
        }


        public override HashSet<Error> GetErrors()
        {
            return new OrderValidation().CustomValidate(this);
        }

        public override bool IsInvalid()
        {
            return new OrderValidation().CustomValidate(this).Any();
        }
    }
}
