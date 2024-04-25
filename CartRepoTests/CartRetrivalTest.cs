using ShoppingDALLib;
using SolutionModelLib;
using SolutionModelLib.Exceptions;

namespace CartRepoTests
{
    public class CartRetrieval
    {
        private CartRepo _cartRepo;

        [SetUp]
        public void Setup()
        {
            _cartRepo = new CartRepo();
            _cartRepo.Add(new Cart(1, 1, null, []));
        }

        [Test]
        public void GetCartSuccess()
        {
            var cart = _cartRepo.GetByKey(1);

            Assert.That(cart, Is.Not.Null);
            Assert.That(cart.Id, Is.EqualTo(1));


        }

        [Test]
        public void GetCartFail()
        {
            var exception = Assert.Throws<EntityNotFoundException>(() => _cartRepo.GetByKey(2));

            Assert.That(exception.Message, Is.EqualTo("Cart not found"));
        }
    }
}