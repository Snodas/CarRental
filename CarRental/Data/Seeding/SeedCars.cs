using CarRental.Models;

namespace CarRental.Data.Seeding
{
    public class SeedCars
    {
        public static async Task CarSeeding(ApplicationDbContext context)
        {
            context.Cars.Add(new Car
            {
                Brand = "Volvo",
                Model = "V90",
                MakeYear = 2022,
            });
        }
    }
}
