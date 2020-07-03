using BusinessLogicalLayer.Models.OrderModel;
using Domain.Entities;
using Shared;
using System.Linq;

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
            var orderResponse = Map.ChangeValues<Order, OrderResponseModel>(order);
            orderResponse.Snacks = order.Snacks.Select(x => SnackMap.SnackToSnackResponseModel(x)).ToList();
            return orderResponse;
        }
    }
}
