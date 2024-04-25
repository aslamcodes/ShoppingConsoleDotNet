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
    public void CustomerCreationTest()
    {
        var customer = customerService.CreateCustomer(new Customer(1, "123", 12));
        Assert.That(customer, Is.Not.Null);
        Assert.That(customer.Age, Is.EqualTo(12));

    }
}