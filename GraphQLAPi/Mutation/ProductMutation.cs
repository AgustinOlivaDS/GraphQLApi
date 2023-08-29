using GraphQL;
using GraphQL.Types;
using GraphQLAPi.Intefaces;
using GraphQLAPi.Models;
using GraphQLAPi.Type;

namespace GraphQLAPi.Mutation
{
    public class ProductMutation : ObjectGraphType
    {
        public ProductMutation(iProduct productService) {


            Field<ProductType>("createProduct", arguments: new QueryArguments(new QueryArgument<ProductInputType> { Name = "product" }),
                resolve: context => { return productService.AddProduct(context.GetArgument<Product>("product")); });

            Field<ProductType>("updateProduct", 
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }, new QueryArgument<ProductInputType> { Name = "product" }),
                resolve: context => {
                    var productObj = context.GetArgument<Product>("product"); 
                    return productService.UpdateProduct(context.GetArgument<int>("id"), productObj); 
                });

            Field<StringGraphType>("deleteProduct", arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context => { 
                    productService.DeleteProduct(context.GetArgument<int>("id"));
                    return "The product has been deleted";
                });

        }
    }
}
