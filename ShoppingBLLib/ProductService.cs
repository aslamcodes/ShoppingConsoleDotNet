using ShoppingDALLib;
using SolutionModelLib;

namespace ShoppingBLLib
{
    public class ProductService : IProductService
    {
        private readonly ProductRepository productRepository;

        public ProductService()
        {
            productRepository = new ProductRepository();
        }

        public Task<Product> CreateProductAsync(Product product)
        {
            var createdProduct = productRepository.Add(product);

            return createdProduct;
        }

        public Task<Product> DeleteProductAsync(int id)
        {
            var product = productRepository.Delete(id);

            return product;
        }

        public Task<Product> GetProductByIdAsync(int id)
        {
            var product = productRepository.GetByKey(id);

            return product;

        }

        public Task<Product> UpdateProductAsync(int id, Product product)
        {

            var updatedProduct = productRepository.Update(product);

            return updatedProduct;

        }
    }
}
