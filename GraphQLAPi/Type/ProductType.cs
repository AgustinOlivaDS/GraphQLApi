using GraphQL.Types;
using GraphQLAPi.Models;

namespace GraphQLAPi.Type
{
    public class ProductType : ObjectGraphType<Product>
    {
        public ProductType()
        {
            Field(p => p.id);
            Field(p => p.Name);
            Field(p => p.Price);
        }
    }
}
