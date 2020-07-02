using BusinessLogicalLayer.Models.OrderModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.IServices
{
    public interface IOrderService
    {
        Task<List<OrderResponseModel>> GetAll();
        Task<OrderResponseModel> GetById(int id);
        Task<OrderResponseModel> Create(OrderRequestModel orderModel);
        Task<OrderResponseModel> AddDelivery(int orderId, int deliveryId);
        Task<OrderResponseModel> Delete(int id);
    }
}