using CarRental.Data.Interfaces;
using CarRental.Models;

namespace CarRental.Data.Repositories
{
    public class CarRepository : GenericRepository<Car, ApplicationDbContext>, ICar
    {
        public CarRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
