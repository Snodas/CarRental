using CarRental.Data;
using CarRental.Data.Interfaces;
using CarRental.Data.Repositories;
using CarRental.Models;

namespace CarRental.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBooking _bookingRepository;
        private readonly ICar _carRepository;
        private readonly ApplicationDbContext applicationDbContext;

        public BookingService(IBooking bookingRepository, ICar carRepository, ApplicationDbContext applicationDbContext)
        {
            _bookingRepository = bookingRepository;
            _carRepository = carRepository;
            this.applicationDbContext = applicationDbContext;
        }

        public Task<IEnumerable<Booking>> GetAllBookingsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Booking> GetBookingByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ValidateBooking(int carId, DateTime startDate, DateTime endDate)
        {
            if (endDate <= startDate)
            {
                return false;
            }

            var overlappingBookings = await _bookingRepository.AllAsync();


            //Check 1
            var c1 = overlappingBookings.Any(b =>
                b.CarId == carId &&
                (startDate >= b.StartDate && startDate <= b.EndDate));

            //Check 2
            var c2 = overlappingBookings.Any(b =>
                b.CarId == carId &&
                (endDate >= b.StartDate && endDate <= b.EndDate));

            return true;
        }
    }
}
