using SolutionModelLib;

namespace ShoppingBLLib
{
    public interface IProductService
    {
        Task<Product> GetProductByIdAsync(int id);

        Task<Product> UpdateProductAsync(int id, Product product);

        Task<Product> DeleteProductAsync(int id);

        Task<Product> CreateProductAsync(Product product);

    }
}
