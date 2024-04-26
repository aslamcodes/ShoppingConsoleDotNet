using ShoppingDALLib;
using SolutionModelLib;
using SolutionModelLib.Enums;
using SolutionModelLib.Exceptions;

namespace ShoppingBLLib
{
    public class ProductService : IProductService
    {
        private readonly ProductRepository productRepository;

        public ProductService()
        {
            productRepository = new ProductRepository();
        }

        public Product CreateProduct(Product product)
        {
            var createdProduct = productRepository.Add(product);

            return createdProduct;
        }

        public Product DeleteProduct(int id)
        {
            var product = productRepository.Delete(id);

            if (product == null)
            {
                throw new EntityNotFoundException(Entity.Product);
            }

            return product;
        }

        public Product GetProductById(int id)
        {
            var product = productRepository.GetByKey(id);

            if (product == null)
            {
                throw new EntityNotFoundException(Entity.Product);
            }

            return product;

        }

        public Product UpdateProduct(int id, Product product)
        {

            var updatedProduct = productRepository.Update(product);

            return updatedProduct;

        }
    }
}
