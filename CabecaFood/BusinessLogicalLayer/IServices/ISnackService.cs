using BusinessLogicalLayer.Models.SnackModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.IServices
{
    public interface ISnackService
    {
        Task<List<SnackResponseModel>> GetAll();
        Task<SnackResponseModel> GetById(int id);
        Task<SnackResponseModel> Create(SnackRequestModel snackModel);
        Task<SnackResponseModel> Update(int id, SnackRequestModel snackModel);
        Task<SnackResponseModel> Delete(int id);
    }
}