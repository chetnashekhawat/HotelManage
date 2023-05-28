

using Microsoft.EntityFrameworkCore;

namespace HotelBook.Models
{
    public class HotelBookingDbContext : DbContext
    {

      
        
            public HotelBookingDbContext(DbContextOptions<HotelBookingDbContext> options) : base(options) { }



            public DbSet<Hotel> Hotels { get; set; }
            public DbSet<Rooms> Rooms { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {

                modelBuilder.Entity<Hotel>()
                    .HasMany(h => h.Rooms)
                    .WithOne(r => r.Hotel)
                    .HasForeignKey(r => r.Hid);
            }

     }
}

