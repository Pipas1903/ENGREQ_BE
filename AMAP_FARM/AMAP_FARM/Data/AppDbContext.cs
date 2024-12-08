using AMAP_FARM.DTO;
using AMAP_FARM.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductType> ProductTypes { get; set; }
    public DbSet<Producer> Producers { get; set; }
    public DbSet<CoProducer> CoProducers { get; set; }
    public DbSet<SubscriptionPeriod> SubscriptionPeriods { get; set; }
    public DbSet<DeliveryDate> DeliveryDates { get; set; }
    public DbSet<PaymentMethod> PaymentMethods { get; set; }
    public DbSet<Fractionation> Fractionations { get; set; }
    public DbSet<Offer> Offers { get; set; }
    public DbSet<OfferItem> OfferItems { get; set; }
    public DbSet<SubscribeOffer> SubscribeOffers { get; set; }
    public DbSet<SubscribeOfferItem> SubscribeOfferItems { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
                .HasOne<Role>()
                .WithMany()
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Producer>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<CoProducer>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Restrict);

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

        modelBuilder.Entity<Product>()
                .HasOne<ProductType>()
                .WithMany()
                .HasForeignKey(u => u.ProductCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Offer>()
            .HasOne<SubscriptionPeriod>()
            .WithMany()
            .HasForeignKey(oi => oi.SubscriptionPeriodId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Offer>()
            .HasOne<PaymentMethod>()
            .WithMany()
            .HasForeignKey(oi => oi.PaymentMethodId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Offer>()
            .HasOne<Fractionation>()
            .WithMany()
            .HasForeignKey(oi => oi.FractionationId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<OfferItem>()
            .HasOne<Offer>()
            .WithMany()
            .HasForeignKey(oi => oi.OfferId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<SubscribeOffer>()
            .HasOne<CoProducer>()
            .WithMany()
            .HasForeignKey(oi => oi.CoProducerId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<SubscribeOfferItem>()
            .HasOne<SubscribeOffer>()
            .WithMany()
            .HasForeignKey(oi => oi.SubscribeOfferId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<SubscribeOfferItem>()
            .HasOne<PaymentMethod>()
            .WithMany()
            .HasForeignKey(oi => oi.PaymentMethodId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<SubscribeOfferItem>()
            .HasOne<Fractionation>()
            .WithMany()
            .HasForeignKey(oi => oi.FractionationId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
