using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace POS_ApiServer.Models
{
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int? zipCode { get; set; }
        [Required]
        public string street { get; set; }
        [Required]
        public string streetNumber { get; set; }
        [Required]
        public string city { get; set; }

        public int PersonId { get; set; }
        public Person person { get; set; }

        public Address() { }

        public Address(int zipCode, string street, string streetNumber, string city)
        {
            this.zipCode = zipCode;
            this.street = street;
            this.streetNumber = streetNumber;
            this.city = city;

        }
    }
}
