﻿using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class RepositoryContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public RepositoryContext(DbContextOptions<RepositoryContext> options)
        : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
            .HasData(
                new Product()
                {
                    ProductId = 1,
                    ProductName = "Computer",
                    Price = 15000
                },
                new Product()
                {
                    ProductId = 2,
                    ProductName = "Keyboard",
                    Price = 1500
                },
                new Product()
                {
                    ProductId = 3,
                    ProductName = "Mouse",
                    Price = 500
                },
                new Product()
                {
                    ProductId = 4,
                    ProductName = "Monitor",
                    Price = 5000
                },
                new Product()
                {
                    ProductId = 5,
                    ProductName = "Deck",
                    Price = 1000
                }
            );
            
            modelBuilder.Entity<Category>()
            .HasData(
                new Category(){
                    CategoryId = 1,
                    CategoryName = "Books"
                },
                new Category(){
                    CategoryId = 2,
                    CategoryName = "Technology"
                }
            );
        }

    }
}

