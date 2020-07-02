using BusinessLogicalLayer.Models.Interface;
using Domain.Entities;

namespace BusinessLogicalLayer.Models.UserModel
{
    public class UserResponseModel : UserRequestModel, IResponseModel
    {
        public int Id { get; set; }
        public Address address { get; set; }
    }
}
