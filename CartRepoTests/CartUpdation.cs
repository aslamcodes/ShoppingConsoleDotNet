using ShoppingDALLib;
using SolutionModelLib;
using SolutionModelLib.Exceptions;

namespace CartRepoTests
{
    public class CartUpdation
    {
        private CartRepo _cartRepo;

        [SetUp]
        public void Setup()
        {
            _cartRepo = new CartRepo();
            _cartRepo.Add(new Cart(1, 1, null, []));
        }

        [Test]
        public void UpdateCartSuccess()
        {
            var cart = _cartRepo.GetByKey(1);

            cart.CartItems.Add(new CartItem(1, 1, null, 1, 1, new DateTime()));

            var updatedCart = _cartRepo.Update(cart);

            Assert.That(updatedCart, Is.Not.Null);
            Assert.That(updatedCart.CartItems.Count, Is.EqualTo(1));

        }

        [Test]
        public void UpdateCartFail()
        {
            var exception = Assert.Throws<EntityNotFoundException>(() => _cartRepo.GetByKey(2));

            Assert.That(exception.Message, Is.EqualTo("Cart not found"));
        }
    }
}