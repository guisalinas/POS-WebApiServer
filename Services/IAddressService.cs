using POS_ApiServer.DTOs.Address;

namespace POS_ApiServer.Services
{
    public interface IAddressService
    {
        Task<AddressDTO> addAddressAsync(AddressDTO address);
        Task<bool> updateAddressAsync(AddressDTO address);
    }
}
