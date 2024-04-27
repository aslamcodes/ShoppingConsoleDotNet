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

        productService.CreateProductAsync(product);
    }

    [Test]
    public void DeleteProductSuccess()
    {
        var product = productService.DeleteProductAsync(1);

        Assert.That(product, Is.Not.Null);
        Assert.Throws<EntityNotFoundException>(() => productService.GetProductByIdAsync(1));

    }

    [Test]
    public void DeleteProductFails()
    {

        var exception = Assert.Throws<EntityNotFoundException>(() => productService.GetProductByIdAsync(12));
        Assert.That(exception.Message, Is.EqualTo("Product not found"));

    }
}