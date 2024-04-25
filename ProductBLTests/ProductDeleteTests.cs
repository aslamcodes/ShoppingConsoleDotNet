using ShoppingBLLib;
using SolutionModelLib;
using SolutionModelLib.Exceptions;

namespace ProductBLTests;

public class ProductDeletionTests
{
    private ProductService productService;
    [SetUp]
    public void Setup()
    {
        productService = new ProductService();

        var product = new Product(1, 100, "Phone 21", 10);

        productService.CreateProduct(product);
    }

    [Test]
    public void DeleteProductSuccess()
    {
        var product = productService.DeleteProduct(1);

        Assert.That(product, Is.Not.Null);
        Assert.Throws<EntityNotFoundException>(() => productService.GetProductById(1));

    }

    [Test]
    public void DeleteProductFails()
    {

        var exception = Assert.Throws<EntityNotFoundException>(() => productService.GetProductById(12));
        Assert.That(exception.Message, Is.EqualTo("Product not found"));

    }
}