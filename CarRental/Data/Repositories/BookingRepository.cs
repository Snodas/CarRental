using CarRental.Models;
using CarRental.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Data.Repositories
{
    public class IBookingRepository : GenericRepository<Booking, ApplicationDbContext>, IBooking
    {
        public IBookingRepository(ApplicationDbContext context) : base(context)
        {

        }
        
        public async Task<IEnumerable<Booking>> GetAllBookingsAsync()
        {
            return await dbContext.Bookings.ToListAsync();
        }
    }
}
