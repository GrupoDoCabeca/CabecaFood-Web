using BusinessLogicalLayer.Models.Order_SnackModel;
using Domain.Entities;
using Shared;

namespace BusinessLogicalLayer.CustomsAutoMapper
{
    public static class Order_SnackMap
    {
        public static Order_Snack Order_SnackRequestToOrder_Snack(Order_SnackRequestModel order_SnackRequestModel)
        {
            return Map.ChangeValues<Order_SnackRequestModel, Order_Snack>(order_SnackRequestModel);
        }

        public static Order_SnackResponseModel Order_SnackToOrder_SnackResponse(Order_Snack order_Snack)
        {
            return Map.ChangeValues<Order_Snack, Order_SnackResponseModel>(order_Snack);
        }
    }
}
