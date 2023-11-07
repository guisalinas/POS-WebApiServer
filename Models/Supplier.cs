using System.ComponentModel.DataAnnotations;


namespace POS_ApiServer.Models
{
    public class Supplier : Person
    {
        
        public string? web { get; set; }

        [Required]
        public string tradeName { get; set; }

        public ICollection<Product> products { get; set; } = new List<Product>();

        public Supplier() { }

        public Supplier(string name, string surname, string email, string phoneNumber, string web, string tradeName) : base(name, surname, email, phoneNumber)
        {
            this.web = web;
            this.tradeName = tradeName;
        }
    }
}
