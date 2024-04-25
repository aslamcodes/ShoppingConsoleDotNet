using SolutionModelLib;

namespace ShoppingBLLib
{
    public interface IProductService
    {
        Product GetProductById(int id);

        Product UpdateProduct(int id, Product product);

        Product DeleteProduct(int id);

        Product CreateProduct(Product product);

    }
}
