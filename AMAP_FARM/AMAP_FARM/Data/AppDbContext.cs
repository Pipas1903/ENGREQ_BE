using AMAP_FARM.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Producer> Producers { get; set; }
    public DbSet<Basket> Baskets { get; set; }
    public DbSet<SubscriptionPeriod> SubscriptionPeriods { get; set; }
    public DbSet<DeliveryDate> DeliveryDates { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
                .HasOne<Role>()
                .WithMany()
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Producer>()
                .ToTable("Producers");

        modelBuilder.Entity<Product>()
                .HasOne<ProductCategory>()
                .WithMany()
                .HasForeignKey(u => u.ProductCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Product>()
                .HasOne<Producer>()
                .WithMany()
                .HasForeignKey(u => u.ProducerId)
                .OnDelete(DeleteBehavior.Restrict);
    }
}
