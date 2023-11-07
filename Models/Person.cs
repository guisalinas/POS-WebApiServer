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
            public string surname { get; set; }
            public string dni { get; set; }
            public string? email { get; set; }
            public string? phoneNumber { get; set; }
            public bool isDeleted { get; set; } = false;
            public ICollection<Address> addresses { get; set; } = new List<Address>();
            public Person() { }

            public Person(string name, string surname, string email, string phoneNumber)
            {
                this.name = name;
                this.surname = surname;
                this.email = email;
                this.phoneNumber = phoneNumber;
            }

            public void AddAddress(Address address)
            {
                addresses.Add(address);
            }
        }
}
