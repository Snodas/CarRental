using CarRental.Data.Interfaces;

namespace CarRental.Models
{
    public class Booking : IEntity
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CarId { get; set; }
        public int UserId { get; set; }
        
        // Navigation properties
        public virtual Car Car { get; set; } = null!;
        public virtual BaseUser User { get; set; } = null!;
        
    }        
}
