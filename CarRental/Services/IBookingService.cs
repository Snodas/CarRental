using CarRental.Models;

namespace CarRental.Services
{
    public interface IBookingService
    {
        Task<Booking> GetBookingByIdAsync(int id);
        Task<IEnumerable<Booking>> GetAllBookingsAsync();

        Task<Booking> ValidateAndCreateBookingAsync(Booking booking);
        Task<Booking> CreateBookingAsync(Booking booking);
        Task<Booking> UpdateBookingAsync(int id, Booking booking);
        Task<Booking> DeleteBookingAsync(int id);
    }
}
