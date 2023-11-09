using POS_ApiServer.Data;
using POS_ApiServer.Models;

namespace POS_ApiServer.Repositories.Implements
{
    public class AddressRepository : IAddressRepository
    {
        private readonly DBContext _dbContext;

        public AddressRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Address> addAddressAsync(Address address)
        {
            try
            {
                _dbContext.Address.Add(address);
                await _dbContext.SaveChangesAsync();
                return address;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> updateAddressAsync(Address address)
        {
            try
            {
                _dbContext.Address.Update(address);
                await _dbContext.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
