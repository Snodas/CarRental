using CarRental.Data.Interfaces;

namespace CarRental.Models
{
    public class Car : IEntity
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int MakeYear { get; set; }
        public string? ImageUrl { get; set; } 
        
        //Nav

        public virtual Booking? Booking { get; set; } 
    }
}
