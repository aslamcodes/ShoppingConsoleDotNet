using ShoppingDALLib;
using SolutionModelLib;
using SolutionModelLib.Exceptions;

namespace CustomerRepoTests
{
    public class CustomerDeletionTests
    {
        private CustomerRepository _customerRepository;

        [SetUp]
        public void Setup()
        {
            _customerRepository = new CustomerRepository();

        }

        [Test]
        public async Task DeleteCustomeruccess()
        {

            await _customerRepository.Add(new Customer(1, "123", 12));

            var customer = await _customerRepository.Delete(1);

            Assert.That(customer, Is.Not.Null);
            Assert.That(customer.Id, Is.EqualTo(1));
            Assert.ThrowsAsync<EntityNotFoundException>(async () => await _customerRepository.Delete(1));
        }

        [Test]
        public void DeleteCustomerFail()
        {
            var exception = Assert.ThrowsAsync<EntityNotFoundException>(async () => await _customerRepository.Delete(2));

            Assert.That(exception.Message, Is.EqualTo("Customer not found"));
        }
    }
}