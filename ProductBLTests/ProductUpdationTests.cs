using ShoppingBLLib;
using SolutionModelLib;
using SolutionModelLib.Exceptions;

namespace ProductBLTests;

public class ProductUpdationTests
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
    public void UpdateProductTests()
    {
        var product = productService.UpdateProductAsync(1, new Product(1, 110, "Phone 2A", 1));

        Assert.That(product, Is.Not.Null);

        Assert.Multiple(() =>
        {
            Assert.That(product.Name, Is.EqualTo("Phone 2A"));
            Assert.That(product.Price, Is.EqualTo(110));
            Assert.That(product.QuantityInHand, Is.EqualTo(1));
        });

    }

    [Test]
    public void DeleteProductFails()
    {

        var exception = Assert.Throws<EntityNotFoundException>(() => productService.UpdateProductAsync(11, new Product(11, 110, "Phone 2A", 1)));
        Assert.That(exception.Message, Is.EqualTo("Product not found"));

    }
}