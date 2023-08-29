using GraphQLAPi.Mutation;
using GraphQLAPi.Query;

namespace GraphQLAPi.Schema
{
    public class ProductSchema : GraphQL.Types.Schema
    {
        public ProductSchema(ProductQuery productQuery, ProductMutation productMutation) {
            Query = productQuery;
            Mutation = productMutation;
        }
    }
}
