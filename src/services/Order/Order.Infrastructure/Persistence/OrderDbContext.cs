using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Order.Domain.Entity;

namespace Order.Infrastructure.Persistence
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
        {

        }

        public DbSet<Domain.Entity.Order> Orders => Set<Domain.Entity.Order>();
        public DbSet<OrderItem> OrderItems => Set<OrderItem>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Domain.Entity.Order>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<Domain.Entity.Order>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Domain.Entity.Order>()
                .Property(x => x.StoreId)
                .IsRequired();
            modelBuilder.Entity<Domain.Entity.Order>()
                .Property(x => x.OrderDate)
                .IsRequired();
            modelBuilder.Entity<Domain.Entity.Order>()
                .Property(x => x.DeliveryDate)
                .IsRequired();
            modelBuilder.Entity<Domain.Entity.Order>()
                .Property(x => x.Total)
                .HasPrecision(13, 2)
                .IsRequired();

            modelBuilder.Entity<OrderItem>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<OrderItem>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<OrderItem>()
                .HasOne(x => x.Order)
                .WithMany(x => x.Items)
                .HasForeignKey(x => x.OrderId);
            modelBuilder.Entity<OrderItem>()
                .Property(x => x.ProductId)
                .IsRequired();
            modelBuilder.Entity<OrderItem>()
                .Property(x => x.Box)
                .HasDefaultValue(0)
                .IsRequired();
            modelBuilder.Entity<OrderItem>()
                .Property(x => x.Each)
                .HasDefaultValue(0)
                .IsRequired();
            modelBuilder.Entity<OrderItem>()
                .Property(x => x.Pound)
                .HasDefaultValue(0)
                .IsRequired();
            modelBuilder.Entity<OrderItem>()
                .Property(x => x.Price)
                .HasPrecision(13,2)
                .IsRequired();
            modelBuilder.Entity<OrderItem>()
                .Property(x => x.Market)
                .HasMaxLength(50);
            modelBuilder.Entity<OrderItem>()
                .Property(x => x.Note)
                .HasMaxLength(255);
            modelBuilder.Entity<OrderItem>()
                .Property(x => x.RouteId)
                .IsRequired();

        }
    }
}