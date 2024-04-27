using ShoppingBLLib;
using SolutionModelLib;
using SolutionModelLib.Exceptions;

namespace ProductBLTests;

public class Tests
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
    public void GetProductTests()
    {
        var product = productService.GetProductByIdAsync(1);

        Assert.That(product, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(product.Id, Is.EqualTo(1));
            Assert.That(product.QuantityInHand, Is.EqualTo(10));
        });

    }

    [Test]
    public void GetProductFails()
    {

        var exception = Assert.Throws<EntityNotFoundException>(() => productService.GetProductByIdAsync(12));
        Assert.That(exception.Message, Is.EqualTo("Product not found"));

    }
}