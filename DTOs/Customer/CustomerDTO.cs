using POS_ApiServer.Models;

namespace POS_ApiServer.DTOs.Customer
{
    public class CustomerDTO
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string dni { get; set; }
        public string? email { get; set; }
        public string? phoneNumber { get; set; }
    }
}
