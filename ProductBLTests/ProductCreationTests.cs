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
    public async Task CreateProductSuccess()
    {
        var product = new Product(1, 100, "Phone 21", 10);

        await productService.CreateProductAsync(product);

        Assert.That(product, Is.Not.Null);

    }

    [Test]
    public void CreateProductFails()
    {

        var exception = Assert.ThrowsAsync<EntityNotFoundException>(async () => await productService.GetProductByIdAsync(12));
        Assert.That(exception.Message, Is.EqualTo("Product not found"));

    }
}