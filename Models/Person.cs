using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace POS_ApiServer.Models
{
        public class Person
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int id { get; set; }
            [Required]
            public string name { get; set; }
            [Required]
            public string surname { get; set; }
            [Required]
            public string dni { get; set; }
            public string? email { get; set; }

            public string? phoneNumber { get; set; }
            public ICollection<Address> addresses { get; set; }
            public Person() { }

            public Person(string name, string surname, string email, string phoneNumber, ICollection<Address> addresses)
            {
                this.name = name;
                this.surname = surname;
                this.email = email;
                this.phoneNumber = phoneNumber;
                this.addresses = addresses;
            }
        }
}
