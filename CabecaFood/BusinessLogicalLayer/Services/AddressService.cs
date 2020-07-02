using BusinessLogicalLayer.CustomsAutoMapper;
using BusinessLogicalLayer.IServices;
using BusinessLogicalLayer.Models.AddressModel;
using Domain.DTO;
using Domain.Entities;
using Infra.IRepositories;
using Infra.Repositories.IRepositories;
using Shared;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Services
{
    public class AddressService : BaseService<Address>, IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IUserRepository _userRepository;

        public AddressService(IAddressRepository addressRepository, IUserRepository userRepository)
        {
            _addressRepository = addressRepository;
            _userRepository = userRepository;
        }

        public async Task<AddressResponseModel> Create(AddressRequestModel addressModel)
        {
            var address = AddressMap.AddressRequestToAddress(addressModel);

            Validate(address);

            await _addressRepository.Create(address);
            await _addressRepository.Save();

            return AddressMap.AddressToAddressResponse(address);
        }

        public async Task<List<AddressResponseModel>> GetAll()
        {
            var adresses = await _addressRepository.GetAll();
            return adresses.Select(x => AddressMap.AddressToAddressResponse(x)).ToList();
        }

        public async Task<AddressResponseModel> GetById(int id)
        {
            ValidateId(id);

            HandleError();

            var address = await _addressRepository.GetById(id);

            if (address == null)
                AddError("Endereco", "Não encontrado");

            HandleError();

            return AddressMap.AddressToAddressResponse(address);
        }

        public async Task<AddressResponseModel> GetByUserId(int userId)
        {
            ValidateId(userId);

            HandleError();

            var address = await _addressRepository.GetByUserId(userId);

            if (address == null)
                AddError("Endereco", "Não encontrado");

            HandleError();

            return AddressMap.AddressToAddressResponse(address);
        }

        public async Task<AddressResponseModel> Update(int id, AddressRequestModel addressModel)
        {
            var address = AddressMap.AddressRequestToAddress(addressModel);

            ValidateId(id);
            Validate(address);

            var addressToUpdate = await _addressRepository.GetById(id);

            if (address == null)
                AddError("Endereco", "Não encontrado");

            var addressDTO = Map.ChangeValues<Address, AddressDTO>(address);
            addressToUpdate.Update(addressDTO);

            await _addressRepository.Update(addressToUpdate);
            await _addressRepository.Save();

            return AddressMap.AddressToAddressResponse(addressToUpdate);
        }

        public override void Validate(Address entity)
        {
            if (entity.IsInvalid())
                AddErrors(entity.GetErrors());

            HandleError();

            var user = _userRepository.GetById(entity.UserId);

            if (user == null)
                AddError("Usuario", "Não existe");

            HandleError();
        }
    }
}
