using Microsoft.EntityFrameworkCore;
using TiendaOnlineV2.Web.Models;

namespace TiendaOnlineV2.Web.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Department>().HasIndex("Name", "IdCountry").IsUnique();
            modelBuilder.Entity<City>().HasIndex("Name", "IdDepartment").IsUnique();
            modelBuilder.Entity<Product>().HasIndex(c => c.Name).IsUnique();
        }
    }
}
