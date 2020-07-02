using BusinessLogicalLayer.CustomsAutoMapper;
using BusinessLogicalLayer.IServices;
using BusinessLogicalLayer.Models.SnackModel;
using Domain.DTO;
using Domain.Entities;
using Infra.IRepositories;
using Shared;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Services
{
    public class SnackService : BaseService<Snack>, ISnackService
    {

        private readonly ISnackRepository _snackRepository;

        public SnackService(ISnackRepository snackRepository)
        {
            _snackRepository = snackRepository;
        }

        public async Task<SnackResponseModel> Create(SnackRequestModel snackModel)
        {
            var snack = SnackMap.SnackRequestToSnack(snackModel);

            Validate(snack);

            await _snackRepository.Create(snack);
            await _snackRepository.Save();


            return SnackMap.SnackToSnackResponseModel(snack);
        }

        public async Task<SnackResponseModel> Delete(int id)
        {
            ValidateId(id);

            HandleError();

            var snack = await _snackRepository.GetById(id);

            if (snack == null)
                AddError("Lanche", "Não encontrado");

            HandleError();

            await _snackRepository.Delete(id);
            await _snackRepository.Save();

            return SnackMap.SnackToSnackResponseModel(snack);
        }

        public async Task<List<SnackResponseModel>> GetAll()
        {
            var snacks = await _snackRepository.GetAll();
            return snacks.Select(x => SnackMap.SnackToSnackResponseModel(x)).ToList();
        }

        public async Task<SnackResponseModel> GetById(int id)
        {
            ValidateId(id);

            HandleError();

            var snack = await _snackRepository.GetById(id);

            if (snack == null)
                AddError("Lanche", "Não encontrado");

            HandleError();

            return SnackMap.SnackToSnackResponseModel(snack);
        }

        public async Task<SnackResponseModel> Update(int id, SnackRequestModel snackModel)
        {
            var snack = SnackMap.SnackRequestToSnack(snackModel);

            Validate(snack);
            ValidateId(id);

            HandleError();

            var snackToUpdate = await _snackRepository.GetById(id);

            if (snackToUpdate == null)
                AddError("Lanche", "Não encontrado");

            HandleError();

            var snackDTO = Map.ChangeValues<Snack, SnackDTO>(snack);
            snackToUpdate.Update(snackDTO);

            await _snackRepository.Update(snackToUpdate);
            await _snackRepository.Save();

            return SnackMap.SnackToSnackResponseModel(snackToUpdate);
        }

        public override void Validate(Snack entity)
        {
            if (entity.IsInvalid())
                AddErrors(entity.GetErrors());

            HandleError();
        }
    }
}
