using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class UpEnergyContext : DbContext
    {
        // DB Configurasyonu
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-GO1C0B0;Database=UpEnergy;Trusted_Connection=true;TrustServerCertificate=True",option=>
            {
                option.EnableRetryOnFailure();
            });
        }

        // EF Core Fluent API - Code First
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Müşteri Tablosu
            modelBuilder.Entity<Customer>()
               .Property(c => c.Id)
               .HasColumnName("Id")
               .UseIdentityColumn(1, 1)
               .IsRequired();

            modelBuilder.Entity<Customer>()
               .Property(c => c.FirstName)
               .HasColumnName("FirstName")
               .HasMaxLength(50)
               .IsRequired(false);

            modelBuilder.Entity<Customer>()
              .Property(c => c.LastName)
              .HasColumnName("LastName")
              .HasMaxLength(50)
              .IsRequired(false);

            modelBuilder.Entity<Customer>()
              .Property(c => c.TCKN)
              .HasColumnName("TCKN")
              .HasMaxLength(50)
              .IsRequired(false);

            modelBuilder.Entity<Customer>()
              .Property(c => c.Address)
              .HasColumnName("Address")
              .HasMaxLength(500)
              .IsRequired(false);

            modelBuilder.Entity<Customer>()
             .Property(c => c.StatusCode)
             .HasColumnName("StatusCode")
             .HasMaxLength(50)
             .IsRequired(false);

            modelBuilder.Entity<Customer>()
              .Property(c => c.Status)
              .HasColumnName("Status")
              .HasMaxLength(50)
              .IsRequired(false);


            /*-----------------------------------------------------------------------------------------------*/


            // Araç Tablosu
            modelBuilder.Entity<Car>()
              .Property(c => c.Id)
              .HasColumnName("Id")
              .UseIdentityColumn(1, 1)
              .IsRequired();

            modelBuilder.Entity<Car>()
              .Property(c => c.Plaque)
              .HasColumnName("Plaque")
              .HasMaxLength(50)
              .IsRequired(false);

            modelBuilder.Entity<Car>()
              .Property(c => c.CarCode)
              .HasColumnName("CarCode")
              .HasMaxLength(50)
              .IsRequired(false);

            modelBuilder.Entity<Car>()
              .Property(c => c.CarType)
              .HasColumnName("CarType")
              .HasMaxLength(50)
              .IsRequired(false);

            modelBuilder.Entity<Car>()
              .Property(c => c.FuelOilCode)
              .HasColumnName("FuelOilCode")
              .HasMaxLength(50)
              .IsRequired(false);

            modelBuilder.Entity<Car>()
              .Property(c => c.FuelOilType)
              .HasColumnName("FuelOilType")
              .HasMaxLength(50)
              .IsRequired(false);

            // Araç-Müşteri One-To-Many 
            modelBuilder.Entity<Car>()
              .HasOne<Customer>(o => o.Customer)
              .WithMany(c => c.Cars)
              .HasForeignKey(o => o.CustomerId)
              .OnDelete(DeleteBehavior.Cascade);


            /*-----------------------------------------------------------------------------------------------*/


            // Akaryakıt Tablosu
            modelBuilder.Entity<FuelOil>()
              .Property(f => f.Id)
              .HasColumnName("Id")
              .UseIdentityColumn(1, 1)
              .IsRequired();

            modelBuilder.Entity<FuelOil>()
              .Property(f => f.Plaque)
              .HasColumnName("Plaque")
              .HasMaxLength(50)
              .IsRequired(false);

            modelBuilder.Entity<FuelOil>()
              .Property(f => f.TransactionAmount)
              .HasColumnName("TransactionAmount")
              .HasPrecision(18, 4)
              .IsRequired(false);

            modelBuilder.Entity<FuelOil>()
              .Property(f => f.TransactionDate)
              .HasColumnName("TransactionDate")
              .HasDefaultValueSql("getdate()")
              .IsRequired(false);

            // Akaryakıt-Araç One-To-Many 
            modelBuilder.Entity<FuelOil>()
              .HasOne<Car>(o => o.Car)
              .WithMany(c => c.FuelOils)
              .HasForeignKey(o => o.CarId)
              .OnDelete(DeleteBehavior.Cascade);


            /*-----------------------------------------------------------------------------------------------*/

            // Bakiye Tablosu
            modelBuilder.Entity<Balance>()
              .Property(b => b.Id)
              .HasColumnName("Id")
              .UseIdentityColumn(1, 1)
              .IsRequired();

            modelBuilder.Entity<Balance>()
              .Property(c => c.BalanceCode)
              .HasColumnName("BalanceCode")
              .HasMaxLength(50)
              .IsRequired(false);

            modelBuilder.Entity<Balance>()
              .Property(b => b.Gift)
              .HasColumnName("Gift")
              .HasMaxLength(50)
              .IsRequired(false);

            modelBuilder.Entity<Balance>()
              .Property(b => b.Credit)
              .HasColumnName("Credit")
              .HasMaxLength(50)
              .IsRequired(false);

            modelBuilder.Entity<Balance>()
              .Property(b => b.DownPayment)
              .HasColumnName("DownPayment")
              .HasMaxLength(50)
              .IsRequired(false);

            modelBuilder.Entity<Balance>()
              .HasOne<Customer>(o => o.Customer)
              .WithMany(c => c.Balances)
              .HasForeignKey(o => o.CustomerId)
              .OnDelete(DeleteBehavior.Cascade);



            /*-----------------------------------------------------------------------------------------------*/




            // Transaction

            modelBuilder.Entity<Transaction>()
             .Property(t => t.Id)
             .HasColumnName("Id")
             .UseIdentityColumn(1, 1);


            modelBuilder.Entity<Transaction>()
             .Property(t => t.TransactionNo)
             .HasColumnName("TransactionNo")
             .HasDefaultValue(10000);


            modelBuilder.Entity<Transaction>()
             .Property(t => t.TransactionDate)
             .HasColumnName("TransactionDate")
             .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Transaction>()
             .Property(t => t.IsSuccess)
             .HasColumnName("isSuccess")
             .ValueGeneratedNever()
             .HasDefaultValue(true);


            modelBuilder.Entity<Transaction>()
             .HasOne<Customer>(t => t.Customer)
             .WithMany(c => c.Transactions)
             .HasForeignKey(t => t.CustomerID);

            /*-----------------------------------------------------------------------------------------------*/

            // Logs
            modelBuilder.Entity<Log>()
             .Property(t => t.Id)
             .HasColumnName("Id")
             .UseIdentityColumn(1, 1);

            modelBuilder.Entity<Log>()
              .Property(b => b.Detail)
              .HasColumnName("Detail")
              .HasColumnType("nvarchar(max)")
              .IsRequired(false);

            modelBuilder.Entity<Log>()
              .Property(t => t.Date)
              .HasColumnName("Date")
              .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Log>()
              .Property(b => b.Audit)
              .HasColumnName("Audit")
              .HasMaxLength(50)
              .IsRequired(false);

          
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<FuelOil> FuelOils { get; set; }
        public DbSet<Balance> Balances { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Log> Logs { get; set; }

    }
}
