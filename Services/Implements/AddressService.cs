using AutoMapper;
using POS_ApiServer.DTOs.Address;
using POS_ApiServer.Models;
using POS_ApiServer.Repositories;

namespace POS_ApiServer.Services.Implements
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public AddressService (IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public async Task<AddressDTO> addAddressAsync(AddressDTO addressDTO)
        {
           var newAddress = await _addressRepository.addAddressAsync(_mapper.Map<Address>(addressDTO));
           return _mapper.Map<AddressDTO>(newAddress);
  
        }

        public Task<bool> updateAddressAsync(AddressDTO address)
        {
            throw new NotImplementedException();
        }
    }
}
