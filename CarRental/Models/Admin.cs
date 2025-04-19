using CarRental.Data;

namespace CarRental.Models
{
    public class Admin : BaseUser
    {
        public override Role Role => Role.Admin;
    }
}
