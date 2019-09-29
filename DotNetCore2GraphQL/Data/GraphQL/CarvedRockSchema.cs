using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore2GraphQL.Data.GraphQL
{
    public class CarvedRockSchema:Schema
    {
        public CarvedRockSchema(IDependencyResolver dependencyResolver):base(dependencyResolver)
        {
            Query = dependencyResolver.Resolve<CarvedRockQuery>();
            Mutation = dependencyResolver.Resolve<CarvedRockMutation>();
        }
    }
}
