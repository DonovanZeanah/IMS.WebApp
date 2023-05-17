using IMS.CoreBusiness.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace IMS.Plugins.SQLite.Data
{
    public class IMSSQLiteDbContext : DbContext
    {
        //parameterless constructor should call the base constructor with the proper DbContextOptions
        public IMSSQLiteDbContext() : base(GetOptions())
        {
            //Database.EnsureCreated();
        }
        //allows context class to accept the configuration passed to it from program.cs
        public IMSSQLiteDbContext(DbContextOptions<IMSSQLiteDbContext> options)
        : base(options)
        {
        }
        private static DbContextOptions GetOptions()
        {
            return new DbContextOptionsBuilder<IMSSQLiteDbContext>().UseSqlite("Data Source=../IMS.WebApp/IMS2.db").Options;

           
        }

        // Add your DbSets for your entities here.
   
        public DbSet<Source> Sources { get; set; }
        public DbSet<InventorySource> InventorySources { get; set; }


        public DbSet<Inventory> Inventories { get; set; } //=> Set<Inventory>();
        public DbSet<LocationSource> LocationSources { get; set; }
        public DbSet<StoreSource> StoreSources { get; set; }
        public DbSet<ContactSource> ContactSources { get; set; }
        public DbSet<SelfObtainedSource> SelfObtainedSources { get; set; }
        public DbSet<Accessory> Accessories { get; set; }

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accessory>()
    .HasKey(a => a.Id);




            modelBuilder.Entity<InventorySource>()
        .HasKey(isrc => new { isrc.InventoryId, isrc.SourceId });

            //modelBuilder.Entity<InventorySource>()
                
            //    .HasForeignKey(isrc => isrc.InventoryId);

            //modelBuilder.Entity<InventorySource>()
            //    .HasOne(isrc => isrc.Source)
            //    .WithMany(src => src.InventorySources)
            //    .HasForeignKey(isrc => isrc.SourceId);

            // Seed data for Source derived classes
            modelBuilder.Entity<LocationSource>().HasData(
                new LocationSource { Id = 1, Name = "Location 1", Address = "123 Main St" },
                new LocationSource { Id = 2, Name = "Location 2", Address = "456 Oak St" }
            );

            modelBuilder.Entity<StoreSource>().HasData(
                new StoreSource { Id = 3, Name = "Store 1", StoreName = "Best Mart" },
                new StoreSource { Id = 4, Name = "Store 2", StoreName = "Super Store" }
            );

            modelBuilder.Entity<ContactSource>().HasData(
                new ContactSource { Id = 5, Name = "Contact 1", ContactName = "John Doe", PhoneNumber = "555-1234" },
                new ContactSource { Id = 6, Name = "Contact 2", ContactName = "Jane Smith", PhoneNumber = "555-5678" }
            );

            modelBuilder.Entity<SelfObtainedSource>().HasData(
                new SelfObtainedSource { Id = 7, Name = "Self Obtained 1", Process = "Manual" },
                new SelfObtainedSource { Id = 8, Name = "Self Obtained 2", Process = "Automated" }
            );

            // Seed data for Inventory
            modelBuilder.Entity<Inventory>().HasData(
                new Inventory() { Id = 25, InventoryName = "Steering Wheel", Quantity = 10, Price = 30 }, //SourceId = 1, DiscriminatorId = 1 },
                new Inventory() { Id = 26, InventoryName = "Driver Seat", Quantity = 100, Price = 20  }, //SourceId = 1, DiscriminatorId = 1 },
                new Inventory() { Id = 27, InventoryName = "Battery Bank", Quantity = 100, Price = 12  }, //SourceId = 2, DiscriminatorId = 1 },
                new Inventory() { Id = 28, InventoryName = "Drive Motor", Quantity = 100, Price = 1  } //, SourceId = 2, DiscriminatorId = 1 }

            );

            base.OnModelCreating(modelBuilder);
            SaveChangesAsync();

            // Configure other models as needed
        }

    }

    public class IMSSQLiteDbContextFactory : IDesignTimeDbContextFactory<IMSSQLiteDbContext>
    {
        public IMSSQLiteDbContext CreateDbContext(string[] args)
        {
            return new IMSSQLiteDbContext();
        }
    }
}

