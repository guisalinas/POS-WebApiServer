using POS_ApiServer.Models;

namespace POS_ApiServer.Repositories
{
    public interface IAddressRepository
    {
        Task<Address> addAddressAsync (Address address);
        Task<bool> updateAddressAsync (Address address);
    }
}
