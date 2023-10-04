using System.ComponentModel.DataAnnotations.Schema;

namespace POS_ApiServer.Models
{
    [Table("Customers")]
    public class Customer : Person
    {
        public ICollection<Sale> sales { get; set; }
        public TieredType tieredType { get; set; }

        public Customer() { }
        public Customer(string name, string surname, string email, string phoneNumber, ICollection<Address> addresses, ICollection<Sale> sales, TieredType tieredType) : base(name, surname, email, phoneNumber, addresses)
        {
            this.sales = sales;
            this.tieredType = tieredType;

        }
    }
}
