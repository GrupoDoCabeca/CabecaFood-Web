using Domain.DTO;

namespace Domain.Entities
{
    public class Order_Snack
    {
        public int SnackId { get; protected set; }
        public virtual Snack Snack { get; protected set; }

        public int OrderId { get; protected set; }
        public virtual Order Order { get; protected set; }

        public Order_Snack()
        {

        }

        public Order_Snack(Order_SnackDTO order_SnackDTO)
        {
            this.SnackId = order_SnackDTO.SnackId;
            this.OrderId = order_SnackDTO.OrderId;
        }
    }
}
