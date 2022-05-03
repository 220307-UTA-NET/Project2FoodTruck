﻿// <auto-generated />
using System;
using FoodTruckAPI.ClassLibrary.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FoodTruckAPI.ClassLibrary.Migrations
{
    [DbContext(typeof(FoodTruckContext))]
    [Migration("20220503020050_AddTruckBool")]
    partial class AddTruckBool
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("foodtruck")
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FoodTruckAPI.ClassLibrary.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeID"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("EmployeeID");

                    b.ToTable("Employees", "foodtruck");
                });

            modelBuilder.Entity("FoodTruckAPI.ClassLibrary.Models.EmployeeTruckLink", b =>
                {
                    b.Property<int>("EmployeeTruckLinkID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeTruckLinkID"), 1L, 1);

                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<int>("TruckID")
                        .HasColumnType("int");

                    b.HasKey("EmployeeTruckLinkID");

                    b.HasIndex("TruckID");

                    b.ToTable("EmployeeTruckLinks", "foodtruck");
                });

            modelBuilder.Entity("FoodTruckAPI.ClassLibrary.Models.Menu", b =>
                {
                    b.Property<int>("MenuID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MenuID"), 1L, 1);

                    b.Property<string>("MenuName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MenuID");

                    b.ToTable("Menus", "foodtruck");
                });

            modelBuilder.Entity("FoodTruckAPI.ClassLibrary.Models.MenuItem", b =>
                {
                    b.Property<int>("MenuItemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MenuItemID"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FoodType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("MenuItemID");

                    b.ToTable("MenuItems", "foodtruck");
                });

            modelBuilder.Entity("FoodTruckAPI.ClassLibrary.Models.MenuItemLink", b =>
                {
                    b.Property<int>("MenuItemLinkID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MenuItemLinkID"), 1L, 1);

                    b.Property<int>("MenuID")
                        .HasColumnType("int");

                    b.Property<int>("MenuItemID")
                        .HasColumnType("int");

                    b.HasKey("MenuItemLinkID");

                    b.HasIndex("MenuID");

                    b.ToTable("MenuItemLinks", "foodtruck");
                });

            modelBuilder.Entity("FoodTruckAPI.ClassLibrary.Models.Truck", b =>
                {
                    b.Property<int>("TruckID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TruckID"), 1L, 1);

                    b.Property<DateTime>("Day")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MenuID")
                        .HasColumnType("int");

                    b.HasKey("TruckID");

                    b.ToTable("Trucks", "foodtruck");
                });

            modelBuilder.Entity("FoodTruckAPI.ClassLibrary.Models.EmployeeTruckLink", b =>
                {
                    b.HasOne("FoodTruckAPI.ClassLibrary.Models.Truck", null)
                        .WithMany("workingEmployees")
                        .HasForeignKey("TruckID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FoodTruckAPI.ClassLibrary.Models.MenuItemLink", b =>
                {
                    b.HasOne("FoodTruckAPI.ClassLibrary.Models.Menu", null)
                        .WithMany("Links")
                        .HasForeignKey("MenuID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FoodTruckAPI.ClassLibrary.Models.Menu", b =>
                {
                    b.Navigation("Links");
                });

            modelBuilder.Entity("FoodTruckAPI.ClassLibrary.Models.Truck", b =>
                {
                    b.Navigation("workingEmployees");
                });
#pragma warning restore 612, 618
        }
    }
}
