using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GripFoodEntities
{
    public class GripFoodDbContext : DbContext
    {
        public GripFoodDbContext(DbContextOptions<GripFoodDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurant>()
                .HasMany(x => x.FoodItems)
                .WithOne(x => x.Restaurant)
                .HasForeignKey(x => x.RestaurantId);

            modelBuilder.Entity<FoodItem>()
                .HasOne(x => x.Restaurant)
                .WithMany(x => x.FoodItems)
                .HasForeignKey(x => x.RestaurantId);

            modelBuilder.Entity<User>()
                .HasMany(x => x.Carts)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);

            var restaurant1 = new Restaurant
            {
                Id = Ulid.NewUlid().ToString(),
                Name = "Warung Pak Eko",
                
            };

            var restaurant2 = new Restaurant
            {
                Id = Ulid.NewUlid().ToString(),
                Name = "Geprek Sambal Bakar"
            };

            var restaurant3 = new Restaurant
            {
                Id = Ulid.NewUlid().ToString(),
                Name = "Kafe Hijau"
            };

            var user1 = new User
            {
                Id = Ulid.NewUlid().ToString(),
                Name = "user01",
                Email = "user01@gmail.com",
                Password = "password123"
            };

            var user2 = new User
            {
                Id = Ulid.NewUlid().ToString(),
                Name = "user02",
                Email = "user02@gmail.com",
                Password = "password231"
            };

            var user3 = new User
            {
                Id = Ulid.NewUlid().ToString(),
                Name = "user03",
                Email = "user03@gmail.com",
                Password = "password312"
            };

            var food1 = new FoodItem
            {
                Id = Ulid.NewUlid().ToString(),
                Name = "Empal Goreng",
                Price = 10000,
                RestaurantId = restaurant1.Id,
            };

            var food2 = new FoodItem
            {
                Id = Ulid.NewUlid().ToString(),
                Name = "Telur Balado",
                Price = 6000,
                RestaurantId = restaurant1.Id,
            };

            var food3 = new FoodItem
            {
                Id = Ulid.NewUlid().ToString(),
                Name = "Geprek Ayam",
                Price = 12000,
                RestaurantId = restaurant2.Id,
            };

            var food4 = new FoodItem
            {
                Id = Ulid.NewUlid().ToString(),
                Name = "Mie Geprek",
                Price = 15000,
                RestaurantId = restaurant2.Id,
            };

            var food5 = new FoodItem
            {
                Id = Ulid.NewUlid().ToString(),
                Name = "Cappucino Cincau",
                Price = 11000,
                RestaurantId = restaurant3.Id,
            };

            var food6 = new FoodItem
            {
                Id = Ulid.NewUlid().ToString(),
                Name = "Mocha Latte",
                Price = 21000,
                RestaurantId = restaurant3.Id,
            };

            modelBuilder.Entity<Restaurant>().HasData(restaurant1, restaurant2, restaurant3);
            modelBuilder.Entity<User>().HasData(user1,user2,user3);
            modelBuilder.Entity<FoodItem>().HasData(food1, food2, food3,food4,food5,food6);

        }

        public DbSet<User> Users  => Set<User>();
        public DbSet<Restaurant> Restaurants => Set<Restaurant>();
        public DbSet<Cart> Carts => Set<Cart>();
        public DbSet<CartDetail> CartDetails => Set<CartDetail>();
        public DbSet<FoodItem> FoodItems => Set<FoodItem>();

    }
}
