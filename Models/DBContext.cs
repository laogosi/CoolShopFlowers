using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CoolShopFlowers.Models
{
    public class DBContext : IdentityDbContext<User>
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Flower> Flowers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Налаштування для Order
            modelBuilder.Entity<Order>(o =>
            {
                o.HasOne(o => o.User)
                  .WithMany(u => u.Orders)
                  .HasForeignKey(o => o.UserId)
                  .OnDelete(DeleteBehavior.SetNull);  // Тепер працюватиме, бо UserId nullable
            });

            // Налаштування для OrderDetail
            modelBuilder.Entity<OrderDetail>(od =>
            {
                od.HasKey(od => new { od.OrderId, od.FlowerId });

                od.HasOne(od => od.Order)
                  .WithMany(o => o.OrderDetails)
                  .HasForeignKey(od => od.OrderId)
                  .OnDelete(DeleteBehavior.Cascade);

                od.HasOne(od => od.Flower)
                  .WithMany(f => f.OrderDetails)
                  .HasForeignKey(od => od.FlowerId)
                  .OnDelete(DeleteBehavior.Cascade);
            });

            // Налаштування для Flower
            modelBuilder.Entity<Flower>(f =>
            {
                f.HasOne(f => f.Category)
                  .WithMany(c => c.Flowers)
                  .HasForeignKey(f => f.CategoryId)
                  .OnDelete(DeleteBehavior.SetNull);
            });

            // Налаштування для Category
            modelBuilder.Entity<Category>(c =>
            {
                c.HasMany(c => c.Flowers)
                  .WithOne(f => f.Category)
                  .OnDelete(DeleteBehavior.SetNull);
            });
        }
    }
}
