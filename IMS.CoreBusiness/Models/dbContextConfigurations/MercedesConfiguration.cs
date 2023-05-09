using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IMS.CoreBusiness.Models.dbContextConfigurations
{
    public class MercedesConfiguration : IEntityTypeConfiguration<Mercede>
    {
        public void Configure(EntityTypeBuilder<Mercede> builder) =>
            // Configure Id property as auto-increment and primary key
            builder.Property(m => m.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();// Configure other properties as needed// ...// Configure relationships as needed// ...
    }
}

/*
 * In DbContext class, apply this configuration using the OnModelCreating method:
 * This configures the Id property of the Mercedes class to be auto-incremented in the database when a new record is inserted.

public class MyDbContext : DbContext
{
    public DbSet<Mercedes> Mercedes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Apply Mercedes configuration
        modelBuilder.ApplyConfiguration(new MercedesConfiguration());

        // Apply other configurations as needed
        // ...
    }
}
 *
 */
