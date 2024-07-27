using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.ProductId);
            builder.Property(p => p.ProductName).IsRequired();
            builder.Property(p => p.Price).IsRequired();

            builder.HasData(
                new Product()
                {
                    ProductId = 1,
                    CategoryId = 2,
                    ProductName = "Computer",
                    Price = 15000
                },
                new Product()
                {
                    ProductId = 2,
                    CategoryId = 2,
                    ProductName = "Keyboard",
                    Price = 1500
                },
                new Product()
                {
                    ProductId = 3,
                    CategoryId = 2,
                    ProductName = "Mouse",
                    Price = 500
                },
                new Product()
                {
                    ProductId = 4,
                    CategoryId = 2,
                    ProductName = "Monitor",
                    Price = 5000
                },
                new Product()
                {
                    ProductId = 5,
                    CategoryId = 2,
                    ProductName = "Deck",
                    Price = 1000
                },
                new Product()
                {
                    ProductId = 6,
                    CategoryId = 1,
                    ProductName = "A Novel",
                    Price = 100
                },
                new Product()
                {
                    ProductId = 7,
                    CategoryId = 1,
                    ProductName = "Hamlet",
                    Price = 25
                }
            );
        }
    }
}