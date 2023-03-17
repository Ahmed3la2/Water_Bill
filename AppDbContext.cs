using Microsoft.EntityFrameworkCore;
using water_bill.Models;
using Water_Bill.Models;

namespace water_bill
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Slice_Values>().HasData(
                new Slice_Values { Slice_Values_Code = "a", Slice_Values_Name = "اقل من 16 ", Slice_Values_Condtion = 15, Slice_Values_Water_Price = 0.10, Slice_Values_Sanitation_Price = 0.05 },
                new Slice_Values { Slice_Values_Code = "b", Slice_Values_Name = " من بين 16 الى 30", Slice_Values_Condtion = 30, Slice_Values_Water_Price = 1.00, Slice_Values_Sanitation_Price = 0.50 },
                new Slice_Values { Slice_Values_Code = "c", Slice_Values_Name = "من بين 31 الى 45", Slice_Values_Condtion = 45, Slice_Values_Water_Price = 3.00, Slice_Values_Sanitation_Price = 1.5 },
                new Slice_Values { Slice_Values_Code = "d", Slice_Values_Name = "من بين 46 الى 60", Slice_Values_Condtion = 60, Slice_Values_Water_Price = 4.00, Slice_Values_Sanitation_Price = 2.00 },
                new Slice_Values { Slice_Values_Code = "e", Slice_Values_Name = "اكثر من 60", Slice_Values_Condtion = 60, Slice_Values_Water_Price = 6.00, Slice_Values_Sanitation_Price = 3.00 }
             );
        }

        public DbSet<Rreal_Estate_Types> real_Estate_Type { get; set; }

        public DbSet<Subscriber_File> subscriber { get; set; }

        public DbSet<Subscription_File> subscription { get; set; }

        public DbSet<Slice_Values> slice_Value { get; set; }

        public DbSet<Invoices> Invoices { get; set; }
    }
}
