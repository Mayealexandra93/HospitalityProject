//using Microsoft.EntityFrameworkCore;

//namespace HospitalityProject.Models
//{
//    public class HotelContext : DbContext
//    {
//        public DbSet<Room> Room { get; set; }
//        public DbSet<Booking> Booking { get; set; }

//        public HotelContext(DbContextOptions<HotelContext> options) : base(options) { }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            base.OnConfiguring(optionsBuilder); // keeps EF's default behavior

//            if (!optionsBuilder.IsConfigured) 
//            {
//                //warning To protect potentially ensitive information in your connection string
//                optionsBuilder.UseSqlServer("Server=vaio; Database=Hotel; Trusted_Connector=True;");
//            }
//        }
//    }
//}
