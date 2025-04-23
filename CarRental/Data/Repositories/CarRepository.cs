using CarRental.Data.Interfaces;
using CarRental.Data;
using CarRental.Models;
using Microsoft.EntityFrameworkCore;
using CarRental.ViewModels;

namespace CarRental.Data.Repositories
{
    public class CarRepository : GenericRepository<Car, ApplicationDbContext>, ICar
    {
        private readonly ApplicationDbContext dbContext;

        public CarRepository(ApplicationDbContext context) : base(context)
        {
            dbContext = context;
        }

        public async Task<IEnumerable<Car>> GetAllCarsAsync()
        {
            return await dbContext.Cars.ToListAsync();
        }
    }
}
