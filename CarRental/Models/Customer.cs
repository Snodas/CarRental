using CarRental.Data;

namespace CarRental.Models
{
    public class Customer : BaseUser
    {
        public override Role Role => Role.Customer;
    }
}
