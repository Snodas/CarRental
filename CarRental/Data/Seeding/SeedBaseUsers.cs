using CarRental.Models;

namespace CarRental.Data.Seeding
{
    public class SeedBaseUsers
    {
        public static async Task BaseUserSeeding(ApplicationDbContext context)
        {
            context.BaseUsers.Add(new Customer
            {
                FirstName = "Test",
                LastName = "Testsson",
                Email = "test@gmail.com",
                Password = "1"
            });

            await context.SaveChangesAsync();
        }



    }
}
