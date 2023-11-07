using POS_ApiServer.Models;

namespace POS_ApiServer.DTOs.Product
{
    public class UpdateProductDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public decimal currentPrice { get; set; }
        public int currentStock { get; set; }
        public long? supplierId { get; set; }
    }
}
