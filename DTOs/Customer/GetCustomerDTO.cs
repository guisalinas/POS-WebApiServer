using POS_ApiServer.DTOs.Address;
using POS_ApiServer.Models;

namespace POS_ApiServer.DTOs.Customer
{
    public class GetCustomerDTO
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string dni { get; set; }
        public string? email { get; set; }
        public string? phoneNumber { get; set; }
        public bool isDeleted { get; set; } = false;
        public TieredType tieredType;
        public ICollection<AddressDTO> addresses { get; set; } = new List<AddressDTO>();
    }
}
