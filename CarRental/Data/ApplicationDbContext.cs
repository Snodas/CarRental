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
            // Configure the relationships and keys here if needed
            //modelBuilder.Entity<Car>()
            //    .HasKey(c => c.Id);
            //modelBuilder.Entity<Booking>()
            //    .HasKey(b => b.Id);
            //modelBuilder.Entity<BaseUser>()
            //    .HasKey(u => u.Id);
        }
    }  
}
