using BusinessLogicalLayer.Models.OrderModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.IServices
{
    public interface IOrderService
    {
        Task<List<OrderResponseModel>> GetByRestaurantId(int restaurantId);
        Task<OrderResponseModel> GetById(int restaurantId, int id);
        Task<OrderResponseModel> Create(int restaurantId, OrderRequestModel orderModel);
        Task<OrderResponseModel> AddDelivery(int orderId, int deliveryId);
        Task<OrderResponseModel> Delete(int restaurantId, int id);
    }
}