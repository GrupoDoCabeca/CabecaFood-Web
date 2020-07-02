using BusinessLogicalLayer.Models.DeliveryManMolder;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.IServices
{
    public interface IDeliveryManService
    {
        Task<List<DeliveryManResponseModel>> GetAll();
        Task<DeliveryManResponseModel> GetById(int id);
        Task<DeliveryManResponseModel> Create(DeliveryManRequestModel deliveryManModel);
        Task<DeliveryManResponseModel> Update(int id, DeliveryManRequestModel deliveryManModel);
        Task<DeliveryManResponseModel> Delete(int id);
    }
}