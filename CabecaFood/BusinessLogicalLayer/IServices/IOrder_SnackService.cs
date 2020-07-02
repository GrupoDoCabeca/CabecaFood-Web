using BusinessLogicalLayer.Models.Order_SnackModel;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.IServices
{
    public interface IOrder_SnackService
    {
        Task<Order_SnackResponseModel> Create(Order_SnackRequestModel order_SnackModel);
    }
}