using ShoppingBLLib;
using ShoppingDALLib;
using SolutionModelLib;
using SolutionModelLib.Exceptions;

namespace CartBLTests;

public class CartCreationTests
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
    }

    [Test]
    public void CreateCart()
    {
        // Arange

        var customer = new Customer(1, "123", 12);
        _customerRepository.Add(customer);

        // Action
        var cart = _cartService.CreateCartAsync(new Cart(1, 1, customer, []));

        // Assert
        Assert.That(cart, Is.Not.Null);
        Assert.That(cart.Id, Is.EqualTo(1));
    }

    [Test]
    public void CreateCartFail()
    {
        var customer = new Customer(1, "123", 12);
        _customerRepository.Add(customer);

        var cart = new Cart(1, 1, customer, []);
        _cartService.CreateCartAsync(cart);

        Assert.Throws<DuplicateEntityException>(() => _cartService.CreateCartAsync(cart));
    }

}