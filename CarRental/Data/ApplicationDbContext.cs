using CarRental.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<BaseUser> BaseUsers { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // BaseUser
            modelBuilder.Entity<BaseUser>()
                .HasKey(c => c.Id);
                //.HasDiscriminator<string>("Role")
                //.HasValue<Admin>("Admin")
                //.HasValue<Customer>("Customer");

            // Car
            modelBuilder.Entity <Car>()
                .HasKey(c => c.Id);





            // Booking
            modelBuilder.Entity<Booking>()
                .HasKey(c => c.Id);




        }
    }  
}
