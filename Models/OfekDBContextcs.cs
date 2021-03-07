using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfekCore.Models
{
    public class OfekDBContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<CustomerProduct> CustomerProducts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //this is called fluent API

            ////to prevent foreign key
            //modelBuilder.Entity<HistoryCustomerProduct>().Map(m =>
            //{
            //    m.MapInheritedProperties();
            //    m.ToTable("HistoryCustomerProduct");
            //});

        }
        public OfekDBContext(DbContextOptions<OfekDBContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
