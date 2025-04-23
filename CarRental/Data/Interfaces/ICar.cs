using CarRental.Models;
using CarRental.ViewModels;

namespace CarRental.Data.Interfaces
{
    public interface ICar : IRepository<Car>     
    {
        Task<IEnumerable<Car>> GetAllCarsAsync();
    }
}
