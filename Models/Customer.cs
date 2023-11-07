
namespace POS_ApiServer.Models
{
    public class Customer : Person
    {
        public ICollection<Sale> sales { get; set; } = new List<Sale>();
        public TieredType tieredType { get; set; } = TieredType.CLASSIC;

        public Customer() { }
        public Customer(string name, string surname, string email, string phoneNumber) : base(name, surname, email, phoneNumber)
        {
        }
    }
}
