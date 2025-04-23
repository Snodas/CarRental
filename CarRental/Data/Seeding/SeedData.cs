using CarRental.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using CarRental.Data;
using CarRental.Data.Seeding;

namespace CarRental.Data.Seeding
{
    public class SeedData
    {
        public static async Task SeedAsync(ApplicationDbContext context)
        {
            if (!context.Cars.Any())
            {
                await SeedCars.CarSeeding(context);
            }

            if (!context.BaseUsers.Any())
            {
                await SeedBaseUsers.BaseUserSeeding(context);
            }

            //if (!context.Bookings.Any())
            //{
            //    await SeedBookings.BookingsSeeding(context);
            //}
        }
    }
}
