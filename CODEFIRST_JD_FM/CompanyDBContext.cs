using CODEFIRST_JD_FM.MODEL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CODEFIRST_JD_FM
{
    public class CompanyDBContext: DbContext
    {
        public CompanyDBContext() { }
        public CompanyDBContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //En cas que el context no estigui configurat, el configurem mitjançant la cadena..
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=localhost;Database=COMPANYDB;Uid=root;Pwd=\"\"");
            }
        }

        public virtual DbSet<ProductLines> ProductLines { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Offices> Offices { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Payments> Payments { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ////CompositeKey OrderDetails
            modelBuilder.Entity<OrderDetails>()
                .HasKey(od => new { od.orderNumber, od.productCode });

            ////CompositeKey Payments
            modelBuilder.Entity<Payments>()
                .HasKey(p => new { p.customerNumber, p.checkNumber });

            ////ForeignKey Payments
            modelBuilder.Entity<Payments>()
                .HasOne(p => p.Customers)
                .WithMany(c => c.Payments)
                .HasForeignKey(p => p.customerNumber);

            ////ForeignKey OrderDetails
            modelBuilder.Entity<OrderDetails>()
                .HasOne(od => od.Orders)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.orderNumber);
        }
    }
}
