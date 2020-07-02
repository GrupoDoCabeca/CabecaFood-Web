using BusinessLogicalLayer.Models.OrderModel;
using Domain.Entities;
using Shared;

namespace BusinessLogicalLayer.CustomsAutoMapper
{
    public static class OrderMap
    {
        public static Order OrderRequestToOrder(OrderRequestModel orderRequestModel)
        {
            return Map.ChangeValues<OrderRequestModel, Order>(orderRequestModel);
        }

        public static OrderResponseModel OrderToOrderResponse(Order order)
        {
            return Map.ChangeValues<Order, OrderResponseModel>(order);
        }
    }
}
