using DotNetCore2GraphQL.Data.Models;
using DotNetCore2GraphQL.Data.Repositories;
using GraphQL.DataLoader;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore2GraphQL.Data.GraphQL.Types
{
    public class ProductType: ObjectGraphType<Product>
    {
        public ProductType(IProductReviewRepository productReviewRepository, IDataLoaderContextAccessor dataLoaderContextAccessor)
        //public ProductType()

        {
            Field(p => p.Id);
            Field(p => p.Name);
            Field(p => p.Price);
            Field<ProductTypeEnumType>("Type", "The type of product");
            Field<ListGraphType<ProductReviewType>>(
                "reviews",
                resolve: context =>
                {
                    //return productReviewRepository.GetForProduct(context.Source.Id); 
                    var loader = dataLoaderContextAccessor.Context.GetOrAddCollectionBatchLoader<int, ProductReview>(
                        "GetReviewsByProductId", productReviewRepository.GetForProducts);
                    return loader.LoadAsync(context.Source.Id);
                }
                );
        }
    }
}
