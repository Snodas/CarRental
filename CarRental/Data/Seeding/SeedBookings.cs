using CarRental.Models;

namespace CarRental.Data.Seeding
{
    public class SeedBookings
    {
        public static async Task BookingsSeeding(ApplicationDbContext context)
        {
            context.Bookings.Add(new Booking
            {

            });

            await context.SaveChangesAsync();
        }
    }
}
