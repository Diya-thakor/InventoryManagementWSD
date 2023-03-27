using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Models
{
    public class AppDbContext:DbContext
    {
        //DbContext --> Provides relation between Database and 
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductItem>().HasKey(pi => new {pi.ProductId,pi.ItemId});
            modelBuilder.Entity<Product>().HasIndex(p => new {p.Name,p.OrganizationId}).IsUnique();
            modelBuilder.Entity<Organization>().HasIndex(p=>p.Name).IsUnique();
            modelBuilder.Entity<Item>().HasIndex(i => new { i.Name, i.OrganizationId }).IsUnique();
        }
        public DbSet<Item> Items { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Organization> Organizations { get; set; } = null!;
        public DbSet<ProductItem> ProductItems { get; set; } = null!;
    }
}
