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
        customerService.CreateCustomerAsync(new Customer(1, "12123", 12));
    }

    [Test]
    public async Task GetCustomer()
    {
        var customer = await customerService.GetCustomerAsync(1);

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
        Assert.ThrowsAsync<EntityNotFoundException>(async () => await customerService.GetCustomerAsync(2));

    }
}