using ShoppingDALLib;
using SolutionModelLib;
using SolutionModelLib.Exceptions;

namespace CustomerRepoTests
{
    public class CustomerUpdationTests
    {
        private CustomerRepository _customerRepository;

        [SetUp]
        public void Setup()
        {
            _customerRepository = new CustomerRepository();
            _customerRepository.Add(new Customer(1, "123", 12));
        }

        [Test]
        public async Task UpdateCustomerSuccess()
        {
            var customer = await _customerRepository.GetByKey(1);

            customer.Age = 112;

            var updatedCustomer = await _customerRepository.Update(customer);

            Assert.That(updatedCustomer, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(updatedCustomer.Id, Is.EqualTo(1));
                Assert.That(updatedCustomer.Age, Is.EqualTo(112));
            });

        }

        [Test]
        public void UpdateCustomerFail()
        {
            var exception = Assert.ThrowsAsync<EntityNotFoundException>(async () => await _customerRepository.Update(await _customerRepository.GetByKey(2)));

            Assert.That(exception.Message, Is.EqualTo("Customer not found"));
        }
    }
}