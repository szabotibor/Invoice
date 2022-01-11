using Microsoft.EntityFrameworkCore;
using Store.Application.Dto;

namespace Store.Infrastructure.Persistence
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {

        }

        public DbSet<Domain.Entity.Store> Stores => Set<Domain.Entity.Store>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Domain.Entity.Store>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Domain.Entity.Store>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Domain.Entity.Store>()
                .Property(x => x.Name)
                .HasMaxLength(255)
                .IsRequired();

            modelBuilder.Entity<Domain.Entity.Store>()
                .Property(x => x.Phone)
                .HasMaxLength(15)
                .IsRequired();

            modelBuilder.Entity<Domain.Entity.Store>()
                .Property(x => x.Address)
                .HasMaxLength(255)
                .IsRequired();

            modelBuilder.Entity<Domain.Entity.Store>()
                .Property(x => x.ContactName)
                .HasMaxLength(255);

            modelBuilder.Entity<Domain.Entity.Store>()
                .Property(x => x.ContactPhone)
                .HasMaxLength(15);

            modelBuilder.Entity<Domain.Entity.Store>()
                .Property(x => x.Detail)
                .HasMaxLength(255);

            modelBuilder.Entity<Domain.Entity.Store>()
                .Property(x => x.Fax)
                .HasMaxLength(15);

            modelBuilder.Entity<Domain.Entity.Store>()
                .Property(x => x.IsMarket)
                .HasDefaultValue(0);
            
            modelBuilder.Entity<Domain.Entity.Store>()
                .Property(x => x.IsMyStore)
                .HasDefaultValue(0);
        }
    }
}