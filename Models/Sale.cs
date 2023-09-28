using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace POS_ApiServer.Models
{
    public class Sale
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        public DateTime dateTime { get; set; }
        [Required]
        public decimal amount { get; set; }
        [Required]
        public int ticketNumber { get; set; }
        public decimal? discount { get; set; }

        public ICollection<SaleDetail> saleDetails { get; set; }

        public int customerId { get; set; }
        public Customer customer { get; set; }


        public Sale() { }
        public Sale(DateTime dateTime, decimal amount, int ticketNumber, decimal discount)
        {
            this.dateTime = dateTime;
            this.amount = amount;
            this.ticketNumber = ticketNumber;
            this.discount = discount;
        }
    }
}
