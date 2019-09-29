using DotNetCore2GraphQL.Data.Models;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore2GraphQL.Data.GraphQL.Types
{
    public class ProductReviewType:ObjectGraphType<ProductReview>
    {
        public ProductReviewType()
        {
            Field(p => p.Id);
            Field(p => p.Title);
            Field(p => p.Review);
        }
    }
}
