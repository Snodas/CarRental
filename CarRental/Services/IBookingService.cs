using CarRental.Models;

namespace CarRental.Services
{
    public interface IBookingService
    {
        Task<Booking> GetBookingByIdAsync(int id);
        Task<IEnumerable<Booking>> GetAllBookingsAsync();

        Task<bool> ValidateBooking(int carId, DateTime startDate, DateTime endDate);
    }
}
