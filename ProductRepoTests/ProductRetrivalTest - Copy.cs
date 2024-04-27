using ShoppingDALLib;
using SolutionModelLib;
using SolutionModelLib.Exceptions;

namespace ProductRepoTests
{
    public class ProductRetrivalTests
    {
        private ProductRepository _productRepo;
        [SetUp]
        public void Setup()
        {
            _productRepo = new ProductRepository();

            Product product = new(1, 200, "Iphone", 2);

            _productRepo.Add(product);

        }

        [Test]
        public async Task GetProductSuccess()
        {
            var product = await _productRepo.GetByKey(1);

            Assert.That(product, Is.Not.Null);
            Assert.That(product.Id, Is.EqualTo(1));

        }

        [Test]
        public void GetProductFail()
        {
            var exception = Assert.ThrowsAsync<EntityNotFoundException>(async () => await _productRepo.GetByKey(2));

            Assert.That(exception.Message, Is.EqualTo("Product not found"));
        }
    }
}