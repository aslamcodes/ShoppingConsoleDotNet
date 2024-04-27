using ShoppingBLLib;
using SolutionModelLib;
using SolutionModelLib.Exceptions;

namespace CustomerBLTests;

public class CustomerUpdationTests
{
    private CustomerService customerService;

    [SetUp]
    public void Setup()
    {
        customerService = new CustomerService();
        customerService.CreateCustomerAsync(new Customer(1, "12123", 12));
    }

    [Test]
    public void UpdateCustomer()
    {
        var customer = customerService.UpdateCustomerAsync(1, new Customer(1, "123", 15));

        Assert.That(customer, Is.Not.Null);
        Assert.That(customer.Age, Is.EqualTo(15)); Assert.That(customer.Phone, Is.EqualTo("123"));

    }

    [Test]
    public void UpdateCustomerFails()
    {
        Assert.Throws<EntityNotFoundException>(() => customerService.UpdateCustomerAsync(2, new Customer(2, "123", 12)));

    }
}