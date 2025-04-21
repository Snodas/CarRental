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

        public BookingService(IBooking bookingRepository, ICar carRepository)
        {
            _bookingRepository = bookingRepository;
            _carRepository = carRepository;
        }

        public Task<Booking> CreateBookingAsync(Booking booking)
        {
            throw new NotImplementedException();
        }

        public async Task<Booking> DeleteBookingAsync(int id)
        {
            var booking = await _bookingRepository.GetByIdAsync(id);
        }

        public Task<IEnumerable<Booking>> GetAllBookingsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Booking> GetBookingByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Booking> UpdateBookingAsync(int id, Booking booking)
        {
            throw new NotImplementedException();
        }

        public Task<Booking> ValidateAndCreateBookingAsync(Booking booking)
        {
            throw new NotImplementedException();
        }
    }
}
