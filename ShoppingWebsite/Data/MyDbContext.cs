using Microsoft.EntityFrameworkCore;
using ShoppingWebsite.Models;
using System.Security.Principal;

namespace ShoppingWebsite.Data
{
    public class MyDbContext : DbContext
    {

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        
        public DbSet<Accounts> Accounts { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accounts>().HasKey(a => a.AccountID);
        }

    }
}
