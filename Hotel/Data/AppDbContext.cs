using Hotel.Models;
using Hotel.Models.InterfaceModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {


        }

        public DbSet<Main> Mains { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<NumberInfo> NumberInfos { get; set; }
        public DbSet<SliderImage> SliderImages { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Hotell> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomsFeatures> RoomsFeatures { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Rezervation> Rezervations { get; set; }

    }
}
