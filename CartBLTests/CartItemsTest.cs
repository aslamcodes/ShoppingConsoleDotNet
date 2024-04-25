using ShoppingBLLib;
using ShoppingDALLib;
using SolutionModelLib;
using SolutionModelLib.Exceptions;

namespace CartBLTests;

public class CartItemsTests
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
    public void TestAddItemsToCart()
    {
        // Arange
        var product = new Product(2, 200, "GameBoy Pro", 10);
        _productRepo.Add(product);
        var cartItem = new CartItem(2, 2, product, 12, 100, new DateTime(2024, 12, 12));
        List<CartItem> cartItemsToAdd = [cartItem];

        // Action
        Cart cart = _cartService.AddItemstoCart(1, cartItemsToAdd);

        // Assert
        Assert.That(cart.CartItems, Has.Count.EqualTo(2));
        Assert.That(cart.CartItems[1].CartId, Is.EqualTo(2));
    }

    [Test]
    public void TestAddItemsToCartFail()
    {
        // Arange
        var product = new Product(2, 200, "GameBoy Pro", 10);
        _productRepo.Add(product);
        var cartItem = new CartItem(2, 2, product, 12, 100, new DateTime(2024, 12, 12));
        var cartItem2 = new CartItem(2, 2, product, 12, 100, new DateTime(2024, 12, 12));
        var cartItem3 = new CartItem(2, 2, product, 12, 100, new DateTime(2024, 12, 12));
        var cartItem4 = new CartItem(2, 2, product, 12, 100, new DateTime(2024, 12, 12));
        var cartItem5 = new CartItem(2, 2, product, 12, 100, new DateTime(2024, 12, 12));
        var cartItem6 = new CartItem(2, 2, product, 12, 100, new DateTime(2024, 12, 12));


        List<CartItem> cartItemsToAdd = [cartItem, cartItem2, cartItem3, cartItem4, cartItem5, cartItem6];

        // Action
        Assert.Throws<CartFullException>(() => _cartService.AddItemstoCart(1, cartItemsToAdd));

    }


    [Test]
    public void RemoveItemsFromCart()
    {
        var cart = _cartService.RemoveItemsFromCart(1, [1]);

        Assert.That(cart.CartItems, Is.Empty);
    }
}