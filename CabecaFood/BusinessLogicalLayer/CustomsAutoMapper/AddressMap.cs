using BusinessLogicalLayer.Models.AddressModel;
using Domain.Entities;
using Shared;

namespace BusinessLogicalLayer.CustomsAutoMapper
{
    public static class AddressMap
    {
        public static Address AddressRequestToAddress(AddressRequestModel addressModel)
        {
            return Map.ChangeValues<AddressRequestModel, Address>(addressModel);
        }

        public static AddressResponseModel AddressToAddressResponse(Address address)
        {
            return Map.ChangeValues<Address, AddressResponseModel>(address);
        }
    }
}
