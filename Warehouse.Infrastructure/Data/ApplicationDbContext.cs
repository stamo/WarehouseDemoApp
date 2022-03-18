using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Warehouse.Infrastructure.Data.Identity;

namespace Warehouse.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contragent>()
                .HasIndex(c => c.CustomerNumber)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<Rack> Racks { get; set; }

        public DbSet<Contragent> Contragents { get; set; }

        public DbSet<Deal> Deals { get; set; }

        public DbSet<DealSubject> DealSubjects { get; set; }
    }
}