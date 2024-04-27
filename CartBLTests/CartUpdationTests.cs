using ShoppingBLLib;
using ShoppingDALLib;
using SolutionModelLib;

namespace CartBLTests;

public class CartUpdationTests
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
        _productRepo.Add(product1);

        var cartItem1 = new CartItem(1, 1, product1, 12, 1002, new DateTime(2024, 12, 12));

        var customer = new Customer(1, "123", 12);
        _customerRepository.Add(customer);


        _cartRepo.Add(new Cart(1, 1, customer, [cartItem1]));
    }


    [Test]
    public void CartUpdationTest()
    {
        var customer = new Customer(1, "123", 12);
        var newCart = new Cart(1, 1, customer, []);
        var cart = _cartService.UpdateCartAsync(1, newCart);

        Assert.That(cart, Is.Not.Null);
        Assert.That(cart.CartItems, Has.Count.EqualTo(0));
    }


}