using DotNetCore2GraphQL.Data.GraphQL.Types;
using DotNetCore2GraphQL.Data.Models;
using DotNetCore2GraphQL.Data.Repositories;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore2GraphQL.Data.GraphQL
{
    public class CarvedRockMutation:ObjectGraphType
    {
        public CarvedRockMutation(IProductReviewRepository productReviewRepository)
        {
            FieldAsync<ProductReviewType>(
                "createReview",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ProductReviewInputType>> { Name = "review" }),
                resolve: async context =>
                {
                    var review = context.GetArgument<ProductReview>("review");
                    return await context.TryAsyncResolve(
                        async c=> await productReviewRepository.AddReview(review)
                        );
                }
                );
        }
    }
}
