using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace POS_ApiServer.Models
{
    public class SaleDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        public int quantity { get; set; }
        [Required]
        public decimal unitPrice { get; set; }

        public int saleId { get; set; }
        public Sale sale { get; set; }

        public int productId { get; set; }
        public Product product { get; set; }

        public SaleDetail() { }

        public SaleDetail(int quantity, decimal unitPrice)
        {
            this.quantity = quantity;
            this.unitPrice = unitPrice;
        }
    }
}
