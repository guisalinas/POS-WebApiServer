using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS_ApiServer.Models
{
    [Table("Suppliers")]
    public class Supplier : Person
    {
        
        public string? web { get; set; }

        [Required]
        public string tradeName { get; set; }

        public ICollection<Product> products { get; set; }

        public Supplier() { }

        public Supplier(string name, string surname, string email, string phoneNumber, ICollection<Address> addresses, string web) : base(name, surname, email, phoneNumber, addresses)
        {
            this.web = web;
        }
    }
}
