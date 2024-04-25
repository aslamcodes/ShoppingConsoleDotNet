using ShoppingBLLib;
using ShoppingDALLib;
using SolutionModelLib;
using SolutionModelLib.Exceptions;

namespace CartBLTests;

public class CartDeletionTests
{
    private CartService _cartService;
    private CartRepo _cartRepo;
    private ProductRepository _productRepo;
    private CustomerRepository _customerRepository;
    [SetUp]
    public void Setup()
    {
        _cartRepo = new CartRepo();
        _cartService = new CartService(_cartRepo);
        _customerRepository = new CustomerRepository();
        _productRepo = new ProductRepository();



        var product1 = new Product(1, 100, "GameBoy", 10);
        var product2 = new Product(2, 200, "GameBoy Pro", 10);

        _productRepo.Add(product1);
        _productRepo.Add(product2);

        var cartItem1 = new CartItem(1, 1, product1, 12, 1002, new DateTime(2024, 12, 12));
        var cartItem2 = new CartItem(1, 2, product1, 12, 100, new DateTime(2024, 12, 12));

        var customer = new Customer(1, "123", 12);
        _customerRepository.Add(customer);
        _cartRepo.Add(new Cart(1, 1, customer, [cartItem1, cartItem2]));



    }

    [Test]
    public void DeleteCartSuccess()
    {
        // Action
        var cart = _cartService.DeleteCart(1);

        // Assert
        Assert.That(cart, Is.Not.Null);
        Assert.That(cart.Id, Is.EqualTo(1));
    }

    [Test]
    public void DeleteCartFailure()
    {
        // Assert
        var exception = Assert.Throws<EntityNotFoundException>(() => _cartService.DeleteCart(2));
        Assert.That(exception.Message, Is.EqualTo("Cart not found"));
    }

}