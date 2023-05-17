using IMS.CoreBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IMS.Plugins.SQLite.Data
{
    public static class SeedData
    {
        private const double DBL = 00.00;

        public static void Initialize(IMSSQLiteDbContext db)
        {
            Console.WriteLine("Initializing seed data...");

            var accessories = new Accessory[]
            {
            new Accessory()
            {
                Id = 1,
                    Name = "Camera System",
                    Type = "standard",
                    Version = DBL,
            },
            new Accessory()
            {
                                Id = 2,

                    Name = "Software Package",
                    Type = "standard",
                    Version = 00.00,
            },
            new Accessory()
            {

                 Id = 3,
                    Name = "Data Box",
                    Type = "standard",
                    Version = 00.00,
            },
            new Accessory()
            {Id = 4,
                    Name = "Module 1",
                    Type = "standard",
                    Version = 00.00,
            },
            new Accessory()
            {Id = 5,
                    Name = "Module 2",
                    Type = "standard",
                    Version = 00.00
            },
            
            };

            // Accessories
            foreach (var accessory in accessories)
            {
                var existingAccessory = db.Accessories.Find(accessory.Id);
                if (existingAccessory != null)
                {
                    if (AreAccessoriesDifferent(existingAccessory, accessory))
                    {
                        Console.WriteLine($"Updating Accessory with Id {accessory.Name}...{accessory.Version}...{accessory.Type}");
                        db.Entry(existingAccessory).CurrentValues.SetValues(accessory);
                    }
                }
                else
                {
                    Console.WriteLine($"adding Accessory with Id {accessory.Name}...{accessory.Version}...{accessory.Type}");
                    db.Accessories.Add(accessory);
                }
            }
            db.SaveChangesAsync();


            /*foreach (var accessory in accessories)
            {
                var existingAccessory = db.Accessories.Find(accessory.Name);
                if (existingAccessory != null)
                {

                    if (existingAccessory.Name != accessory.Name || existingAccessory.Type != accessory.Type || existingAccessory.Version != accessory.Version)
                    {
                        Console.WriteLine($"Updating Accessory with Id {accessory.Name}...{accessory.Version}...{accessory.Type}");

                        db.Entry(existingAccessory).CurrentValues.SetValues(accessory);
                    }
                }
                else
                {
                    Console.WriteLine($"adding Accessory with Id {accessory.Name}...{accessory.Version}...{accessory.Type}");

                    db.Accessories.Add(accessory);
                }
            }
            db.SaveChangesAsync();*/



            //var locationSource = new LocationSource { Id = 1, Name = "Location 1", Address = "123 Main St" };
            //        var locationSources = new LocationSource[]
            //{
            //    new LocationSource { Id = 1, Name = "Location 1", Address = "123 Main St" },
            //    new LocationSource { Id = 2, Name = "Location 2", Address = "456 Oak St" }
            //};

            //        foreach (var locationSource in locationSources)
            //        {
            //            var existingLocationSource = db.LocationSources.Find(locationSource.Id);
            //            if (existingLocationSource != null)
            //            {
            //                if (existingLocationSource.Name != locationSource.Name || existingLocationSource.Address != locationSource.Address)
            //                {
            //                    Console.WriteLine($"Updating LocationSource with Id {locationSource.Id}...");
            //                    db.Entry(existingLocationSource).CurrentValues.SetValues(locationSource);
            //                }
            //            }
            //            else
            //            {
            //                Console.WriteLine($"Adding new LocationSource with Id {locationSource.Id}...");
            //                db.LocationSources.Add(locationSource);
            //            }
            //        }
            //            var storeSource = new StoreSource { Id = 2, Name = "Store 1", StoreName = "Super Store" };
            //        var contactSource = new ContactSource { Id = 3, Name = "Contact 1", ContactName = "John Doe" };
            //        var selfObtainedSource = new SelfObtainedSource { Id = 4, Process = "Woodcutting" };

            //        db.AddRange(locationSources, storeSource, contactSource, selfObtainedSource);
            //        db.SaveChanges();

            var inventories = new List<Inventory>()
{
    new Inventory() { Id = 1, InventoryName = "Steering Wheel", Quantity = 10, Price = 30, }, // SourceId = 1, DiscriminatorId = 1 },
    new Inventory() { Id = 2, InventoryName = "Brake Pad", Quantity = 20, Price = 15, }, // SourceId = 1, DiscriminatorId = 1 },
    new Inventory() { Id = 3, InventoryName = "Air Filter", Quantity = 50, Price = 5, }, // SourceId = 2, DiscriminatorId = 1 },
    new Inventory() { Id = 4, InventoryName = "Spark Plug", Quantity = 100, Price = 2, }, // SourceId = 2, DiscriminatorId = 1 },
    new Inventory() { Id = 5, InventoryName = "Oil Filter", Quantity = 30, Price = 10, }, // SourceId = 1, DiscriminatorId = 1 },
    new Inventory() { Id = 6, InventoryName = "Tire", Quantity = 15, Price = 50, }, // SourceId = 1, DiscriminatorId = 1 },
    new Inventory() { Id = 7, InventoryName = "Battery", Quantity = 5, Price = 100, }, // SourceId = 2, DiscriminatorId = 1 },
    new Inventory() { Id = 8, InventoryName = "Wiper Blade", Quantity = 25, Price = 7, }, // SourceId = 1, DiscriminatorId = 1 },
    new Inventory() { Id = 9, InventoryName = "Alternator", Quantity = 2, Price = 150, }, // SourceId = 1, DiscriminatorId = 1 },
    new Inventory() { Id = 10, InventoryName = "Radiator", Quantity = 3, Price = 80, }, // SourceId = 2, DiscriminatorId = 1 },
    new Inventory() { Id = 11, InventoryName = "Shock Absorber", Quantity = 8, Price = 40, }, // SourceId = 1, DiscriminatorId = 1 },
    new Inventory() { Id = 12, InventoryName = "Fuel Filter", Quantity = 20, Price = 12, }, // SourceId = 1, DiscriminatorId = 1 },
    new Inventory() { Id = 13, InventoryName = "Serpentine Belt", Quantity = 12, Price = 18, }, // SourceId = 1, DiscriminatorId = 1 },
    new Inventory() { Id = 14, InventoryName = "Water Pump", Quantity = 5, Price = 75, }, // SourceId = 2, DiscriminatorId = 1 },
    new Inventory() { Id = 15, InventoryName = "Starter Motor", Quantity = 3, Price = 120, }, // SourceId = 1, DiscriminatorId = 1 },
    new Inventory() { Id = 16, InventoryName = "Brake Rotor", Quantity = 6, Price = 60, }, // SourceId = 1, DiscriminatorId = 1 },
    new Inventory() { Id = 17, InventoryName = "Timing Belt", Quantity = 8, Price = 25, }, // SourceId = 2, DiscriminatorId = 1 },
    new Inventory() { Id = 18, InventoryName = "Headlight Bulb", Quantity = 30, Price = 5,}, //  SourceId = 1, DiscriminatorId= 1 },
new Inventory() { Id = 19, InventoryName = "Exhaust Pipe", Quantity = 4, Price = 90, }, // SourceId = 1, DiscriminatorId = 1 },
new Inventory() { Id = 20, InventoryName = "Oxygen Sensor", Quantity = 5, Price = 50, }, // SourceId = 2, DiscriminatorId = 1 },
new Inventory() { Id = 21, InventoryName = "Steering Wheel", Quantity = 10, Price = 30, }, // SourceId = 1, DiscriminatorId = 1 },
new Inventory() { Id = 22, InventoryName = "Driver Seat", Quantity = 100, Price = 20, }, // SourceId = 1, DiscriminatorId = 1 },
new Inventory() { Id = 23, InventoryName = "Battery Bank", Quantity = 100, Price = 12, }, // SourceId = 2, DiscriminatorId = 1 },
new Inventory() { Id = 24, InventoryName = "Drive Motor", Quantity = 100, Price = 1, }, // SourceId = 2, DiscriminatorId = 1 },
};



            foreach (var inventory in inventories)
            {
                var existingInventory = db.Inventories.Find(inventory.Id);
                if (existingInventory != null)
                {
                    if (existingInventory.InventoryName != inventory.InventoryName ||
                    existingInventory.Quantity != inventory.Quantity ||
                    existingInventory.Price != inventory.Price) 
                    // ||
                    //existingInventory.SourceId != inventory.SourceId ||
                    //existingInventory.DiscriminatorId != inventory.DiscriminatorId)
                    {
                        db.Entry(existingInventory).CurrentValues.SetValues(inventory);
                    }
                }
                else
                {
                    db.Inventories.Add(inventory);
                }
            }

            db.SaveChangesAsync();



            // db.AddRange(accessories);

            //        var locationSources = new List<LocationSource>
            //{
            //    new LocationSource { Id = 1, Name = "Location 1", Address = "123 Main St" },
            //    new LocationSource { Id = 2, Name = "Location 2", Address = "456 Oak St" }
            //};
            //        SeedSources(db, locationSources);

            //        var storeSources = new List<StoreSource>
            //{
            //    new StoreSource { Id = 3, Name = "Store 1", StoreName = "Super Store" },
            //};
            //        SeedSources(db, storeSources);

            //        var contactSources = new List<ContactSource>
            //{
            //    new ContactSource { Id = 4, Name = "Contact 1", ContactName = "John Doe" },
            //};
            //        SeedSources(db, contactSources);

            //        var selfObtainedSources = new List<SelfObtainedSource>
            //{
            //    new SelfObtainedSource { Id = 5, Process = "Woodcutting" },
            //};
            //        SeedSources(db, selfObtainedSources);

            //        // ...

            //        Console.WriteLine("Seed data initialization complete. Saving changes..");
            //        db.SaveChangesAsync();
            var locationSources = new List<LocationSource>
{
    new LocationSource { Id = 1, Name = "Location 1", Address = "123 Main St" }, //DiscriminatorID = 1 },
    new LocationSource { Id = 2, Name = "Location 2", Address = "456 Oak St" }, //DiscriminatorID = 1 }
};
            SeedSources<LocationSource>(db, locationSources);

            var storeSources = new List<StoreSource>
{
    new StoreSource { Id = 3, Name = "Store 1", StoreName = "Super Store" }, //DiscriminatorID = 2 },
};
            SeedSources<StoreSource>(db, storeSources);

            var contactSources = new List<ContactSource>
{
    new ContactSource { Id = 4, Name = "Contact 1", ContactName = "John Doe" },
};
            SeedSources<ContactSource>(db, contactSources);

            var selfObtainedSources = new List<SelfObtainedSource>
{
    new SelfObtainedSource { Id = 5, Process = "Woodcutting" }, // DiscriminatorID = 4 },
};
            SeedSources<SelfObtainedSource>(db, selfObtainedSources);

            // ...

            Console.WriteLine("Seed data initialization complete. Saving changes..");
             db.SaveChangesAsync();







        }

        private static void SeedSources<T>(IMSSQLiteDbContext db, List<T> sources) where T : Source
        {
            //db.Sources.RemoveRange(db.Sources);
            // db.SaveChanges();

            foreach (var source in sources)
            {
                var existingSource = db.Set<T>().Find(source.Id);
                if (existingSource != null)
                {
                    // Check if there's a difference between the existing source and the source to be seeded
                    if (AreSourcesDifferent(existingSource, source))
                    {
                        Console.WriteLine($"Skipping {typeof(T).Name} with Id {source.Id} as it has the same Id.");
                        continue;
                    }

                    Console.WriteLine($"Updating {typeof(T).Name} with Id {source.Id}...");
                    db.Entry(existingSource).CurrentValues.SetValues(source);
                }
                else
                {
                    Console.WriteLine($"Adding new {typeof(T).Name} with Id {source.Id}...");
                    db.Set<T>().Add(source);
                }
            }
            db.SaveChangesAsync();
        }


        private static bool AreSourcesDifferent<T>(T existingSource, T sourceToSeed) where T : Source
        {
            // Here you can add the comparison logic to check if the existing source and the source to be seeded are different.
            // For example, if you only want to check if the Id property is different:
            return !existingSource.Id.Equals(sourceToSeed.Id);
        }

        private static bool AreAccessoriesDifferent(Accessory existingAccessory, Accessory accessoryToSeed)
        {
            return existingAccessory.Name != accessoryToSeed.Name ||
                   existingAccessory.Type != accessoryToSeed.Type ||
                   existingAccessory.Version != accessoryToSeed.Version;
        }
    }
}