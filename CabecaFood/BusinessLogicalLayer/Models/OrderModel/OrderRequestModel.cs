using System.Collections.Generic;

namespace BusinessLogicalLayer.Models.OrderModel
{
    public class OrderRequestModel
    {
        public int UserId { get; set; }
        public int? DeliveryManId { get; set; }
        public ICollection<int> SnacksId { get; set; } = new List<int>();
    }
}
