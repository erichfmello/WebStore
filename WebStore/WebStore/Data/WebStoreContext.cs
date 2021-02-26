using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebStore.Models;

namespace WebStore.Data
{
    public class WebStoreContext : DbContext
    {
        public WebStoreContext (DbContextOptions<WebStoreContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShoppingCart>().HasKey(item => new { item._cpf, item._idProduct });
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<People> People { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ShoppingCart> ShoppingCart { get; set; }
    }
}
