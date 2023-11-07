namespace POS_ApiServer.DTOs.Product
{
    public class ProductDTO
    {
        public string name { get; set; }
        public string productCode { get; set; }
        public string description { get; set; }
        public decimal currentPrice { get; set; }
        public int currentStock { get; set; }
    }
}
