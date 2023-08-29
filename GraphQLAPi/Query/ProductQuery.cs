using GraphQL;
using GraphQL.Types;
using GraphQLAPi.Intefaces;
using GraphQLAPi.Type;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace GraphQLAPi.Query
{
    public class ProductQuery : ObjectGraphType
    {
        public ProductQuery(iProduct productService) {
            Field<ListGraphType<ProductType>>("products", resolve : context => { return productService.GetAllProducts(); });

            Field<ProductType>("product", arguments : new QueryArguments( new QueryArgument<IntGraphType> { Name = "id" }), 
                resolve: context => { return productService.GetProductById(context.GetArgument<int>("id")); });
        }
    }
}
