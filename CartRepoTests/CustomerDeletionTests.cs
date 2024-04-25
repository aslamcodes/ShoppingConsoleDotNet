using ShoppingDALLib;
using SolutionModelLib;
using SolutionModelLib.Exceptions;

namespace CartRepoTests
{
    public class CartDeletionTests
    {
        private CartRepo _cartRepository;

        [SetUp]
        public void Setup()
        {
            _cartRepository = new CartRepo();
            _cartRepository.Add(new Cart(1, 1, null, []));

        }

        [Test]
        public void DeleteCartSuccess()
        {

            var cart = _cartRepository.Delete(1);

            Assert.That(cart, Is.Not.Null);
            Assert.That(cart.Id, Is.EqualTo(1));
            Assert.Throws<EntityNotFoundException>(() => _cartRepository.Delete(1));
        }

        [Test]
        public void DeleteCartFail()
        {
            var exception = Assert.Throws<EntityNotFoundException>(() => _cartRepository.Delete(2));

            Assert.That(exception.Message, Is.EqualTo("Cart not found"));
        }
    }
}