using BusinessLogicalLayer.CustomsAutoMapper;
using BusinessLogicalLayer.IServices;
using BusinessLogicalLayer.Models.CommentRestaurantModel;
using Domain.Entities;
using Infra.IRepositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Services
{
    public class CommentRestaurantService : BaseService<CommentRestaurant>, ICommentRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly ICommentRestaurantRepository _commentRestaurantRepository;
        private readonly IUserRepository _userRepository;

        public CommentRestaurantService(IRestaurantRepository restaurantRepository, ICommentRestaurantRepository commentRestaurantRepository, IUserRepository userRepository)
        {
            _restaurantRepository = restaurantRepository;
            _commentRestaurantRepository = commentRestaurantRepository;
            _userRepository = userRepository;
        }

        public async Task<CommentRestaurantResponseModel> Create(CommentRestaurantRequestModel commentModel)
        {
            var comment = CommentRestaurantMap.CommentRestaurantRequestToCommentRestaurant(commentModel);

            Validate(comment);

            await _commentRestaurantRepository.Create(comment);
            await _commentRestaurantRepository.Save();

            return CommentRestaurantMap.CommentRestaurantToCommentRestaurantResponse(comment);
        }

        public async Task<CommentRestaurantResponseModel> Delete(int id)
        {
            var comment = await _commentRestaurantRepository.GetById(id);

            if (comment == null)
                AddError("Comentario", "Não encontrado");

            HandleError();

            await _commentRestaurantRepository.Delete(id);
            await _commentRestaurantRepository.Save();

            return CommentRestaurantMap.CommentRestaurantToCommentRestaurantResponse(comment);
        }

        public async Task<List<CommentRestaurantResponseModel>> GetAll()
        {
            var comments = await _commentRestaurantRepository.GetAll();
            return comments.Select(comment => CommentRestaurantMap.CommentRestaurantToCommentRestaurantResponse(comment)).ToList();
        }

        public async Task<CommentRestaurantResponseModel> GetById(int id)
        {
            var comment = await _commentRestaurantRepository.GetById(id);

            if (comment == null)
                AddError("Comentario", "Não encontrado");

            HandleError();

            return CommentRestaurantMap.CommentRestaurantToCommentRestaurantResponse(comment);
        }

        public async Task<ICollection<CommentRestaurantResponseModel>> GetByRestaurantId(int restaurantId)
        {
            var restaurantExist = await _restaurantRepository.GetById(restaurantId);

            if (restaurantExist == null)
                AddError("Restaurante", "Não encontrado");

            var comments = await _commentRestaurantRepository.GetByRestaurantId(restaurantId);
            return comments.Select(comment => CommentRestaurantMap.CommentRestaurantToCommentRestaurantResponse(comment)).ToList();
        }

        public async Task<CommentRestaurantResponseModel> Update(int id, CommentUpdateModel commentModel)
        {
            var commentToUpdate = await _commentRestaurantRepository.GetById(id);

            if (commentToUpdate == null)
                AddError("Comentario", "Não encontrado");

            HandleError();

            commentToUpdate.Update(commentModel.Commentary, commentModel.IsGood);

            HandleError();

            await _commentRestaurantRepository.Update(commentToUpdate);
            await _commentRestaurantRepository.Save();

            return CommentRestaurantMap.CommentRestaurantToCommentRestaurantResponse(commentToUpdate);

        }

        public override void Validate(CommentRestaurant entity)
        {
            if (entity.IsInvalid())
                AddErrors(entity.GetErrors());

            var restaurantExist = _restaurantRepository.GetById(entity.RestaurantId);

            var userExist = _userRepository.GetById(entity.UserId);

            if (userExist.Result == null)
                AddError("Usuario", "Não encontrado");

            if (restaurantExist.Result == null)
                AddError("Restaurante", "Não encontrado");

            HandleError();
        }
    }
}
