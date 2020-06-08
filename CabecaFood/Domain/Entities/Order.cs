using Domain.DTO;
using Domain.FluentValidations.HBSIS.Padawan.Produtos.Domain;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Order : BaseEntity
    {
        //Propriedades
        public DateTime DateTime { get; protected set; }

        public int UserId { get; protected set; }
        public virtual User User { get; protected set; }

        public virtual ICollection<Order_Snack> Orders_Snacks { get; protected set; }

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

        public override HashSet<Error> GetErrors()
        {
            throw new NotImplementedException();
        }

        public override bool IsInvalid()
        {
            throw new NotImplementedException();
        }
    }
}
