using API_Core.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Core.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
         
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerDetails> CustomerDetails { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<SupplierDetails> SuppliersDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración para la entidad Customer
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToView("CustomerView"); // Mapea la entidad a la vista

                entity.HasKey(cd => cd.CustomerID);

                // Propiedades de Customer mapeadas a las columnas de la vista
                entity.Property(e => e.CustomerID)
                    .HasColumnName("CustomerID");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(100);

                entity.Property(e => e.CustomerCategoryName)
                    .HasMaxLength(50);

                entity.Property(e => e.DeliveryMethodName)
                    .HasMaxLength(50);
            });

            // Configuración para la entidad CustomerDetails
            modelBuilder.Entity<CustomerDetails>(entity =>
            {
                entity.ToView("CustomerDetailsView"); // Mapea la entidad a la vista

                entity.HasKey(cd => cd.CustomerID);

                // Propiedades de CustomerDetails mapeadas a las columnas de la vista
                entity.Property(e => e.CustomerID)
                    .HasColumnName("CustomerID");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(100);

                entity.Property(e => e.CustomerCategoryName)
                    .HasMaxLength(50);

                entity.Property(e => e.BuyingGroupName)
                    .HasMaxLength(50);

                entity.Property(e => e.PrimaryContact)
                    .HasMaxLength(100);

                entity.Property(e => e.AlternateContact)
                    .HasMaxLength(100);

                entity.Property(e => e.BillToCustomer)
                    .HasMaxLength(100);

                entity.Property(e => e.DeliveryMethodName)
                    .HasMaxLength(50);

                entity.Property(e => e.DeliveryCity)
                    .HasMaxLength(100);

                entity.Property(e => e.DeliveryPostalCode)
                    .HasMaxLength(20);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20);

                entity.Property(e => e.FaxNumber)
                    .HasMaxLength(20);

                entity.Property(e => e.PaymentDays)
                    .HasColumnType("int");

                entity.Property(e => e.WebsiteURL)
                    .HasMaxLength(100);

                entity.Property(e => e.DeliveryPostal1)
                    .HasMaxLength(200);

                entity.Property(e => e.DeliveryPostal2)
                    .HasMaxLength(200);

                entity.Property(e => e.DeliveryLocation)
                    .HasMaxLength(200);
            });

            // Configuración para la entidad Customer
            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.ToView("SupplierView"); // Mapea la entidad a la vista

                entity.HasKey(cd => cd.SupplierID);

                // Propiedades de Customer mapeadas a las columnas de la vista
                entity.Property(e => e.SupplierID)
                    .HasColumnName("SupplierID");

                entity.Property(e => e.SupplierName)
                    .HasMaxLength(100);

                entity.Property(e => e.SupplierCategoryName)
                    .HasMaxLength(50);

                entity.Property(e => e.DeliveryMethodName)
                    .HasMaxLength(50);
            });

            // Configuración para la entidad CustomerDetails
            modelBuilder.Entity<SupplierDetails>(entity =>
            {
                entity.ToView("SupplierDetailsView"); // Mapea la entidad a la vista

                entity.HasKey(cd => cd.SupplierID);

                // Propiedades de CustomerDetails mapeadas a las columnas de la vista
                entity.Property(e => e.SupplierID)
                    .HasColumnName("SupplierID");

                entity.Property(e => e.SupplierReference)
                    .HasMaxLength(20);

                entity.Property(e => e.SupplierName)
                    .HasMaxLength(100);

                entity.Property(e => e.SupplierCategoryName)
                    .HasMaxLength(50);

                entity.Property(e => e.PrimaryContact)
                    .HasMaxLength(50);

                entity.Property(e => e.AlternateContact)
                    .HasMaxLength(50);

                entity.Property(e => e.DeliveryMethodName)
                    .HasMaxLength(50);

                entity.Property(e => e.DeliveryCity)
                    .HasMaxLength(50);

                entity.Property(e => e.DeliveryPostalCode)
                    .HasMaxLength(10);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20);

                entity.Property(e => e.FaxNumber)
                    .HasMaxLength(20);

                entity.Property(e => e.WebsiteURL)
                    .HasMaxLength(100);

                entity.Property(e => e.DeliveryPostal1)
                    .HasMaxLength(200);

                entity.Property(e => e.DeliveryPostal2)
                    .HasMaxLength(200);

                entity.Property(e => e.DeliveryLocation)
                    .HasMaxLength(200);

                entity.Property(e => e.BankAccountName)
                    .HasMaxLength(50);

                entity.Property(e => e.BankAccountNumber)
                    .HasMaxLength(50);

                entity.Property(e => e.PaymentDays)
                    .HasColumnType("int");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
