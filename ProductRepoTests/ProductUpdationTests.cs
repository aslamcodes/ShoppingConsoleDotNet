using ShoppingDALLib;
using SolutionModelLib;
using SolutionModelLib.Exceptions;

namespace ProductRepoTests
{
    public class ProductUpdationTests
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
        public void UpdateProductSucess()
        {
            var product = _productRepo.GetByKey(1);

            product.Name = "Samsung";

            var updatedProduct = _productRepo.Update(product);


            Assert.That(updatedProduct, Is.Not.Null);
            Assert.That(updatedProduct.Id, Is.EqualTo(1));
            Assert.That(updatedProduct.Name, Is.EqualTo("Samsung"));

        }

        [Test]
        public void UpdateProductFailure()
        {
            var exception = Assert.Throws<EntityNotFoundException>(() => _productRepo.Update(_productRepo.GetByKey(2)));

            Assert.That(exception.Message, Is.EqualTo("Product not found"));
        }
    }
}