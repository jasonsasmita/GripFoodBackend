﻿// <auto-generated />
using GripFoodEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GripFoodEntities.Migrations
{
    [DbContext(typeof(GripFoodDbContext))]
    [Migration("20230417045335_GripFoodMigrate")]
    partial class GripFoodMigrate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.16");

            modelBuilder.Entity("GripFoodEntities.Cart", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("RestaurantId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.HasIndex("UserId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("GripFoodEntities.CartDetail", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("CartId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FoodItemId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Qty")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("FoodItemId");

                    b.ToTable("CartDetails");
                });

            modelBuilder.Entity("GripFoodEntities.FoodItem", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Price")
                        .HasColumnType("INTEGER");

                    b.Property<string>("RestaurantId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.ToTable("FoodItems");

                    b.HasData(
                        new
                        {
                            Id = "01GY6RZ9X6XJJMAX76B9F2RKTQ",
                            Name = "Empal Goreng",
                            Price = 10000,
                            RestaurantId = "01GY6RZ9X6DJ4Q712S7314DFG4"
                        },
                        new
                        {
                            Id = "01GY6RZ9X6XTW8KHAEX7RSTHN0",
                            Name = "Telur Balado",
                            Price = 6000,
                            RestaurantId = "01GY6RZ9X6DJ4Q712S7314DFG4"
                        },
                        new
                        {
                            Id = "01GY6RZ9X614BW04Y4W5PADAH7",
                            Name = "Geprek Ayam",
                            Price = 12000,
                            RestaurantId = "01GY6RZ9X65QR5WMKGXEBTV1C3"
                        },
                        new
                        {
                            Id = "01GY6RZ9X674AZTTNKGA8ZVBXJ",
                            Name = "Mie Geprek",
                            Price = 15000,
                            RestaurantId = "01GY6RZ9X65QR5WMKGXEBTV1C3"
                        },
                        new
                        {
                            Id = "01GY6RZ9X6EYBY2Z23QX7GXNVM",
                            Name = "Cappucino Cincau",
                            Price = 11000,
                            RestaurantId = "01GY6RZ9X6W38Z0B9NX9SPVT7R"
                        },
                        new
                        {
                            Id = "01GY6RZ9X6WXSEFS0WB170SHXG",
                            Name = "Mocha Latte",
                            Price = 21000,
                            RestaurantId = "01GY6RZ9X6W38Z0B9NX9SPVT7R"
                        });
                });

            modelBuilder.Entity("GripFoodEntities.Restaurant", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Restaurants");

                    b.HasData(
                        new
                        {
                            Id = "01GY6RZ9X6DJ4Q712S7314DFG4",
                            Name = "Warung Pak Eko"
                        },
                        new
                        {
                            Id = "01GY6RZ9X65QR5WMKGXEBTV1C3",
                            Name = "Geprek Sambal Bakar"
                        },
                        new
                        {
                            Id = "01GY6RZ9X6W38Z0B9NX9SPVT7R",
                            Name = "Kafe Hijau"
                        });
                });

            modelBuilder.Entity("GripFoodEntities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = "01GY6RZ9X63A2DX1DPGG9JZ9E0",
                            Email = "user01@gmail.com",
                            Name = "user01",
                            Password = "password123"
                        },
                        new
                        {
                            Id = "01GY6RZ9X6XE89K32EAVKASWXF",
                            Email = "user02@gmail.com",
                            Name = "user02",
                            Password = "password231"
                        },
                        new
                        {
                            Id = "01GY6RZ9X6F52CBC9NFD3YGG2H",
                            Email = "user03@gmail.com",
                            Name = "user03",
                            Password = "password312"
                        });
                });

            modelBuilder.Entity("GripFoodEntities.Cart", b =>
                {
                    b.HasOne("GripFoodEntities.Restaurant", "Restaurant")
                        .WithMany("Carts")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GripFoodEntities.User", "User")
                        .WithMany("Carts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");

                    b.Navigation("User");
                });

            modelBuilder.Entity("GripFoodEntities.CartDetail", b =>
                {
                    b.HasOne("GripFoodEntities.Cart", "Cart")
                        .WithMany("CartDetails")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GripFoodEntities.FoodItem", "FoodItem")
                        .WithMany("CartDetails")
                        .HasForeignKey("FoodItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("FoodItem");
                });

            modelBuilder.Entity("GripFoodEntities.FoodItem", b =>
                {
                    b.HasOne("GripFoodEntities.Restaurant", "Restaurant")
                        .WithMany("FoodItems")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("GripFoodEntities.Cart", b =>
                {
                    b.Navigation("CartDetails");
                });

            modelBuilder.Entity("GripFoodEntities.FoodItem", b =>
                {
                    b.Navigation("CartDetails");
                });

            modelBuilder.Entity("GripFoodEntities.Restaurant", b =>
                {
                    b.Navigation("Carts");

                    b.Navigation("FoodItems");
                });

            modelBuilder.Entity("GripFoodEntities.User", b =>
                {
                    b.Navigation("Carts");
                });
#pragma warning restore 612, 618
        }
    }
}
