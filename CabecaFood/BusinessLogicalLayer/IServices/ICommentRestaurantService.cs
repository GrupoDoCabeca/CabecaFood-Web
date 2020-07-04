using BusinessLogicalLayer.Models.CommentRestaurantModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.IServices
{
    public interface ICommentRestaurantService
    {
        Task<List<CommentRestaurantResponseModel>> GetAll();
        Task<CommentRestaurantResponseModel> GetById(int id);
        Task<CommentRestaurantResponseModel> Create(CommentRestaurantRequestModel commentModel);
        Task<CommentRestaurantResponseModel> Update(int id, CommentUpdateModel commentModel);
        Task<CommentRestaurantResponseModel> Delete(int id);
        Task<ICollection<CommentRestaurantResponseModel>> GetByRestaurantId(int restaurantId);
    }
}
