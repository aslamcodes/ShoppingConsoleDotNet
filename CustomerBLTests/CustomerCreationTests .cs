using ShoppingBLLib;
using SolutionModelLib;

namespace CustomerBLTests;

public class CustomerCreationTests
{
    private CustomerService customerService;

    [SetUp]
    public void Setup()
    {
        customerService = new CustomerService();

    }

    [Test]
    public async Task CustomerCreationTest()
    {
        var customer = await customerService.CreateCustomerAsync(new Customer(1, "123", 12));
        Assert.That(customer, Is.Not.Null);
        Assert.That(customer.Age, Is.EqualTo(12));

    }
}