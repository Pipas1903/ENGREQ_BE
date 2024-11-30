using AMAP_FARM.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Product> Products { get; set; }

    public DbSet<ProductCategory> ProductCategories { get; set; }

    public DbSet<SubscriptionPeriod> SubscriptionPeriods { get; set; }
    public DbSet<DeliveryDate> DeliveryDates { get; set; }

}
