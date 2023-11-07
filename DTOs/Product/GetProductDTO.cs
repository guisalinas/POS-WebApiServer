namespace POS_ApiServer.DTOs.Product
{
    public class GetProductDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public string productCode { get; set; }
        public string description { get; set; }
        public decimal currentPrice { get; set; }
        public int currentStock { get; set; }
        public int? supplierId { get; set; }
        public bool isDeleted { get; set; }
    }
}
