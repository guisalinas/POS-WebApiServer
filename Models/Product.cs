using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace POS_ApiServer.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string productCode { get; set; }
        public string? description { get; set; }
        [Required]
        public decimal currentPrice { get; set; }
        [Required]
        public int currentStock { get; set; }

        public int supplierId { get; set; }
        public Supplier supplier { get; set; }

        public ICollection<SaleDetail> saleDetails { get; set; }

        public Product() { }

        public Product(string name, string productCode, string? description, decimal currentPrice, int currentStock, int supplierId)
        {
            this.name = name;
            this.productCode = productCode;
            this.description = description;
            this.currentPrice = currentPrice;
            this.currentStock = currentStock;
            this.supplierId = supplierId;
        }
    }
}
