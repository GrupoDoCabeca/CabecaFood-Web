namespace BusinessLogicalLayer.Models.OrderModel
{
    public class OrderRequestModel
    {
        public int UserId { get; protected set; }
        public int? DeliveryManId { get; protected set; }
    }
}
