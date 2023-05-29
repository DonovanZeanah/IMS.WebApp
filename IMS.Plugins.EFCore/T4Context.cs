using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BlazorSignalRChartApp.Models;

public partial class T4Context : DbContext
{
    public T4Context()
    {
    }

    public T4Context(DbContextOptions<T4Context> options)
        : base(options)
    {
    }

    public virtual DbSet<CarDetailsTable> CarDetailsTables { get; set; }

    public virtual DbSet<CarStatusTable> CarStatusTables { get; set; }

    public virtual DbSet<CarTable> CarTables { get; set; }

    public virtual DbSet<ErrorLogTable> ErrorLogTables { get; set; }

    public virtual DbSet<EventTable> EventTables { get; set; }

    public virtual DbSet<EventTypeTable> EventTypeTables { get; set; }

    public virtual DbSet<LoggerTable> LoggerTables { get; set; }

    public virtual DbSet<PlaceholderUserRoleTable> PlaceholderUserRoleTables { get; set; }

    public virtual DbSet<PlaceholderUserTable> PlaceholderUserTables { get; set; }

    public virtual DbSet<RepairTable> RepairTables { get; set; }

    public virtual DbSet<SoftwareTable> SoftwareTables { get; set; }

    public virtual DbSet<SourceTable> SourceTables { get; set; }

