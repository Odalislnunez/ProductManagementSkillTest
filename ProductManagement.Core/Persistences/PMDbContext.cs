using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Core.Models;

namespace ProductManagement.Core.Persistences
{
    public class PMDbContext : IdentityDbContext<IdentityUser>
    {
        public PMDbContext(DbContextOptions<PMDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<CustomerProduct> CustomersProducts { get; set; }
    }
}
