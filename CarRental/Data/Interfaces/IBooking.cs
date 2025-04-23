using CarRental.Models;

namespace CarRental.Data.Interfaces
{
    public interface IBooking : IRepository<Booking>
    {
        Task<IEnumerable<Booking>> GetAllBookingsAsync();
    }
}
