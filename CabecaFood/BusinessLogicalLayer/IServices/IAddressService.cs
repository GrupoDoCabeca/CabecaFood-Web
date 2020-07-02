using BusinessLogicalLayer.Models.AddressModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.IServices
{
    public interface IAddressService
    {
        Task<List<AddressResponseModel>> GetAll();
        Task<AddressResponseModel> GetById(int id);
        Task<AddressResponseModel> Create(AddressRequestModel addressModel);
        Task<AddressResponseModel> Update(int id, AddressRequestModel addressModel);
        Task<AddressResponseModel> GetByUserId(int userId);
    }
}