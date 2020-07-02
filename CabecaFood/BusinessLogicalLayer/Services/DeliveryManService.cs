using BusinessLogicalLayer.CustomsAutoMapper;
using BusinessLogicalLayer.IServices;
using BusinessLogicalLayer.Models.DeliveryManMolder;
using Domain.DTO;
using Domain.Entities;
using Infra.IRepositories;
using Shared;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Services
{
    public class DeliveryManService : BaseService<DeliveryMan>, IDeliveryManService
    {
        private readonly IDeliveryManRepository _deliveryManRepository;

        public DeliveryManService(IDeliveryManRepository deliveryManRepository)
        {
            _deliveryManRepository = deliveryManRepository;
        }

        public async Task<DeliveryManResponseModel> Create(DeliveryManRequestModel deliveryManModel)
        {
            var deliveryMan = DeliveryManMap.DeliveryManRequestModelToDeliveryMan(deliveryManModel);

            Validate(deliveryMan);

            await _deliveryManRepository.Create(deliveryMan);
            await _deliveryManRepository.Save();

            return DeliveryManMap.DeliveryManToDeliveryManResponse(deliveryMan);
        }

        public async Task<DeliveryManResponseModel> Delete(int id)
        {
            ValidateId(id);

            HandleError();

            var deliveryMan = await _deliveryManRepository.GetById(id);

            if (deliveryMan == null)
                AddError("Entregador", "Não encontrado");

            await _deliveryManRepository.Delete(id);
            await _deliveryManRepository.Save();

            return DeliveryManMap.DeliveryManToDeliveryManResponse(deliveryMan);
        }

        public async Task<List<DeliveryManResponseModel>> GetAll()
        {
            var deliveriesMans = await _deliveryManRepository.GetAll();
            return deliveriesMans.Select(x => DeliveryManMap.DeliveryManToDeliveryManResponse(x)).ToList();
        }

        public async Task<DeliveryManResponseModel> GetById(int id)
        {
            ValidateId(id);

            HandleError();

            var deliveryMan = await _deliveryManRepository.GetById(id);

            if (deliveryMan == null)
                AddError("Entregador", "Não encontrado");

            HandleError();

            return DeliveryManMap.DeliveryManToDeliveryManResponse(deliveryMan);
        }

        public async Task<DeliveryManResponseModel> Update(int id, DeliveryManRequestModel deliveryManModel)
        {
            var deliveryMan = DeliveryManMap.DeliveryManRequestModelToDeliveryMan(deliveryManModel);

            ValidateId(id);
            Validate(deliveryMan);

            var deliveryManToUpdate = await _deliveryManRepository.GetById(id);

            if (deliveryManToUpdate == null)
                AddError("Endereco", "Não encontrado");

            var deliveryManDTO = Map.ChangeValues<DeliveryMan, DeliveryManDTO>(deliveryMan);
            deliveryManToUpdate.Update(deliveryManDTO);

            await _deliveryManRepository.Update(deliveryManToUpdate);
            await _deliveryManRepository.Save();

            return DeliveryManMap.DeliveryManToDeliveryManResponse(deliveryManToUpdate);
        }

        public override void Validate(DeliveryMan entity)
        {
            if (entity.IsInvalid())
                AddErrors(entity.GetErrors());

            HandleError();
        }
    }
}
