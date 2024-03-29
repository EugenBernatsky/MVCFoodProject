﻿// <auto-generated />
using System;
using MVCFoodProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MVCFoodProject.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240102221910_InitAuth")]
    partial class InitAuth
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MVCFoodProject.Models.DataBase.Courier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<string>("imgURl")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Courier");
                });

            modelBuilder.Entity("MVCFoodProject.Models.DataBase.Orders", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CourierID")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("TotalPrice")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("MVCFoodProject.Models.DataBase.ProductOrders", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Total")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductOrder");
                });

            modelBuilder.Entity("MVCFoodProject.Models.DataBase.Products", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CategoryType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("InternalId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("ProductsDetailsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductsDetailsId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("MVCFoodProject.Models.DataBase.ProductsDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("imgURL")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("ProductsDetails");
                });

            modelBuilder.Entity("MVCFoodProject.Models.DataBase.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<int?>("UserOrdersId")
                        .HasColumnType("int");

                    b.Property<string>("imgURL")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("UserOrdersId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("MVCFoodProject.Models.DataBase.Courier", b =>
                {
                    b.HasOne("MVCFoodProject.Models.DataBase.Orders", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("MVCFoodProject.Models.DataBase.ProductOrders", b =>
                {
                    b.HasOne("MVCFoodProject.Models.DataBase.Orders", "Order")
                        .WithMany("ProductOrders")
                        .HasForeignKey("OrderId");

                    b.HasOne("MVCFoodProject.Models.DataBase.Products", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("MVCFoodProject.Models.DataBase.Products", b =>
                {
                    b.HasOne("MVCFoodProject.Models.DataBase.ProductsDetails", "ProductsDetails")
                        .WithMany()
                        .HasForeignKey("ProductsDetailsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductsDetails");
                });

            modelBuilder.Entity("MVCFoodProject.Models.DataBase.Users", b =>
                {
                    b.HasOne("MVCFoodProject.Models.DataBase.Orders", "UserOrders")
                        .WithMany()
                        .HasForeignKey("UserOrdersId");

                    b.Navigation("UserOrders");
                });

            modelBuilder.Entity("MVCFoodProject.Models.DataBase.Orders", b =>
                {
                    b.Navigation("ProductOrders");
                });
#pragma warning restore 612, 618
        }
    }
}
