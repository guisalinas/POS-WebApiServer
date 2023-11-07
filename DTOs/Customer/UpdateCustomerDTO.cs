namespace POS_ApiServer.DTOs.Customer
{
    public class UpdateCustomerDTO
    {
        public long id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string? email { get; set; }
        public string? phoneNumber { get; set; }
    }
}
