﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repositories;

#nullable disable

namespace StoreApp.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20240721192240_Category")]
    partial class Category
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.0");

            modelBuilder.Entity("Entities.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Books"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Technology"
                        });
                });

            modelBuilder.Entity("Entities.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProductName")
                        .HasColumnType("TEXT");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            Price = 15000m,
                            ProductName = "Computer"
                        },
                        new
                        {
                            ProductId = 2,
                            Price = 1500m,
                            ProductName = "Keyboard"
                        },
                        new
                        {
                            ProductId = 3,
                            Price = 500m,
                            ProductName = "Mouse"
                        },
                        new
                        {
                            ProductId = 4,
                            Price = 5000m,
                            ProductName = "Monitor"
                        },
                        new
                        {
                            ProductId = 5,
                            Price = 1000m,
                            ProductName = "Deck"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
