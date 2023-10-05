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

        public int? supplierId { get; set; }
        public virtual Supplier supplier { get; set; }

        public virtual ICollection<SaleDetail> saleDetails { get; set; }

        public Product() { }

        public Product(string name, string productCode, string? description, decimal currentPrice, int currentStock)
        {
            this.name = name;
            this.productCode = productCode;
            this.description = description;
            this.currentPrice = currentPrice;
            this.currentStock = currentStock;
        }
    }
}
