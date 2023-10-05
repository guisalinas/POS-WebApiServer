namespace POS_ApiServer.DTOs.Product
{
    public class addProductDTO
    {
        public string name { get; set; }
        public string productCode { get; set; }
        public string description { get; set; }
        public decimal currentPrice { get; set; }
        public int currentStock { get; set; }
    }
}
