using DotNetCore2GraphQL.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore2GraphQL.Data.Repositories
{
    public interface IProductReviewRepository
    {
        Task<List<ProductReview>> GetForProduct(int productId);
        Task<ILookup<int, ProductReview>> GetForProducts(IEnumerable<int> productIds);
        Task<ProductReview> AddReview(ProductReview productReview);
    }
    public class ProductReviewRepository : IProductReviewRepository
    {
        private readonly CarvedRockContext _context;
        public async Task<ProductReview> AddReview(ProductReview productReview)
        {
             _context.ProductReviews.Add(productReview);
            await _context.SaveChangesAsync();
            return productReview;
        }
        public ProductReviewRepository(CarvedRockContext context)
        {
            this._context = context;
        }
        public async Task<List<ProductReview>> GetForProduct(int productId)
        {
            return await _context.ProductReviews.Where(p => p.ProductId == productId).ToListAsync();
        }

        public async Task<ILookup<int, ProductReview>> GetForProducts(IEnumerable<int> productIds)
        {
            var reviews= await _context.ProductReviews.Where(p => productIds.Contains(p.ProductId)).ToListAsync();
            return reviews.ToLookup(r => r.ProductId);
        }
    }
}
