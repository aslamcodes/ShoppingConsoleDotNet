using ShoppingBLLib;
using SolutionModelLib;
using SolutionModelLib.Exceptions;

namespace CustomerBLTests;

public class CustomerDeletionTests
{
    private CustomerService customerService;

    [SetUp]
    public void Setup()
    {
        customerService = new CustomerService();
        customerService.CreateCustomerAsync(new Customer(1, "12123", 12));
    }

    [Test]
    public void DeleteCustomer()
    {
        var customer = customerService.DeleteCustomerAsync(1);

        Assert.That(customer, Is.Not.Null);
        Assert.That(customer.Age, Is.EqualTo(12));
        Assert.Throws<EntityNotFoundException>(() => customerService.DeleteCustomerAsync(1));

    }

    [Test]
    public void DeleteCustomerFails()
    {
        Assert.Throws<EntityNotFoundException>(() => customerService.DeleteCustomerAsync(2));

    }
}