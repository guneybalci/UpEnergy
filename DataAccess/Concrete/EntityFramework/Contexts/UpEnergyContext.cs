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
               .HasMaxLength(50);

            modelBuilder.Entity<Customer>()
              .Property(c => c.LastName)
              .HasColumnName("LastName")
              .HasMaxLength(50);

            modelBuilder.Entity<Customer>()
              .Property(c => c.TCKN)
              .HasColumnName("TCKN")
              .HasMaxLength(50);

            modelBuilder.Entity<Customer>()
              .Property(c => c.Address)
              .HasColumnName("Address")
              .HasMaxLength(500);

            // Müşteri-Araç İlişkisi One-To-Many
            //modelBuilder.Entity<Customer>()
            //  .HasMany<Car>(o => o.Cars)
            //  .WithOne(o => o.Customer)
            //  .HasForeignKey(o => o.CustomerId);


            //// Müşteri-Ödeme İlişkisi One-To-One
            //modelBuilder.Entity<Customer>()
            //.HasOne(p => p.Balance) //Müşterinin bir adet Bakiye Tanımı var
            //.WithOne(p => p.Customer) //Bakiye Sadece Bir Müşteriye Aid
            //.HasForeignKey<Balance>(p => p.CustomerId); //Bakiye Tablosundaki ikincil anahtars



            /*-----------------------------------------------------------------------------------------------*/


            // Araç Tablosu
            modelBuilder.Entity<Car>()
              .Property(c => c.Id)
              .HasColumnName("Id")
              .UseIdentityColumn(1, 1)
              .IsRequired();

            modelBuilder.Entity<Car>()
              .Property(c => c.CarType)
              .HasColumnName("CarType")
              .HasMaxLength(50);

            modelBuilder.Entity<Car>()
              .Property(c => c.FuelOilType)
              .HasColumnName("FuelOilType")
              .HasMaxLength(50);

            // Araç-Müşteri One-To-Many 
            modelBuilder.Entity<Car>()
              .HasOne<Customer>(o => o.Customer)
              .WithMany(c => c.Cars)
              .HasForeignKey(o => o.CustomerId)
              .OnDelete(DeleteBehavior.Cascade);


            //// Araç-Akaryakıt İlişkisi One-To-Many
            //modelBuilder.Entity<Car>()
            //  .HasMany<FuelOil>(o => o.FuelOils)
            //  .WithOne(o => o.Car)
            //  .HasForeignKey(o => o.Id);






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
              .HasMaxLength(50);

            modelBuilder.Entity<FuelOil>()
              .Property(f => f.TransactionAmount)
              .HasColumnName("TransactionAmount")
              .HasPrecision(18, 4);

            modelBuilder.Entity<FuelOil>()
              .Property(f => f.TransactionDate)
              .HasColumnName("TransactionDate")
              .HasDefaultValueSql("getdate()");

            //// Akaryakıt-Araç One-To-Many
            //modelBuilder.Entity<FuelOil>()
            //  .HasOne<Car>(f => f.Car)
            //  .WithMany(f => f.FuelOils)
            //  .HasForeignKey(f => f.CarId);


            /*-----------------------------------------------------------------------------------------------*/

            // Bakiye Tablosu
            modelBuilder.Entity<Balance>()
              .Property(b => b.Id)
              .HasColumnName("Id")
              .UseIdentityColumn(1, 1)
              .IsRequired();

            modelBuilder.Entity<Balance>()
              .Property(b => b.Gift)
              .HasColumnName("Gift")
              .HasMaxLength(50);

            modelBuilder.Entity<Balance>()
              .Property(b => b.Credit)
              .HasColumnName("Credit")
              .HasMaxLength(50);

            modelBuilder.Entity<Balance>()
              .Property(b => b.DownPayment)
              .HasColumnName("DownPayment")
              .HasMaxLength(50);

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<FuelOil> FuelOils { get; set; }
        public DbSet<Balance> Balances { get; set; }

    }
}
