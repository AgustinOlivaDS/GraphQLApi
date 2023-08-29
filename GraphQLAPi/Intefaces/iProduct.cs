using GraphQLAPi.Models;

namespace GraphQLAPi.Intefaces
{
    public interface iProduct
    {
        List<Product> GetAllProducts();

        Product AddProduct(Product product);

        Product UpdateProduct(int id, Product product);

        void DeleteProduct(int id);

        Product GetProductById(int id);

    }
}
