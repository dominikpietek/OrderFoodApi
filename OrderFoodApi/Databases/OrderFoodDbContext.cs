using Microsoft.EntityFrameworkCore;
using OrderFoodApi.Models;
using System.Configuration;

namespace OrderFoodApi.Databases
{
    public class OrderFoodDbContext : DbContext
    {
        public DbSet<UserAdress> UserAdresses { get; set; }
        public DbSet<RestaurantAdress> RestaurantAdresses { get; set; }
        public DbSet<Deliverer> Deliverers { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<DelivererReview> DelivererReviews { get; set; }
        public DbSet<RestaurantReview> RestaurantReviews { get; set; }
        public DbSet<User> Users { get; set; }
        public OrderFoodDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasOne(o => o.Deliverer).WithMany(d => d.Orders);
            modelBuilder.Entity<Deliverer>().HasMany(d => d.Reviews).WithOne(r => r.Deliverer).HasForeignKey(r => r.DelivererId);
            modelBuilder.Entity<Restaurant>().HasMany(r => r.Reviews).WithOne(r => r.Restaurant).HasForeignKey(r => r.RestaurantId);
            modelBuilder.Entity<Restaurant>().HasMany(r => r.Menu).WithOne(m => m.Restaurant).HasForeignKey(m => m.RestaurantId);
            modelBuilder.Entity<Restaurant>().HasOne(r => r.Adress).WithOne(a => a.Restaurant).HasForeignKey<RestaurantAdress>(ra => ra.RestaurantId);
            modelBuilder.Entity<User>().HasOne(u => u.Adress).WithOne(a => a.User).HasForeignKey<UserAdress>(ua => ua.UserId);
            modelBuilder.Entity<User>().HasMany(u => u.Orders).WithOne(o => o.Customer).HasForeignKey(c => c.CustomerId);
        }
    }
}
