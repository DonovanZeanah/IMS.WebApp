using IMS.CoreBusiness.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace IMS.Plugins.SQLite
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
            return new DbContextOptionsBuilder<IMSSQLiteDbContext>().UseSqlite("Data Source=IMS.db").Options;
            //var optionsBuilder = new DbContextOptionsBuilder<IMSSQLiteDbContext>();
            //optionsBuilder.UseSqlite("Data Source=IMS.db");
            //return optionsBuilder.Options;
        }

        // Add your DbSets for your entities here.
        // For example:
        // public DbSet<MyEntity> MyEntities { get; set; }
        public DbSet<Source> Sources { get; set; }

        public DbSet<Inventory> Inventories { get; set; } //=> Set<Inventory>();
        public DbSet<LocationSource> LocationSources { get; set; }
        public DbSet<StoreSource> StoreSources { get; set; }
        public DbSet<ContactSource> ContactSources { get; set; }
        public DbSet<SelfObtainedSource> SelfObtainedSources { get; set; }
        public DbSet<Accessory> Accessories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //seedd setup
            modelBuilder.Entity<Accessory>().HasKey(a => a.Name);
            modelBuilder.Entity<Accessory>().Property(a => a.Type).IsRequired();
            modelBuilder.Entity<Accessory>().Property(a => a.Version).IsRequired(); 


            modelBuilder.Entity<LocationSource>().HasBaseType<Source>();
            modelBuilder.Entity<StoreSource>().HasBaseType<Source>();
            modelBuilder.Entity<ContactSource>().HasBaseType<Source>();
            modelBuilder.Entity<SelfObtainedSource>().HasBaseType<Source>();


            modelBuilder.Entity<Inventory>()
               .HasOne(i => i.Source)
               .WithMany(s => s.Inventories) // Replace this with the appropriate collection navigation property name in your Source class
               .HasForeignKey(i => i.SourceId);


            // Seed data

            // Seed data for Source derived classes
            modelBuilder.Entity<LocationSource>().HasData(
                new LocationSource { Id = 1, Name = "Location 1", Address = "123 Main St" },
                new LocationSource { Id = 2, Name = "Location 2", Address = "456 Oak St" }
            );
            // Check if a LocationSource entity already exists before seeding
            //foreach (var locationSource in new[]
            //{
            //    new LocationSource { Id = 1, Name = "Location 1", Address = "123 Main St" },
            //    new LocationSource { Id = 2, Name = "Location 2", Address = "456 Oak St" }
            //})
            //{
            //    if (modelBuilder.Entity<LocationSource>().HasData(locationSource))
            //    {
            //        continue;
            //    }
            //    modelBuilder.Entity<LocationSource>().HasData(locationSource);
            //}

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
                new Inventory { Id = 1, InventoryId = 100, InventoryName = "Item A", Quantity = 10, Price = 5, SourceId = 1 },
                new Inventory { Id = 2, InventoryId = 200, InventoryName = "Item B", Quantity = 20, Price = 10, SourceId = 3 },
                new Inventory { Id = 3, InventoryId = 300, InventoryName = "Item C", Quantity = 15, Price = 7.5, SourceId = 5 },
                new Inventory { Id = 4, InventoryId = 400, InventoryName = "Item D", Quantity = 8, Price = 12.5, SourceId = 7 }
            );
            base.OnModelCreating(modelBuilder);
            SaveChangesAsync();

            // Configure other models as needed
        }
        //SaveChangesAsync();
    }

    public class IMSSQLiteDbContextFactory : IDesignTimeDbContextFactory<IMSSQLiteDbContext>
    {
        public IMSSQLiteDbContext CreateDbContext(string[] args)
        {
            return new IMSSQLiteDbContext();
        }
    }
}