using ShoppingBLLib;
using SolutionModelLib;
using SolutionModelLib.Exceptions;

namespace CustomerBLTests;

public class CustomerRetrivalTests
{
    private CustomerService customerService;

    [SetUp]
    public void Setup()
    {
        customerService = new CustomerService();
        customerService.CreateCustomer(new Customer(1, "12123", 12));
    }

    [Test]
    public void GetCustomer()
    {
        var customer = customerService.GetCustomer(1);

        Assert.That(customer, Is.Not.Null);

        Assert.Multiple(() =>
        {
            Assert.That(customer.Age, Is.EqualTo(12));
            Assert.That(customer.Phone, Is.EqualTo("12123"));
        });

    }

    [Test]
    public void GetCustomerFails()
    {
        Assert.Throws<EntityNotFoundException>(() => customerService.GetCustomer(2));

    }
}