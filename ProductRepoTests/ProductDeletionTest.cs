using ShoppingDALLib;
using SolutionModelLib;
using SolutionModelLib.Exceptions;

namespace ProductRepoTests
{
    public class ProductDeletionTests
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
        public async Task DeleteProductSuccess()
        {
            var product = await _productRepo.Delete(1);

            Assert.That(product, Is.Not.Null);
            Assert.That(product.Id, Is.EqualTo(1));

        }

        [Test]
        public void DeleteProductFail()
        {
            var exception = Assert.ThrowsAsync<EntityNotFoundException>(async () => await _productRepo.Delete(2));

            Assert.That(exception.Message, Is.EqualTo("Product not found"));
        }
    }
}