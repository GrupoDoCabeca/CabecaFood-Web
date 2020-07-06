using BusinessLogicalLayer.Models.Interface;

namespace BusinessLogicalLayer.Models.OrderModel
{
    public class OrderResponseModel : OrderRequestModel, IResponseModel
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
    }
}
