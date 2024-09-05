using Microsoft.EntityFrameworkCore;
using SYACTest.Entitys;

namespace SYACTest.AppDbContext
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PurchesOrders>()
                .Property(p => p.totalValue)
                .HasColumnType("decimal(18,2)");

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ClientsEntity> clients { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<PurchesOrders> purchesOrders { get; set; }

        public DbSet<OrderProducts> orderProducts { get; set; }

    }
}
