using CarRental.Models;
using CarRental.Data.Interfaces;

namespace CarRental.Data.Repositories
{
    public class BookingRepository : GenericRepository<Booking, ApplicationDbContext>, IBooking
    {
        public BookingRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
