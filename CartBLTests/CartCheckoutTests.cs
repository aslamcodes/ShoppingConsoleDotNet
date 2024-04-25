using ShoppingBLLib;
using ShoppingDALLib;
using SolutionModelLib;

namespace CartBLTests;

public class CartCheckoutTests
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

        var product1 = new Product(1, 100, "GameBoy Basic", 10);
        var product2 = new Product(2, 1000, "GameBoy Pro", 10);
        var product3 = new Product(3, 700, "GameBoy Plus", 10);

        _productRepo.Add(product1);
        _productRepo.Add(product2);
        _productRepo.Add(product3);

        var cartItem1 = new CartItem(1, 1, product1, 5, product1.Price, new DateTime(2024, 12, 12));
        var cartItem2 = new CartItem(1, 2, product2, 1, product2.Price, new DateTime(2024, 12, 12));
        var cartItem3 = new CartItem(1, 3, product3, 1, product3.Price, new DateTime(2024, 12, 12));

        var customer = new Customer(1, "123", 12);
        _customerRepository.Add(customer);


        _cartRepo.Add(new Cart(1, 1, customer, [cartItem1, cartItem2, cartItem3]));
    }


    [Test]
    public void CartCheckoutTest()
    {
        (double total, string paymentDetails) = _cartService.GetCartTotal(1);

        Assert.That(total, Is.EqualTo(2700 - 2700 * 0.05));
        Assert.That(paymentDetails, Is.EqualTo("GameBoy Basic ==> 100 + 100rs(delivery) X 5\nGameBoy Pro ==> 1000 X 1\nGameBoy Plus ==> 700 X 1\n\t\tDiscount = -128.25\nTotal = $2565"));
    }


}