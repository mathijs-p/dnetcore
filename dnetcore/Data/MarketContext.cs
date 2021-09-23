using Microsoft.EntityFrameworkCore;
using dnetcore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dnetcore.Models.DomainModels;

namespace dnetcore.Data
{
    public class MarketContext : DbContext
    {
        public MarketContext(DbContextOptions<MarketContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User").HasMany(u => u.Stores).WithOne(s => s.User);
            modelBuilder.Entity<Store>().ToTable("Store").HasMany(s => s.Products).WithOne(p => p.Store);
            modelBuilder.Entity<Product>().ToTable("Product");
        }
    }
}
