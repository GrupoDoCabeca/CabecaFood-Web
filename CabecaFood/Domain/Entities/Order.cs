using Domain.DTO;
using System;

namespace Domain.Entities
{
    public class Order : BaseEntity
    {
        //Propriedades
        public DateTime DateTime { get; protected set; }

        //Construtores
        public Order()
        {
        }
        public Order(OrderDTO order)
        {
            this.DateTime = order.DateTime;
        }
        //Metodos
    }
}
