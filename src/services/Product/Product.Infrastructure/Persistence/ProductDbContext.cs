using Microsoft.EntityFrameworkCore;
using Product.Domain.Entity;

namespace Product.Infrastructure.Persistence
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Domain.Entity.Product> Products => Set<Domain.Entity.Product>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Category>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
            
            modelBuilder.Entity<Category>()
                .Property(x => x.Name)
                .HasMaxLength(255)
                .IsRequired();

            modelBuilder.Entity<Category>()
                .Property(x => x.SubCategoryName)
                .HasMaxLength(255);
            
            modelBuilder.Entity<Domain.Entity.Product>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Domain.Entity.Product>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
            
            modelBuilder.Entity<Domain.Entity.Product>()
                .Property(x => x.Name)
                .HasMaxLength(255)
                .IsRequired();
            
            modelBuilder.Entity<Domain.Entity.Product>()
                .Property(x => x.Price)
                .HasPrecision(13,2)
                .IsRequired();
            modelBuilder.Entity<Domain.Entity.Product>()
                .Property(x => x.Quantity)
                .IsRequired();
            
            modelBuilder.Entity<Domain.Entity.Product>()
                .Property(x => x.Category)
                .HasMaxLength(255)
                .IsRequired();

            modelBuilder.Entity<Domain.Entity.Product>()
                .Property(x => x.SubCategory)
                .HasMaxLength(255)
                .IsRequired();

            modelBuilder.Entity<Domain.Entity.Product>()
                .Property(x => x.Note)
                .HasMaxLength(2000);

        }
    }
}