using ShoppingBLLib;
using SolutionModelLib;
using SolutionModelLib.Exceptions;

namespace ProductBLTests;

public class ProductCreationTests
{
    private ProductService productService;
    [SetUp]
    public void Setup()
    {
        productService = new ProductService();
    }

    [Test]
    public void CreateProductSuccess()
    {
        var product = new Product(1, 100, "Phone 21", 10);

        productService.CreateProduct(product);

        Assert.That(product, Is.Not.Null);

    }

    [Test]
    public void CreateProductFails()
    {

        var exception = Assert.Throws<EntityNotFoundException>(() => productService.GetProductById(12));
        Assert.That(exception.Message, Is.EqualTo("Product not found"));

    }
}