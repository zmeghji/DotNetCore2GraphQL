using DotNetCore2GraphQL.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore2GraphQL.Data
{
    public class CarvedRockContext:DbContext
    {
        public CarvedRockContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductReview> ProductReviews { get; set; }
    }
    public static class CarvedRockContextExtensions
    {
        public static void InitializeData(this CarvedRockContext context)
        {
            for (int i = 0; i < 99; i++)
            {
                var product = new Product
                {
                    Name = $"Product {i}",
                    Price = i
                };
                if (i % 3 == 2)
                {
                    product.Type = ProductType.Backpack;
                }
                else if (i % 3 == 1)
                {
                    product.Type = ProductType.Boots;
                }
                else
                {
                    product.Type = ProductType.Kayak;
                }
                context.Products.Add(product);

                var review = new ProductReview
                {
                    Title = $"Product {i} Review",
                    ProductId = i
                };
                if (i % 2==1)
                {
                    review.Review = "Good Product";
                }
                else
                {
                    review.Review = "Bad Product";
                }
                context.ProductReviews.Add(review);
            }
            context.SaveChanges();
        }
    }
}
