using GraphQLAPi.Data;
using GraphQLAPi.Intefaces;
using GraphQLAPi.Models;
using System.Reflection.Metadata.Ecma335;

namespace GraphQLAPi.Services
{
    public class ProductService : iProduct
    {
        //private static List<Product> products = new List<Product>() { 
        //    new Product(){ id = 0, Name = "Coffee", Price = 10 },
        //    new Product(){ id = 1, Name = "Tea", Price = 8.5  },
        //    new Product(){ id = 2, Name = "Coke", Price = 11.3 }
        //};
        private GraphQLDbContext _dbContext;

        public ProductService(GraphQLDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        Product iProduct.AddProduct(Product product)
        {
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
            return product;

        }

        void iProduct.DeleteProduct(int id)
        {
            var productObj = _dbContext.Products.Find(id);
            _dbContext.Products.Remove(productObj);
            _dbContext.SaveChanges();
        }

        List<Product> iProduct.GetAllProducts()
        {
            return _dbContext.Products.ToList();
        }

        Product iProduct.GetProductById(int id)
        {
            return _dbContext.Products.Find(id);
        }

        Product iProduct.UpdateProduct(int id, Product product)
        {
            var productObj = _dbContext.Products.Find(id);

            productObj.Name = product.Name;
            productObj.Price = product.Price;
            _dbContext.SaveChanges();
            return product;
        }
    }
}
