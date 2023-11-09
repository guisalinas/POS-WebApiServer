using POS_ApiServer.DTOs.Address;


namespace POS_ApiServer.DTOs.Customer
{
    public class CustomerDTO
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string dni { get; set; }
        public string? email { get; set; }
        public string? phoneNumber { get; set; }
        public ICollection<AddressDTO> addresses { get; set; } = new List<AddressDTO>();
    }
}
