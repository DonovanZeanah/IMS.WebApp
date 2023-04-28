using IMS.CoreBusiness.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Plugins.InMemory
{
    public class IMSContext : DbContext
  {
    public IMSContext(DbContextOptions options) : base(options)
    {

    }
    public DbSet<Inventory> Inventories { get; set; }
        //public object Accessories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Inventory>().HasData(
        new Inventory() { InventoryId = 1, InventoryName = "Power Pole", Quantity = 10, Price = 30 },
        new Inventory() { InventoryId = 2, InventoryName = "Tool box", Quantity = 100, Price = 500 },
        new Inventory() { InventoryId = 3, InventoryName = "Camera Head Pole-Mount", Quantity = 100, Price = 60 },
        new Inventory() { InventoryId = 4, InventoryName = "Monopod", Quantity = 100, Price = 300 }
        );
      base.OnModelCreating(modelBuilder);
    }
  }
}
