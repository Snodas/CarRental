using CarRental.Data.Interfaces;
using CarRental.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Data.Repositories
{
    public class CarRepository : GenericRepository<Car, ApplicationDbContext>, ICar
    {
        public CarRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Car>> GetAllCarsAsync()
        {
            return await dbContext.Cars.ToListAsync();
        }
    }
}
