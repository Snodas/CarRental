using CarRental.Data;
using CarRental.Data.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRental.Models
{
    public class BaseUser : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public virtual Role Role { get; set; } = Role.None;

        public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    }
}
