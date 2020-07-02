using BusinessLogicalLayer.Models.UserModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.IServices
{
    public interface IUserService
    {
        Task<List<UserResponseModel>> GetAll();
        Task<UserResponseModel> GetById(int id);
        Task<UserResponseModel> Create(UserRequestModel userModel);
        Task<UserResponseModel> Update(int id, UserRequestModel userModel);
        Task<UserResponseModel> Delete(int id);
    }
}