    /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
 #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
         => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=t4;Trusted_Connection=True;MultipleActiveResultSets=true;Integrated Security=True;TrustServerCertificate=True");*/

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CarDetailsTable>(entity =>
        {
            entity.HasKey(e => e.CarId).HasName("PK__CarDetai__68A0340E83489880");

            entity.ToTable("CarDetailsTable");

            entity.Property(e => e.CarId)
                .ValueGeneratedNever()
                .HasColumnName("CarID");
            entity.Property(e => e.Finas)
                .HasMaxLength(50)
                .HasColumnName("FINAS");
            entity.Property(e => e.FullVin)
                .HasMaxLength(50)
                .HasColumnName("FullVIN");
            entity.Property(e => e.HarnessStatus)
                .HasMaxLength(50)
                .HasColumnName("HARNESS_STATUS");
            entity.Property(e => e.Tag)
                .HasMaxLength(50)
                .HasColumnName("TAG");
            entity.Property(e => e.Vinlast4)
                .HasMaxLength(50)
                .HasColumnName("VINLAST4");

            entity.HasOne(d => d.Car).WithOne(p => p.CarDetailsTable)
                .HasForeignKey<CarDetailsTable>(d => d.CarId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CarDetail__CarID__5535A963");
        });

        modelBuilder.Entity<CarStatusTable>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__CarStatu__C8EE2043332A7367");

            entity.ToTable("CarStatusTable");

            entity.Property(e => e.StatusId).HasColumnName("StatusID");
            entity.Property(e => e.StatusName).HasMaxLength(50);
        });

        modelBuilder.Entity<CarTable>(entity =>
        {
            entity.HasKey(e => e.CarId).HasName("PK__CarTable__68A0340E7D6C0894");

            entity.ToTable("CarTable");

            entity.Property(e => e.CarId).HasColumnName("CarID");
            entity.Property(e => e.CurrentStatusId).HasColumnName("CurrentStatusID");
            entity.Property(e => e.Location).HasMaxLength(255);
            entity.Property(e => e.Make).HasMaxLength(50);
            entity.Property(e => e.Model).HasMaxLength(50);
            entity.Property(e => e.SourceId).HasColumnName("SourceID");
            entity.Property(e => e.TeleGeneration).HasMaxLength(50);

            entity.HasOne(d => d.CurrentStatus).WithMany(p => p.CarTables)
                .HasForeignKey(d => d.CurrentStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CarTable__Curren__440B1D61");

            entity.HasOne(d => d.Source).WithMany(p => p.CarTables)
                .HasForeignKey(d => d.SourceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CarTable__Source__4316F928");
        });

        modelBuilder.Entity<ErrorLogTable>(entity =>
        {
            entity.HasKey(e => e.ErrorId).HasName("PK__ErrorLog__358565CA9D5D92BD");

            entity.ToTable("ErrorLogTable");

            entity.Property(e => e.ErrorId).HasColumnName("ErrorID");
            entity.Property(e => e.CarId).HasColumnName("CarID");
            entity.Property(e => e.ErrorDetails).HasMaxLength(255);
            entity.Property(e => e.ErrorNotes).HasMaxLength(255);

            entity.HasOne(d => d.Car).WithMany(p => p.ErrorLogTables)
                .HasForeignKey(d => d.CarId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ErrorLogT__CarID__5812160E");
        });

        modelBuilder.Entity<EventTable>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("PK__EventTab__7944C8704E03B7AC");

            entity.ToTable("EventTable");

            entity.Property(e => e.EventId).HasColumnName("EventID");
            entity.Property(e => e.CarId).HasColumnName("CarID");
            entity.Property(e => e.EventTypeId).HasColumnName("EventTypeID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Car).WithMany(p => p.EventTables)
                .HasForeignKey(d => d.CarId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EventTabl__CarID__46E78A0C");

            entity.HasOne(d => d.EventType).WithMany(p => p.EventTables)
                .HasForeignKey(d => d.EventTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EventTabl__Event__48CFD27E");

            entity.HasOne(d => d.User).WithMany(p => p.EventTables)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EventTabl__UserI__47DBAE45");
        });

        modelBuilder.Entity<EventTypeTable>(entity =>
        {
            entity.HasKey(e => e.EventTypeId).HasName("PK__EventTyp__A9216B1F9B2618CE");

            entity.ToTable("EventTypeTable");

            entity.Property(e => e.EventTypeId).HasColumnName("EventTypeID");
            entity.Property(e => e.EventTypeName).HasMaxLength(50);
        });

        modelBuilder.Entity<LoggerTable>(entity =>
        {
            entity.HasKey(e => e.LoggerId).HasName("PK__LoggerTa__0ABCCA66CF8A270A");

            entity.ToTable("LoggerTable");

            entity.Property(e => e.LoggerId).HasColumnName("LoggerID");
            entity.Property(e => e.CarId).HasColumnName("CarID");
            entity.Property(e => e.TypeLogger).HasMaxLength(50);

            entity.HasOne(d => d.Car).WithMany(p => p.LoggerTables)
                .HasForeignKey(d => d.CarId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LoggerTab__CarID__4F7CD00D");
        });

        modelBuilder.Entity<PlaceholderUserRoleTable>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Placehol__8AFACE3A1CAB7816");

            entity.ToTable("PlaceholderUserRoleTable");

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.RoleName).HasMaxLength(50);
        });

        modelBuilder.Entity<PlaceholderUserTable>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Placehol__1788CCAC61D7AAD6");

            entity.ToTable("PlaceholderUserTable");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("UserID");
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.Username).HasMaxLength(50);

            entity.HasOne(d => d.Role).WithMany(p => p.PlaceholderUserTables)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Placehold__RoleI__3F466844");
        });

        modelBuilder.Entity<RepairTable>(entity =>
        {
            entity.HasKey(e => e.RepairId).HasName("PK__RepairTa__07D0BDCD1B3DFC22");

            entity.ToTable("RepairTable");

            entity.Property(e => e.RepairId).HasColumnName("RepairID");
            entity.Property(e => e.CarId).HasColumnName("CarID");
            entity.Property(e => e.RepairDetails).HasMaxLength(255);
            entity.Property(e => e.TechnicianId).HasColumnName("TechnicianID");

            entity.HasOne(d => d.Car).WithMany(p => p.RepairTables)
                .HasForeignKey(d => d.CarId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RepairTab__CarID__4BAC3F29");

            entity.HasOne(d => d.Technician).WithMany(p => p.RepairTables)
                .HasForeignKey(d => d.TechnicianId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RepairTab__Techn__4CA06362");
        });

        modelBuilder.Entity<SoftwareTable>(entity =>
        {
            entity.HasKey(e => e.SoftwareId).HasName("PK__Software__25EDB8DC7DADE632");

            entity.ToTable("SoftwareTable");

            entity.Property(e => e.SoftwareId).HasColumnName("SoftwareID");
            entity.Property(e => e.CarId).HasColumnName("CarID");
            entity.Property(e => e.HeadUnit).HasMaxLength(50);
            entity.Property(e => e.NextSoftwareVersion).HasMaxLength(50);
            entity.Property(e => e.SoftwareVersion).HasMaxLength(50);

            entity.HasOne(d => d.Car).WithMany(p => p.SoftwareTables)
                .HasForeignKey(d => d.CarId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SoftwareT__CarID__52593CB8");
        });

        modelBuilder.Entity<SourceTable>(entity =>
        {
            entity.HasKey(e => e.SourceId).HasName("PK__SourceTa__16E019F9A10D7E2C");

            entity.ToTable("SourceTable");

            entity.Property(e => e.SourceId).HasColumnName("SourceID");
            entity.Property(e => e.SourceName).HasMaxLength(50);
            entity.Property(e => e.SourceType).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
